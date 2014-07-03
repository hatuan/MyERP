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
    [Authorize]
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
            var model = new AccountCreateViewModel
            {
                Status = AccountStatusType.Active
            };
            return View(model);
        }

        //
        //POST: /Account/Create
        [HttpPost]
        public ActionResult Create(AccountCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }

    }
}