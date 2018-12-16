﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 12/11/2018 10:45:15 PM
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

    public partial class VatEntryConfiguration : EntityTypeConfiguration<VatEntry>
    {

        public VatEntryConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("vat_entry", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchHeaderId)
                    .HasColumnName(@"purch_header_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CashHeaderId)
                    .HasColumnName(@"cash_header_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.DocumentType)
                    .HasColumnName(@"document_type")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.DocumentSubType)
                    .HasColumnName(@"document_sub_type")
                    .IsRequired()
                    .HasColumnType("tinyint");
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
                .Property(p => p.InvoiceIssuedDate)
                    .HasColumnName(@"invoice_issued_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.InvoiceNumber)
                    .HasColumnName(@"invoice_number")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceSeries)
                    .HasColumnName(@"invoice_series")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.LineNo)
                    .HasColumnName(@"line_no")
                    .IsRequired()
                    .HasColumnType("bigint");
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
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.TaxCode)
                    .HasColumnName(@"tax_code")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.CurrencyId)
                    .HasColumnName(@"currency_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CurrencyFactor)
                    .HasColumnName(@"currency_factor")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatBaseAmount)
                    .HasColumnName(@"vat_base_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatBaseAmountLCY)
                    .HasColumnName(@"vat_base_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatId)
                    .HasColumnName(@"vat_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.VatPercentage)
                    .HasColumnName(@"vat_percentage")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatAmount)
                    .HasColumnName(@"vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatAmountLCY)
                    .HasColumnName(@"vat_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.AccountVatId)
                    .HasColumnName(@"account_vat_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.CorrespAccountId)
                    .HasColumnName(@"corresp_account_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.JobId)
                    .HasColumnName(@"job_id")
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
            // Associations:
            this
                .HasRequired(p => p.BusinessPartner)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Vat)
                    .WithMany()
                .HasForeignKey(p => p.VatId)
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
                .HasRequired(p => p.AccountVat)
                    .WithMany()
                .HasForeignKey(p => p.AccountVatId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.CorrespAccount)
                    .WithMany()
                .HasForeignKey(p => p.CorrespAccountId)
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
