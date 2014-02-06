using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Providers;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Web;
using Telerik.OpenAccess.Metadata;

namespace Telerik.OpenAccess.DataServices
{
    /// <summary>
    /// Provides metadata to an OpenAccessDataService.
    /// </summary>
    /// <typeparam name="T">Type of the OpenAccessContext that will be exposed through the service</typeparam>
    public class OpenAccessMetadataProvider<T> : IOpenAccessMetadataProvider where T : OpenAccessContext
    {
        private List<ResourceSet> resourceSets = null;
        private List<ResourceType> resourceTypes = null;
        private IDictionary<string, ServiceOperation> serviceOperations = null;
        private readonly Type dataServiceType;
        private MetadataContainer contextMetadata = null;
        private readonly Dictionary<Tuple<MetaNavigationMember, MetaNavigationMember>, ResourceAssociationSet> resourceAssociationSets = new Dictionary<Tuple<MetaNavigationMember, MetaNavigationMember>, ResourceAssociationSet>();

        /// <summary>
        /// Creates a new instance of the OpenAccessMetadataProvider and binds it to the provided OpenAccessDataService instance.
        /// </summary>
        /// <param name="dataServiceInstance">The bound OpenAccessDataService instance</param>
        public OpenAccessMetadataProvider(OpenAccessDataService<T> dataServiceInstance)
        {
            if (dataServiceInstance == null)
            {
                throw new ArgumentNullException("dataServiceInstance");
            }

            this.dataServiceType = dataServiceInstance.GetType();


            this.InitializeResourceSets();
            this.InitializeServiceOperations();
            this.MakeConfigurationReadonly();
        }

        private void InitializeResourceSets()
        {
            BindingFlags publicInstanceFlags = BindingFlags.Public | BindingFlags.Instance;
            Type dataSourceType = typeof(T);
            PropertyInfo[] properties = dataSourceType.GetProperties(publicInstanceFlags);
            Type queryableType = typeof(IQueryable);

            this.resourceSets = new List<ResourceSet>();
            this.resourceTypes = new List<ResourceType>();

            // first create all resource types
            foreach (PropertyInfo propertyInfo in properties)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType)
                {
                    Type genericType = propertyType.GetGenericTypeDefinition();
                    if (queryableType.IsAssignableFrom(genericType))
                    {
                        ResourceType resourceType = this.CreateResourceType(propertyType.GetGenericArguments()[0]);
                        this.resourceTypes.Add(resourceType);
                        ResourceSet resourceSet = new ResourceSet(propertyInfo.Name, resourceType);
                        this.resourceSets.Add(resourceSet);
                    }
                }
            }

