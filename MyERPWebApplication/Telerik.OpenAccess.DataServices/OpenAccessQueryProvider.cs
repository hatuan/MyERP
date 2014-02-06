using System;
using System.Collections.Generic;
using System.Data.Services.Providers;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Telerik.OpenAccess.DataServices
{
    /// <summary>
    /// Defines a metadata and query source implementation for OpenAccess Data Service provider.
    /// </summary>
    /// <typeparam name="T">Type of the underlying OpenAccessContext</typeparam>
    public class OpenAccessQueryProvider<T> : IDataServiceQueryProvider where T : OpenAccessContext
    {
        private readonly IDataServiceMetadataProvider metadataProvider;
        private T currentDataSource = null;
        private readonly object dataServiceInstance;
        private bool nullProp = false;
        
        /// <summary>
        /// Creates a new instance of OpenAccessQueryProvider
        /// </summary>
        /// <param name="dataServiceInstance">OpenAccessContext instance</param>
        /// <param name="dataServiceMetadataProvider">MetadataProvider instance</param>
        public OpenAccessQueryProvider(object dataServiceInstance, IDataServiceMetadataProvider dataServiceMetadataProvider)
        {
            if (dataServiceInstance == null)
            {
                throw new ArgumentNullException("dataServiceInstance");
            }
            if (dataServiceMetadataProvider == null)
            {
                throw new ArgumentNullException("dataServiceMetadataProvider");
            }

            this.dataServiceInstance = dataServiceInstance;
            this.metadataProvider = dataServiceMetadataProvider;
        }

        /// <summary>
        /// Gets or sets the OpenAccessContext instance from which data is provided.
        /// </summary>
        /// <value>The data source.</value>
        public object CurrentDataSource
        {
            get
            {
                return this.currentDataSource;
            }
            set
            {
                this.currentDataSource = value as T;
            }
        }

        /// <summary>
        /// Gets the value of the open property.
        /// </summary>
        /// <remarks>Currently not implemented!</remarks>
        /// <param name="target">Instance of the type that declares the open property.</param>
        /// <param name="propertyName">Name of the open property.</param>
        /// <returns>The value of the open property.</returns>
        public object GetOpenPropertyValue(object target, string propertyName)
        {
            // open properties are not currently supported
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the name and values of all the properties that are defined in the given instance of an open type.
        /// </summary>
        /// <remarks>Currently not implemented!</remarks>
        /// <param name="target">Instance of the type that declares the open property.</param>
        /// <returns>A collection of name and values of all the open properties.</returns>
        public IEnumerable<KeyValuePair<string, object>> GetOpenPropertyValues(object target)
        {
            // open properties are not currently supported
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value of the open property.
        /// </summary>
        /// <remarks>Currently not implemented!</remarks>
        /// <param name="target">Instance of the type that declares the open property.</param>
        /// <param name="resourceProperty">Value for the open property.</param>
        /// <returns>Value for the property.</returns>
        public object GetPropertyValue(object target, ResourceProperty resourceProperty)
        {
            // open properties are not currently supported
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the System.Linq.IQueryable&lt;T&gt; that represents the container.
        /// </summary>
        /// <param name="resourceSet">The resource set.</param>
        /// <returns>An System.Linq.IQueryable&lt;T&gt; that represents the resource set, or a null
        /// value if there is no resource set for the specified resourceSet.
        /// </returns>
        public IQueryable GetQueryRootForResourceSet(ResourceSet resourceSet)
        {
            if (this.currentDataSource == null)
            {
                return null;
            }

            if (resourceSet == null)
            {
                return null;
            }

            Func<T, IQueryable> getQueryable = this.CreateGetQueryableFunc(resourceSet.ResourceType.InstanceType);
            IQueryable queryable = getQueryable(this.currentDataSource);

            return queryable;
        }

        private Func<T, IQueryable> CreateGetQueryableFunc(Type entityType)
        {
            ParameterExpression contextParameter = Expression.Parameter(typeof(T), "context");
            MethodCallExpression getAllExpression = Expression.Call(
                contextParameter, "GetAll", new Type[] { entityType });
            Expression<Func<T, IQueryable>> getQueryableExpression = Expression.Lambda<Func<T, IQueryable>>(
                getAllExpression, contextParameter);
            // TODO Add fetch group for byte[]
            return getQueryableExpression.Compile();
        }

        /// <summary>
        /// Gets the resource type for the instance that is specified by the parameter.
        /// </summary>
        /// <param name="target">Instance to extract a resource type from.</param>
        /// <returns>The System.Data.Services.Providers.ResourceType of the supplied object.</returns>
        public ResourceType GetResourceType(object target)
        {
            if (target == null)
            {
                return null;
            }

            Type entityType = target.GetType();
            ResourceType resourceType = this.metadataProvider.Types.FirstOrDefault(rt => rt.InstanceType == entityType);

            return resourceType;
        }

        /// <summary>
        /// Invokes the given service operation and returns the results.
        /// </summary>
        /// <param name="serviceOperation">Service operation to invoke.</param>
        /// <param name="parameters">Values of parameters to pass to the service operation.</param>
        /// <returns>
        /// The result of the service operation, or a null value for a service operation that returns void.
        /// </returns>
        public object InvokeServiceOperation(ServiceOperation serviceOperation, object[] parameters)
        {
            if (serviceOperation == null)
                return null;

            return ((MethodInfo)serviceOperation.CustomState).Invoke(this.dataServiceInstance, BindingFlags.FlattenHierarchy | BindingFlags.Instance, null, parameters, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets or sets whether null propagation is required in expression trees.
        /// </summary>
        /// <value>True to enable automatic null checks, otherwise False</value>
        public bool IsNullPropagationRequired
        {
            get
            {
                // return true so that null check are automatically inserted
                return nullProp;
            }
            set
            {
                nullProp = value;
            }
        }
    }
}