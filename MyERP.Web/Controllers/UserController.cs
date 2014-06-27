using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    [Authorize]
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
                    if (user != null)
                    {
                        string[] roles = Roles.Provider.GetRolesForUser(user.UserName);

                        FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                        return RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
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
        public ActionResult Preference()
        {
            var model = new PreferenceViewModel();
            model.WorkingDate = DateTime.Now;
            
            var organizationRepository = new OrganizationRepository();
            var organizations = organizationRepository.GetOrganizations(User).ToList()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            
            model.Organizations = new SelectList(organizations, "Value", "Text"); ;
            return View(model);
        }

        //
        //POST: /User/Preference
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Preference(PreferenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Save User Preference

                return RedirectToAction("Index", "Home");
            }

            var organizationRepository = new OrganizationRepository();
            var organizations = organizationRepository.GetOrganizations(User).ToList()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            model.Organizations = new SelectList(organizations, "Value", "Text"); ;
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
    }
}