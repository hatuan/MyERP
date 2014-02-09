using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Services.Providers;
using System.Linq;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.RT;

namespace Telerik.OpenAccess.DataServices
{
    /// <summary>
    /// Defines the methods that must be implemented to supply eTag values to the OpenAccess Data Service provider.
    /// </summary>
    /// <typeparam name="T">The type of the underlying OpenAccessContext</typeparam>
    public class OpenAccessUpdateProvider<T> : IDataServiceUpdateProvider where T : OpenAccessContext
    {
        private readonly IOpenAccessMetadataProvider metadataProvider=null;
        private readonly IDataServiceQueryProvider queryProvider=null;

        /// <summary>
        /// Creates a new instance of OpenAccessUpdateProvider
        /// </summary>
        /// <param name="metadataProvider">Metadata provider instance</param>
        /// <param name="queryProvider">Query provider instance</param>
        public OpenAccessUpdateProvider(IOpenAccessMetadataProvider metadataProvider, 
                                        IDataServiceQueryProvider queryProvider)
        {
            if (metadataProvider == null)
            {
                throw new ArgumentNullException("metadataProvider");
            }
            if (queryProvider == null)
            {
                throw new ArgumentNullException("queryProvider");
            }

            this.metadataProvider = metadataProvider;
            this.queryProvider = queryProvider;
        }

        private T Context
        {
            get
            {
                T context = this.queryProvider.CurrentDataSource as T;
                if (context == null)
                {
                    throw new InvalidOperationException(string.Format("The query provider is not associated with a valid context of type {0}.", typeof(T).Name));
                }
                return context;
            }
        }

        /// <summary>
        /// Supplies the eTag value for the given entity resource.
        /// </summary>
        /// <remarks>Currently not implemented.</remarks>
        /// <param name="resourceCookie">Cookie that represents the resource.</param>
        /// <param name="checkForEquality">
        /// A System.Boolean that is true when property values must be compared for equality; false when property values must be compared for inequality.
        /// </param>
        /// <param name="concurrencyValues">
        /// An System.Collections.Generic.IEnumerable&lt;T&gt; list of the eTag property names and corresponding values.
        /// </param>
        public void SetConcurrencyValues(object resourceCookie, bool? checkForEquality, IEnumerable<KeyValuePair<string, object>> concurrencyValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified value to the collection.
        /// </summary>
        /// <param name="targetResource">Target object that defines the property.</param>
        /// <param name="propertyName">The name of the collection property to which the resource should be added..</param>
        /// <param name="resourceToBeAdded">The opaque object representing the resource to be added.</param>
        public void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            if (targetResource == null)
            {
                throw new ArgumentNullException("targetResource");
            }

            MetaNavigationMember property = this.GetNavigationalMember(propertyName, targetResource.GetType().FullName);
            

            IList collection = targetResource.FieldValue<object>(propertyName) as IList;
            if (collection == null)
            {
                throw new ArgumentException("The value of the property '" + propertyName
                + "' does not implement IList or is not instantiated, which is a requirement for resource set reference property.");
            }

            collection.Add(resourceToBeAdded);

            //in case of one to many
            string typeName = targetResource.GetType().FullName;
            MetaMember inverseProperty = this.GetInverseMember(typeName, propertyName);
            if (inverseProperty != null)
            {
                if (!(property.Association is MetaJoinTableAssociation))
                { 
                    resourceToBeAdded.SetFieldValue(inverseProperty.PropertyName, targetResource);
                }
            }
        }

        /// <summary>
        /// Removes the specified value from the collection.
        /// </summary>
        /// <param name="targetResource">The target object that defines the property.</param>
        /// <param name="propertyName">The name of the property whose value needs to be updated.</param>
        /// <param name="resourceToBeRemoved">The property value that needs to be removed.</param>
        public void RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            if (targetResource == null)
            {
                throw new ArgumentNullException("targetResource");
            }

            MetaNavigationMember property = this.GetNavigationalMember(propertyName, targetResource.GetType().FullName);

