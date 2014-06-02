using System;
using System.Data.Services.Client;
using MyERP.Repository.MyERPService;


namespace MyERP.Repositories
{
    public abstract class RepositoryBase
    {
        private static readonly Container container = new Container(new Uri("/MyERP.Web/odata", UriKind.Relative));

        private static bool isCreated = false;
        protected RepositoryBase()
        {
            if (!isCreated)
            {
                container.MergeOption = MergeOption.OverwriteChanges;
                container.SaveChangesDefaultOptions = SaveChangesOptions.ReplaceOnUpdate;
                container.SendingRequest2 += (s, e) =>
                {
                    if (AuthHeader != null && !String.IsNullOrWhiteSpace(AuthHeader))
                    {
                        e.RequestMessage.SetHeader("Authorization", AuthHeader);
                    }

                    System.Diagnostics.Debug.WriteLine("{0} {1}", e.RequestMessage.Method, e.RequestMessage.Url);
                };

                isCreated = true;
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

        public virtual void SaveChanges()
        {
            this.Container.BeginSaveChanges(result =>
            {
                DataServiceResponse response = this.Container.EndSaveChanges(result);
                foreach (ChangeOperationResponse change in response)
                {
                    // Get the descriptor for the entity.
                    EntityDescriptor descriptor = change.Descriptor as EntityDescriptor;

                    if (descriptor != null)
                    {

                    }
                }
            }, null);
        }

        public virtual void Update(object entity)
        {
            this.Container.UpdateObject(entity);
        }

        public virtual void Delete(object entity)
        {
            this.Container.DeleteObject(entity);
        }

        public virtual void AddNew(string entitySetName, object entity)
        {
            this.Container.AddObject(entitySetName, entity);
        }
    }
}
