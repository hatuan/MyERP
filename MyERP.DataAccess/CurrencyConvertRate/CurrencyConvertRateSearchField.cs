using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public enum CurrencyConvertRateSearchField : byte
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Organization Code")]
        CurrencyOrganizationCode = 1 << 0,
        [Display(Name = "Currency Code")]
        CurrencyCode = 1 << 1,
        [Display(Name = "Currency Relation Code")]
        CurrencyRelationCode = 1 << 2,
        [Display(Name = "Valid From")]
        ValidFrom = 1 << 3,
    }
}
