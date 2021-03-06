//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/03/2021 3:16:01 PM
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
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
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
                .Property(p => p.ItemId)
                    .HasColumnName(@"item_id")
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
                .Property(p => p.UnitId)
                    .HasColumnName(@"unit_id")
                    .IsRequired()
                    .HasColumnType("bigint");
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
                .Property(p => p.ItemTotalAmountWithoutVATLCY)
                    .HasColumnName(@"item_total_amount_without_vat_lcy")
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
                    .HasColumnType("smallint");
            this
                .Property(p => p.VATAmount)
                    .HasColumnName(@"vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VATAmountLCY)
                    .HasColumnName(@"vat_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ItemTotalAmountWithVAT)
                    .HasColumnName(@"item_total_amount_with_vat")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ItemTotalAmountWithVATLCY)
                    .HasColumnName(@"item_total_amount_with_vat_lcy")
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
            this
                .HasRequired(p => p.Item)
                    .WithMany()
                .HasForeignKey(p => p.ItemId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Uom)
                    .WithMany()
                .HasForeignKey(p => p.UnitId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
