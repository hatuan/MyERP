using System.Data.Services.Providers;
using Telerik.OpenAccess.Metadata;

namespace Telerik.OpenAccess.DataServices
{
    /// <summary>
    /// Provides metadata to an OpenAccessDataService.
    /// </summary>
    public interface IOpenAccessMetadataProvider : IDataServiceMetadataProvider
    {
        /// <summary>
        /// Gets the metadata that the OpenAccessDataService will operate on.
        /// </summary>
        MetadataContainer MetadataContainer
        {
            get;
        }
    }
}