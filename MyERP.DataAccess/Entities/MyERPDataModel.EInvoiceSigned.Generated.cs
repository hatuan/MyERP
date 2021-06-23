﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/21/2021 10:23:21 PM
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
    public partial class EInvoiceSigned
    {

        public EInvoiceSigned()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [Required()]
        public virtual long EInvoiceHeaderId { get; set; }

        [Required()]
        public virtual long FormTypeId { get; set; }

        public virtual long? OriginalEInvoiceId { get; set; }

        [StringLength(32)]
        public virtual string OriginalInvoiceId { get; set; }

        public virtual global::System.DateTime? OriginalInvoiceIssueDate { get; set; }

        [StringLength(6)]
        [Required()]
        public virtual string InvoiceType { get; set; }

        [StringLength(11)]
        [Required()]
        public virtual string TemplateCode { get; set; }

        [StringLength(6)]
        [Required()]
        public virtual string InvoiceSeries { get; set; }

        [StringLength(7)]
        [Required()]
        public virtual string InvoiceNumber { get; set; }

        [StringLength(100)]
        [Required()]
        public virtual string InvoiceName { get; set; }

        [Required()]
        public virtual global::System.DateTime InvoiceIssuedDate { get; set; }

        public virtual global::System.DateTime? SignedDate { get; set; }

        public virtual global::System.DateTime? SubmittedDate { get; set; }

        [StringLength(50)]
        public virtual string ContractNumber { get; set; }

        public virtual global::System.DateTime? ContractDate { get; set; }

        [StringLength(256)]
        public virtual string Description { get; set; }

        [StringLength(3)]
        [Required()]
        public virtual string CurrencyCode { get; set; }

        [Required()]
        public virtual decimal ExchangeRate { get; set; }

        [StringLength(400)]
        public virtual string InvoiceNote { get; set; }

        [Required()]
        public virtual byte AdjustmentType { get; set; }

        [StringLength(255)]
        public virtual string AdditionalReferenceDesc { get; set; }

        public virtual global::System.DateTime? AdditionalReferenceDate { get; set; }

        [StringLength(255)]
        [Required()]
        public virtual string BuyerDisplayName { get; set; }

        [StringLength(255)]
        [Required()]
        public virtual string BuyerLegalName { get; set; }

        [StringLength(14)]
        [Required()]
        public virtual string BuyerTaxCode { get; set; }

        [StringLength(255)]
        [Required()]
        public virtual string BuyerAddressLine { get; set; }

        [StringLength(10)]
        public virtual string BuyerPostalCode { get; set; }

        [StringLength(50)]
        public virtual string BuyerDistrictName { get; set; }

        [StringLength(50)]
        public virtual string BuyerCityName { get; set; }

        [StringLength(2)]
        public virtual string BuyerCountryCode { get; set; }

        [StringLength(20)]
        public virtual string BuyerPhoneNumber { get; set; }

        [StringLength(20)]
        public virtual string BuyerFaxNumber { get; set; }

        [StringLength(50)]
        public virtual string BuyerEmail { get; set; }

        [StringLength(100)]
        public virtual string BuyerBankName { get; set; }

        [StringLength(20)]
        public virtual string BuyerBankAccount { get; set; }

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

        [StringLength(50)]
        [Required()]
        public virtual string PaymentMethodName { get; set; }

        [Required()]
        public virtual decimal SumOfTotalLineAmountWithoutVAT { get; set; }

        [Required()]
        public virtual decimal TotalAmountWithoutVAT { get; set; }

        public virtual bool? IsTotalAmountWithoutVATPos { get; set; }

        [Required()]
        public virtual decimal TotalVATAmount { get; set; }

        public virtual bool? IsTotalVATAmountPos { get; set; }

        [Required()]
        public virtual decimal TotalAmountWithVAT { get; set; }

        [Required()]
        public virtual decimal TotalAmountWithVATFrn { get; set; }

        [StringLength(255)]
        [Required()]
        public virtual string TotalAmountWithVATInWords { get; set; }

        public virtual bool? IsTotalAmountPos { get; set; }

        [Required()]
        public virtual decimal DiscountAmount { get; set; }

        public virtual bool? IsDiscountAmtPos { get; set; }

        [StringLength(36)]
        [Required()]
        public virtual string ReservationCode { get; set; }

        public virtual string Logo { get; set; }

        public virtual string Watermark { get; set; }

        [Required()]
        public virtual string SignedXML { get; set; }

        [Required()]
        public virtual string SignedXSL { get; set; }

        [StringLength(100)]
        [Required()]
        public virtual string SignedFileName { get; set; }

        [Required()]
        public virtual long ClientId { get; set; }

        [Required()]
        public virtual long OrganizationId { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        [Required()]
        public virtual MyERP.DataAccess.Enum.EInvoiceDocumentStatusType Status { get; set; }

        [Required()]
        public virtual long RecCreatedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecCreatedAt { get; set; }

        [Required()]
        public virtual long RecModifiedBy { get; set; }

        [Required()]
        public virtual global::System.DateTime RecModifiedAt { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
