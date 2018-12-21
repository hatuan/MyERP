using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;

namespace MyERP.Web.Areas.Item.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.Item, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new ItemRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.Item, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Product/Index
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
            var paging = ((ItemRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new ItemViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                BaseUomCode = c.BaseUom.Code,
                ItemGroup1Code = c.ItemGroupId1 != null ? c.ItemGroup1.Code : "",
                ItemGroup2Code = c.ItemGroupId2 != null ? c.ItemGroup2.Code : "",
                ItemGroup3Code = c.ItemGroupId3 != null ? c.ItemGroup3.Code : "",
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreProductList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
        {
            if (id != null && id > 0)
            {
                var data = repository.Get(c => c.Id == id, new []{ "Organization" }).Select( c =>
                    new ItemViewModel()
                    {
                        Code = c.Code,
                        Id = c.Id,
                        Description = c.Description,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    });
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((ItemRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection, parameters.Query);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                    .Select(c => new ItemViewModel
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

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new ItemEditViewModel()
            {
                Id = null,
                ItemGroupId1 = null,
                ItemGroupId2 = null,
                ItemGroupId3 = null,
                Status = DefaultStatusType.Active
            };
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] {"BaseUom", "ItemGroup1", "ItemGroup2", "ItemGroup3", "SalesUom", "PurchUom", "PurchVendor", "ItemDiscountGroup", "Vat", "InventoryAccount", "ConsignmentAccount", "SalesAccount", "SalesInternalAccount", "SalesReturnAccount", "SalesDiscountAccount", "COGSAccount", "COGSDiffAccount", "WIPAccount" }).Single();
                model = new ItemEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    BaseUomId = entity.BaseUomId,
                    UnitPrice = entity.UnitPrice,
                    UnitCost = entity.UnitCost,
                    ItemGroupId1 = entity.ItemGroupId1,
                    ItemGroupId2 = entity.ItemGroupId2,
                    ItemGroupId3 = entity.ItemGroupId3,
                    Description = entity.Description,
                    SalesUomId = entity.SalesUomId,
                    PurchVendorId = entity.PurchVendorId,
                    PurchUomId = entity.PurchUomId,
                    VatId = entity.VatId,
                    InventoryAccountId = entity.InventoryAccountId,
                    ConsignmentAccountId = entity.ConsignmentAccountId,
                    SalesAccountId = entity.SalesAccountId,
                    SalesInternalAccountId = entity.SalesInternalAccountId,
                    SalesDiscountAccountId = entity.SalesDiscountAccountId,
                    SalesReturnAccountId = entity.SalesReturnAccountId,
                    COGSAccountId = entity.COGSAccountId,
                    COGSDiffAccountId = entity.COGSDiffAccountId,
                    WIPAccountId = entity.WIPAccountId,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };

                ViewData["BaseUomItems"] = new List<Uom>
                {
                    new Uom()
                    {
                        Id = entity.BaseUomId,
                        Code = entity.BaseUom.Code,
                        Description = entity.BaseUom.Description
                    }
                };
                
                if (entity.ItemGroupId1.HasValue)
                {
                    ViewData["ItemGroup1Items"] = new List<ItemGroup>
                    {
                        new ItemGroup()
                        {
                            Id = entity.ItemGroupId1??0,
                            Code = entity.ItemGroup1.Code,
                            Description = entity.ItemGroup1.Description
                        }
                    };
                }
                if (entity.ItemGroupId2.HasValue)
                {
                    ViewData["ItemGroup2Items"] = new List<ItemGroup>
                    {
                        new ItemGroup()
                        {
                            Id = entity.ItemGroupId2??0,
                            Code = entity.ItemGroup2.Code,
                            Description = entity.ItemGroup2.Description
                        }
                    };
                }
                if (entity.ItemGroupId3.HasValue)
                {
                    ViewData["ItemGroup3Items"] = new List<ItemGroup>
                    {
                        new ItemGroup()
                        {
                            Id = entity.ItemGroupId3??0,
                            Code = entity.ItemGroup3.Code,
                            Description = entity.ItemGroup3.Description
                        }
                    };
                }
                if (entity.VatId.HasValue)
                {
                    ViewData["VatStore"] = new List<VatLookupViewModel>
                    {
                        new VatLookupViewModel()
                        {
                            Id = entity.VatId??0,
                            Code = entity.Vat.Code,
                            Description = entity.Vat.Description
                        }
                    };
                }
                if (entity.InventoryAccountId.HasValue)
                {
                    ViewData["InventoryAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.InventoryAccountId??0,
                            Code = entity.InventoryAccount.Code,
                            Description = entity.InventoryAccount.Description
                        }
                    };
                }
                if (entity.ConsignmentAccountId.HasValue)
                {
                    ViewData["ConsignmentAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.ConsignmentAccountId??0,
                            Code = entity.ConsignmentAccount.Code,
                            Description = entity.ConsignmentAccount.Description
                        }
                    };
                }
                if (entity.SalesAccountId.HasValue)
                {
                    ViewData["SalesAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.SalesAccountId??0,
                            Code = entity.SalesAccount.Code,
                            Description = entity.SalesAccount.Description
                        }
                    };
                }
                if (entity.SalesInternalAccountId.HasValue)
                {
                    ViewData["SalesInternalAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.SalesInternalAccountId??0,
                            Code = entity.SalesInternalAccount.Code,
                            Description = entity.SalesInternalAccount.Description
                        }
                    };
                }
                if (entity.SalesDiscountAccountId.HasValue)
                {
                    ViewData["SalesDiscountAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.SalesDiscountAccountId??0,
                            Code = entity.SalesDiscountAccount.Code,
                            Description = entity.SalesDiscountAccount.Description
                        }
                    };
                }
                if (entity.SalesReturnAccountId.HasValue)
                {
                    ViewData["SalesReturnAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.SalesReturnAccountId??0,
                            Code = entity.SalesReturnAccount.Code,
                            Description = entity.SalesReturnAccount.Description
                        }
                    };
                }
                if (entity.COGSAccountId.HasValue)
                {
                    ViewData["COGSAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.COGSAccountId??0,
                            Code = entity.COGSAccount.Code,
                            Description = entity.COGSAccount.Description
                        }
                    };
                }
                if (entity.COGSDiffAccountId.HasValue)
                {
                    ViewData["COGSDiffAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.COGSDiffAccountId??0,
                            Code = entity.COGSDiffAccount.Code,
                            Description = entity.COGSDiffAccount.Description
                        }
                    };
                }
                if (entity.WIPAccountId.HasValue)
                {
                    ViewData["WIPAccountStore"] = new List<AccountLookupViewModel>
                    {
                        new AccountLookupViewModel()
                        {
                            Id = entity.WIPAccountId??0,
                            Code = entity.WIPAccount.Code,
                            Description = entity.WIPAccount.Description
                        }
                    };
                }
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model, ViewData = ViewData };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(ItemEditViewModel model)
        {
            DirectResult r = new DirectResult();

            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                long clientId = user.ClientId ?? 0;
                long organizationId = user.OrganizationId ?? 0;

                if (clientId == 0 || organizationId == 0)
                {
                    r.Success = false;
                    r.ErrorMessage = Resources.Resources.User_dont_have_Client_or_Organization_Please_set;
                    return r;
                }
                bool isEdit = model.Id.HasValue;

                if (model.Id.HasValue)
                {
                    var _update = repository.Get(c => c.Id == model.Id).SingleOrDefault();
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Item has been changed or deleted! Please check";
                        return r;
                    }

                    _update.Code = model.Code;
                    _update.Description = model.Description;
                    _update.BaseUomId = model.BaseUomId;
                    _update.PurchUomId = model.BaseUomId;
                    _update.SalesUomId = model.BaseUomId;
                    _update.UnitPrice = model.UnitPrice;
                    _update.UnitCost = model.UnitCost;
                    _update.ItemGroupId1 = model.ItemGroupId1;
                    _update.ItemGroupId2 = model.ItemGroupId2;
                    _update.ItemGroupId3 = model.ItemGroupId3;
                    _update.VatId = model.VatId;
                    _update.InventoryAccountId = model.InventoryAccountId;
                    _update.ConsignmentAccountId = model.ConsignmentAccountId;
                    _update.SalesAccountId = model.SalesAccountId;
                    _update.SalesInternalAccountId = model.SalesInternalAccountId;
                    _update.SalesDiscountAccountId = model.SalesDiscountAccountId;
                    _update.SalesReturnAccountId = model.SalesReturnAccountId;
                    _update.COGSAccountId = model.COGSAccountId;
                    _update.COGSDiffAccountId = model.COGSDiffAccountId;
                    _update.WIPAccountId = model.WIPAccountId;
                    _update.Status = (byte)model.Status;
                    _update.RecModifiedAt = DateTime.Now;
                    _update.RecModifiedBy = (long)user.ProviderUserKey;
                    _update.Version++;

                    try
                    {
                        this.repository.Update(_update);
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }

                }
                else
                {
                    var _newModel = new DataAccess.Item()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        BaseUomId = model.BaseUomId,
                        PurchUomId = model.BaseUomId,
                        SalesUomId = model.BaseUomId,
                        UnitPrice = model.UnitPrice,
                        UnitCost = model.UnitCost,
                        ItemGroupId1 = model.ItemGroupId1 == 0 ? null : model.ItemGroupId1,
                        ItemGroupId2 = model.ItemGroupId2 == 0 ? null : model.ItemGroupId2,
                        ItemGroupId3 = model.ItemGroupId3 == 0 ? null : model.ItemGroupId3,
                        VatId = model.VatId == 0 ? null : model.VatId,
                        InventoryAccountId = model.InventoryAccountId == 0 ? null : model.InventoryAccountId,
                        ConsignmentAccountId = model.ConsignmentAccountId == 0 ? null : model.ConsignmentAccountId,
                        SalesAccountId = model.SalesAccountId == 0 ? null : model.SalesAccountId,
                        SalesInternalAccountId = model.SalesInternalAccountId == 0 ? null : model.SalesInternalAccountId,
                        SalesDiscountAccountId = model.SalesDiscountAccountId == 0 ? null : model.SalesDiscountAccountId,
                        SalesReturnAccountId = model.SalesReturnAccountId == 0 ? null : model.SalesReturnAccountId,
                        COGSAccountId = model.COGSAccountId == 0 ? null : model.COGSAccountId,
                        COGSDiffAccountId = model.COGSDiffAccountId == 0 ? null : model.COGSDiffAccountId,
                        WIPAccountId = model.WIPAccountId == 0 ? null : model.WIPAccountId,
                        Status = (byte)model.Status,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long)user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long)user.ProviderUserKey
                    };

                    try
                    {
                        var newEntity = this.repository.AddNew(_newModel);
                        model.Id = newEntity.Id;
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }
                }
                //Update ItemUOM
                var itemUomRepository = new ItemUomRepository();
                var baseItemUOM = itemUomRepository.Get(c => c.ItemId == model.Id && c.IsBaseUom == 1).SingleOrDefault();
                if (baseItemUOM != null)
                {
                    baseItemUOM.UomId = model.BaseUomId;
                    baseItemUOM.QtyPerUom = 1;
                    baseItemUOM.Version++;
                    baseItemUOM.RecModifiedAt = DateTime.Now;
                    baseItemUOM.RecModifiedBy = (long) user.ProviderUserKey;
                    try
                    {
                        itemUomRepository.Update(baseItemUOM);
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }
                }
                else
                {
                    var _newModel = new DataAccess.ItemUom()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        ItemId = model.Id ?? 0,
                        UomId = model.BaseUomId,
                        QtyPerUom = 1,
                        IsBaseUom = 1,
                        Status = (byte)DefaultStatusType.Active,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long)user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long)user.ProviderUserKey
                    };

                    try
                    {
                        itemUomRepository.AddNew(_newModel);
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }
                }

                r.Success = true;
                r.Result = new { Id = model.Id };
                return r;
            }
            r.Success = false;
            return r;
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DirectResult r = new DirectResult();
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id).SingleOrDefault();
                if (entity == null)
                {
                    r.Success = false;
                    r.ErrorMessage = "Item not found! Please check";
                    return r;
                }

                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception e)
                {
                    r.Success = false;
                    r.ErrorMessage = e.Message;
                    return r;
                }

                Store StoreItemList = X.GetCmp<Store>("StoreItemList");
                StoreItemList.Reload();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }
    }
}