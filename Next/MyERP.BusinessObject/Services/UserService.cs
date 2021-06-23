using MyERP.BusinessObject.ViewModels;
using MyERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisej.Web;

namespace MyERP.BusinessObject.Services
{
    public class UserService
    {
        public bool UpdateDefaultOrganization(string name, long organizationId)
        {
            using(UnitOfWork uom = new UnitOfWork())
            {
                var user = uom.UserRepository.GetBy(c => c.Name == name);
                if (user == null) return false;
                try
                {
                    user.OrganizationId = organizationId;
                    uom.UserRepository.Update(user);

                    uom.Commit();

                    Application.Session.OrganizationId = organizationId;
                    return true;
                }
                catch (Exception)
                {
                }
                return false;
            }
        }

        public bool Login(String userName, String passWord)
        {
            using (UnitOfWork uom = new UnitOfWork())
            {
                var user = uom.UserRepository.Get(x => x.Name == userName, new string[] { "Organization" }).SingleOrDefault();

                if (user == null)
                    throw new KeyNotFoundException("username");

                if (user.Password != passWord)
                    throw new KeyNotFoundException("password");

                Application.Session.LoginUser = userName;
                Application.Session.ClientId = user.ClientId;
                Application.Session.Client = new ClientService().GetClientById(user.ClientId); 
                Application.Session.OrganizationId = user.OrganizationId;
                Application.Session.Organization = new OrganizationViewModel
                {
                    Id = user.Organization.Id,
                    Code = user.Organization.Code,
                    Name = user.Organization.Description,
                    Status = user.Organization.Status,
                };

                return true;
            }
        }

    }
}
