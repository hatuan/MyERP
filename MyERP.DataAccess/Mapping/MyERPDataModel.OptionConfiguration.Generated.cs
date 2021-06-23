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
using System.Data.Entity.ModelConfiguration;

namespace MyERP.DataAccess.Mapping
{

    public partial class OptionConfiguration : EntityTypeConfiguration<Option>
    {

        public OptionConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("option", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesPosLocationId)
                    .HasColumnName(@"sales_pos_location_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesPosSequenceId)
                    .HasColumnName(@"sales_pos_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesOrderSequenceId)
                    .HasColumnName(@"sales_order_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesShipmentSeqId)
                    .HasColumnName(@"sales_shipment_seq_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesInvoiceSeqId)
                    .HasColumnName(@"sales_invoice_seq_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchOrderSequenceId)
                    .HasColumnName(@"purch_order_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchReceiveSeqId)
                    .HasColumnName(@"purch_receive_seq_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchInvoiceSeqId)
                    .HasColumnName(@"purch_invoice_seq_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.OneTimeBusinessPartnerId)
                    .HasColumnName(@"one_time_business_partner_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.GeneralLedgerSequenceId)
                    .HasColumnName(@"general_ledger_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CashReceiptSequenceId)
                    .HasColumnName(@"cash_receipt_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CashPaymentSequenceId)
                    .HasColumnName(@"cash_payment_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BankReceiptSequenceId)
                    .HasColumnName(@"bank_receipt_sequence_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BankCheckqueSequenceId)
                    .HasColumnName(@"bank_checkque_sequence_id")
                    .HasColumnType("bigint");
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
                .Property(p => p.Status)
                    .HasColumnName(@"status")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
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
                .HasRequired(p => p.RecModifiedByUser)
                    .WithMany()
                .HasForeignKey(p => p.RecModifiedBy)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesPosSequence)
                    .WithMany()
                .HasForeignKey(p => p.SalesPosSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesOrderSequence)
                    .WithMany()
                .HasForeignKey(p => p.SalesOrderSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesShipmentSequence)
                    .WithMany()
                .HasForeignKey(p => p.SalesShipmentSeqId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesInvoiceSequence)
                    .WithMany()
                .HasForeignKey(p => p.SalesInvoiceSeqId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.PurchOrderSequence)
                    .WithMany()
                .HasForeignKey(p => p.PurchOrderSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.PurchReceiveSequence)
                    .WithMany()
                .HasForeignKey(p => p.PurchReceiveSeqId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.PurchInvoiceSequence)
                    .WithMany()
                .HasForeignKey(p => p.PurchInvoiceSeqId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.RecCreatedByUser)
                    .WithMany()
                .HasForeignKey(p => p.RecCreatedBy)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.SalesPosLocation)
                    .WithOptional()
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.OneTimeBusinessPartner)
                    .WithOptional()
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.GeneralLedgerSequence)
                    .WithMany()
                .HasForeignKey(p => p.GeneralLedgerSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.CashReceiptSequence)
                    .WithMany()
                .HasForeignKey(p => p.CashReceiptSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.CashPaymentSequence)
                    .WithMany()
                .HasForeignKey(p => p.CashPaymentSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.BankReceiptSequence)
                    .WithMany()
                .HasForeignKey(p => p.BankReceiptSequenceId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BankCheckque)
                    .WithMany()
                .HasForeignKey(p => p.BankCheckqueSequenceId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