            IList collection = targetResource.FieldValue<object>(propertyName) as IList;
            if (collection == null)
            {
                throw new ArgumentException("The value of the property '" + propertyName
                + "' does not implement IList or is not instantiated, which is a requirement for resource set reference property.");
            }
            collection.Remove(resourceToBeRemoved);

            //in case of one to many
            string typeName = targetResource.GetType().FullName;
            MetaMember inverseProperty = this.GetInverseMember(typeName, propertyName);
            if (inverseProperty != null)
            {
                if (!(property.Association is MetaJoinTableAssociation))
                {
                    resourceToBeRemoved.SetFieldValue<object>(inverseProperty.PropertyName, null);
                }
            }
        }

        /// <summary>
        /// Sets the value of the specified reference property on the target object.
        /// </summary>
        /// <param name="targetResource">The target object that defines the property.</param>
        /// <param name="propertyName">The name of the property whose value needs to be updated.</param>
        /// <param name="propertyValue">The property value to be updated.</param>
        public void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            SetValue(targetResource, propertyName, propertyValue);
        }

        /// <summary>
        /// Cancels a change to the data.
        /// </summary>
        public void ClearChanges()
        {
            T context = this.Context;
            if (context == null)
            {
                return;
            }
            context.ClearChanges();
        }

        /// <summary>
        /// Creates the resource of the specified type and that belongs to the specified container.
        /// </summary>
        /// <param name="containerName">The name of the entity set to which the resource belongs.</param>
        /// <param name="fullTypeName">The full namespace-qualified type name of the resource.</param>
        /// <returns>
        /// The object representing a resource of specified type and belonging to the specified container.
        /// </returns>
        public object CreateResource(string containerName, string fullTypeName)
        {
            ResourceType resourceType = null;
            if (this.metadataProvider.TryResolveResourceType(fullTypeName, out resourceType))
            {
                Type entityType = resourceType.InstanceType;
                object newEntity = this.CreateInstanceOfType(entityType);

                T context = this.Context;
                context.Add(newEntity);

                return newEntity;
            }

            throw new OpenAccessException(string.Format("Type with name {0} cannot be found in the list of persistent types.", fullTypeName), Telerik.OpenAccess.OpenAccessException.Failure.InvalidOperation);
        }

        private object CreateInstanceOfType(Type type)
        {
            return PersistentClassesRegistry.getInstance().newInstance(type, null);
        }

        /// <summary>
        /// Deletes the specified resource.
        /// </summary>
        /// <param name="targetResource">The resource to be deleted.</param>
        public void DeleteResource(object targetResource)
        {
            this.Context.Delete(targetResource);
        }

        /// <summary>
        /// Gets the resource of the specified type identified by a query and type name.
        /// </summary>
        /// <param name="query">Language integrated query (LINQ) pointing to a particular resource.</param>
        /// <param name="fullTypeName">The fully qualified type name of resource.</param>
        /// <returns>
        /// An opaque object representing a resource of the specified type, referenced by the specified query.
        /// </returns>
        public object GetResource(IQueryable query, string fullTypeName)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            IEnumerator enumerator = query.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new ArgumentException("Resource not found.", "query");
            }

            object entity = enumerator.Current;
            if (enumerator.MoveNext())
            {
                // the query must return a single object
                throw new ArgumentException("Resource not uniquely identified.", "query");
            }

            if (!string.IsNullOrEmpty(fullTypeName))
            {
                ResourceType resourceType = null;
                if (!this.metadataProvider.TryResolveResourceType(fullTypeName, out resourceType))
                {
                    throw new ArgumentException(string.Format("Resource type {0} not found.", fullTypeName), "fullTypeName");
                }
                if (!resourceType.InstanceType.IsAssignableFrom(entity.GetType()))
                {
                    throw new InvalidOperationException("Unexpected resource type.");
                }
            }

            return entity;
        }

        /// <summary>
        /// Gets the value of the specified property on the target object.
        /// </summary>
        /// <param name="targetResource">An opaque object that represents a resource.</param>
        /// <param name="propertyName">The name of the property whose value needs to be retrieved.</param>
        /// <returns>The value of the object.</returns>
        public object GetValue(object targetResource, string propertyName)
        {
            if (targetResource == null)
            {
                throw new ArgumentNullException("targetResource");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            object value = targetResource.FieldValue<object>(propertyName);

            return value;
        }

        /// <summary>
        /// Resets the resource identified by the parameter resource to its default value.
        /// </summary>
        /// <param name="resource">The resource to be updated.</param>
        /// <returns>The resource with its value reset to the default value.</returns>
        public object ResetResource(object resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }
            this.Context.Refresh(RefreshMode.OverwriteChangesFromStore, resource);
            return resource;
        }

        /// <summary>
        /// Returns the instance of the resource represented by the specified resource object.
        /// </summary>
        /// <param name="resource">The object representing the resource whose instance needs to be retrieved.</param>
        /// <returns>
        /// Returns the instance of the resource represented by the specified resource object.
        /// </returns>
        public object ResolveResource(object resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }
            this.Context.Refresh(RefreshMode.PreserveChanges, resource);
            return resource;
        }

        /// <summary>
        /// Saves all the changes that have been made by using the System.Data.Services.IUpdatable APIs.
        /// </summary>
        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Sets the value of the property with the specified name on the target resource to the specified property value.
        /// </summary>
        /// <param name="targetResource">The target object that defines the property.</param>
        /// <param name="propertyName">The name of the property whose value needs to be updated.</param>
        /// <param name="propertyValue">The property value for update.</param>
        public void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            if (targetResource == null)
            {
                throw new ArgumentNullException("targetResource");
            }

            targetResource.SetFieldValue(propertyName, propertyValue);
        }

        private MetaMember GetInverseMember(string collectionSideTypeFullName, string collectionPropertyName)
        {
            MetaNavigationMember collectionMember = GetMember(collectionPropertyName, collectionSideTypeFullName) as MetaNavigationMember;
            if (collectionMember != null)
            { 
                MetaNavigationMember oppositeMember = collectionMember.GetOppositeMember();
                if (oppositeMember != null)
                {
                    return oppositeMember;
                }
            }

            return null;
        }

        private MetaMember GetMember(string propertyName, string className)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }
            if (string.IsNullOrEmpty(className))
            {
                throw new ArgumentNullException("className");
            }

            IOpenAccessMetadataProvider castMetadataProvider = this.metadataProvider;
            ThrowInvalidOnNull(castMetadataProvider, "The metadata provider could not be found");

            MetadataContainer container = castMetadataProvider.MetadataContainer;
            ThrowInvalidOnNull(container, "The metadata container for the metadata provider was not set");

            MetaPersistentType persistentType = container.PersistentTypes.FirstOrDefault(c => string.Equals(c.FullName, className));
            ThrowInvalidOnNull(persistentType, string.Format("No persistent type has been registered for class {0}", className));

            MetaMember member = persistentType.Members.FirstOrDefault(x => string.Equals(x.PropertyName, propertyName));
            if (member == null)
            {
                throw new ArgumentException(string.Format("propertyName"));
            }
            return member;
        }

        private MetaNavigationMember GetNavigationalMember(string propertyName, string className)
        {
            MetaNavigationMember navigationProperty = this.GetMember(propertyName, className) as MetaNavigationMember;

            if (navigationProperty.Association is MetaJoinTableAssociation && !navigationProperty.IsManaged)
            {
                string exceptionMessage = string.Format("Change made on property {0} of type {1} that has IsManaged set to False will not be persisted.",
                    navigationProperty.PropertyName, navigationProperty.DeclaringType.FullName);

                throw new InvalidOperationException(exceptionMessage);
            }

            return navigationProperty;
        }

        private static void ThrowInvalidOnNull(object nullReference, string message)
        {
            if (nullReference == null)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}