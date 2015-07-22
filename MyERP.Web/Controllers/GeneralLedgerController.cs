using System;
using System.Collections.Generic;
using System.Data;
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
    public class GeneralLedgerController : OpenAccessBaseController<MyERP.DataAccess.GeneralJournalDocument, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public GeneralLedgerController()
            : this(new GeneralJournalDocumentRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public GeneralLedgerController(IOpenAccessBaseRepository<MyERP.DataAccess.GeneralJournalDocument, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        //
        //GET: 
        public ActionResult Index(string currentFilter, string searchString, int? page, Guid? currentItemId)
        {

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var glDocuments = repository.GetAll(User)
                .Where(searchString ?? "1=1")
                .OrderBy(c => c.DocumentNo)
                .ToList()
                .Select(c => new GeneralJournalDocumentViewModels()
                {
                    DocumentNo = c.DocumentNo,
                    DocumentCreated = c.DocumentCreated,
                    DocumentPosted = c.DocumentPosted,
                    NumberSequenceId = c.NumberSequenceId,
                    NumberSequenceCode = c.NumberSequence.Code,
                    CurrencyId = c.CurrencyId ?? Guid.Empty,
                    CurrencyCode = c.CurrencyId == null ? "" : c.Currency.Code,
                    ExchangeRateAmount = c.ExchangeRateAmount,
                    RelationalExchRateAmount = c.RelationalExchRateAmount,
                    TotalCreditAmount = c.TotalCreditAmount,
                    TotalCreditAmountLcy = c.TotalCreditAmountLcy,
                    TotalDebitAmount = c.TotalDebitAmount,
                    TotalDebitAmountLcy = c.TotalDebitAmountLcy,
                    TransactionType = c.TransactionType,
                    Id = c.Id,
                    OrganizationName = c.Organization.Name,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    Status = (GeneralJournalDocumentStatusType) c.Status,
                    Version = c.Version
                });

            int pageNumber = (page ?? 1);

            if (currentItemId != null)
            {
                var currentItem = glDocuments.Select((item, index) => new { item, index })
                    .FirstOrDefault(x => x.item.Id.Equals(currentItemId));

                if (currentItem != null)
                    pageNumber = (currentItem.index / MyERP.Common.Define.PAGESIZE) + 1;
            }

            return View(glDocuments.ToPagedList(pageNumber, MyERP.Common.Define.PAGESIZE));
        }

        //
        //GET: /Create
        public ActionResult Create(string currentFilter)
        {
            var generalJournalSetupRepo = new GeneralJournalSetupRepository();
            var preference = Session["Preference"] as PreferenceViewModel;
            var generalJournalSetup = generalJournalSetupRepo.GetAll().FirstOrDefault(c => c.Id == preference.Organization.Id) ??
                                      generalJournalSetupRepo.GetAll().FirstOrDefault(c => c.Id == preference.RootOrganization.Id);

            if (generalJournalSetup == null)
            {
                TempData["GeneralJournalSetupNotFound"] = "General Journal Setup Not Found";
                return RedirectToAction("Index");
            }
            var model = new GeneralJournalDocumentCreateViewModel()
            {
                Id = Guid.NewGuid(),
                NumberSequenceId = generalJournalSetup.GeneralJournalNumberSequence.Id,
                NumberSequenceCode = generalJournalSetup.GeneralJournalNumberSequence.Code,
                CurrencyId = generalJournalSetup.LocalCurrency.Id,
                CurrencyCode = generalJournalSetup.LocalCurrency.Code,
                DocumentCreated = DateTime.Now,
                Status = GeneralJournalDocumentStatusType.Draft
            };

            ViewBag.CurrentFilter = currentFilter;

            return PartialView("_Create", model);
        }

        //
        //POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeneralJournalDocumentEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser) Membership.GetUser(User.Identity.Name, true);
                
                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                GeneralJournalDocument newItem = new GeneralJournalDocument()
                {
                    Id = model.Id,
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    CurrencyId = model.CurrencyId,
                    Status = (byte) model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedBy = (Guid) user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedBy = (Guid)user.ProviderUserKey
                };
                try
                {
                    this.repository.AddNew(newItem);

                    return RedirectToAction("Index", routeValues: new { currentFilter, currentItemId = newItem.Id });
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
                    Json(new { Error = String.Format("General Journal Document not found : {0}", entity.DocumentNo) });
                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("General Journal Document delete error : {0}", entity.DocumentNo) });
                }
            }

            return Json(true);
        }


        //
        // GET: /Edit
        public ActionResult Edit(Guid id, string currentFilter)
        {
            ViewBag.CurrentFilter = currentFilter;

            var account = repository.GetBy(c => c.Id == id);
            var model = new GeneralJournalDocumentEditViewModel()
                {

                    CurrencyId = account.CurrencyId ?? Guid.Empty,
                    CurrencyCode = account.CurrencyId == null ? "" : account.Currency.Code,
                    Id = account.Id,
                    Status = (GeneralJournalDocumentStatusType)account.Status,
                    Version = account.Version
                };

            return View(model);
        }

        //
        //POST: /Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GeneralJournalDocumentEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                var updateEntity = repository.GetBy(c => c.Id == model.Id);
                if (updateEntity == null || updateEntity.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "General Journal Document has been changed or deleted! Please update");
                    return RedirectToAction("Index");
                }
                updateEntity.CurrencyId = model.CurrencyId;
                updateEntity.Status = (byte) model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                updateEntity.RecModified = DateTime.Now;
                updateEntity.RecModifiedBy = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(updateEntity);
                    return RedirectToAction("Index", routeValues: new { currentFilter, currentItemId = updateEntity.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Id", ex.Message);
                }
                
            }

            return View(model);
        }

        //
        //GET: /Search
        public ActionResult Search()
        {
            var model = new SearchViewModel();
            model.Searches.Add(new MyERP.Search.SearchFieldInfo() { AccountSearchField = AccountSearchField.None, SearchFieldValue = "" });
            return View(model);
        }

        //
        //POST: /Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                String search = null;
                foreach (var searchField in model.Searches)
                {
                    if (searchField.AccountSearchField != AccountSearchField.None &&
                        !String.IsNullOrEmpty(searchField.SearchFieldValue))
                    {
                        Scanner scanner = new Scanner();
                        Parser parser = new Parser(scanner);
                        String searchFieldValue = null;
                        ParseTree tree = null;

                        switch (searchField.AccountSearchField)
                        {
                            case AccountSearchField.AccountCode:
                                searchFieldValue = String.Format("Code={0}", searchField.SearchFieldValue);
                                tree = parser.Parse(searchFieldValue);
                                if (tree.Errors.Count <= 0)
                                {
                                    if( String.IsNullOrEmpty(search))
                                        search = tree.Eval(null).ToString().Replace("#<#", "\"").Replace("#>#", "\"");
                                    else
                                        search += " AND " + tree.Eval(null).ToString().Replace("#<#", "\"").Replace("#>#", "\"");
                                }
                                else
                                {
                                    ModelState.AddModelError(String.Format("Searches[{0}].SearchFieldValue", model.Searches.IndexOf(searchField)), "Error on conditions of search");
                                    return View(model);
                                }

                                break;
                            case AccountSearchField.AccountName:
                                break;
                            case AccountSearchField.AccountCurrencyCode:
                                searchFieldValue = String.Format("Currency.Code={0}", searchField.SearchFieldValue);
                                tree = parser.Parse(searchFieldValue);
                                if (tree.Errors.Count <= 0)
                                {
                                    if( String.IsNullOrEmpty(search))
                                        search = "(Currency != null AND (" + tree.Eval(null).ToString().Replace("#<#", "\"").Replace("#>#", "\"") + "))";
                                    else
                                        search += " AND " + "(Currency != null AND (" + tree.Eval(null).ToString().Replace("#<#", "\"").Replace("#>#", "\"") + "))";
                                }
                                else
                                {
                                    ModelState.AddModelError(String.Format("Searches[{0}].SearchFieldValue", model.Searches.IndexOf(searchField)), "Error on conditions of search");
                                    return View(model);
                                }


                                break;
                            case AccountSearchField.AccountOrganizationCode:
                                searchFieldValue = String.Format("Organization.Code={0}", searchField.SearchFieldValue);
                                tree = parser.Parse(searchFieldValue);
                                if (tree.Errors.Count <= 0)
                                {
                                    if( String.IsNullOrEmpty(search))
                                        search = "(Organization != null AND (" + tree.Eval(null).ToString().Replace("#<#", "\"").Replace("#>#", "\"") + "))";
                                    else
                                        search += " AND " + "(Organization != null AND (" + tree.Eval(null).ToString().Replace("#<#", "\"").Replace("#>#", "\"") + "))";
                                }
                                else
                                {
                                    ModelState.AddModelError(String.Format("Searches[{0}].SearchFieldValue", model.Searches.IndexOf(searchField)), "Error on conditions of search");
                                    return View(model);
                                }
                                break;
                        }
                    }
                }
                if( String.IsNullOrEmpty(search))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index", routeValues: new { searchString = search });
            }

            return View(model);
        }
    }
}