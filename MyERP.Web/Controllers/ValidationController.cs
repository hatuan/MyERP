using System;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using MyERP.DataAccess;

namespace MyERP.Web.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : BaseController
    {
        //
        // CheckDuplicateCurrency
        public JsonResult CheckDuplicateCurrency(string code, long? id)
        {
            var repository = new CurrencyRepository();
            Currency exists;
            if (id != null)
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase) && c.Id != id);
            else
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

            if (exists == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // CheckDuplicateCurrency
        public JsonResult CheckDuplicateOrganization(string code, long? id)
        {
            var repository = new OrganizationRepository();
            Organization exists;
            if (id != null)
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase) && c.Id != id);
            else
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

            if (exists == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}