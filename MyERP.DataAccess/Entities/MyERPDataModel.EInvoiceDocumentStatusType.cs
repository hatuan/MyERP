﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/10/2021 7:03:41 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess.Enum
{
    public enum EInvoiceDocumentStatusType : byte
    {
        [System.ComponentModel.DataAnnotations.Display(Name = @"Draft", Order = 0)]
        Draft = 0,
        [System.ComponentModel.DataAnnotations.Display(Name = @"Released", Order = 1)]
        Released = 1,
        [System.ComponentModel.DataAnnotations.Display(Name = @"Signed", Order = 2)]
        Signed = 2
    }

}
