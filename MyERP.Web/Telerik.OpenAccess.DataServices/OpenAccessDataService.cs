using System;
using System.Data.Services;
using System.Data.Services.Providers;

namespace Telerik.OpenAccess.DataServices
{
    /// <summary>
    /// The main entry point for developing an ADO.NET Data Service that expose Telerik OpenAccess context models.
    /// </summary>
    /// <typeparam name="T">The type of the underlying OpenAccessContext</typeparam>
    public class OpenAccessDataService<T> : DataService<T>, IServiceProvider where T : OpenAccessContext
    {
        private readonly IOpenAccessMetadataProvider metadataProvider=null;
        private readonly IDataServiceQueryProvider queryProvider=null;
        private readonly IDataServiceUpdateProvider updateProvider=null;

        /// <summary>
        /// Creates a new data service that deploys data of the type indicated by the template class.
        /// </summary>
        public OpenAccessDataService()
        {
            this.metadataProvider = this.GetMetadataProvider();
            this.queryProvider = this.GetQueryProvider(this.metadataProvider);
            this.updateProvider = this.GetUpdateProvider(this.metadataProvider, this.queryProvider);
        }

        /// <summary>
        /// Returns an instance of the OpenAccessDataService's specific metadata provider
        /// </summary>
        /// <returns>Instance of the type that is used as metadata provider</returns>
        protected virtual IOpenAccessMetadataProvider GetMetadataProvider()
        {
            return new OpenAccessMetadataProvider<T>(this);
        }

        /// <summary>
        /// Returns an instance of the OpenAccessDataService's specific query provider
        /// </summary>
        /// <param name="metadataProvider">Instance of the specific metadata provider</param>
        /// <returns>Instance of the type that is used as query provider</returns>
        protected virtual IDataServiceQueryProvider GetQueryProvider(IDataServiceMetadataProvider metadataProvider)
        {
            return new OpenAccessQueryProvider<T>(this, metadataProvider);
        }

        /// <summary>
        /// Returns an instance of the OpenAccessDataService's specific update provider
        /// </summary>
        /// <param name="metadataProvider">Instance of the specific metadata provider</param>
        /// <param name="queryProvider">Instance of the specific query provider</param>
        /// <returns>Instance of the type that is used as update provider</returns>
        protected virtual IDataServiceUpdateProvider GetUpdateProvider(IOpenAccessMetadataProvider metadataProvider, 
                                                                       IDataServiceQueryProvider queryProvider)
        {
            return new OpenAccessUpdateProvider<T>(metadataProvider, queryProvider);
        }
   

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>
        /// A service object of type serviceType.-or- null if there is no service object of type serviceType.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IDataServiceQueryProvider))
            {
                return this.queryProvider;
            }
            else if (serviceType == typeof(IDataServiceMetadataProvider))
            {
                return this.metadataProvider;
            }
            else if (serviceType == typeof(IDataServiceUpdateProvider))
            {
                return this.updateProvider;
            }
            return null;
        }
    }
}