using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class LookupViewModel
    {
        [Required]
        public Int64 Id { get; set; }

        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Blocked")]
        public Boolean Blocked { get; set; }
    }
}