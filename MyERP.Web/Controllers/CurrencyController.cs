using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class CurrencyController : OpenAccessBaseController<MyERP.DataAccess.Currency, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public CurrencyController() : this(new CurrencyRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public CurrencyController(IOpenAccessBaseRepository<MyERP.DataAccess.Currency, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: Currency
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
                .OrderBy(c => c.Code)
                .ToList()
                .Select(c => new CurrencyViewModel()
                {
                    Code = c.Code,
                    Id = c.Id,
                    Name = c.Name,
                    OrganizationName = c.Organization.Name,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    Status = (CurrencyStatusType)c.Status,
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

        public ActionResult Autocomplete(string q)
        {
            var currencies = repository.GetAll(User)
                .Where(c => c.Code.StartsWith(q, StringComparison.CurrentCultureIgnoreCase) || c.Name.Contains(q))
                .OrderBy(c => c.Code)
                .Select(c => new 
                {
                    id = c.Id,
                    code = c.Code,
                    name = c.Name
                });

            return Json(currencies.ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        //GET: /XXX/Create
        public ActionResult Create(string currentFilter)
        {
            var model = new CurrencyEditViewModel()
            {
                Id = Guid.NewGuid(),
                Status = CurrencyStatusType.Active
            };

            ViewBag.CurrentFilter = currentFilter;

            return View(model);
        }

        //
        //POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CurrencyEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                var _newModel = new Currency()
                {
                    Id = model.Id,
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    Code = model.Code,
                    Name = model.Name,
                    Status = (byte)model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedById = (Guid)user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedById = (Guid)user.ProviderUserKey
                };
                try
                {
                    this.repository.AddNew(_newModel);

                    return RedirectToAction("Index", "Currency", routeValues: new { currentFilter, currentItemId = _newModel.Id });
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
                    Json(new { Error = String.Format("Currency not found : {0}", entity.Code) });
                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("Currency delete error : {0}", entity.Code) });
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
            var model = new CurrencyEditViewModel()
            {
                Code = _model.Code,
                Id = _model.Id,
                Name = _model.Name,
                Status = (CurrencyStatusType)_model.Status,
                Version = _model.Version
            };

            return View(model);
        }

        //
        //POST: XXX/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CurrencyEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                var _update = repository.GetBy(c => c.Id == model.Id);
                if (_update == null || _update.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Currency has been changed or deleted! Please update");
                    return RedirectToAction("Index", "Currency");
                }
                _update.Code = model.Code;
                _update.Name = model.Name;
                _update.Status = (byte)model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                _update.RecModified = DateTime.Now;
                _update.RecModifiedById = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(_update);
                    return RedirectToAction("Index", "Currency", routeValues: new { currentFilter, currentItemId = _update.Id });
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
            model.Searches.Add(new MyERP.Search.SearchFieldInfo() { AccountSearchField = AccountSearchField.None, SearchFieldValue = "" });
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
                    if (searchField.CurrencySearchField != CurrencySearchField.None &&
                        !String.IsNullOrEmpty(searchField.SearchFieldValue))
                    {
                        Scanner scanner = new Scanner();
                        Parser parser = new Parser(scanner);
                        String searchFieldValue = null;
                        ParseTree tree = null;

                        switch (searchField.CurrencySearchField)
                        {
                            case CurrencySearchField.CurrencyCode:
                                searchFieldValue = String.Format("Code={0}", searchField.SearchFieldValue);
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

                            case CurrencySearchField.CurrencyName:
                                break;

                            case CurrencySearchField.CurrencyOrganizationCode:
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