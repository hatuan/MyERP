using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net.MVC;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    [DirectController]
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index(bool showPreference = false)
        {
            ViewBag.showPreference = showPreference;

            var model = new PreferenceViewModel();
            model.WorkingDate = DateTime.Now;

            var organizationRepository = new OrganizationRepository();
            var organizations = organizationRepository.GetAll(User)
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Desctiption
                }).ToList();

            model.RootOrganization = organizationRepository.GetRootOrganization(User);

            var defaultOrganizationId = (Membership.GetUser(User.Identity.Name, true) as MyERPMembershipUser).OrganizationId.ToString();
            var defaultCultureUI = (Membership.GetUser(User.Identity.Name, true) as MyERPMembershipUser).CultureUiId;

            if (Session["Preference"] != null)
            {
                defaultOrganizationId = model.OrganizationId = (Session["Preference"] as PreferenceViewModel).OrganizationId;
                defaultCultureUI = model.CultureUI = (Session["Preference"] as PreferenceViewModel).CultureUI;
                model.WorkingDate = (Session["Preference"] as PreferenceViewModel).WorkingDate;
            }

            if (!string.IsNullOrEmpty(defaultOrganizationId) && defaultOrganizationId != Guid.Empty.ToString())
            {
                SelectListItem selected = organizations.FirstOrDefault(c => c.Value == defaultOrganizationId);

                if (selected != null)
                {
                    selected.Selected = true;
                    ViewBag.Organizations = new SelectList(organizations, "Value", "Text", selected.Value);
                }
                else
                {
                    ViewBag.Organizations = new SelectList(organizations, "Value", "Text");
                }
            }
            else
                ViewBag.Organizations = new SelectList(organizations, "Value", "Text");

            var cultureUIs = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "vi-VN", Text = "VietNam"},
                new SelectListItem() { Value = "en-US", Text = "English"},
            };

            if (!String.IsNullOrEmpty(defaultCultureUI))
            {
                SelectListItem selectedcultureUI = cultureUIs.FirstOrDefault(c => c.Value == defaultCultureUI);

                if (selectedcultureUI != null)
                {
                    selectedcultureUI.Selected = true;
                    ViewBag.CultureUIs = new SelectList(cultureUIs, "Value", "Text", defaultCultureUI);
                }
                else
                    ViewBag.CultureUIs = new SelectList(cultureUIs, "Value", "Text");
            }
            else
                ViewBag.CultureUIs = new SelectList(cultureUIs, "Value", "Text");

            return View(model);
        }

        public ActionResult Home()
        {
            return View();
        }

        [OutputCache(Duration = 3600)]
        public ActionResult GetMenuNodes(string node)
        {
            if (node == "Root")
            {
                return this.Content(TreeMenusModel.GetTreeMenusNodes().ToJson());
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }
}