using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess.Enum
{
    public enum  SalesPriceSalesType : short
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Customer", Order = 0)]
        Customer = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = "Customer Price Group", Order = 1)]
        CustomerPriceGroup = 2,
        [System.ComponentModel.DataAnnotations.Display(Name = "All Customers", Order = 2)]
        AllCustomers = 3,
        //[System.ComponentModel.DataAnnotations.Display(Name = "Campain", Order = 3)]
        //Campaign = 4
    }
}
