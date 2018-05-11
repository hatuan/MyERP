using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum OrganizationStatusType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Inactive", Order = 1)]
        Inactive = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = "Active", Order = 0)]
        Active = 1
    }
}
