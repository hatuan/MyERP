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
        public JsonResult CheckDuplicateCurrency(CurrencyEditViewModel entity)
        {
            var repository = new NoSequenceRepository();
            object exists;
            if (entity.Id != null && entity.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != entity.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateCurrency(CurrencyEditViewModel entity)
        {
            var repository = new CurrencyRepository();
            object exists;
            if (entity.Id != null && entity.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != entity.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase));

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

        public JsonResult ExtCheckLookupCodeUom(String Value)
        {
            var repository = new UomRepository();
            var exists = repository.GetBy(c => c.Code.Equals(Value, StringComparison.InvariantCultureIgnoreCase));

            return new JsonResult
            {
                Data = new
                {
                    serviceResponse = new
                    {
                        valid = exists != null
                    }
                }
            };
        }

        //
        // CheckDuplicateItem
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

        //
        // CheckDuplicateItemGroup
        public JsonResult CheckDuplicateItemGroup(ItemGroupEditViewModel product)
        {
            var repository = new ItemGroupRepository();
            ItemGroup exists;
            if (product.Id != null && product.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != product.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateItemGroup(ItemGroupEditViewModel product)
        {
            var repository = new ItemGroupRepository();
            ItemGroup exists;
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

        //
        // CheckDuplicateBusinessPartner
        public JsonResult CheckDuplicateBusinessPartner(BusinessPartnerEditViewModel product)
        {
            var repository = new BusinessPartnerRepository();
            BusinessPartner exists;
            if (product.Id != null && product.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != product.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateBusinessPartner(BusinessPartnerEditViewModel product)
        {
            var repository = new BusinessPartnerRepository();
            BusinessPartner exists;
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

        //
        // CheckDuplicateBusinessPartnerGroup
        public JsonResult CheckDuplicateBusinessPartnerGroup(BusinessPartnerGroupEditViewModel product)
        {
            var repository = new BusinessPartnerGroupRepository();
            BusinessPartnerGroup exists;
            if (product.Id != null && product.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != product.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateBusinessPartnerGroup(BusinessPartnerGroupEditViewModel product)
        {
            var repository = new BusinessPartnerGroupRepository();
            BusinessPartnerGroup exists;
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

        //
        // CheckDuplicateBusinessPartnerPriceGroup
        public JsonResult CheckDuplicateBusinessPartnerPriceGroup(BusinessPartnerPriceGroupEditViewModel busPartnerPriceGroup)
        {
            var repository = new BusinessPartnerPriceGroupRepository();
            BusinessPartnerPriceGroup exists;
            if (busPartnerPriceGroup.Id != null && busPartnerPriceGroup.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(busPartnerPriceGroup.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != busPartnerPriceGroup.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(busPartnerPriceGroup.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateBusinessPartnerPriceGroup(BusinessPartnerGroupEditViewModel busPartnerPriceGroup)
        {
            var repository = new BusinessPartnerPriceGroupRepository();
            BusinessPartnerPriceGroup exists;
            if (busPartnerPriceGroup.Id != null && busPartnerPriceGroup.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(busPartnerPriceGroup.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != busPartnerPriceGroup.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(busPartnerPriceGroup.Code, StringComparison.InvariantCultureIgnoreCase));

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

        //
        // CheckDuplicateSalesPriceGroup
        public JsonResult CheckDuplicateSalesPriceGroup(SalesPriceGroupEditViewModel product)
        {
            var repository = new SalesPriceGroupRepository();
            SalesPriceGroup exists;
            if (product.Id != null && product.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != product.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(product.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateSalesPriceGroup(SalesPriceGroupEditViewModel product)
        {
            var repository = new SalesPriceGroupRepository();
            SalesPriceGroup exists;
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

        //
        // CheckDuplicateLocation
        public JsonResult CheckDuplicateLocation(LocationEditViewModel entity)
        {
            var repository = new LocationRepository();
            object exists;
            if (entity.Id != null && entity.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != entity.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateLocation(LocationEditViewModel entity)
        {
            var repository = new LocationRepository();
            object exists;
            if (entity.Id != null && entity.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != entity.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase));

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

        //
        // CheckDuplicateNoSequence
        public JsonResult CheckDuplicateNoSequence(NoSequenceEditViewModel entity)
        {
            var repository = new NoSequenceRepository();
            object exists;
            if (entity.Id != null && entity.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != entity.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase));

            return Json(exists != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExtCheckDuplicateNoSequence(NoSequenceEditViewModel entity)
        {
            var repository = new NoSequenceRepository();
            object exists;
            if (entity.Id != null && entity.Id != 0)
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase) && c.Id != entity.Id);
            else
                exists = repository.GetBy(c => c.Code.Equals(entity.Code, StringComparison.InvariantCultureIgnoreCase));

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