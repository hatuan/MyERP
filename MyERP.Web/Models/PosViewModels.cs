using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyERP.DataAccess.Enum;

namespace MyERP.Web.Models
{
    public class PosHeaderEditViewModel
    {
        public long? Id { get; set; }
        
        public string DocumentNo { get; set; }

        public string DocumentDate { get; set; }

        [Display(Name = "Customer")]
        public long? SellToCustomerId { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToCustomerName { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String SellToAddress { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "Location")]
        public long? LocationId { get; set; }

        [Display(Name = "Sales Person")]
        public long? SalesPersonId { get; set; }

        public List<PosLineEditViewModel> PosLineEditViewModels { get; set; }
    }

    public class PosLineEditViewModel
    {
        public long? Id { get; set; }

        public long LineNo { get; set; }
                                                 
        [Display(Name = "Item")]
        public long? ItemId { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Description { get; set; }

        [Display(Name = "UOM")]
        public long? UomId { get; set; }

        [Display(Name = "UOM")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String UomDescription { get; set; }

        [Display(Name = "Quantity")]
        public Decimal Quantity { get; set; }

        [Display(Name = "UnitPrice")]
        public Decimal UnitPrice { get; set; }

        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }
    }
}