//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/03/2021 3:16:01 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    public partial class EInvFormType
    {

        public EInvFormType()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [StringLength(100)]
        [Required()]
        public virtual string InvoiceName { get; set; }

        [StringLength(6)]
        [Required()]
        public virtual string InvoiceType { get; set; }

        [StringLength(3)]
        [Required()]
        public virtual string InvoiceTypeNo { get; set; }

        [StringLength(11)]
        [Required()]
        public virtual string TemplateCode { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string InvoiceForm { get; set; }

        [StringLength(6)]
        [Required()]
        public virtual string InvoiceSeries { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string FormFileName { get; set; }

        [Required()]
        public virtual string FormFile { get; set; }

        [StringLength(255)]
        [Required()]
        public virtual string SellerLegalName { get; set; }

        [StringLength(14)]
        [Required()]
        public virtual string SellerTaxCode { get; set; }

        [StringLength(255)]
        [Required()]
        public virtual string SellerAddressLine { get; set; }

        [StringLength(10)]
        public virtual string SellerPostalCode { get; set; }

        [StringLength(50)]
        public virtual string SellerDistrictName { get; set; }

        [StringLength(50)]
        public virtual string SellerCityName { get; set; }

        [StringLength(2)]
        public virtual string SellerCountryCode { get; set; }

        [StringLength(20)]
        public virtual string SellerPhoneNumber { get; set; }

        [StringLength(20)]
        public virtual string SellerFaxNumber { get; set; }

        [StringLength(50)]
        public virtual string SellerEmail { get; set; }

        [StringLength(100)]
        public virtual string SellerBankName { get; set; }

        [StringLength(20)]
        public virtual string SellerBankAccount { get; set; }

        [StringLength(100)]
        public virtual string SellerContactPersonName { get; set; }

        [StringLength(100)]
        public virtual string SellerSignedPersonName { get; set; }

        [StringLength(100)]
        public virtual string SellerSubmittedPersonName { get; set; }

        public virtual string Logo { get; set; }

        public virtual string Watermark { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        public virtual long? OrganizationId { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        [Required()]
        public virtual bool Blocked { get; set; }

        [Required()]
        public virtual global::System.DateTime RecCreatedAt { get; set; }

        [Required()]
        public virtual long RecCreatedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecModifiedAt { get; set; }

        [Required()]
        public virtual long RecModifiedBy { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<EInvFormRelease> EInvFormReleases { get; set; }
        public virtual Client Client { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual User RecCreatedByUser { get; set; }
        public virtual User RecModifiedByUser { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
