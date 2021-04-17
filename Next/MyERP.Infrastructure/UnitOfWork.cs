using MyERP.DataAccess;
using MyERP.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Infrastructure
{
    //reference : https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public class UnitOfWork: Disposable, IUnitOfWork
    {

        protected EntitiesModel dataContext = new EntitiesModel();

        public EntitiesModel DataContext
        {
            get { return dataContext; }
        }

        ClientRepository clientRepository;
        public ClientRepository ClientRepository
        {
            get
            {
                if (this.clientRepository == null)
                {
                    this.clientRepository = new ClientRepository();
                }
                return clientRepository;
            }
        }

        CurrencyRepository currencyRepository;
        public CurrencyRepository CurrencyRepository
        {
            get
            {
                if (this.currencyRepository == null)
                {
                    this.currencyRepository = new CurrencyRepository();
                }
                return currencyRepository;
            }
        }

        OrganizationRepository organizationRepository;
        public OrganizationRepository OrganizationRepository
        {
            get
            {
                if (this.organizationRepository == null)
                {
                    this.organizationRepository = new OrganizationRepository();
                }
                return organizationRepository;
            }
        }

        UserRepository userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository();
                }
                return userRepository;
            }
        }

        RoleRepository roleRepository;
        public RoleRepository RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository();
                }
                return roleRepository;
            }
        }

        NoSequenceRepository noSequenceRepository;
        public NoSequenceRepository NoSequenceRepository
        {
            get
            {
                if (this.noSequenceRepository == null)
                {
                    this.noSequenceRepository = new NoSequenceRepository();
                }
                return noSequenceRepository;
            }
        }

        NoSequenceLineRepository noSequenceLineRepository;
        public NoSequenceLineRepository NoSequenceLineRepository
        {
            get
            {
                if (this.noSequenceLineRepository == null)
                {
                    this.noSequenceLineRepository = new NoSequenceLineRepository();
                }
                return noSequenceLineRepository;
            }
        }

        OptionRepository optionRepository;
        public OptionRepository OptionRepository
        {
            get
            {
                if (this.optionRepository == null)
                {
                    this.optionRepository = new OptionRepository();
                }
                return optionRepository;
            }
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
