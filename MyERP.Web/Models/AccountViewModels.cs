﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyERP.DataAccess;

namespace MyERP.Web.Models
{
    public class AccountViewModels
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid OrganizationId { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public String OrganizationCode { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        
        public Guid CurrencyId { get; set; }

        [Display(Name="Currency")]
        public String Currency { get; set; }

        public Guid ParentAccountId { get; set; }

        [Display(Name = "Parent Account")]
        public String ParentAccount { get; set; }

        [Display(Name="Level")]
        public Byte Level { get; set; }

        [Display(Name = "Detail")]
        public Boolean Detail { get; set; }

        [Display(Name = "AR/AP Account")]
        public Boolean ArAp { get; set; }

        [Required]
        public Int64 Version { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Byte Status { get; set; }

        [Required]
        [Display(Name="Created By")]
        public String RecCreateBy { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTime RecCreated { get; set; }

        [Required]
        [Display(Name = "Modified By")]
        public String RecModifiedBy { get; set; }

        [Required]
        [Display(Name = "Modified")]
        public DateTime RecModified { get; set; }
    }
}