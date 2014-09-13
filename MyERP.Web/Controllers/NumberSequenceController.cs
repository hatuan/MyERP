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
    public class NumberSequenceController : OpenAccessBaseController<MyERP.DataAccess.NumberSequence, MyERP.DataAccess.EntitiesModel>
    {
        // <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public NumberSequenceController() : this(new NumberSequenceRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public NumberSequenceController(IOpenAccessBaseRepository<MyERP.DataAccess.NumberSequence, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }


        // GET: NumberSequence
        public ActionResult Index()
        {
            var numberSequences = repository.GetAll(User).OrderBy(c => c.Code)
                .ToList()
                .Select(c => new NumberSequenceViewModel()
                {
                    Code = c.Code,
                    CurrentNo = c.CurrentNo,
                    EndingNo = c.EndingNo,
                    FormatNo = c.FormatNo,
                    Id = c.Id,
                    IsDefault = c.IsDefault,
                    Manual = c.Manual,
                    Name = c.Name,
                    OrganizationName = c.Organization.Name,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    StartingNo = c.StartingNo,
                    Status = (NumberSequenceStatusType)c.Status,
                });

            return View(numberSequences);
        }

        //
        //GET: /NumberSequence/Create
        public ActionResult Create()
        {
            var model = new NumberSequenceEditViewModel()
            {
                StartingNo = 1,
                EndingNo = 999999,
                FormatNo = "000000",
                CurrentNo = 1,
                Status = NumberSequenceStatusType.Active
            };
            return View(model);
        }

        //
        //POST: /NumberSequence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NumberSequenceEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                var newNumberSequence = new NumberSequence()
                {
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    Code = model.Code,
                    Name = model.Name,
                    IsDefault = false,
                    Manual = model.Manual,
                    CurrentNo = model.CurrentNo,
                    StartingNo = model.StartingNo,
                    EndingNo = model.EndingNo,
                    FormatNo = model.FormatNo,
                    NoSeqName = "",
                    Status = (byte)model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedBy = (Guid)user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedBy = (Guid)user.ProviderUserKey
                };
                try
                {
                    //newNumberSequence = this.repository.AddNew(newNumberSequence);
                    //(this.repository as NumberSequenceRepository).CreateSequenceOfNumberSequence(newNumberSequence);

                    (this.repository as NumberSequenceRepository).AddNew(newNumberSequence);
                    
                    return RedirectToAction("Index", "NumberSequence");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ExceptionError", ex.Message);
                }
            }

            return View(model);
        }

        //
        //POST: /NumberSequence/Delete
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Delete(List<String> values)
        {
            //TODO: check values has transaction => disable delete
            foreach (var value in values)
            {
                var entity = repository.GetBy(c => c.Id == new Guid(value));
                if (entity == null)
                    Json(new { Error = String.Format("NumberSequence not found : {0}", entity.Code) }); 
                try
                {
                    (this.repository as NumberSequenceRepository).Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("NumberSequence delete error : {0}", entity.Code) });
                }    
            }
            
            return Json(true);
        }

        //
        // GET: Account/Edit
        public ActionResult Edit(Guid id)
        {
            var entity = repository.GetBy(c => c.Id == id);
            var model = new NumberSequenceEditViewModel()
            {
                Code = entity.Code,
                CurrentNo = entity.CurrentNo,
                EndingNo = entity.EndingNo,
                FormatNo = entity.FormatNo,
                Id = entity.Id,
                Name = entity.Name,
                IsDefault = entity.IsDefault,
                Manual = entity.Manual,
                StartingNo = entity.StartingNo,
                Status = (NumberSequenceStatusType)entity.Status,
                Version = entity.Version
            };

            return View(model);
        }

        //
        //POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NumberSequenceEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = repository.GetBy(c => c.Id == model.Id);
                if (entity == null || entity.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Number Sequence has been changed or deleted! Please update");
                    return RedirectToAction("Index");
                }
                entity.Code = model.Code;
                entity.CurrentNo = model.CurrentNo; //TODO : set database sequence value too
                entity.EndingNo = model.EndingNo;
                entity.FormatNo = model.FormatNo;
                entity.IsDefault = model.IsDefault;
                entity.Manual = model.Manual;
                entity.Name = model.Name;
                entity.StartingNo = model.StartingNo;
                entity.Status = (byte) model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                entity.RecModified = DateTime.Now;
                entity.RecModifiedBy = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(entity);
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