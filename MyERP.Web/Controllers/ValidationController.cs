using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        // CheckDuplicateAccount
        public JsonResult CheckDuplicateAccount(string code, Guid? id)
        {
            var repository = new AccountRepository();
            Account existsAccount;
            if(id != null && id != Guid.Empty)
                existsAccount = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase) && c.Id != id);
            else
                existsAccount = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

            if (existsAccount == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // CheckParentAccount
        public JsonResult CheckParentAccount(string parentAccountCode)
        {
            if (parentAccountCode.IsNullOrWhiteSpace())
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var repository = new AccountRepository();

            //TODO: Kiem tra phat sinh cua ParentAccountId neu da co ps thi khong cho tao tai khoan con
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        //
        // CheckDuplicateNumberSequence
        public JsonResult CheckDuplicateNumberSequence(string code, Guid? id)
        {
            var repository = new NumberSequenceRepository();
            NumberSequence exists;
            if (id != null && id != Guid.Empty)
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
        public JsonResult CheckDuplicateCurrency(string code, Guid? id)
        {
            var repository = new CurrencyRepository();
            Currency exists;
            if (id != null && id != Guid.Empty)
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