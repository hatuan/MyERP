using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.Web.Helpers;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
  public class UserController : EntityBaseController<MyERP.DataAccess.User, MyERP.DataAccess.EntitiesModel>
    {
         /// <summary>
        /// Constructor used by the Controller.
        /// </summary>
        public UserController() : this (new UserRepository())
        {
            
        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public UserController(IBaseRepository<MyERP.DataAccess.User, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        //POST: /User/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(LoginViewModel model, string returnUrl)
        {
            DirectResult r = new DirectResult();

            if (ModelState.IsValid)
            {
                string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(model.Name + model.Password), model.Password);
                if (Membership.Provider.ValidateUser(model.Name, passEncrypt))
                {
                    //Delete cache key
                    var cacheKey = string.Format("UserData_{0}", model.Name);
                    HttpRuntime.Cache.Remove(cacheKey);

                    var user = (MyERPMembershipUser) Membership.GetUser(model.Name, true);
                    if (user != null && user.ClientId != null)
                    {
                        //Delete cache key
                        cacheKey = string.Format("UserData_{0}", user.ProviderUserKey);
                        HttpRuntime.Cache.Remove(cacheKey);

                        //Lay thong tin mac dinh cua user
                        var preference = new PreferenceViewModel();
                        preference.OrganizationId = user.OrganizationId ?? 0;
                        preference.Organization = user.Organization;
                        preference.CultureUI = user.CultureUiId;
                        preference.WorkingDate = DateTime.Now;
                        preference.CultureId = user.Client.CultureId;
                        Session["Preference"] = preference;
                        string[] roles = Roles.Provider.GetRolesForUser(user.UserName);

                        FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                        r.Success = true;
                        return r;

                        #region If don't use Ext.net.directRequest in handleLogin (remove return r; before)
                        var cultureUIName = preference.CultureUI;
                        var cultureName = preference.Organization.Client.CultureId;
                        // Validate culture name
                        cultureUIName = CultureHelper.GetImplementedCulture(cultureUIName); // This is safe
                        cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

                        // Modify current thread's cultures            
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureUIName);
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);

                        //var cacheKey = string.Format("UserData_{0}", user.UserName);
                        HttpRuntime.Cache.Remove(cacheKey);

                        cacheKey = string.Format("UserData_{0}", user.ProviderUserKey);
                        HttpRuntime.Cache.Remove(cacheKey);

                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(user.UserName), roles);
                        var organizationRepository = new OrganizationRepository();
                        var organizations = organizationRepository.GetAll(principal)
                            .Select(c => new Ext.Net.ListItem(c.Desctiption, c.Id)).ToList();

                        preference.RootOrganization = organizationRepository.GetRootOrganization(principal);
                        preference.Organizations = organizations;

                        var cultureUIs = new List<Ext.Net.ListItem>()
                        {
                            new Ext.Net.ListItem() { Value = "vi-VN", Text = "VietNam"},
                            new Ext.Net.ListItem() { Value = "en-US", Text = "English"},
                        };
                        preference.CultureUIs = cultureUIs;

                        return new Ext.Net.MVC.PartialViewResult { ViewName = "_Preference", Model = preference };
                        #endregion
                    }
                    
                    if (user != null && user.ClientId == null)
                    {
                        r.ErrorMessage = "User don't have available Client - Press create new Client";
                        r.Success = false;
                        return r;
                    }
                }
                else
                {
                    r.ErrorMessage = "Invalid username or password.";
                    r.Success = false;
                    return r;
                }
            }
            r.Success = false;
            r.ErrorMessage = "Invalid username or password.";
            return r;
        }

        //
        // GET: /User/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /User/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status;
                string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(model.Name + model.Password), model.Password);
                MembershipUser user = Membership.CreateUser(model.Name, passEncrypt, model.Email, model.PasswordQuestion,
                    model.PasswordAnswer, true, out status);

                if (status == MembershipCreateStatus.Success)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if(status == MembershipCreateStatus.DuplicateEmail)
                        ModelState.AddModelError("Email", "Duplicate Email");
                    else if(status == MembershipCreateStatus.DuplicateUserName)
                        ModelState.AddModelError("Name", "Duplicate User Name");
                    else
                        ModelState.AddModelError("", "Register User Error");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /User/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        //
        // GET: /User/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            
            return View();
        }

        //
        // POST: /User/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    string oldPassword = Cryptography.Encrypt(Cryptography.GetHashKey(User.Identity.Name + model.OldPassword), model.OldPassword);
                    var user = (MyERPMembershipUser) Membership.Provider.GetUser(User.Identity.Name, true);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "User not found");
                    }
                    else if (!Membership.Provider.ValidateUser(User.Identity.Name, oldPassword))
                    {
                        ModelState.AddModelError("OldPassword", "OldPassword is not correctly");
                    }
                    else
                    {
                        string newPassword = Cryptography.Encrypt(Cryptography.GetHashKey(User.Identity.Name + model.NewPassword), model.NewPassword);

                        bool result = Membership.Provider.ChangePassword(User.Identity.Name, oldPassword, newPassword);

                        if (result)
                        {
                            return RedirectToAction("Manage", new {Message = ManageMessageId.ChangePasswordSuccess});
                        }
                        else
                        {
                            ModelState.AddModelError("", "Change Password had error");
                        }
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    var user = (MyERPMembershipUser)Membership.Provider.GetUser(User.Identity.Name, true);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "User not found");
                    }
                    else
                    {
                        string oldPassword = user.GetPassword();
                        
                        string newPassword = Cryptography.Encrypt(Cryptography.GetHashKey(User.Identity.Name + model.NewPassword), model.NewPassword);
                        bool result = Membership.Provider.ChangePassword(User.Identity.Name, oldPassword, newPassword);

                        if (result)
                        {
                            return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Change Password had error");
                        }
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        //GET: /User/Preference
        public ActionResult Preference(string returnUrl = "~/")
        {
            ViewBag.ReturnUrl = returnUrl;

            var preference = new PreferenceViewModel();
            preference.WorkingDate = DateTime.Now;

            var organizationRepository = new OrganizationRepository();
            var organizations = (from org in organizationRepository.Get()
                                select new Ext.Net.ListItem
                                    {
                                        Text = org.Desctiption,
                                        Value = org.Id + ""
                                    }
                                ).ToList();
            var user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);

            var defaultOrganizationId = user.OrganizationId ?? 0;
            var defaultCultureUI = user.CultureUiId;
            var defaultCultureId = user.Client.CultureId;

            if (Session["Preference"] != null)
            {
                preference.OrganizationId = ((PreferenceViewModel) Session["Preference"]).OrganizationId;
                preference.CultureUI = ((PreferenceViewModel) Session["Preference"]).CultureUI;
                preference.CultureId = ((PreferenceViewModel) Session["Preference"]).CultureId;
                preference.WorkingDate = ((PreferenceViewModel) Session["Preference"]).WorkingDate;
            }
            else
            {
                preference.OrganizationId = defaultOrganizationId;
                preference.CultureUI = defaultCultureUI;
                preference.CultureId = defaultCultureId;
            }

            preference.Organizations = organizations;

            var cultureUIs = new List<Ext.Net.ListItem>()
            {
                new Ext.Net.ListItem() { Value = "vi-VN", Text = "VietNam"},
                new Ext.Net.ListItem() { Value = "en-US", Text = "English"},
            };

            preference.CultureUIs = cultureUIs;

            return new Ext.Net.MVC.PartialViewResult { ViewName = "_Preference", Model = preference };
        }

        //
        //POST: /User/Preference
        [HttpPost]
        public ActionResult Preference([Bind(Exclude = "Organization,RootOrganization,Organizations,CultureUIs")] PreferenceViewModel model, string returnUrl = "~/")
        {
            DirectResult r = new DirectResult();
            if (ModelState.IsValid)
            {
                model.Organization = (new OrganizationRepository()).Get(c => c.Id == model.OrganizationId).Single();
                model.RootOrganization = (new OrganizationRepository()).GetRootOrganization(User);

                Session["Preference"] = model;

                var userRepository = new UserRepository();
                if (userRepository.UpdateDefaultOrganization(User.Identity.Name, model.OrganizationId))
                {
                    if (returnUrl.Trim().ToLower() == "~/")
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToLocal(returnUrl);
                }
                r.ErrorMessage = "Set default Organization of User failed ";
            }

            r.Success = false;
            return r;
        }

        private bool HasPassword()
        {
            var user = (MyERPMembershipUser) Membership.GetUser(User.Identity.Name, true);
            
            if (user != null)
            {
                return user.GetPassword() != null;
            }
            return false;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

      public ActionResult CreateCompany()
      {
          throw new NotImplementedException();
      }
    }
}