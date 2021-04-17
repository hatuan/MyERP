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
    public interface IUnitOfWork
    {
        EntitiesModel DataContext { get;  }

        ClientRepository ClientRepository { get; }
        CurrencyRepository CurrencyRepository { get; }
        OrganizationRepository OrganizationRepository { get; }
        UserRepository UserRepository { get; }
        RoleRepository RoleRepository { get; }
        NoSequenceRepository NoSequenceRepository { get; }
        NoSequenceLineRepository NoSequenceLineRepository { get; }
        OptionRepository OptionRepository { get; }

        void Commit();
    }
}
