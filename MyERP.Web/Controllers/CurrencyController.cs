using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Web.Controllers
{
    public class CurrencyController : OpenAccessBaseController<MyERP.DataAccess.Currency, MyERP.DataAccess.EntitiesModel>
    {
         /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public CurrencyController() : this(new CurrencyRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CurrencyController(IOpenAccessBaseRepository<MyERP.DataAccess.Currency, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Currency
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autocomplete(string q)
        {
            var currencies = repository.GetAll(User)
                .Where(c => c.Code.StartsWith(q, StringComparison.CurrentCultureIgnoreCase) || c.Name.Contains(q))
                .OrderBy(c => c.Code)
                .Select(c => new 
                {
                    id = c.Id,
                    code = c.Code,
                    name = c.Name
                });

            return Json(currencies.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}