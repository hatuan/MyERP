using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyERP.Web.Controllers;

namespace MyERP.Web.Areas.BusinessPartner.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.BusinessPartner, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new BusinessPartnerRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.BusinessPartner, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: BusinessPartner/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}