            // then populate the properties for each resource type
            foreach (ResourceType type in this.resourceTypes)
            {
                this.AddPropertiesForResourceType(type);
            }
        }

        private void InitializeServiceOperations()
        {
            MethodInfo[] methods = dataServiceType.GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);

            serviceOperations = new Dictionary<string, ServiceOperation>(methods.Length);

            foreach (MethodInfo info in methods)
            {
                this.AddServiceOperation(info);
            }
        }

        private void AddServiceOperation(MethodInfo method)
        {
            //check first the HTTP verb and if there is no WebGet or WebInvoke skip the method
            string protocolMethod = GetServiceOperationHttpMethod(method);
            if (string.IsNullOrWhiteSpace(protocolMethod))
                return;

            if (this.serviceOperations.ContainsKey(method.Name))
            {
                string message = string.Format("Overloading is not supported but type '{0}' has an overloaded method '{1}'.",
                                                dataServiceType.Name, method.Name);
                throw new InvalidOperationException(message);
            }

            // discover the return type of the operation
            bool isSingleResult = method.GetCustomAttributes(typeof(SingleResultAttribute), true).Any();
            ResourceType primitiveResourceType = null;
            ServiceOperationResultKind resultKind;
            if (method.ReturnType == typeof(void))
            {
                resultKind = ServiceOperationResultKind.Void;
            }
            else
            {
                Type returnType = null;
                if (IsPrimitiveType(method.ReturnType))
                {
                    resultKind = ServiceOperationResultKind.DirectValue;
                    primitiveResourceType = ResourceType.GetPrimitiveResourceType(method.ReturnType);
                }
                else
                {
                    Type genericInterfaceElementType = GetGenericInterfaceElementType(method.ReturnType, new TypeFilter(IQueryableTypeFilter));
                    if (genericInterfaceElementType != null)
                    {
                        resultKind = isSingleResult ? ServiceOperationResultKind.QueryWithSingleResult : ServiceOperationResultKind.QueryWithMultipleResults;
                        returnType = genericInterfaceElementType;
                    }
                    else
                    {
                        Type iEnumerableElement = GetIEnumerableElement(method.ReturnType);
                        if (iEnumerableElement != null)
                        {
                            resultKind = ServiceOperationResultKind.Enumeration;
                            returnType = iEnumerableElement;
                        }
                        else
                        {
                            returnType = method.ReturnType;
                            resultKind = ServiceOperationResultKind.DirectValue;
                        }
                    }
                    primitiveResourceType = ResourceType.GetPrimitiveResourceType(returnType);
                    if (primitiveResourceType == null)
                    {
                        primitiveResourceType = resourceTypes.FirstOrDefault(r => r.FullName == returnType.FullName);
                    }
                }

                if (primitiveResourceType == null)
                {
                    string message = string.Format("Unable to load metadata for return type '{1}' of method '{0}'.", method, method.ReturnType);
                    throw new InvalidOperationException(message);
                }

                if ((resultKind == ServiceOperationResultKind.Enumeration) && isSingleResult)
                {
                    string message = string.Format("Type '{0}' has a method '{1}' which is a generic IEnumerable but is marked with a SingleResultAttribute. Only IQueryable methods support this attribute.",
                                                    dataServiceType.Name, method);
                    throw new InvalidOperationException(message);
                }
            }

            ServiceOperationParameter[] parameterArray = GetServiceOperationParameters(method);

            ResourceSet container = null;
            if (((primitiveResourceType != null) &&
                (primitiveResourceType.ResourceTypeKind == ResourceTypeKind.EntityType)) &&
                !this.TryFindAnyContainerForType(primitiveResourceType, out container))
            {
                string message = string.Format("Service operation '{0}' produces instances of type '{1}', but having a single entity set for that type is required.",
                                                method.Name, primitiveResourceType.FullName);
                throw new InvalidOperationException(message);
            }

            ServiceOperation operation = new ServiceOperation(method.Name, resultKind, primitiveResourceType, container, protocolMethod, parameterArray);

            operation.CustomState = method;
            string mimeType = GetServiceOperationMimeType(method);
            if (!string.IsNullOrWhiteSpace(mimeType))
            {
                operation.MimeType = mimeType;
            }

            this.serviceOperations.Add(method.Name, operation);
        }

        private string GetServiceOperationHttpMethod(MethodInfo method)
        {
            if (method.GetCustomAttributes(typeof(WebGetAttribute), true).Any())
            {
                return "GET";
            }
            else
            {
                WebInvokeAttribute webInvokeAtt = method.GetCustomAttributes(typeof(WebInvokeAttribute), true).FirstOrDefault() as WebInvokeAttribute;
                if (webInvokeAtt != null)
                {
                    //so far ServiceOperation ctor supports only GET and POST
                    //this includes version up to DataServices ver 5.0 (including)
                    return "POST";
                    //return webInvokeAtt.Method;
                }
            }
            return null;
        }

        private string GetServiceOperationMimeType(MethodInfo method)
        {
            MimeTypeAttribute mimeTypeAttribute = method.ReflectedType.GetCustomAttributes(typeof(MimeTypeAttribute), true)
                                                                      .Cast<MimeTypeAttribute>()
                                                                      .FirstOrDefault(a => a.MemberName == method.Name);

            return mimeTypeAttribute != null ? mimeTypeAttribute.MimeType : null;
        }

        private ServiceOperationParameter[] GetServiceOperationParameters(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            ServiceOperationParameter[] parameterArray = new ServiceOperationParameter[parameters.Length];
            for (int i = 0; i < parameterArray.Length; i++)
            {
                ParameterInfo info = parameters[i];
                if (info.IsOut || info.IsRetval)
                {
                    string message = string.Format("Method '{0}' has a parameter '{1}' which is not an [in] parameter.", method.Name, info.Name);
                    throw new InvalidOperationException(message);
                }
                ResourceType parameterType = ResourceType.GetPrimitiveResourceType(info.ParameterType);
                if (parameterType == null)
                {
                    string message = string.Format("Method '{0}' has a parameter '{1}' of type '{2}' which is not supported for service operations. Only primitive types are supported as parameters.",
                                                    method.Name, info.Name, info.ParameterType.Name);
                    throw new InvalidOperationException(message);
                }
                string name = info.Name ?? ("p" + i.ToString(System.Globalization.CultureInfo.InvariantCulture));
                parameterArray[i] = new ServiceOperationParameter(name, parameterType);
            }
            return parameterArray;
        }

        private bool TryFindAnyContainerForType(ResourceType type, out ResourceSet container)
        {
            foreach (ResourceSet set in this.resourceSets)
            {
                if (IsAssignableFrom(type, set.ResourceType))
                {
                    container = set;
                    return true;
                }
            }
            container = null;
            return false;
        }

        private static bool IsAssignableFrom(ResourceType superType, ResourceType baseType)
        {
            while (superType != null)
            {
                if (superType == baseType)
                {
                    return true;
                }
                superType = superType.BaseType;
            }
            return false;
        }

        private static Type GetGenericInterfaceElementType(Type type, TypeFilter typeFilter)
        {
            if (typeFilter(type, null))
            {
                return type.GetGenericArguments()[0];
            }
            Type[] typeArray = type.FindInterfaces(typeFilter, null);
            if ((typeArray != null) && (typeArray.Length == 1))
            {
                return typeArray[0].GetGenericArguments()[0];
            }
            return null;
        }

        private static bool IQueryableTypeFilter(Type m, object filterCriteria)
        {
            return (m.IsGenericType && (m.GetGenericTypeDefinition() == typeof(IQueryable<>)));
        }

        private static Type GetIEnumerableElement(Type type)
        {
            return GetGenericInterfaceElementType(type, new TypeFilter(IEnumerableTypeFilter));
        }

        private static bool IEnumerableTypeFilter(Type m, object filterCriteria)
        {
            return (m.IsGenericType && (m.GetGenericTypeDefinition() == typeof(IEnumerable<>)));
        }


        private static readonly KeyValuePair<Type, string>[] primitiveTypesEdmNameMapping = new KeyValuePair<Type, string>[] 
        { 
            new KeyValuePair<Type, string>(typeof(string), "Edm.String"), 
            new KeyValuePair<Type, string>(typeof(bool), "Edm.Boolean"), 
            new KeyValuePair<Type, string>(typeof(bool?), "Edm.Boolean"), 
            new KeyValuePair<Type, string>(typeof(byte), "Edm.Byte"), 
            new KeyValuePair<Type, string>(typeof(byte?), "Edm.Byte"), 
            new KeyValuePair<Type, string>(typeof(DateTime), "Edm.DateTime"), 
            new KeyValuePair<Type, string>(typeof(DateTime?), "Edm.DateTime"), 
            new KeyValuePair<Type, string>(typeof(decimal), "Edm.Decimal"), 
            new KeyValuePair<Type, string>(typeof(decimal?), "Edm.Decimal"), 
            new KeyValuePair<Type, string>(typeof(double), "Edm.Double"), 
            new KeyValuePair<Type, string>(typeof(double?), "Edm.Double"), 
            new KeyValuePair<Type, string>(typeof(Guid), "Edm.Guid"), 
            new KeyValuePair<Type, string>(typeof(Guid?), "Edm.Guid"), 
            new KeyValuePair<Type, string>(typeof(short), "Edm.Int16"), 
            new KeyValuePair<Type, string>(typeof(short?), "Edm.Int16"), 
            new KeyValuePair<Type, string>(typeof(int), "Edm.Int32"), 
            new KeyValuePair<Type, string>(typeof(int?), "Edm.Int32"), 
            new KeyValuePair<Type, string>(typeof(long), "Edm.Int64"), 
            new KeyValuePair<Type, string>(typeof(long?), "Edm.Int64"), 
            new KeyValuePair<Type, string>(typeof(sbyte), "Edm.SByte"), 
            new KeyValuePair<Type, string>(typeof(sbyte?), "Edm.SByte"), 
            new KeyValuePair<Type, string>(typeof(float), "Edm.Single"), 
            new KeyValuePair<Type, string>(typeof(float?), "Edm.Single"), 
            new KeyValuePair<Type, string>(typeof(byte[]), "Edm.Binary"), 
            new KeyValuePair<Type, string>(typeof(System.Xml.Linq.XElement), "Edm.String"), 
            new KeyValuePair<Type, string>(typeof(System.Data.Linq.Binary), "Edm.Binary")
        };

        private static bool IsPrimitiveType(Type type)
        {
            if (type != null)
            {
                foreach (KeyValuePair<Type, string> pair in primitiveTypesEdmNameMapping)
                {
                    if (type == pair.Key)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void MakeConfigurationReadonly()
        {
            foreach (ResourceSet resourceSet in this.resourceSets)
            {
                ResourceType resourceType = resourceSet.ResourceType;
                foreach (ResourceProperty property in resourceType.Properties)
                {
                    property.SetReadOnly();
                }
                resourceType.SetReadOnly();
                resourceSet.SetReadOnly();
            }

            foreach (ServiceOperation operation in this.serviceOperations.Values)
            {
                operation.SetReadOnly();
            }
        }

        /// <summary>
        /// Gets the metadata that the OpenAccessDataService will operate on.
        /// </summary>
        public MetadataContainer MetadataContainer
        {
            get
            {
                if (this.contextMetadata == null)
                {
                    this.contextMetadata = this.GetContextMetadata();
                }
                return this.contextMetadata;
            }
        }

        private MetadataContainer GetContextMetadata()
        {
            object contextObject = Activator.CreateInstance(typeof(T), new object[] { });
            using (OpenAccessContext context = contextObject as OpenAccessContext)
            {
                if (context != null)
                {
                    return context.Metadata;
                }
                return null;
            }
        }

        private ResourceType CreateResourceType(Type entityType)
        {
            ResourceType baseType = this.GetBaseType(entityType);
            ResourceType resourceType = new ResourceType(entityType, ResourceTypeKind.EntityType, baseType,
                entityType.Namespace, entityType.Name, entityType.IsAbstract);

            return resourceType;
        }

        private MetaPersistentType FindPersistentTypeForResourceType(ResourceType resourceType)
        {
            Type entityType = resourceType.InstanceType;
            MetadataContainer metadataContainer = this.MetadataContainer;
            MetaPersistentType persistentType = metadataContainer.PersistentTypes.FirstOrDefault(
                pt => pt.FullName == entityType.FullName);

            return persistentType;
        }

        private void AddPropertiesForResourceType(ResourceType resourceType)
        {
            MetaPersistentType persistentType = this.FindPersistentTypeForResourceType(resourceType);
            if (persistentType != null)
            {
                foreach (MetaMember member in persistentType.GetMembers(true))
                {
                    ResourceProperty property = this.CreateResourceProperty(member);
                    if (property != null)
                    {
                        resourceType.AddProperty(property);
                    }
                }
            }
        }

        private ResourceProperty CreateResourceProperty(MetaMember member)
        {
            if (member == null || member.IsVisible == false || member.MemberAccessModifier != MemberAccessModifier.Public)
            {
                return null;
            }

            ResourcePropertyKind propertyKind = ResourcePropertyKind.Primitive;
            ResourceType resourceType = null;
            MetaNavigationMember navigationMember = member as MetaNavigationMember;
            if (navigationMember != null)
            {
                propertyKind = GetResourcePropertyKind(navigationMember);
                MetaPersistentType persistentType = navigationMember.MemberType as MetaPersistentType;
                this.TryResolveResourceType(persistentType.FullName, out resourceType);
            }
            else
            {
                MetaPrimitiveMember primitiveMember = member as MetaPrimitiveMember;
                if (primitiveMember.IsIdentity)
                {
                    propertyKind = propertyKind | ResourcePropertyKind.Key;
                }
                MetaPrimitiveType primitiveType = primitiveMember.MemberType as MetaPrimitiveType;
                resourceType = ResourceType.GetPrimitiveResourceType(primitiveType.ClrType);
            }
            if (resourceType == null)
            {
                // the resource type was not resolved. 
                // Possible reasons: 
                // - it is a persistent type that is not exposed via an endpoint,
                // - it is an enum(not supported by DS) etc..
                return null; 
            }
            return new ResourceProperty(member.PropertyName, propertyKind, resourceType);
        }

        private static ResourcePropertyKind GetResourcePropertyKind(MetaNavigationMember navigationMember)
        {
            if (navigationMember.Multiplicity == Multiplicity.Many)
            {
                return ResourcePropertyKind.ResourceSetReference;
            }
            else
            {
                return ResourcePropertyKind.ResourceReference;
            }
        }

        private ResourceType GetBaseType(Type entityType)
        {
            return null;
        }

        /// <summary>
        /// Gets the type name of the underlying OpenAccessContext
        /// </summary>
        public string ContainerName
        {
            get
            {
                return typeof(T).Name;
            }
        }

        /// <summary>
        /// Gets the namespace of the underlying OpenAccessContext
        /// </summary>
        public string ContainerNamespace
        {
            get
            {
                return typeof(T).Namespace;
            }
        }

        /// <summary>
        /// Returns all types that are derived from the provided type.
        /// </summary>
        /// <remarks>Inheritance between resource types is not supported in the current version.</remarks>
        /// <param name="resourceType">The base types of all types in the result</param>
        /// <returns>Enumeration of all types derived from the provided type.</returns>
        public IEnumerable<ResourceType> GetDerivedTypes(ResourceType resourceType)
        {
            // Currently there is no support for inherited entities
            yield break;
        }

        /// <summary>
        /// Gets the System.Data.Services.Providers.ResourceAssociationSet instance when given the source association end.
        /// </summary>
        /// <param name="resourceSet">Resource set of the source association end.</param>
        /// <param name="resourceType">Resource type of the source association end.</param>
        /// <param name="resourceProperty">Resource property of the source association end.</param>
        /// <returns>A System.Data.Services.Providers.ResourceAssociationSet instance.</returns>
        public ResourceAssociationSet GetResourceAssociationSet(ResourceSet resourceSet, ResourceType resourceType, ResourceProperty resourceProperty)
        {
            if (resourceSet == null)
                throw new ArgumentNullException("resourceSet");

            if (resourceType == null)
                throw new ArgumentNullException("resourceType");

            if (resourceProperty == null)
                throw new ArgumentNullException("resourceProperty");

            MetaPersistentType persistentType = this.FindPersistentTypeForResourceType(resourceType);
            ResourceAssociationSet result = null;
            if (persistentType != null)
            {
                string propertyName = resourceProperty.Name;
                MetaNavigationMember navigationMember = persistentType.GetMembers(true).FirstOrDefault(
                    m => m.PropertyName == propertyName) as MetaNavigationMember;

                MetaAssociation association = navigationMember.Association;

                var associationKey = new Tuple<MetaNavigationMember, MetaNavigationMember>(association.SourceEnd, association.TargetEnd);

                if (this.resourceAssociationSets.TryGetValue(associationKey, out result))
                {
                    return result;
                }
                else
                {
                    ResourceAssociationSetEnd sourceEnd = this.CreateResourceAssociationEnd(association.Source.FullName, association.SourceEnd);
                    ResourceAssociationSetEnd targetEnd = this.CreateResourceAssociationEnd(association.Target.FullName, association.TargetEnd);
                    string associationName = string.Concat(resourceType.Name, "_", resourceProperty.Name);

                    result = new ResourceAssociationSet(associationName, sourceEnd, targetEnd);
                    this.resourceAssociationSets[associationKey] = result;
                }
            }

            return result;
        }

        private ResourceAssociationSetEnd CreateResourceAssociationEnd(string resourceTypeFullName, MetaNavigationMember navigationMember)
        {
            // find resource set and type
            ResourceSet resourceSet = null;

            foreach (ResourceSet set in this.resourceSets)
            {
                if (set.ResourceType.FullName == resourceTypeFullName)
                {
                    resourceSet = set;
                    break;
                }
            }

            if (resourceSet == null)
                throw new ArgumentOutOfRangeException("resourceTypeFullName", resourceTypeFullName, "Unknown Resource Type Name!");

            ResourceType resourceType = resourceSet.ResourceType;

            // find resource property
            ResourceProperty resourceProperty = null;
            if (navigationMember != null)
            {
                resourceProperty = resourceType.Properties.FirstOrDefault(p => p.Name == navigationMember.PropertyName);
            }
            //it's OK for the property to be null!
            return new ResourceAssociationSetEnd(resourceSet, resourceType, resourceProperty);
        }

        /// <summary>
        /// Determines whether a resource type has derived types.
        /// </summary>
        /// <remarks>Currently not implemented!</remarks>
        /// <param name="resourceType">A System.Data.Services.Providers.ResourceType object to evaluate.</param>
        /// <returns>True when resourceType represents an entity that has derived types; otherwise False.</returns>
        public bool HasDerivedTypes(ResourceType resourceType)
        {
            // TODO: implement support for inheritance
            return false;
        }

        /// <summary>
        /// Gets all available containers.
        /// </summary>\
        /// <value>An System.Collections.Generic.IEnumerable&lt;T&gt; collection of System.Data.Services.Providers.ResourceSet objects.</value>
        public IEnumerable<ResourceSet> ResourceSets
        {
            get
            {
                return this.resourceSets;
            }
        }

        /// <summary>
        /// Gets all the service operations in this data source.
        /// </summary>
        /// <value>An System.Collections.Generic.IEnumerable&lt;T&gt; collection of System.Data.Services.Providers.ServiceOperation objects.</value>
        public IEnumerable<ServiceOperation> ServiceOperations
        {
            get
            {
                return this.serviceOperations.Values;
            }
        }

        /// <summary>
        /// Tries to get a resource set based on the specified name.
        /// </summary>
        /// <param name="name">Name of the System.Data.Services.Providers.ResourceSet to resolve.</param>
        /// <param name="resourceSet">Returns the resource set or a null value if a resource set with the given name is not found.</param>
        /// <returns>True when resource set with the given name is found; otherwise False.</returns>
        public bool TryResolveResourceSet(string name, out ResourceSet resourceSet)
        {
            resourceSet = this.resourceSets.Find(rs => rs.Name == name);
            return resourceSet != null;
        }

        /// <summary>
        /// Tries to get a resource type based on the specified name.
        /// </summary>
        /// <param name="name">Name of the type to resolve.</param>
        /// <param name="resourceType">Returns the resource type or a null value if a resource type with the given name is not found.</param>
        /// <returns>True when resource type with the given name is found; otherwise False.</returns>
        public bool TryResolveResourceType(string name, out ResourceType resourceType)
        {
            resourceType = this.resourceTypes.Find(rt => rt.FullName == name);
            return resourceType != null;
        }

        /// <summary>
        /// Tries to get a service operation based on the specified name.
        /// </summary>
        /// <param name="name">Name of the service operation to resolve.</param>
        /// <param name="serviceOperation">Returns the service operation or a null value if a service operation with the given name is not found.</param>
        /// <returns>True when service operation with the given name is found; otherwise False.</returns>
        public bool TryResolveServiceOperation(string name, out ServiceOperation serviceOperation)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                serviceOperation = null;
                return false;
            }

            return serviceOperations.TryGetValue(name, out serviceOperation);
        }

        /// <summary>
        /// Returns all the types in this data source.
        /// </summary>
        /// <returns>An System.Collections.Generic.IEnumerable&lt;T&gt; collection of System.Data.Services.Providers.ResourceType objects.</returns>
        public IEnumerable<ResourceType> Types
        {
            get
            {
                return this.resourceTypes;
            }
        }
    }
}