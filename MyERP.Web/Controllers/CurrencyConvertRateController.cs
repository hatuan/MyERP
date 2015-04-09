using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyERP.DataAccess;
using MyERP.Parse;
using MyERP.Web.Models;
using PagedList;

namespace MyERP.Web.Controllers
{
    public class CurrencyConvertRateController : OpenAccessBaseController<MyERP.DataAccess.CurrencyConvertRate, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public CurrencyConvertRateController() : this(new CurrencyConvertRateRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CurrencyConvertRateController(IOpenAccessBaseRepository<MyERP.DataAccess.CurrencyConvertRate, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: CurrencyConvertRate
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

            var _models = repository.GetAll(User)
                .Where(searchString ?? "1=1")
                .OrderBy(c => c.ValidFrom)
                .ThenBy(c => c.Currency.Code)
                .ToList()
                .Select(c => new CurrencyConvertRateViewModel()
                {
                    CurrencyCode = c.Currency.Code,
                    Id = c.Id,
                    CurrencyRelationalCode = c.CurrencyRelational.Code,
                    ValidFrom = c.ValidFrom,
                    ExchangeRateAmount = c.ExchangeRateAmount,
                    RelationalExchRateAmount = c.RelationalExchRateAmount,
                    OrganizationName = c.Organization.Name,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    Status = (CurrencyConvertRateStatusType)c.Status,
                    Version = c.Version
                });

            int pageNumber = (page ?? 1);

            if (currentItemId != null)
            {
                var currentItem = _models.Select((account, index) => new { account, index })
                    .FirstOrDefault(x => x.account.Id.Equals(currentItemId));

                if (currentItem != null)
                    pageNumber = (currentItem.index / MyERP.Common.Define.PAGESIZE) + 1;
            }

            return View(_models.ToPagedList(pageNumber, MyERP.Common.Define.PAGESIZE));
        }

        //
        //GET: /XXX/Create
        public ActionResult Create(string currentFilter)
        {
            var model = new CurrencyConvertRateEditViewModel()
            {
                Id = Guid.NewGuid(),
                ValidFrom = DateTime.Today,
                Status = CurrencyConvertRateStatusType.Active
            };

            ViewBag.CurrentFilter = currentFilter;

            return View(model);
        }

        //
        //POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CurrencyConvertRateEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                var _newModel = new CurrencyConvertRate()
                {
                    Id = model.Id,
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    CurrencyId = model.CurrencyId,
                    CurrencyRelationalId = model.CurrencyRelationId,
                    ValidFrom = model.ValidFrom,
                    ExchangeRateAmount = model.ExchangeRateAmount,
                    RelationalExchRateAmount = model.RelationalExchRateAmount,
                    Status = (byte)model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedBy = (Guid)user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedBy = (Guid)user.ProviderUserKey
                };
                try
                {
                    this.repository.AddNew(_newModel);

                    return RedirectToAction("Index", routeValues: new { currentFilter, currentItemId = _newModel.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ExceptionError", ex.Message);
                }
            }

            return View(model);
        }

        //
        //POST: /XXX/Delete
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Delete(List<String> values)
        {
            //TODO: check values has transaction => disable delete
            foreach (var value in values)
            {
                var entity = repository.GetBy(c => c.Id == new Guid(value));
                if (entity == null)
                    Json(new { Error = String.Format("Currency Convert Rate not found : {0}-{1} Date {2}", new object[] {entity.Currency.Code, entity.CurrencyRelational.Code, entity.ValidFrom}) });
                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("Currency delete error : {0}-{1} Date {2}", new object[] { entity.Currency.Code, entity.CurrencyRelational.Code, entity.ValidFrom }) });
                }
            }

            return Json(true);
        }

        //
        // GET: XXX/Edit
        public ActionResult Edit(Guid id, string currentFilter)
        {
            ViewBag.CurrentFilter = currentFilter;

            var _model = repository.GetBy(c => c.Id == id);
            var model = new CurrencyConvertRateEditViewModel()
            {
                Id = _model.Id,
                CurrencyId = _model.CurrencyId,
                CurrencyCode = _model.Currency.Code,
                CurrencyRelationId = _model.CurrencyId,
                CurrencyRelationCode =  _model.CurrencyRelational.Code,
                ValidFrom = _model.ValidFrom,
                ExchangeRateAmount = _model.ExchangeRateAmount,
                RelationalExchRateAmount = _model.RelationalExchRateAmount,
                Status = (CurrencyConvertRateStatusType)_model.Status,
                Version = _model.Version
            };

            return View(model);
        }

        //
        //POST: XXX/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CurrencyConvertRateEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                var _update = repository.GetBy(c => c.Id == model.Id);
                if (_update == null || _update.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Currency Convert Rate has been changed or deleted! Please update");
                    return RedirectToAction("Index");
                }
                _update.CurrencyId = model.CurrencyId;
                _update.CurrencyRelationalId = model.CurrencyRelationId;
                _update.ValidFrom = model.ValidFrom;
                _update.ExchangeRateAmount = model.ExchangeRateAmount;
                _update.RelationalExchRateAmount = model.RelationalExchRateAmount;
                _update.Status = (byte)model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                _update.RecModified = DateTime.Now;
                _update.RecModifiedBy = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(_update);
                    return RedirectToAction("Index", routeValues: new { currentFilter, currentItemId = _update.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Id", ex.Message);
                }

            }

            return View(model);
        }

        //
        //GET: /XXX/Search
        public ActionResult Search()
        {
            var model = new SearchViewModel();
            model.Searches.Add(new MyERP.Search.SearchFieldInfo() { CurrencyConvertRateSearchField = CurrencyConvertRateSearchField.None, SearchFieldValue = "" });
            return View(model);
        }

        //
        //POST: Account/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                String search = null;
                foreach (var searchField in model.Searches)
                {
                    if (searchField.CurrencyConvertRateSearchField != CurrencyConvertRateSearchField.None &&
                        !String.IsNullOrEmpty(searchField.SearchFieldValue))
                    {
                        Scanner scanner = new Scanner();
                        Parser parser = new Parser(scanner);
                        String searchFieldValue = null;
                        ParseTree tree = null;

                        switch (searchField.CurrencyConvertRateSearchField)
                        {
                            case CurrencyConvertRateSearchField.CurrencyCode:
                                searchFieldValue = String.Format("Currency.Code={0}", searchField.SearchFieldValue);
                                tree = parser.Parse(searchFieldValue);
                                if (tree.Errors.Count <= 0)
                                {
                                    if (String.IsNullOrEmpty(search))
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

                            case CurrencyConvertRateSearchField.CurrencyRelationCode:
                                searchFieldValue = String.Format("CurrencyRelational.Code={0}", searchField.SearchFieldValue);
                                tree = parser.Parse(searchFieldValue);
                                if (tree.Errors.Count <= 0)
                                {
                                    if (String.IsNullOrEmpty(search))
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

                            case CurrencyConvertRateSearchField.CurrencyOrganizationCode:
                                searchFieldValue = String.Format("Organization.Code={0}", searchField.SearchFieldValue);
                                tree = parser.Parse(searchFieldValue);
                                if (tree.Errors.Count <= 0)
                                {
                                    if (String.IsNullOrEmpty(search))
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

                            case CurrencyConvertRateSearchField.ValidFrom:
                                
                                break;
                        }
                    }
                }
                if (String.IsNullOrEmpty(search))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index", routeValues: new { searchString = search });
            }

            return View(model);
        }

    }
}