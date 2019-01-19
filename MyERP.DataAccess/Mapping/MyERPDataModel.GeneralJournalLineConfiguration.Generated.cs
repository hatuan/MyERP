﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 1/20/2019 12:10:21 AM
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

    public partial class GeneralJournalLineConfiguration : EntityTypeConfiguration<GeneralJournalLine>
    {

        public GeneralJournalLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("general_journal_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            this
                .Property(p => p.GeneralJournalHeaderId)
                    .HasColumnName(@"general_journal_header_id")
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
                    .HasColumnType("datetime2");
            this
                .Property(p => p.LineNo)
                    .HasColumnName(@"line_no")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.AccountId)
                    .HasColumnName(@"account_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.DebitAmountLCY)
                    .HasColumnName(@"debit_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.DebitAmount)
                    .HasColumnName(@"debit_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CreditAmountLCY)
                    .HasColumnName(@"credit_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CreditAmount)
                    .HasColumnName(@"credit_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.BusinessPartnerId)
                    .HasColumnName(@"business_partner_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.JobId)
                    .HasColumnName(@"job_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.FixAssetId)
                    .HasColumnName(@"fix_asset_id")
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
                .Property(p => p.PostingGroup)
                    .HasColumnName(@"posting_group")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("varchar");
            // Associations:
            this
                .HasRequired(p => p.Account)
                    .WithMany()
                .HasForeignKey(p => p.AccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BusinessPartner)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerId)
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
