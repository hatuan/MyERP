﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/17/2018 5:54:43 PM
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

    public partial class PosLineConfiguration : EntityTypeConfiguration<PosLine>
    {

        public PosLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("pos_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.PosHeaderId)
                    .HasColumnName(@"pos_header_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.LineNo)
                    .HasColumnName(@"line_no")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Type)
                    .HasColumnName(@"type")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.ItemId)
                    .HasColumnName(@"item_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.LocationId)
                    .HasColumnName(@"location_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.UomId)
                    .HasColumnName(@"uom_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.UomDescription)
                    .HasColumnName(@"uom_description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Quantity)
                    .HasColumnName(@"quantity")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.SalesPriceId)
                    .HasColumnName(@"sales_price_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.UnitPrice)
                    .HasColumnName(@"unit_price")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.Amount)
                    .HasColumnName(@"amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatIdentifierId)
                    .HasColumnName(@"vat_identifier_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.VatPercentage)
                    .HasColumnName(@"vat_percentage")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.VatAmount)
                    .HasColumnName(@"vat_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.DiscountId)
                    .HasColumnName(@"discount_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.LineDiscountPercentage)
                    .HasColumnName(@"line_discount_percentage")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.LineDiscountAmount)
                    .HasColumnName(@"line_discount_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.InvoiceDiscountAmount)
                    .HasColumnName(@"invoice_discount_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.UnitPriceLCY)
                    .HasColumnName(@"unit_price_lcy")
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
                .Property(p => p.VatAmountLCY)
                    .HasColumnName(@"vat_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.LineDiscountAmountLCY)
                    .HasColumnName(@"line_discount_amount_lcy")
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
                .Property(p => p.QtyPerUom)
                    .HasColumnName(@"qty_per_uom")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QuantityBase)
                    .HasColumnName(@"quantity_base")
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
            // Associations:
            this
                .HasRequired(p => p.SalesPrice)
                    .WithMany()
                .HasForeignKey(p => p.SalesPriceId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Location)
                    .WithMany()
                .HasForeignKey(p => p.LocationId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
