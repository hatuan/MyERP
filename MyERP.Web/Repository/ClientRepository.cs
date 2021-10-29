using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web.Security;
using MyERP.DataAccess;
using MyERP.Web.Models;
using MyERP.Web.Others;

namespace MyERP.Web
{
    public partial class ClientRepository 
    {
        public Client Get(IPrincipal principal, string[] includePaths = null)
        {
            var membershipUser = (MyERPMembershipUser)Membership.GetUser(principal.Identity.Name, true);

            IQueryable<Client> query = dataContext.Set<Client>();
            query = query.Where(c => c.Id == membershipUser.ClientId);
            if (includePaths != null)
            {
                for (var i = 0; i < includePaths.Count(); i++)
                {
                    query = query.Include(includePaths[i]);
                }
            }

            return query.First();
        }

        /// <summary>
        /// Create new Client. 
        /// Default User, Org, Currency will create after client active
        /// </summary>
        /// <param name="modelDTO"></param>
        public Client Register(RegisterDTO modelDTO)
        {
            using (DbContextTransaction scope = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var newClient = new MyERP.DataAccess.Client
                    {
                        UUID = Guid.NewGuid().ToString().ToUpper(),
                        Description = modelDTO.Description,
                        IsActivated = false,
                        CultureId = "vi-VN",
                        AmountDecimalPlaces = 0,
                        AmountRoundingPrecision = 0,
                        UnitAmountDecimalPlaces = 0,
                        UnitAmountRoundingPrecision = 0,
                        CurrencyLcyId = null,
                        TaxCode = modelDTO.TaxCode,
                        Address = modelDTO.Address,
                        AddressTransition = modelDTO.AddressTransition,
                        Telephone = modelDTO.Telephone,
                        Email = modelDTO.Email,
                        Website = modelDTO.Website,
                        Image = null,
                        RepresentativeName = modelDTO.RepresentativeName,
                        RepresentativePosition = modelDTO.RepresentativePosition,
                        ContactName = modelDTO.ContactName,
                        Mobilephone = modelDTO.Mobilephone,
                        TaxAuthoritiesId = null,
                        RecCreatedBy = null,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = null,
                        RecModifiedAt = DateTime.Now,
                        Version = 1
                    };
                    newClient = dataContext.Clients.Add(newClient);

                    dataContext.SaveChanges();

                    scope.Commit();

                    return newClient;
                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Default User, Role, UserInRole, Org, Currency will create after client active
        /// </summary>
        /// <param name="UUID"></param>
        /// <returns></returns>
        public bool Active(string UUID, out string userName, out string password, out string email)
        {
            using (DbContextTransaction scope = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var client = DataContext.Clients.Where(x => x.UUID == UUID && x.IsActivated == false).FirstOrDefault();
                    if (client == null)
                    {
                        throw new System.Data.Entity.Core.ObjectNotFoundException($"Client {UUID} has been changed or deleted! Please check");
                    }

                    client.IsActivated = true;

                    //Register new user
                    var _name = userName = client.TaxCode + "-ADMIN";
                    var _pass = password = Functions.RandomString(8);
                    var _email = email = client.Email;
                    var _salt = Functions.RandomString(8);
                    var _passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(_name + _pass), _pass);
                    var activeUser = new User
                    {
                        Name = client.TaxCode +  "-ADMIN",
                        FullName = client.TaxCode + "-ADMIN",
                        Email = client.Email,
                        IsActivated = true,
                        IsEmailConfirmed = true,
                        Password = _passEncrypt,
                        Salt = _salt,
                        OrganizationId = null,
                        Client = client,
                        CultureUiId = "vi-VN",
                        Comment =  $"Admin user of {client.Description} - {client.TaxCode}",
                        CreatedDate = DateTime.Now,
                        LastModifiedDate = DateTime.Now,
                        LastLoginIp = "0.0.0.0",
                        LastLoginDate = DateTime.Now,
                        IsLockedOut = false,
                        LastLockedOutDate = DateTime.MinValue,
                        LastLockedOutReason = "",
                        Version = 1
                    };
                    activeUser = dataContext.Users.Add(activeUser);
                    dataContext.SaveChanges();

                    //Add Role
                    var role = new Role
                    {
                        Description = "ADMIN",
                        Client = client
                    };
                    role = DataContext.Roles.Add(role);
                    dataContext.SaveChanges();

                    //Add UserInRole
                    var userInRole = new UserInRole
                    {
                        Role = role,
                        User = activeUser,
                    };
                    userInRole = DataContext.UserInRoles.Add(userInRole);
                    dataContext.SaveChanges();

                    //Register new Org
                    var newOrg = new Organization
                    {
                        Code = "*",
                        Description = "*",
                        Client = client,
                        RecCreatedByUser = activeUser,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedByUser = activeUser,
                        RecModifiedAt = DateTime.Now,
                        Blocked = false,
                        Version = 1
                    };
                    newOrg = DataContext.Organizations.Add(newOrg);
                    dataContext.SaveChanges();

                    activeUser.Organization = newOrg;
                    dataContext.SaveChanges();

                    //Register new Currency
                    var newCurrency = new Currency
                    {
                        Code = "VND",
                        Description = "Việt Nam Đồng",
                        OrganizationId = newOrg.Id,
                        Client = client,
                        RecCreatedByUser = activeUser,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedByUser = activeUser,
                        RecModifiedAt = DateTime.Now,
                        Blocked = false,
                        Version = 1
                    };
                    newCurrency = DataContext.Currencies.Add(newCurrency);
                    dataContext.SaveChanges();

                    client.CurrencyLcy = newCurrency;
                    dataContext.SaveChanges();

                    scope.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    throw ex;
                }
            }
        }
    }

}