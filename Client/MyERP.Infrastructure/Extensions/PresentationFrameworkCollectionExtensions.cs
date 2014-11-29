using System.Linq;
using System.Windows;

namespace MyERP.Infrastructure.Extensions
{
    public static class PresentationFrameworkCollectionExtensions
    {
        public static void AddIfMissing(this PresentationFrameworkCollection<ResourceDictionary> collection, ResourceDictionary resourceDictionary)
        {
            if (!collection.Any(rd => rd.Source.OriginalString.Equals(resourceDictionary.Source.OriginalString)))
            {
                collection.Add(resourceDictionary);
            }
        }
    }
}
