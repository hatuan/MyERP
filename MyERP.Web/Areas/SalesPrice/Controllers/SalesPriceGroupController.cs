using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess.Enum;
using MyERP.Web;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using Newtonsoft.Json;

namespace MyERP.Web.Areas.SalesPrice.Controllers
{
    public class
        SalesPriceGroupController : EntityBaseController<MyERP.DataAccess.SalesPriceGroup,
            MyERP.DataAccess.EntitiesModel>
    {
        public SalesPriceGroupController() : this(new SalesPriceGroupRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public SalesPriceGroupController(
            IBaseRepository<MyERP.DataAccess.SalesPriceGroup, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: SalesPrice/SalesPriceGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _List(string containerId = "MainCenterPanel")
        {
            return new Ext.Net.MVC.PartialViewResult
            {
                ContainerId = containerId,
                ViewName = "_List",
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
                ClearContainer = true
            };
        }

        public ActionResult GetData(StoreRequestParameters parameters)
        {
            var paging = ((SalesPriceGroupRepository) repository).Paging(parameters);

            var data = paging.Data.Select(c => new SalesPriceGroupViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                Status = (DefaultStatusType) c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreSalesPriceGroupList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null, string containerId = "SalesPriceGroupMaintenanceContainer")
        {
            var model = new SalesPriceGroupEditViewModel()
            {
                Id = null,
                SalesPrices = new List<SalesPriceEditViewModel>(),
                Status = DefaultStatusType.Active
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id,
                    new string[]
                    {
                        "RecCreatedByUser", "RecModifiedByUser", "SalesPrices", "SalesPrices.Item", "SalesPrices.Uom",
                        "SalesPrices.BusinessPartner", "SalesPrices.BusPartnerPriceGroup"
                    }).SingleOrDefault();
                List<SalesPriceEditViewModel> salesPrices = new List<SalesPriceEditViewModel>();
                salesPrices = (from salesPrice in entity.SalesPrices
                    select new SalesPriceEditViewModel()
                    {
                        Id = salesPrice.Id,
                        SalesPriceGroupId = salesPrice.SalesPriceGroupId,
                        ItemId = salesPrice.ItemId,
                        ItemCode = salesPrice.Item.Code,
                        ItemDescription = salesPrice.Item.Description,
                        Item = salesPrice.Item,
                        UomId = salesPrice.UomId,
                        UomCode = salesPrice.Uom.Code,
                        UomDescription = salesPrice.Uom.Description,
                        Uom = salesPrice.Uom,
                        SalesType = salesPrice.SalesType,
                        SalesCodeId = (
                            salesPrice.SalesType == (short) SalesPriceSalesType.Customer
                                ?
                                salesPrice.BusinessPartnerId
                                :
                                salesPrice.SalesType == (short) SalesPriceSalesType.CustomerPriceGroup
                                    ? salesPrice.BusPartnerPriceGroupId
                                    : null
                        ),
                        SalesCode = (
                            salesPrice.SalesType == (short) SalesPriceSalesType.Customer
                                ?
                                salesPrice.BusinessPartner.Code
                                :
                                salesPrice.SalesType == (short) SalesPriceSalesType.CustomerPriceGroup
                                    ? salesPrice.BusPartnerPriceGroup.Code
                                    : ""
                        ),
                        SalesModel = (
                            salesPrice.SalesType == (short) SalesPriceSalesType.Customer
                                ? new ExtNetComboBoxModel
                                {
                                    Id = salesPrice.BusinessPartnerId,
                                    Code = salesPrice.BusinessPartner.Code,
                                    Description = salesPrice.BusinessPartner.Description
                                }
                                :
                                salesPrice.SalesType == (short) SalesPriceSalesType.CustomerPriceGroup
                                    ?
                                    new ExtNetComboBoxModel
                                    {
                                        Id = salesPrice.BusPartnerPriceGroupId,
                                        Code = salesPrice.BusPartnerPriceGroup.Code,
                                        Description = salesPrice.BusPartnerPriceGroup.Description
                                    }
                                    : null
                        ),
                        StartingDate = salesPrice.StartingDate,
                        MinQty = salesPrice.MinQty,
                        UnitPrice = salesPrice.UnitPrice,
                        EndingDate = salesPrice.EndingDate,
                        Status = (DefaultStatusType) salesPrice.Status,
                        Version = salesPrice.Version
                    }).ToList();

                model = new SalesPriceGroupEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Description,
                    SalesPrices = salesPrices,
                    Status = (DefaultStatusType) entity.Status,
                    RecCreatedBy = entity.RecCreatedByUser.Name,
                    RecCreatedAt = entity.RecCreatedAt,
                    RecModifiedBy = entity.RecModifiedByUser.Name,
                    RecModifiedAt = entity.RecModifiedAt,
                    Version = entity.Version
                };
            }

            return new Ext.Net.MVC.PartialViewResult()
            {
                ContainerId = containerId,
                Model = model,
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
                ClearContainer = true
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(SalesPriceGroupEditViewModel model, string salesPrice)
        {
            List<SalesPriceEditViewModel> salesPriceLine = JsonConvert.DeserializeObject<List<SalesPriceEditViewModel>>(salesPrice, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            return new Ext.Net.MVC.PartialViewResult();
        }

        public ActionResult AddLineToSalesPrice()
        {
            var newItem = new SalesPriceEditViewModel()
            {
                Id = null,
                SalesType = (short) SalesPriceSalesType.AllCustomers,
                SalesCodeId = null,
                ItemId = 0,
                ItemDescription = "",
                UomId = null,
                StartingDate = null,
                MinQty = null,
                UnitPrice = null,
                EndingDate = null,
                Status = DefaultStatusType.Active,
                Version = 1
            };

            Store salesPriceGridStore = X.GetCmp<Store>("SalesPriceGridStore");
            salesPriceGridStore.Add(newItem);
            
            return this.Direct();
        }

        public ActionResult LookupSalesCode(StoreRequestParameters parameters, long? id = null, long? salesType = null)
        {
            if (salesType == 1) //Customer
            {
                BusinessPartnerRepository _repository = new BusinessPartnerRepository();
                if (id != null && id > 0)
                {
                    var entity = _repository.Get(c => c.Id == id, new[] { "Organization" }).SingleOrDefault();
                    var data = new BusinessPartnerViewModel()
                    {
                        Code = entity.Code,
                        Id = entity.Id,
                        Description = entity.Description,
                        OrganizationCode = entity.Organization.Code,
                        Status = (DefaultStatusType)entity.Status
                    };
                    return this.Store(data, 1);
                }
                else
                {
                    var paging = ((BusinessPartnerRepository)_repository).Paging(parameters.Start, parameters.Limit,
                        parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                    var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                        .Select(c => new BusinessPartnerViewModel
                        {
                            Code = c.Code,
                            Id = c.Id,
                            Description = c.Description,
                            OrganizationCode = c.Organization.Code,
                            Status = (DefaultStatusType)c.Status
                        }).ToList();
                    return this.Store(data, paging.TotalRecords);
                }
            } else if (salesType == 2) //Customer Price Group
            {
                BusinessPartnerPriceGroupRepository _repository = new BusinessPartnerPriceGroupRepository();
                if (id != null && id > 0)
                {
                    var entity = _repository.Get(c => c.Id == id, new[] { "Organization" }).SingleOrDefault();
                    var data = new BusinessPartnerPriceGroupViewModel()
                    {
                        Code = entity.Code,
                        Id = entity.Id,
                        Description = entity.Description,
                        OrganizationCode = entity.Organization.Code,
                        Status = (DefaultStatusType)entity.Status
                    };
                    return this.Store(data, 1);
                }
                else
                {
                    var paging = ((BusinessPartnerPriceGroupRepository)_repository).Paging(parameters.Start, parameters.Limit,
                        parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                    var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                        .Select(c => new BusinessPartnerPriceGroupViewModel
                        {
                            Code = c.Code,
                            Id = c.Id,
                            Description = c.Description,
                            OrganizationCode = c.Organization.Code,
                            Status = (DefaultStatusType)c.Status
                        }).ToList();
                    return this.Store(data, paging.TotalRecords);
                }
            }

            return this.Direct();
        }
    }
}