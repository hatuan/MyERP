using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.WebControls;
using MyERP.DataAccess;
using MyERP.Parse;
using MyERP.Web.Models;
using PagedList;

namespace MyERP.Web.Controllers
{
    public class OrganizationController : OpenAccessBaseController<MyERP.DataAccess.Organization, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public OrganizationController() : this(new OrganizationRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public OrganizationController(IOpenAccessBaseRepository<MyERP.DataAccess.Organization, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        //
        //GET: 
        public ActionResult Index(int? page)
        {

            var organizations = repository.GetAll(User)
                .OrderBy(c => c.Code)
                .ToList()
                .Select(c => new OrganizationViewModel()
                {
                    Code = c.Code,
                    Id = c.Id,
                    Name = c.Name,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    Status = (OrganizationStatusType) c.Status,
                    Version = c.Version
                });

            int pageNumber = (page ?? 1);

            return View(organizations.ToPagedList(pageNumber, MyERP.Common.Define.PAGESIZE));
        }

        //
        //GET: /Create
        public ActionResult Create()
        {
            var model = new OrganizationEditViewModel()
            {
                Id = Guid.NewGuid(),
                Status = OrganizationStatusType.Active
            };

            return View(model);
        }

        //
        //POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser) Membership.GetUser(User.Identity.Name, true);
                
                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                Organization newOrg = new Organization()
                {
                    Id = model.Id,
                    ClientId = clientId,
                    Code = model.Code,
                    Name = model.Name,
                    Status = (byte) model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedById = (Guid) user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedById = (Guid)user.ProviderUserKey
                };
                try
                {
                    this.repository.AddNew(newOrg);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ExceptionError", ex.Message);
                }
            }

            return View(model);
        }

        //
        //POST: /Delete
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Delete(List<String> values)
        {
            //TODO: check values has transaction => disable delete
            foreach (var value in values)
            {
                var entity = repository.GetBy(c => c.Id == new Guid(value));
                if (entity == null)
                    Json(new { Error = String.Format("Organization not found : {0}", entity.Code) });
                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("Organization delete error : {0}", entity.Code) });
                }
            }

            return Json(true);
        }


        //
        // GET: /Edit
        public ActionResult Edit(Guid id)
        {
            var organization = repository.GetBy(c => c.Id == id);
            var model = new OrganizationEditViewModel() 
                {
                    Code = organization.Code,
                    Id = organization.Id,
                    Name = organization.Name,
                    Status = (OrganizationStatusType)organization.Status,
                    Version = organization.Version
                };

            return View(model);
        }

        //
        //POST: /Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrganizationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updateOrg = repository.GetBy(c => c.Id == model.Id);
                if (updateOrg == null || updateOrg.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Organization has been changed or deleted! Please update");
                    return RedirectToAction("Index");
                }
                updateOrg.Code = model.Code;
                updateOrg.Name = model.Name;
                updateOrg.Status = (byte) model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                updateOrg.RecModified = DateTime.Now;
                updateOrg.RecModifiedById = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(updateOrg);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Id", ex.Message);
                }
                
            }

            return View(model);
        }
    }
}