using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum TaxAuthoritiesStatus
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Wait", Order = 1)]
        Wait = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "Active", Order = 0)]
        Active = 1
    }
}
