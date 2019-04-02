﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 4/2/2019 10:55:04 PM
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

    public partial class CashHeaderConfiguration : EntityTypeConfiguration<CashHeader>
    {

        public CashHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("cash_header", "dbo");
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
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.BusinessPartnerId)
                    .HasColumnName(@"business_partner_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusinessPartnerName)
                    .HasColumnName(@"business_partner_name")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BusinessPartnerAddress)
                    .HasColumnName(@"business_partner_address")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BusinessPartnerContactId)
                    .HasColumnName(@"business_partner_contact_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusinessPartnerContactName)
                    .HasColumnName(@"business_partner_contact_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.AccountId)
                    .HasColumnName(@"account_id")
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
                .Property(p => p.TotalVatAmount)
                    .HasColumnName(@"total_vat_amount")
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
                .Property(p => p.TotalAmountLCY)
                    .HasColumnName(@"total_amount_lcy")
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
                .Property(p => p.TotalPaymentLCY)
                    .HasColumnName(@"total_payment_lcy")
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
                    .HasColumnType("tinyint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasMany(p => p.CashLines)
                    .WithRequired(c => c.CashHeader)
                .HasForeignKey(p => p.CashHeaderId)
                    .WillCascadeOnDelete(false);
            this
                .HasMany(p => p.VatEntries)
                    .WithOptional()
                .HasForeignKey(p => p.CashHeaderId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.BusinessPartner)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerId)
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
                .HasRequired(p => p.Account)
                    .WithMany()
                .HasForeignKey(p => p.AccountId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
