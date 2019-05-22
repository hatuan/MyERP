using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;

namespace MyERP.Web.Models
{
    
    public class ClientEditViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        public long CurrencyLcyId { get; set; }

        [Required]
        [Display(Name = "Currency LCY")]
        public String CurrencyLCYCode { get; set; }

        [Required]
        [Display(Name = "Culture")]
        public String CultureId { get; set; }

        [Required]
        [Display(Name = "Amount Decimal Places")]
        public Int16 AmountDecimalPlaces { get; set; }

        [Required]
        [Display(Name = "Amount Rounding Precision")]
        public Decimal AmountRoundingPrecision { get; set; }

        [Required]
        [Display(Name = "Unit-Amount Decimal Places")]
        public Int16 UnitAmountDecimalPlaces { get; set; }

        [Required]
        [Display(Name = "Unit-Amount Rounding Precision")]
        public Int16 UnitAmountRoundingPrecision { get; set; }

        [Display(Name = "TaxCode")]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String TaxCode { get; set; }

        [Display(Name = "Adress")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Adress { get; set; }

        [Display(Name = "Address Transition")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String AddressTransition { get; set; }

        [Display(Name = "Telephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Telephone { get; set; }

        [Display(Name = "Email")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Display(Name = "Website")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Url(ErrorMessage = "Please enter a valid url")] // add nuget DataAnnotationsExtensions to get more options
        public String Website { get; set; }

        [Display(Name = "Representative Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String RepresentativeName { get; set; }

        [Display(Name = "Representative Position")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String RepresentativePosition { get; set; }

        [Display(Name = "Contact Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ContactName { get; set; }

        [Display(Name = "Mobilephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Mobilephone { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [Display(Name = "Actived")]
        public Boolean IsActived { get; set; }

        public Int64 Version { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "TaxCode")]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String TaxCode { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Address { get; set; }

        [Display(Name = "Address Transition")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String AddressTransition { get; set; }

        [Display(Name = "Telephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Telephone { get; set; }

        [Display(Name = "Email")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Display(Name = "Website")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Url(ErrorMessage = "Please enter a valid url")] // add nuget DataAnnotationsExtensions to get more options
        public String Website { get; set; }

        [Display(Name = "Representative Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String RepresentativeName { get; set; }

        [Display(Name = "Representative Position")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String RepresentativePosition { get; set; }

        [Display(Name = "Contact Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ContactName { get; set; }

        [Display(Name = "Mobilephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Mobilephone { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The confirm must be checked.")]
        public Boolean Confirm { get; set; }

        [Required]
        [Display(Name = "Captcha is fail")]
        public string Captcha { get; set; }
    }

    /// <summary>
    /// Use in WebAPI register new Client 
    /// </summary>
    public class RegisterDTO
    {
        [Required]
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "TaxCode")]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String TaxCode { get; set; }

        [Required]
        [Display(Name = "Adress")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "Address Transition")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String AddressTransition { get; set; }

        [Required]
        [Display(Name = "Telephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Telephone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Display(Name = "Website")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Url(ErrorMessage = "Please enter a valid url")] // add nuget DataAnnotationsExtensions to get more options
        public String Website { get; set; }

        [Required]
        [Display(Name = "Representative Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String RepresentativeName { get; set; }

        [Required]
        [Display(Name = "Representative Position")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String RepresentativePosition { get; set; }

        [Required]
        [Display(Name = "Contact Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String ContactName { get; set; }

        [Required]
        [Display(Name = "Mobilephone")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Mobilephone { get; set; }
    }

    public class RegisterResultDTO
    {
        public Boolean Succcess { get; set; }

        public String Error { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }
    }
}