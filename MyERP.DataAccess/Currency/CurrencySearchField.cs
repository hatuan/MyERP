using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public enum CurrencySearchField : byte
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Organization Code")]
        CurrencyOrganizationCode = 1 << 0,
        [Display(Name = "Currency Code")]
        CurrencyCode = 1 << 1,
        [Display(Name = "Currency Name")]
        CurrencyName = 1 << 2,
    }
}
