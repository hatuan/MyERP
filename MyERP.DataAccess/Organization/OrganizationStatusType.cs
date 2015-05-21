using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public enum OrganizationStatusType
    {
        [Display(Name = "Inactive")]
        Inactive = 0,
        [Display(Name = "Active")]
        Active = 1
    }
}
