﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/18/2018 12:32:30 PM
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

    public partial class PosHeaderConfiguration : EntityTypeConfiguration<PosHeader>
    {

        public PosHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("pos_header", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
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
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellToAddress)
                    .HasColumnName(@"sell_to_address")
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
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.BillToName)
                    .HasColumnName(@"bill_to_name")
                    .IsRequired()
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
                .Property(p => p.LocationId)
                    .HasColumnName(@"location_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesPersonId)
                    .HasColumnName(@"sales_person_id")
                    .IsRequired()
                    .HasColumnType("bigint");
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
                .Property(p => p.TotalLineDiscountAmount)
                    .HasColumnName(@"total_line_discount_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalLineDiscountAmountLCY)
                    .HasColumnName(@"total_line_discount_amount_lcy")
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
                .Property(p => p.CashOfCustomer)
                    .HasColumnName(@"cash_of_customer")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ChangeReturnToCustomer)
                    .HasColumnName(@"change_return_to_customer")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
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
                    .IsRequired()
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
                .HasMany(p => p.PosLines)
                    .WithRequired(c => c.PosHeader)
                .HasForeignKey(p => p.PosHeaderId)
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
            OnCreated();
        }

        partial void OnCreated();

    }
}
