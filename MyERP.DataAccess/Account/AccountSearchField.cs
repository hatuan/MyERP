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
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Organization Code")]
        AccountOrganizationCode = 1 << 0,
        [Display(Name = "Account Code")]
        AccountCode = 1 << 1,
        [Display(Name = "Account Name")]
        AccountName = 1 << 2,
        [Display(Name = "Account Currency")]
        AccountCurrencyCode = 1 << 3
    }
}
