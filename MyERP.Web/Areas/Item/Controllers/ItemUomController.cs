using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;

namespace MyERP.Web.Areas.Item.Controllers
{
    public class ItemUomController : EntityBaseController<MyERP.DataAccess.ItemUom, MyERP.DataAccess.EntitiesModel>
    {
        public ItemUomController() : this(new ItemUomRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public ItemUomController(IBaseRepository<MyERP.DataAccess.ItemUom, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Item/ItemUom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LookupUomOfItem(string query)
        {
            var itemUomRepository = new ItemUomRepository();
            long itemId = 0;
            if (String.IsNullOrEmpty(query))
                return this.Direct();
            if (!Int64.TryParse(query, out itemId))
            {
                return this.Direct(false, "ERROR : query parameter can not convert to long");
            }
            var listUomOfItem = itemUomRepository.Get(c => c.ItemId == itemId, new string[] {"Uom"});
            
            var data = listUomOfItem
                .Select(c => new ItemUomLookUpViewModel
                {
                    Code = c.Uom.Code,
                    UomId = c.UomId,
                    Description = c.Uom.Description,
                    QtyPerUom = c.QtyPerUom
                }).ToList();
            return this.Store(data, data.Count);
        }
    }
}