using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyERP.DataAccess;
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
                CurrencyLCYCode = c.CurrencyLCY.Code,
                CurrencyLCYId = c.CurrencyLCYId,
                CultureId = c.CultureId,
                AmountDecimalPlaces = c.AmountDecimalPlaces,
                UnitAmountDecimalPlaces = c.UnitAmountDecimalPlaces,
                AmountRoundingPrecision = c.AmountRoundingPrecision,
                UnitAmountRoundingPrecision = c.UnitAmountRoundingPrecision,
                IsActived = c.IsActivated,
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
            if (ModelState.IsValid)
            {
                var updateClient = repository.GetBy(c => c.ClientId == model.Id);
                if (updateClient == null || updateClient.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Client has been changed or deleted! Please update");
                    return RedirectToAction("Edit");
                }
                updateClient.Name = model.Name;
                updateClient.CurrencyLCYId = model.CurrencyLCYId;
                updateClient.CultureId = model.CultureId;
                updateClient.AmountDecimalPlaces = model.AmountDecimalPlaces;
                updateClient.UnitAmountDecimalPlaces = model.UnitAmountDecimalPlaces;
                updateClient.AmountRoundingPrecision = model.AmountRoundingPrecision;
                updateClient.UnitAmountRoundingPrecision = model.UnitAmountRoundingPrecision;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                updateClient.RecModified = DateTime.Now;
                updateClient.RecModifiedById = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(updateClient);
                    return RedirectToAction("Edit");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Id", ex.Message);
                }
            }

            var cultures = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "vi-VN", Text = "vi-VN"},
                new SelectListItem() { Value = "en-US", Text = "en-US"},
            };
            ViewBag.Cultures = new SelectList(cultures, "Value", "Text", model.CultureId);
            return View(model);
        }
    }
}