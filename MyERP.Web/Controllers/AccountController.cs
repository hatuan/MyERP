using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MyERP.DataAccess;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    public class AccountController : OpenAccessBaseController<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public AccountController() : this(new AccountRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public AccountController(IOpenAccessBaseRepository<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        //
        //GET: Account
        public ActionResult Index()
        {
            var accounts = repository.GetAll(User).OrderBy(c => c.Code)
                .ToList()
                .Select(c => new AccountViewModels()
                {
                    ArAp = c.ArAp,
                    Code = c.Code,
                    CurrencyId = c.CurrencyId ?? Guid.Empty,
                    CurrencyCode = c.CurrencyId == null ? "" : c.Currency.Code,
                    Detail = c.Detail,
                    Id = c.Id,
                    Level = c.Level,
                    Name = c.Name,
                    OrganizationName = c.Organization.Name,
                    ParentAccountCode = c.ParentAccountId == null ? "" : c.ParentAccount.Code,
                    ParentAccountId = c.ParentAccountId ?? Guid.Empty,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    Status = (AccountStatusType) c.Status,
                    Version = c.Version
                });

            return View(accounts);
        }

        //
        //GET: /Account/Create
        public ActionResult Create()
        {
            var model = new AccountEditViewModel()
            {
                Id = Guid.NewGuid(),
                Status = AccountStatusType.Active
            };
            return View(model);
        }

        //
        //POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser) Membership.GetUser(User.Identity.Name, true);
                
                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                Account newAccount = new Account()
                {
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    Code = model.Code,
                    Name = model.Name,
                    CurrencyId = model.CurrencyId,
                    ParentAccountId = model.ParentAccountId,
                    ArAp = model.ArAp,
                    Status = (byte) model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedById = (Guid) user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedById = (Guid)user.ProviderUserKey
                };
                try
                {
                    this.repository.AddNew(newAccount);

                    return RedirectToAction("Index", "Account");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ExceptionError", ex.Message);
                }
            }

            return View(model);
        }

        //
        //POST: /Account/Delete
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Delete(List<String> values)
        {
            //TODO: check values has transaction => disable delete
            foreach (var value in values)
            {
                var entity = repository.GetBy(c => c.Id == new Guid(value));
                if (entity == null)
                    Json(new { Error = String.Format("Account not found : {0}", entity.Code) });
                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("Account delete error : {0}", entity.Code) });
                }
            }

            return Json(true);
        }


        //
        // GET: Account/Edit
        public ActionResult Edit(Guid id)
        {
            var account = repository.GetBy(c => c.Id == id);
            var model = new AccountEditViewModel() 
                {
                    ArAp = account.ArAp,
                    Code = account.Code,
                    CurrencyId = account.CurrencyId ?? Guid.Empty,
                    CurrencyCode = account.CurrencyId == null ? "" : account.Currency.Code,
                    Id = account.Id,
                    Name = account.Name,
                    ParentAccountCode = account.ParentAccountId == null ? "" : account.ParentAccount.Code,
                    ParentAccountId = account.ParentAccountId ?? Guid.Empty,
                    Status = (AccountStatusType)account.Status,
                    Version = account.Version
                };

            return View(model);
        }

        //
        //POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updateAccount = repository.GetBy(c => c.Id == model.Id);
                if (updateAccount == null || updateAccount.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Account has been changed or deleted! Please update");
                    return RedirectToAction("Index", "Account");
                }
                updateAccount.Code = model.Code;
                updateAccount.Name = model.Name;
                updateAccount.CurrencyId = model.CurrencyId;
                updateAccount.ParentAccountId = model.ParentAccountId;
                updateAccount.ArAp = model.ArAp;
                updateAccount.Status = (byte) model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                updateAccount.RecModified = DateTime.Now;
                updateAccount.RecModifiedById = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(updateAccount);
                    return RedirectToAction("Index", "Account");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Id", ex.Message);
                }
                
            }

            return View(model);
        }
    }
}