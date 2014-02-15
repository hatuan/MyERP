using System;
using MyERP.Infrastructure.Assets.Resources;

namespace MyERP.Infrastructure.Helpers
{
    public class ResourceWrapper
    {
        private static ApplicationStrings applicationStrings = new ApplicationStrings();

        /// <summary>
        /// Gets the <see cref="ApplicationStrings"/>.
        /// </summary>
        public ApplicationStrings ApplicationStrings
        {
            get { return applicationStrings; }
        }
    }
}
