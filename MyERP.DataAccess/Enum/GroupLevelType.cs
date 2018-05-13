using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum GroupLevelType
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "First", Order = 1)]
        First = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Second", Order = 2)]
        Second = 2,
        [System.ComponentModel.DataAnnotations.Display(Name = "Third", Order = 3)]
        Third = 3,
    }
}
