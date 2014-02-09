using Microsoft.Practices.Prism.Regions;

namespace MyERP.Infrastructure.Extensions
{
    public static class IRegionExtensions
    {
        public static void ClearActiveViews(this IRegion region)
        {
            foreach (var v in region.ActiveViews)
            {
                region.Deactivate(v);
            }
        }
    }
}
