using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    [Authorize]
    public class AccountController : OpenAccessBaseController<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public AccountController()
        {
            this.repository = new AccountRepository();
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

            return View();
        }

        //
        //GET: /Account/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        //POST: /Account/Create
        [HttpPost]
        public ActionResult Create(AccountViewModels model)
        {
            return View(model);
        }

    }
}