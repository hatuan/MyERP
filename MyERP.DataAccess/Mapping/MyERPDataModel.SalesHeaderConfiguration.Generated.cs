﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 06/23/2018 2:13:24 PM
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

    public partial class SalesHeaderConfiguration : EntityTypeConfiguration<SalesHeader>
    {

        public SalesHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("sales_header", "dbo");
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
                    .HasColumnType("datetime2");
            this
                .Property(p => p.SellToCustomerId)
                    .HasColumnName(@"sell_to_customer_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.SellToCustomerName)
                    .HasColumnName(@"sell_to_customer_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellToAddress)
                    .HasColumnName(@"sell_to_address")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellToContactId)
                    .HasColumnName(@"sell_to_contact_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SellToContactName)
                    .HasColumnName(@"sell_to_contact_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BillToCustomerId)
                    .HasColumnName(@"bill_to_customer_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BillToName)
                    .HasColumnName(@"bill_to_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BillToAddress)
                    .HasColumnName(@"bill_to_address")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BillToContactId)
                    .HasColumnName(@"bill_to_contact_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BillToContactName)
                    .HasColumnName(@"bill_to_contact_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BillToVatCode)
                    .HasColumnName(@"bill_to_vat_code")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.BillToVatNote)
                    .HasColumnName(@"bill_to_vat_note")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
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
                .Property(p => p.TotalAmount)
                    .HasColumnName(@"total_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountLCY)
                    .HasColumnName(@"total_amount_lcy")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountNoVat)
                    .HasColumnName(@"total_amount_no_vat")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountVat0)
                    .HasColumnName(@"total_amount_vat0")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountVat5)
                    .HasColumnName(@"total_amount_vat5")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalAmountVat10)
                    .HasColumnName(@"total_amount_vat10")
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
                .Property(p => p.TotalVat5Amount)
                    .HasColumnName(@"total_vat5amount")
                    .HasColumnType("int");
            this
                .Property(p => p.TotalVat10Amount)
                    .HasColumnName(@"total_vat10amount")
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
                    .HasColumnType("datetime2");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
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
                .HasMany(p => p.SalesLines)
                    .WithRequired(c => c.SalesHeader)
                .HasForeignKey(p => p.SalesHeaderId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Location)
                    .WithMany()
                .HasForeignKey(p => p.LocationId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.SellToCustomer)
                    .WithMany()
                .HasForeignKey(p => p.SellToCustomerId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.BillToCustomer)
                    .WithMany()
                .HasForeignKey(p => p.BillToCustomerId)
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
