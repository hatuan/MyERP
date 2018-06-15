using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
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
                        ItemCode = salesPrice.Item?.Code,
                        ItemDescription = salesPrice.Item?.Description,
                        Item = salesPrice.Item,
                        UomId = salesPrice.UomId,
                        UomCode = salesPrice.Uom?.Code,
                        UomDescription = salesPrice.Uom?.Description,
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
                                salesPrice.BusinessPartner?.Code
                                :
                                salesPrice.SalesType == (short) SalesPriceSalesType.CustomerPriceGroup
                                    ? salesPrice.BusPartnerPriceGroup?.Code
                                    : ""
                        ),
                        SalesModel = (
                            salesPrice.SalesType == (short) SalesPriceSalesType.Customer
                                ? new ExtNetComboBoxModel
                                {
                                    Id = salesPrice.BusinessPartnerId,
                                    Code = salesPrice.BusinessPartner?.Code,
                                    Description = salesPrice.BusinessPartner?.Description
                                }
                                :
                                salesPrice.SalesType == (short) SalesPriceSalesType.CustomerPriceGroup
                                    ?
                                    new ExtNetComboBoxModel
                                    {
                                        Id = salesPrice.BusPartnerPriceGroupId,
                                        Code = salesPrice.BusPartnerPriceGroup?.Code,
                                        Description = salesPrice.BusPartnerPriceGroup?.Description
                                    }
                                    : null
                        ),
                        StartingDate = salesPrice.StartingDate.CompareTo(new DateTime(1900, 1, 1, 0, 0, 0)) == 0 ? default(DateTime) : salesPrice.StartingDate,
                        MinQty = salesPrice.MinQty,
                        UnitPrice = salesPrice.UnitPrice,
                        EndingDate = salesPrice.EndingDate,
                        Status = (DefaultStatusType) salesPrice.Status,
                        Version = salesPrice.Version
                    }).ToList();

                ViewData["SalesCodes"] = salesPrices.GroupBy(x => new { x.SalesCodeId, x.SalesCode }).Select(i => i.First())
                    .Select(x => new 
                    {
                        Id = x.SalesCodeId,
                        Code = x.SalesCode,
                        Description = x.SalesCode,
                    });

                ViewData["Items"] = salesPrices.GroupBy(x => new { x.ItemId, x.ItemCode, x.ItemDescription }).Select(i => i.First())
                    .Select(x => new 
                    {
                        Id = x.ItemId,
                        Code = x.ItemCode,
                        Description = x.ItemDescription,
                    });

                ViewData["Uoms"] = salesPrices.GroupBy(x => new { x.UomId, x.UomCode, x.UomDescription }).Select(i => i.First())
                    .Select(x => new 
                    {
                        Id = x.UomId,
                        Code = x.UomCode,
                        Description = x.UomDescription,
                    });

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
                ClearContainer = true,
                ViewData = ViewData
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(SalesPriceGroupEditViewModel model, string salesPrice)
        {
            List<SalesPriceEditViewModel> salesPricesModel = JsonConvert.DeserializeObject<List<SalesPriceEditViewModel>>(salesPrice, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            DirectResult r = new DirectResult();
            r.Success = false;


            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                long clientId = user.ClientId ?? 0;
                long organizationId = user.OrganizationId ?? 0;

                if (clientId == 0 || organizationId == 0)
                {
                    r.Success = false;
                    r.ErrorMessage = "User don't have Client or Organization. Please set";
                    return r;
                }
                if (!model.Id.HasValue) //New
                {
                    SalesPriceGroup newSalesPriceGroup = new SalesPriceGroup()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        Status = (byte) model.Status,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long) user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long) user.ProviderUserKey
                    };
                    List<DataAccess.SalesPrice> salesPriceList = salesPricesModel
                        .Select(c => new DataAccess.SalesPrice()
                        {
                            ClientId = clientId,
                            OrganizationId = organizationId,
                            SalesType = c.SalesType,
                            BusPartnerPriceGroupId = c.SalesType == 2 ? c.SalesCodeId : null,
                            BusinessPartnerId = c.SalesType == 1 ? c.SalesCodeId : null,
                            ItemId = c.ItemId,
                            UomId = c.UomId,
                            StartingDate = c.StartingDate ?? new DateTime(1900, 1, 1, 0, 0, 0),
                            MinQty = c.MinQty ?? 0,
                            UnitPrice = c.UnitPrice ?? 0,
                            Status = (byte)DefaultStatusType.Active,
                            Version = 1,
                            RecModifiedAt = DateTime.Now,
                            RecCreatedBy = (long)user.ProviderUserKey,
                            RecCreatedAt = DateTime.Now,
                            RecModifiedBy = (long)user.ProviderUserKey
                        }).ToList();
                    newSalesPriceGroup.SalesPrices = salesPriceList;

                    newSalesPriceGroup = repository.AddNew(newSalesPriceGroup);
                    r.Result = newSalesPriceGroup.Id;
                }
                Store storeList = X.GetCmp<Store>("StoreSalesPriceGroupList");
                storeList.Reload();

                r.Success = true;
                return r;
            }
            
            return r;
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