﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/12/2019 4:54:58 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.ModelConfiguration;

namespace MyERP.DataAccess.Mapping
{

    public partial class EInvoiceHeaderConfiguration : EntityTypeConfiguration<EInvoiceHeader>
    {

        public EInvoiceHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("einvoice_header", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.FormTypeId)
                    .HasColumnName(@"form_type_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.OriginalInvoiceId)
                    .HasColumnName(@"original_invoice_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.InvoiceNumber)
                    .HasColumnName(@"invoice_number")
                    .HasMaxLength(7)
                    .HasColumnType("varchar");
            this
                .Property(p => p.InvoiceName)
                    .HasColumnName(@"invoice_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceIssuedDate)
                    .HasColumnName(@"invoice_issued_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.SignedDate)
                    .HasColumnName(@"signed_date")
                    .HasColumnType("datetime2");
            this
                .Property(p => p.SubmittedDate)
                    .HasColumnName(@"submitted_date")
                    .HasColumnType("datetime2");
            this
                .Property(p => p.ContractNumber)
                    .HasColumnName(@"contract_number")
                    .HasMaxLength(50)
                    .HasColumnType("varchar");
            this
                .Property(p => p.ContractDate)
                    .HasColumnName(@"contract_date")
                    .HasColumnType("datetime2");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.CurrencyId)
                    .HasColumnName(@"currency_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.ExchangeRate)
                    .HasColumnName(@"exchange_rate")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.InvoiceNote)
                    .HasColumnName(@"invoice_note")
                    .HasMaxLength(400)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.AdjustmentType)
                    .HasColumnName(@"adjustment_type")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.AdditionalReferenceDesc)
                    .HasColumnName(@"additional_reference_desc")
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.AdditionalReferenceDate)
                    .HasColumnName(@"additional_reference_date")
                    .HasColumnType("datetime2");
            this
                .Property(p => p.BuyerId)
                    .HasColumnName(@"buyer_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BuyerDisplayName)
                    .HasColumnName(@"buyer_display_name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerLegalName)
                    .HasColumnName(@"buyer_legal_name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerTaxCode)
                    .HasColumnName(@"buyer_tax_code")
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerAddressLine)
                    .HasColumnName(@"buyer_address_line")
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerPostalCode)
                    .HasColumnName(@"buyer_postal_code")
                    .HasMaxLength(10)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerDistrictName)
                    .HasColumnName(@"buyer_district_name")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerCityName)
                    .HasColumnName(@"buyer_city_name")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerCountryCode)
                    .HasColumnName(@"buyer_country_code")
                    .HasMaxLength(2)
                    .HasColumnType("varchar");
            this
                .Property(p => p.BuyerPhoneNumber)
                    .HasColumnName(@"buyer_phone_number")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerFaxNumber)
                    .HasColumnName(@"buyer_fax_number")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerEmail)
                    .HasColumnName(@"buyer_email")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerBankName)
                    .HasColumnName(@"buyer_bank_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyerBankAccount)
                    .HasColumnName(@"buyer_bank_account")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerLegalName)
                    .HasColumnName(@"seller_legal_name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerTaxCode)
                    .HasColumnName(@"seller_tax_code")
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerAddressLine)
                    .HasColumnName(@"seller_address_line")
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerPostalCode)
                    .HasColumnName(@"seller_postal_code")
                    .HasMaxLength(10)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerDistrictName)
                    .HasColumnName(@"seller_district_name")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerCityName)
                    .HasColumnName(@"seller_city_name")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerCountryCode)
                    .HasColumnName(@"seller_country_code")
                    .HasMaxLength(2)
                    .HasColumnType("varchar");
            this
                .Property(p => p.SellerPhoneNumber)
                    .HasColumnName(@"seller_phone_number")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerFaxNumber)
                    .HasColumnName(@"seller_fax_number")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerEmail)
                    .HasColumnName(@"seller_email")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerBankName)
                    .HasColumnName(@"seller_bank_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerBankAccount)
                    .HasColumnName(@"seller_bank_account")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerContactPersonName)
                    .HasColumnName(@"seller_contact_person_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerSignedPersonName)
                    .HasColumnName(@"seller_signed_person_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerSubmittedPersonName)
                    .HasColumnName(@"seller_submitted_person_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PaymentMethodName)
                    .HasColumnName(@"payment_method_name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SumOfTotalLineAmountWithoutVAT)
                    .HasColumnName(@"sum_of_total_line_amount_without_vat")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountWithoutVAT)
                    .HasColumnName(@"total_amount_without_vat")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalVATAmount)
                    .HasColumnName(@"total_vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountWithVAT)
                    .HasColumnName(@"total_amount_with_vat")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountWithVATFrn)
                    .HasColumnName(@"total_amount_with_vat_frn")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountWithVATInWords)
                    .HasColumnName(@"total_amount_with_vat_in_words")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.IsTotalAmountPos)
                    .HasColumnName(@"is_total_amount_pos")
                    .HasColumnType("bit");
            this
                .Property(p => p.IsTotalVATAmountPos)
                    .HasColumnName(@"is_total_vat_amount_pos")
                    .HasColumnType("bit");
            this
                .Property(p => p.DiscountAmount)
                    .HasColumnName(@"discount_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.IsDiscountAmtPos)
                    .HasColumnName(@"is_discount_amt_pos")
                    .HasColumnType("bit");
            this
                .Property(p => p.ClientId)
                    .HasColumnName(@"client_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.OrganizationId)
                    .HasColumnName(@"organization_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Status)
                    .HasColumnName(@"status")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedAt)
                    .HasColumnName(@"rec_created_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
            // Associations:
            this
                .HasMany(p => p.EInvoiceLines)
                    .WithRequired(c => c.EInvoiceHeader)
                .HasForeignKey(p => p.EInvoiceHeaderId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.EInvFormType)
                    .WithMany()
                .HasForeignKey(p => p.FormTypeId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Client)
                    .WithMany()
                .HasForeignKey(p => p.ClientId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Organization)
                    .WithMany()
                .HasForeignKey(p => p.OrganizationId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.RecCreatedByUser)
                    .WithMany()
                .HasForeignKey(p => p.RecCreatedBy)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.RecModifiedByUser)
                    .WithMany()
                .HasForeignKey(p => p.RecModifiedBy)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Buyer)
                    .WithMany()
                .HasForeignKey(p => p.BuyerId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Currency)
                    .WithMany()
                .HasForeignKey(p => p.CurrencyId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
