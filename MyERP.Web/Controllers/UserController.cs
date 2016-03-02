using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyERP.DataAccess;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
  public class UserController : OpenAccessBaseController<MyERP.DataAccess.User, MyERP.DataAccess.EntitiesModel>
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
        public UserController(IOpenAccessBaseRepository<MyERP.DataAccess.User, MyERP.DataAccess.EntitiesModel> repository)
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
            if (ModelState.IsValid)
            {
                string passEncrypt = Cryptography.Encrypt(Cryptography.GetHashKey(model.Name + model.Password), model.Password);
                if (Membership.Provider.ValidateUser(model.Name, passEncrypt))
                {
                    var user = (MyERPMembershipUser) Membership.GetUser(model.Name, true);
                    if (user != null && user.ClientId != Guid.Empty)
                    {
                        //Lay thong tin mac dinh cua user
                        var preference = new PreferenceViewModel();
                        preference.OrganizationId = user.OrganizationId == Guid.Empty ? "" : user.OrganizationId.ToString();
                        preference.Organization = user.Organization;
                        preference.CultureUI = user.CultureUIId;
                        preference.WorkingDate = DateTime.Now;
                        Session["Preference"] = preference;
                        string[] roles = Roles.Provider.GetRolesForUser(user.UserName);

                        FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                        return RedirectToAction("Preference", routeValues: new { returnUrl = returnUrl });
                        //return RedirectToLocal(returnUrl);
                    }
                    if (user != null && user.ClientId == Guid.Empty)
                    {
                        ModelState.AddModelError("Name", "User don't have available Client - Press create new Client");
                    }
                }
                else
                {
                    ModelState.AddModelError("Name", "Invalid username or password.");
                    ModelState.AddModelError("Password", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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

            var model = new PreferenceViewModel();
            model.WorkingDate = DateTime.Now;
            
            var organizationRepository = new OrganizationRepository();
            var organizations = organizationRepository.GetAll(User).ToList()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            model.RootOrganization = organizationRepository.GetRootOrganization(User);

            var defaultOrganizationId = (Membership.GetUser(User.Identity.Name, true) as MyERPMembershipUser).OrganizationId.ToString();
            var defaultCultureUI = (Membership.GetUser(User.Identity.Name, true) as MyERPMembershipUser).CultureUIId;

            if (Session["Preference"] != null)
            {
                defaultOrganizationId = (Session["Preference"] as PreferenceViewModel).OrganizationId;
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

        //
        //POST: /User/Preference
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Preference([Bind(Exclude = "Organization,RootOrganization")] PreferenceViewModel model, string returnUrl)
        {
            var organizationRepository = new OrganizationRepository();
            model.Organization = organizationRepository.GetBy(c => c.Id == new Guid(model.OrganizationId));
            model.RootOrganization = organizationRepository.GetRootOrganization(model.Organization);

            if (ModelState.IsValid)
            {
                Session["Preference"] = model;

                var userRepository = new UserRepository();
                if (!userRepository.UpdateDefaultOrganization(User.Identity.Name, Guid.Parse(model.OrganizationId)))
                {
                    ModelState.AddModelError("OrganizationId", "Set default Organization of User failed ");
                }
                else
                {
                    //if (returnUrl.Trim().ToLower() == "~/")
                        return RedirectToAction("Index", "Home");
                    //else
                    //    return RedirectToLocal(returnUrl);
                    
                }
            }

            var organizations = organizationRepository.GetAll(User).ToList()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            ViewBag.Organizations = model.OrganizationId != "" ? new SelectList(organizations, "Value", "Text", model.OrganizationId) : new SelectList(organizations, "Value", "Text");

            var cultureUIs = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "vi-VN", Text = "VietNam"},
                new SelectListItem() { Value = "en-US", Text = "English"},
            };
            ViewBag.CultureUIs = new SelectList(cultureUIs, "Value", "Text", model.CultureUI);

            return View(model);
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