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
    public class GeneralLedgerController : OpenAccessBaseController<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel>
    {
        /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public GeneralLedgerController() : this(new AccountRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public GeneralLedgerController(IOpenAccessBaseRepository<MyERP.DataAccess.Account, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        //
        //GET: Account
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

            var accounts = repository.GetAll(User)
                .Where(searchString ?? "1=1")
                .OrderBy(c => c.Code)
                .ToList()
                .Select(c => new AccountViewModels()
                {
                    ArAp = c.ArAp,
                    Code = c.Code,
                    CurrencyId = c.CurrencyId ?? Guid.Empty,
                    CurrencyCode = c.CurrencyId == null ? "" : c.Currency.Code,
                    Detail = c.Detail,
                    Id = c.Id,
                    Level = c.Level,
                    Name = c.Name,
                    OrganizationName = c.Organization.Name,
                    ParentAccountCode = c.ParentAccountId == null ? "" : c.ParentAccount.Code,
                    ParentAccountId = c.ParentAccountId ?? Guid.Empty,
                    RecCreateBy = c.RecCreatedByUser.Name,
                    RecCreated = c.RecCreated,
                    RecModifiedBy = c.RecModifiedByUser.Name,
                    RecModified = c.RecModified,
                    Status = (AccountStatusType) c.Status,
                    Version = c.Version
                });

            int pageNumber = (page ?? 1);

            if (currentItemId != null)
            {
                var currentItem = accounts.Select((account, index) => new { account, index }) 
                    .FirstOrDefault(x => x.account.Id.Equals(currentItemId));

                if (currentItem != null)
                    pageNumber = (currentItem.index / MyERP.Common.Define.PAGESIZE) + 1;
            }

            return View(accounts.ToPagedList(pageNumber, MyERP.Common.Define.PAGESIZE));
        }

        //
        //GET: /Account/Create
        public ActionResult Create(string currentFilter)
        {
            var model = new AccountEditViewModel()
            {
                Id = Guid.NewGuid(),
                Status = AccountStatusType.Active
            };

            ViewBag.CurrentFilter = currentFilter;

            return View(model);
        }

        //
        //POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser) Membership.GetUser(User.Identity.Name, true);
                
                Guid clientId = user.ClientId ?? Guid.Empty;
                Guid organizationId = user.OrganizationId ?? Guid.Empty;

                Account newAccount = new Account()
                {
                    Id = model.Id,
                    ClientId = clientId,
                    OrganizationId = organizationId,
                    Code = model.Code,
                    Name = model.Name,
                    CurrencyId = model.CurrencyId,
                    ParentAccountId = model.ParentAccountId,
                    ArAp = model.ArAp,
                    Status = (byte) model.Status,
                    RecModified = DateTime.Now,
                    RecCreatedById = (Guid) user.ProviderUserKey,
                    RecCreated = DateTime.Now,
                    RecModifiedById = (Guid)user.ProviderUserKey
                };
                try
                {
                    this.repository.AddNew(newAccount);

                    return RedirectToAction("Index", "Account", routeValues: new { currentFilter, currentItemId = newAccount.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ExceptionError", ex.Message);
                }
            }

            return View(model);
        }

        //
        //POST: /Account/Delete
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult Delete(List<String> values)
        {
            //TODO: check values has transaction => disable delete
            foreach (var value in values)
            {
                var entity = repository.GetBy(c => c.Id == new Guid(value));
                if (entity == null)
                    Json(new { Error = String.Format("Account not found : {0}", entity.Code) });
                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception ex)
                {
                    return Json(new { Error = String.Format("Account delete error : {0}", entity.Code) });
                }
            }

            return Json(true);
        }


        //
        // GET: Account/Edit
        public ActionResult Edit(Guid id, string currentFilter)
        {
            ViewBag.CurrentFilter = currentFilter;

            var account = repository.GetBy(c => c.Id == id);
            var model = new AccountEditViewModel() 
                {
                    ArAp = account.ArAp,
                    Code = account.Code,
                    CurrencyId = account.CurrencyId ?? Guid.Empty,
                    CurrencyCode = account.CurrencyId == null ? "" : account.Currency.Code,
                    Id = account.Id,
                    Name = account.Name,
                    ParentAccountCode = account.ParentAccountId == null ? "" : account.ParentAccount.Code,
                    ParentAccountId = account.ParentAccountId ?? Guid.Empty,
                    Status = (AccountStatusType)account.Status,
                    Version = account.Version
                };

            return View(model);
        }

        //
        //POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountEditViewModel model, string currentFilter)
        {
            if (ModelState.IsValid)
            {
                var updateAccount = repository.GetBy(c => c.Id == model.Id);
                if (updateAccount == null || updateAccount.Version != model.Version)
                {
                    ModelState.AddModelError("Id", "Account has been changed or deleted! Please update");
                    return RedirectToAction("Index", "Account");
                }
                updateAccount.Code = model.Code;
                updateAccount.Name = model.Name;
                updateAccount.CurrencyId = model.CurrencyId;
                updateAccount.ParentAccountId = model.ParentAccountId;
                updateAccount.ArAp = model.ArAp;
                updateAccount.Status = (byte) model.Status;

                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                updateAccount.RecModified = DateTime.Now;
                updateAccount.RecModifiedById = (Guid)user.ProviderUserKey;

                try
                {
                    this.repository.Update(updateAccount);
                    return RedirectToAction("Index", "Account", routeValues: new { currentFilter, currentItemId = updateAccount.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Id", ex.Message);
                }
                
            }

            return View(model);
        }

        //
        //GET: /Account/Search
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