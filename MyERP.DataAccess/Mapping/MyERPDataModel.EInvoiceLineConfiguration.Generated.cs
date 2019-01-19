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

    public partial class EInvoiceLineConfiguration : EntityTypeConfiguration<EInvoiceLine>
    {

        public EInvoiceLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("einvoice_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            this
                .Property(p => p.EInvoiceHeaderId)
                    .HasColumnName(@"einvoice_header_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.LineNumber)
                    .HasColumnName(@"line_number")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.ItemCode)
                    .HasColumnName(@"item_code")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.ItemName)
                    .HasColumnName(@"item_name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.UnitCode)
                    .HasColumnName(@"unit_code")
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.UnitName)
                    .HasColumnName(@"unit_name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.UnitPrice)
                    .HasColumnName(@"unit_price")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.Quantity)
                    .HasColumnName(@"quantity")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ItemTotalAmountWithoutVAT)
                    .HasColumnName(@"item_total_amount_without_vat")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatId)
                    .HasColumnName(@"vat_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.VATPercentage)
                    .HasColumnName(@"vat_percentage")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VATAmount)
                    .HasColumnName(@"vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.Promotion)
                    .HasColumnName(@"promotion")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.AdjustmentVATAmount)
                    .HasColumnName(@"adjustment_vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.IsIncreaseItem)
                    .HasColumnName(@"is_increase_item")
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
                .HasRequired(p => p.Vat)
                    .WithMany()
                .HasForeignKey(p => p.VatId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
