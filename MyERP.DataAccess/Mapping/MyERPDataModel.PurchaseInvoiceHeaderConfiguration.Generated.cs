﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 10/13/2018 6:20:15 PM
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

    public partial class PurchaseInvoiceHeaderConfiguration : EntityTypeConfiguration<PurchaseInvoiceHeader>
    {

        public PurchaseInvoiceHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("purchase_invoice_header", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.DocumentType)
                    .HasColumnName(@"document_type")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.DocSequenceId)
                    .HasColumnName(@"doc_sequence_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.DocumentNo)
                    .HasColumnName(@"document_no")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.DocumentDate)
                    .HasColumnName(@"document_date")
                    .IsRequired()
                    .HasColumnType("datetime");
            this
                .Property(p => p.PostingDate)
                    .HasColumnName(@"posting_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.BuyFromVendorId)
                    .HasColumnName(@"buy_from_vendor_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.BuyFromVendorName)
                    .HasColumnName(@"buy_from_vendor_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyFromAddress)
                    .HasColumnName(@"buy_from_address")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BuyFromContactId)
                    .HasColumnName(@"buy_from_contact_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BuyFromContactName)
                    .HasColumnName(@"buy_from_contact_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PayToVendorId)
                    .HasColumnName(@"pay_to_vendor_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.PayToName)
                    .HasColumnName(@"pay_to_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PayToAddress)
                    .HasColumnName(@"pay_to_address")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PaylToContactId)
                    .HasColumnName(@"payl_to_contact_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.PayToContactName)
                    .HasColumnName(@"pay_to_contact_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PayToVatCode)
                    .HasColumnName(@"pay_to_vat_code")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.PayToVatNote)
                    .HasColumnName(@"pay_to_vat_note")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.AccountPayableId)
                    .HasColumnName(@"account_payable_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.ShipToName)
                    .HasColumnName(@"ship_to_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.ShipToAddress)
                    .HasColumnName(@"ship_to_address")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.ShipToContactName)
                    .HasColumnName(@"ship_to_contact_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.CurrencyId)
                    .HasColumnName(@"currency_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.CurrencyFactor)
                    .HasColumnName(@"currency_factor")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.LocationId)
                    .HasColumnName(@"location_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesPersonId)
                    .HasColumnName(@"sales_person_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.TotalLineAmount)
                    .HasColumnName(@"total_line_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalLineAmountLCY)
                    .HasColumnName(@"total_line_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmount)
                    .HasColumnName(@"total_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountLCY)
                    .HasColumnName(@"total_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalChargeAmount)
                    .HasColumnName(@"total_charge_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalChargeAmountLCY)
                    .HasColumnName(@"total_charge_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.DiscountId)
                    .HasColumnName(@"discount_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.InvoiceDiscountPercentage)
                    .HasColumnName(@"invoice_discount_percentage")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.InvoiceDiscountAmount)
                    .HasColumnName(@"invoice_discount_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.InvoiceDiscountAmountLCY)
                    .HasColumnName(@"invoice_discount_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalImportDutyAmount)
                    .HasColumnName(@"total_import_duty_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalImportDutyAmountLCY)
                    .HasColumnName(@"total_import_duty_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalExciseTaxAmount)
                    .HasColumnName(@"total_excise_tax_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalExciseTaxAmountLCY)
                    .HasColumnName(@"total_excise_tax_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalVatAmount)
                    .HasColumnName(@"total_vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalVatAmountLCY)
                    .HasColumnName(@"total_vat_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalPayment)
                    .HasColumnName(@"total_payment")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalPaymentLCY)
                    .HasColumnName(@"total_payment_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.NoPrinted)
                    .HasColumnName(@"no_printed")
                    .IsRequired()
                    .HasColumnType("int");
            this
                .Property(p => p.QuoteId)
                    .HasColumnName(@"quote_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CampaignId)
                    .HasColumnName(@"campaign_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.OpportunityId)
                    .HasColumnName(@"opportunity_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.OrganizationId)
                    .HasColumnName(@"organization_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.ClientId)
                    .HasColumnName(@"client_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedAt)
                    .HasColumnName(@"rec_created_at")
                    .IsRequired()
                    .HasColumnType("datetime");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Status)
                    .HasColumnName(@"status")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasMany(p => p.PurchaseInvoiceLines)
                    .WithRequired(c => c.PurchaseInvoiceHeader)
                .HasForeignKey(p => p.PurchaseHeaderId)
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
                .HasRequired(p => p.Currency)
                    .WithMany()
                .HasForeignKey(p => p.CurrencyId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.NoSequence)
                    .WithMany()
                .HasForeignKey(p => p.DocSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.BuyFromVendor)
                    .WithMany()
                .HasForeignKey(p => p.BuyFromVendorId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.PayToVendor)
                    .WithMany()
                .HasForeignKey(p => p.PayToVendorId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Location)
                    .WithMany()
                .HasForeignKey(p => p.LocationId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.AccountPayable)
                    .WithMany()
                .HasForeignKey(p => p.AccountPayableId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
