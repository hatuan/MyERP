﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/24/2018 5:28:32 PM
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

    public partial class PurchaseLineConfiguration : EntityTypeConfiguration<PurchaseLine>
    {

        public PurchaseLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("purchase_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchaseHeaderId)
                    .HasColumnName(@"purchase_header_id")
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
                    .IsRequired()
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
                    .HasColumnType("decimal");
            this
                .Property(p => p.LineDiscountAmountLCY)
                    .HasColumnName(@"line_discount_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal");
            this
                .Property(p => p.InvoiceDiscountAmount)
                    .HasColumnName(@"invoice_discount_amount")
                    .IsRequired()
                    .HasColumnType("decimal");
            this
                .Property(p => p.InvoiceDiscountAmountLCY)
                    .HasColumnName(@"invoice_discount_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal");
            this
                .Property(p => p.CostUnit)
                    .HasColumnName(@"cost_unit")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CostUnitLCY)
                    .HasColumnName(@"cost_unit_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CostAmount)
                    .HasColumnName(@"cost_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CostAmountLCY)
                    .HasColumnName(@"cost_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QuantityReceived)
                    .HasColumnName(@"quantity_received")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.OutstandingQuantity)
                    .HasColumnName(@"outstanding_quantity")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QuantityInvoiced)
                    .HasColumnName(@"quantity_invoiced")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QtyReceivedNotInvoiced)
                    .HasColumnName(@"qty_received_not_invoiced")
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
                .Property(p => p.OutstandingQtyBase)
                    .HasColumnName(@"outstanding_qty_base")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QuantityReceivedBase)
                    .HasColumnName(@"quantity_received_base")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QuantityInvoicedBase)
                    .HasColumnName(@"quantity_invoiced_base")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.QtyReceivedNotInvoicedBase)
                    .HasColumnName(@"qty_received_not_invoiced_base")
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
                .HasRequired(p => p.Location)
                    .WithMany()
                .HasForeignKey(p => p.LocationId)
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
                .HasRequired(p => p.Uom)
                    .WithMany()
                .HasForeignKey(p => p.UomId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Item)
                    .WithMany()
                .HasForeignKey(p => p.ItemId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
