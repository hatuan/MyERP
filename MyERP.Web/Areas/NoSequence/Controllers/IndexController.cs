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
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace MyERP.Web.Areas.NoSequence.Controllers
{
    public class IndexController : EntityBaseController<MyERP.DataAccess.NoSequence, MyERP.DataAccess.EntitiesModel>
    {
        public IndexController() : this(new NoSequenceRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public IndexController(IBaseRepository<MyERP.DataAccess.NoSequence, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: NoSequence/Index
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
            var paging = ((NoSequenceRepository)repository).Paging(parameters);

            var noSequenceLineRepository = new NoSequenceLineRepository();
            var noSequenceLines =
                from noSequenceLine in noSequenceLineRepository.Get(c => paging.Data.Any(x => x.Id == c.Id))
                orderby noSequenceLine.StartingDate
                group noSequenceLine by noSequenceLine.Id
                into g
                select new
                {
                    Id = g.Key,
                    StartingDate = g.Min(t => t.StartingDate)
                };

            var currentNoSequenceLines = (from curNoSequenceLine in noSequenceLineRepository.Get(x => noSequenceLines.Any(noSequenceLine => noSequenceLine.Id == x.Id && noSequenceLine.StartingDate == x.StartingDate))
                select curNoSequenceLine).ToList();

            var data = paging.Data.Select(c => new NoSequenceViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                Code = c.Code,
                Description = c.Description,
                StartingDate = currentNoSequenceLines.Where(currentNoSequenceLine => currentNoSequenceLine.NoSequenceId == c.Id).Select(currentNoSequenceLine => currentNoSequenceLine.StartingDate).FirstOrDefault(),
                StartingNo = currentNoSequenceLines.Where(currentNoSequenceLine => currentNoSequenceLine.NoSequenceId == c.Id).Select(currentNoSequenceLine => currentNoSequenceLine.StartingNo).FirstOrDefault(),
                EndingNo = currentNoSequenceLines.Where(currentNoSequenceLine => currentNoSequenceLine.NoSequenceId == c.Id).Select(currentNoSequenceLine => currentNoSequenceLine.EndingNo).FirstOrDefault(),
                CurrentNo = currentNoSequenceLines.Where(currentNoSequenceLine => currentNoSequenceLine.NoSequenceId == c.Id).Select(currentNoSequenceLine => currentNoSequenceLine.CurrentNo).FirstOrDefault(),
                WarningNo = currentNoSequenceLines.Where(currentNoSequenceLine => currentNoSequenceLine.NoSequenceId == c.Id).Select(currentNoSequenceLine => currentNoSequenceLine.WarningNo).FirstOrDefault(),
                FormatNo = currentNoSequenceLines.Where(currentNoSequenceLine => currentNoSequenceLine.NoSequenceId == c.Id).Select(currentNoSequenceLine => currentNoSequenceLine.FormatNo).FirstOrDefault(),
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreNoSequenceList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            var model = new NoSequenceEditViewModel()
            {
                Id = null,
                NoSequenceLines = new List<NoSequenceLineEditViewModel>(),
                Status = DefaultStatusType.Active
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id,
                    new string[]
                    {
                        "RecCreatedByUser", "RecModifiedByUser", "NoSequenceLines"
                    }).SingleOrDefault();
                List<NoSequenceLineEditViewModel> noSequenceLines = new List<NoSequenceLineEditViewModel>();
                noSequenceLines = (from noSequenceLine in entity.NoSequenceLines
                                   select new NoSequenceLineEditViewModel()
                               {
                                   Id = noSequenceLine.Id,
                                   NoSequenceId = noSequenceLine.NoSequenceId,
                                   StartingDate = noSequenceLine.StartingDate.CompareTo(new DateTime(1900, 1, 1, 0, 0, 0)) == 0 ? default(DateTime) : noSequenceLine.StartingDate,
                                   StartingNo = noSequenceLine.StartingNo,
                                   EndingNo = noSequenceLine.EndingNo,
                                   CurrentNo = noSequenceLine.CurrentNo,
                                   WarningNo = noSequenceLine.WarningNo,
                                   FormatNo = noSequenceLine.FormatNo,
                                   Status = (DefaultStatusType)noSequenceLine.Status,
                                   Version = noSequenceLine.Version
                               }).ToList();

                model = new NoSequenceEditViewModel()
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Description = entity.Description,
                    NoSequenceLines = noSequenceLines,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };
            }

            return new Ext.Net.MVC.PartialViewResult()
            {
                Model = model,
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(SalesPriceGroupEditViewModel model, string noSequenceLineJSON)
        {
            List<NoSequenceLineEditViewModel> noSequenceLineEditViewModels = JsonConvert.DeserializeObject<List<NoSequenceLineEditViewModel>>(noSequenceLineJSON, new JsonSerializerSettings
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
                    DataAccess.NoSequence newSalesPriceGroup = new DataAccess.NoSequence()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        Code = model.Code,
                        Description = model.Description,
                        Status = (byte)model.Status,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long)user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long)user.ProviderUserKey
                    };

                    List<DataAccess.NoSequenceLine> noSequenceLines = noSequenceLineEditViewModels
                        .Select(c => new DataAccess.NoSequenceLine()
                        {
                            ClientId = clientId,
                            OrganizationId = organizationId,
                            StartingDate = c.StartingDate ?? new DateTime(1900, 1, 1, 0, 0, 0),
                            StartingNo = c.StartingNo,
                            EndingNo = c.EndingNo,
                            WarningNo = c.WarningNo,
                            FormatNo = c.FormatNo,
                            Status = (byte)DefaultStatusType.Active,
                            Version = 1,
                            RecModifiedAt = DateTime.Now,
                            RecCreatedBy = (long)user.ProviderUserKey,
                            RecCreatedAt = DateTime.Now,
                            RecModifiedBy = (long)user.ProviderUserKey
                        }).ToList();
                    newSalesPriceGroup.NoSequenceLines = noSequenceLines;
                    model.Id = newSalesPriceGroup.Id;
                }
                else //edit
                {
                    DataAccess.NoSequence updateNoSequence = repository.Get(c => c.Id == model.Id, new string[] { "NoSequenceLines" }).SingleOrDefault();
                    if (updateNoSequence == null || updateNoSequence.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Sales Price Group has been changed or deleted! Please check";
                        return r;
                    }

                    updateNoSequence.Code = model.Code;
                    updateNoSequence.Description = model.Description;
                    updateNoSequence.Status = (byte)model.Status;
                    updateNoSequence.RecModifiedAt = DateTime.Now;
                    updateNoSequence.RecModifiedBy = (long)user.ProviderUserKey;
                    updateNoSequence.Version++;

                    foreach (var noSequenceLineEditViewModel in noSequenceLineEditViewModels)
                    {
                        if (noSequenceLineEditViewModel.Id == 0 || noSequenceLineEditViewModel.Id == null)
                            updateNoSequence.NoSequenceLines.Add(new DataAccess.NoSequenceLine()
                            {
                                ClientId = clientId,
                                OrganizationId = organizationId,
                                StartingDate = noSequenceLineEditViewModel.StartingDate ?? new DateTime(1900, 1, 1, 0, 0, 0),
                                StartingNo = noSequenceLineEditViewModel.StartingNo,
                                EndingNo = noSequenceLineEditViewModel.EndingNo,
                                WarningNo = noSequenceLineEditViewModel.WarningNo,
                                FormatNo = noSequenceLineEditViewModel.FormatNo,
                                Status = (byte)DefaultStatusType.Active,
                                Version = 1,
                                RecCreatedBy = (long)user.ProviderUserKey,
                                RecCreatedAt = DateTime.Now,
                                RecModifiedAt = DateTime.Now,
                                RecModifiedBy = (long)user.ProviderUserKey
                            });
                        else
                        {
                            updateNoSequence.NoSequenceLines.Where(c => c.Id == noSequenceLineEditViewModel.Id)
                                .ForEach(x =>
                                {
                                    x.StartingDate = noSequenceLineEditViewModel.StartingDate ?? new DateTime(1900, 1, 1, 0, 0, 0);
                                    x.StartingNo = noSequenceLineEditViewModel.StartingNo;
                                    x.EndingNo = noSequenceLineEditViewModel.EndingNo;
                                    x.WarningNo = noSequenceLineEditViewModel.WarningNo;
                                    x.FormatNo = noSequenceLineEditViewModel.FormatNo;
                                    x.Status = (byte)DefaultStatusType.Active;
                                    x.Version++;
                                    x.RecModifiedAt = DateTime.Now;
                                    x.RecModifiedBy = (long)user.ProviderUserKey;
                                });
                        }
                    }

                    foreach (var noSequenceLine in updateNoSequence.NoSequenceLines.Where(x => noSequenceLineEditViewModels.All(u => u.Id != x.Id && u.Id != 0 && u.Id.HasValue)).ToList())
                    {
                        updateNoSequence.NoSequenceLines.Remove(noSequenceLine);
                        this.repository.DataContext.NoSequenceLines.Remove(noSequenceLine); //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
                    }

                    try
                    {
                        this.repository.Update(updateNoSequence);
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

            return r;
        }

        public ActionResult Delete(string id = null)
        {
            DirectResult r = new DirectResult();
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "NoSequenceLines" }).SingleOrDefault();
                if (entity == null)
                {
                    r.Success = false;
                    r.ErrorMessage = "No Sequence not found! Please check";
                    return r;
                }

                foreach (var noSequenceLine in entity.NoSequenceLines.ToList())
                {
                    entity.NoSequenceLines.Remove(noSequenceLine);
                    this.repository.DataContext.NoSequenceLines.Remove(noSequenceLine);  //this.repository.DataContext.Entry(salesPriceRemove).State = EntityState.Deleted;
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
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }

        public ActionResult AddLineToNoSequenceLine()
        {
            var newItem = new NoSequenceLineEditViewModel()
            {
                Id = null,
                NoSequenceId = null,
                StartingDate = default(DateTime),
                StartingNo = 0,
                EndingNo = 0,
                CurrentNo = 0,
                WarningNo = 0,
                FormatNo = "",
                Status = DefaultStatusType.Active,
                Version = 1
            };

            Store noSequenceLineGridStore = X.GetCmp<Store>("NoSequenceLineGridStore");
            noSequenceLineGridStore.Add(newItem);

            return this.Direct();
        }
    }
}