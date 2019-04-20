﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/20/2019 10:57:25 PM
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

    public partial class GeneralJournalHeaderConfiguration : EntityTypeConfiguration<GeneralJournalHeader>
    {

        public GeneralJournalHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("general_journal_header", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            this
                .Property(p => p.DocumentType)
                    .HasColumnName(@"document_type")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.DocSubType)
                    .HasColumnName(@"doc_sub_type")
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
                .Property(p => p.PostingDate)
                    .HasColumnName(@"posting_date")
                    .HasColumnType("datetime2");
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
                .Property(p => p.NoPrinted)
                    .HasColumnName(@"no_printed")
                    .HasColumnType("int");
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
                .Property(p => p.TotalDebitAmountLCY)
                    .HasColumnName(@"total_debit_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalDebitAmount)
                    .HasColumnName(@"total_debit_amount")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalCreditAmountLCY)
                    .HasColumnName(@"total_credit_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.TotalCreditAmount)
                    .HasColumnName(@"total_credit_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
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
            // Associations:
            this
                .HasMany(p => p.GeneralJournalLines)
                    .WithRequired(c => c.GeneralJournalHeader)
                .HasForeignKey(p => p.GeneralJournalHeaderId)
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
                .HasRequired(p => p.Currency)
                    .WithMany()
                .HasForeignKey(p => p.CurrencyId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
