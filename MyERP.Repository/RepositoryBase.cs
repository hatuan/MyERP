using System;
using System.Collections.Generic;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    public abstract class RepositoryBase
    {
        private static Container container = new Container(new Uri("/odata", UriKind.Relative));

        protected IDictionary<object, bool> EntityLoadingOperations = new Dictionary<object, bool>();

        public Container Container
        {
            get
            {
                return RepositoryBase.container;
            }
        }
    }
}
