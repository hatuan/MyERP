using System;
using System.Data.Services.Client;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    public abstract class RepositoryBase
    {
        private static readonly Container container = new Container(new Uri("/MyERP.Web/odata", UriKind.Relative));

        private static bool attachedEvent = false;
        protected RepositoryBase()
        {
            if (!attachedEvent)
            {
                //container.SaveChangesDefaultOptions = SaveChangesOptions.ReplaceOnUpdate;
                container.SendingRequest2 += (s, e) =>
                {
                    if (AuthHeader != null && !String.IsNullOrWhiteSpace(AuthHeader))
                    {
                        e.RequestMessage.SetHeader("Authorization", AuthHeader);
                    }

                    System.Diagnostics.Debug.WriteLine("{0} {1}", e.RequestMessage.Method, e.RequestMessage.Url);
                };

                attachedEvent = true;
            }
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
