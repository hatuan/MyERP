using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ext.Net;
using MyERP.DataAccess;

namespace MyERP.Web.Models
{
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current_password", ResourceType = typeof(Resources.Resources))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "The_0_must_be_at_least_2_characters_long", MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm_new_password", ResourceType = typeof(Resources.Resources))]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessageResourceName = "The_password_and_confirmation_password_do_not_match", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string ConfirmPassword { get; set; }
    }


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User_Name", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [Display(Name = "Remember_me", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User_Name", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Full_Name", ResourceType = typeof(Resources.Resources))]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "The_0_must_be_at_least_2_characters_long", MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm_password", ResourceType = typeof(Resources.Resources))]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceName = "The_password_and_confirmation_password_do_not_match", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Password_Question", ResourceType = typeof(Resources.Resources))]
        public string PasswordQuestion { get; set; }

        [Required]
        [Display(Name = "Password_Answer", ResourceType = typeof(Resources.Resources))]
        public string PasswordAnswer { get; set; }
    }

    public class PreferenceViewModel
    {
        [Required]
        [Display(Name = "Organization", ResourceType = typeof(Resources.Resources))]
        public Int64 OrganizationId
        {
            get;
            set;
        }

        public Organization Organization
        {
            get;
            set;
        }

        public Organization RootOrganization
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public String CultureUI { get; set; }

        [Required]
        [Display(Name = "Working_Date", ResourceType = typeof(Resources.Resources))]
        public DateTime WorkingDate { get; set; }

        public List<ListItem> Organizations { get; set; }
        public List<ListItem> CultureUIs { get; set; }

        [Required]
        public String CultureId { get; set; }
    }
}