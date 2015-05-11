using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    public class ClientController : OpenAccessBaseController<MyERP.DataAccess.Client, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public ClientController() : this(new ClientRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public ClientController(IOpenAccessBaseRepository<MyERP.DataAccess.Client, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Client
        public ActionResult Edit()
        {
            var client = repository.GetAll().Select(c => new ClientEditViewModel()
            {
                Id = c.ClientId,
                Name = c.Name,
                CultureId = c.CultureId,
                AmountDecimalPlaces = c.AmountDecimalPlaces,
                UnitAmountDecimalPlaces = c.UnitAmountDecimalPlaces,
                AmountRoundingPrecision = c.AmountRoundingPrecision,
                UnitAmountRoundingPrecision = c.UnitAmountRoundingPrecision,
                IsActived = c.IsActivated,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreated = c.RecCreated,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModified = c.RecModified,
                Version = c.Version

            }).FirstOrDefault();

            var defaultCulture = client.CultureId;

            var cultures = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "vi-VN", Text = "vi-VN"},
                new SelectListItem() { Value = "en-US", Text = "en-US"},
            };

            if (!String.IsNullOrEmpty(defaultCulture))
            {
                SelectListItem selectedCulture = cultures.FirstOrDefault(c => c.Value == defaultCulture);

                if (selectedCulture != null)
                {
                    selectedCulture.Selected = true;
                    ViewBag.Cultures = new SelectList(cultures, "Value", "Text", defaultCulture);
                }
                else
                    ViewBag.Cultures = new SelectList(cultures, "Value", "Text");
            }
            else
                ViewBag.Cultures = new SelectList(cultures, "Value", "Text");

            return View(client);
        }

        //
        //POST: /User/Preference
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientEditViewModel model)
        {
            return View(model);
        }
    }
}