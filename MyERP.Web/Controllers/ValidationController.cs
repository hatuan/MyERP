using System;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using MyERP.DataAccess;
using MyERP.Web.Models;

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
            if (id != null && id != 0)
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase) && c.Id != id);
            else
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        //
        // CheckDuplicateOrganization
        public JsonResult CheckDuplicateOrganization(string code, long? id)
        {
            var repository = new OrganizationRepository();
            Organization exists;
            if (id != null && id != 0)
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase) && c.Id != id);
            else
                exists = repository.GetBy(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        //
        // CheckDuplicateUOM
        public JsonResult CheckDuplicateUom(UOMEditViewModel uom)
        {
            var repository = new UomRepository();
            Uom exists;
            if (uom.Id != null && uom.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(uom.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != uom.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(uom.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateUom(UOMEditViewModel uom)
        {
            var repository = new UomRepository();
            Uom exists;
            if (uom.Id != null && uom.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(uom.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != uom.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(uom.Code, StringComparison.InvariantCultureIgnoreCase));

            return new JsonResult
            {
                Data = new
                {
                    serviceResponse = new
                    {
                        valid = exists == null
                    }
                }
            };
        }

        /// <summary>
        /// Html.X().TextFieldFor(m => m.Code).AllowBlank(false).ID("Code")
        ///     .IsRemoteValidation(true)
        ///     .RemoteValidation(remotevalid =>
        ///     {
        ///         remotevalid.Url = "/Validation/ExtRemoteCheckDuplicateUom";
        ///         remotevalid.Json = true;
        ///         remotevalid.ExtraParams.Add(new Parameter("NEW_CODE", "function() { return #{Code}.getValue(); }", ParameterMode.Raw));
        ///         remotevalid.ExtraParams.Add(new Parameter("CURRENT_ID", "function() { return #{Id}.getValue(); }", ParameterMode.Raw));
        ///     })
        /// </summary>
        /// <param name="NEW_CODE"></param>
        /// <param name="CURRENT_ID"></param>
        /// <returns></returns>
        public JsonResult ExtRemoteCheckDuplicateUom(string NEW_CODE, string CURRENT_ID)
        {
            var repository = new UomRepository();
            Uom exists;
            if (!String.IsNullOrEmpty(CURRENT_ID))
            {
                long _id = Convert.ToInt64(CURRENT_ID);
                exists = repository.GetBy(c => c.Code.Equals(NEW_CODE, StringComparison.InvariantCultureIgnoreCase) && c.Id != _id);
            }
            else
                exists = repository.GetBy(c => c.Code.Equals(NEW_CODE, StringComparison.InvariantCultureIgnoreCase));

            return new JsonResult
            {
                Data = new
                {
                    serviceResponse = new
                    {
                        message = "UOM code already exists. Please specify another one.",
                        valid = exists == null
                    }
                }
            };
        }

        //
        // CheckDuplicateProduct
        public JsonResult CheckDuplicateItem(ItemEditViewModel product)
        {
            var repository = new ItemRepository();
            Item exists;
            if (product.Id != null && product.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != product.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateItem(ItemEditViewModel product)
        {
            var repository = new ItemRepository();
            Item exists;
            if (product.Id != null && product.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != product.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase));

            return new JsonResult
            {
                Data = new
                {
                    serviceResponse = new
                    {
                        valid = exists == null
                    }
                }
            };
        }
    }
}