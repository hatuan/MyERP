﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 1/20/2019 10:39:55 PM
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

    public partial class CashLineConfiguration : EntityTypeConfiguration<CashLine>
    {

        public CashLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("cash_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.CashHeaderId)
                    .HasColumnName(@"cash_header_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.LineNo)
                    .HasColumnName(@"line_no")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.DocumentType)
                    .HasColumnName(@"document_type")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.DocumentNo)
                    .HasColumnName(@"document_no")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PostingDate)
                    .HasColumnName(@"posting_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.BusinessPartnerId)
                    .HasColumnName(@"business_partner_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CorrespAccountId)
                    .HasColumnName(@"corresp_account_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Amount)
                    .HasColumnName(@"amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.AmountLCY)
                    .HasColumnName(@"amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.JobId)
                    .HasColumnName(@"job_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.AccountsPayableLedgerId)
                    .HasColumnName(@"accounts_payable_ledger_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.AccountsReceivableLedgerId)
                    .HasColumnName(@"accounts_receivable_ledger_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.AccountsRPAmountConv)
                    .HasColumnName(@"accounts_rpamount_conv")
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
            // Associations:
            this
                .HasRequired(p => p.BusinessPartner)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.CorrespAccount)
                    .WithMany()
                .HasForeignKey(p => p.CorrespAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.AccountsReceivableLedger)
                    .WithMany()
                .HasForeignKey(p => p.AccountsReceivableLedgerId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.AccountsPayableLedger)
                    .WithMany()
                .HasForeignKey(p => p.AccountsPayableLedgerId)
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
                .HasOptional(p => p.Job)
                    .WithMany()
                .HasForeignKey(p => p.JobId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
