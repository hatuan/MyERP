﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 4/3/2019 10:01:01 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyERP.DataAccess
{

    /// <summary>
    /// There are no comments for MyERP.DataAccess.EInvFormType in the schema.
    /// </summary>
    public partial class EInvFormType    {

        public EInvFormType()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceType in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(6)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceTypeNo in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(3)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceTypeNo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TemplateCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(11)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string TemplateCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceForm in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceForm
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceSeries in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(6)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string InvoiceSeries
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FormFileName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FormFileName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FormFile in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FormFile
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FormVars in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FormVars
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Logo in the schema.
        /// </summary>
        public virtual string Logo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Watermark in the schema.
        /// </summary>
        public virtual string Watermark
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClientId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long ClientId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganizationId in the schema.
        /// </summary>
        public virtual long? OrganizationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Version in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Version
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual byte Status
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecCreatedAt in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecCreatedAt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecCreatedBy in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecCreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecModifiedAt in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime RecModifiedAt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecModifiedBy in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long RecModifiedBy
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for EInvFormReleases in the schema.
        /// </summary>
        public virtual ICollection<EInvFormRelease> EInvFormReleases
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Client in the schema.
        /// </summary>
        public virtual Client Client
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organization in the schema.
        /// </summary>
        public virtual Organization Organization
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RecCreatedByUser in the schema.
        /// </summary>
        public virtual User RecCreatedByUser
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RecModifiedByUser in the schema.
        /// </summary>
        public virtual User RecModifiedByUser
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
