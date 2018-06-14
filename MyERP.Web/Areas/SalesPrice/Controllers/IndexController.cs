using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using MyERP.Web.Controllers;

namespace MyERP.Web.Areas.SalesPrice.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.SalesPrice, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new SalesPriceRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.SalesPrice, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: SalesPrice/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}