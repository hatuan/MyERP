﻿using System;
using Telerik.OpenAccess;

namespace MyERP.DataAccess
{
    public partial class Module
    {
        public ModuleName IdAsName
        {
            get
            {
                return (ModuleName)this.Id;
            }
        }
    }
}
