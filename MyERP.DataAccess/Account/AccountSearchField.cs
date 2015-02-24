using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public enum AccountSearchField : byte
    {
        [Display(Name = "Organization Name")]
        OrganizationName = 0,
        [Display(Name = "Account Code")]
        Code = 1,
        [Display(Name = "Account Name")]
        Name = 2,
        [Display(Name = "Account Currency")]
        CurrencyCode = 3
    }
}
