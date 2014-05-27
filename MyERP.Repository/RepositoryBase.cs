using System;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    public abstract class RepositoryBase
    {
        private static readonly Container container = new Container(new Uri("/MyERP.Web/odata", UriKind.Relative));

        protected RepositoryBase()
        {
            container.SendingRequest2 += (s, e) =>
            {
                if (AuthHeader != null && !String.IsNullOrWhiteSpace(AuthHeader))
                {
                    e.RequestMessage.SetHeader("Authorization", AuthHeader);
                }
                
                System.Diagnostics.Debug.WriteLine("{0} {1}", e.RequestMessage.Method, e.RequestMessage.Url);
            };
        }

        public Container Container
        {
            get
            {
                return RepositoryBase.container;
            }
        }

        private String _authHeader = "";

        public String AuthHeader
        {
            get { return _authHeader; }
            protected set{ _authHeader = value; }
        }

    }
}
