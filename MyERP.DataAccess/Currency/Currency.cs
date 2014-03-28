using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.DataAccess
{
    public partial class Currency
    {
        public CurrencyStatusType StatusType
        {
            get { return (CurrencyStatusType)Status; }
            set
            {
                //intentionally empty
            }
        }
    }
}
