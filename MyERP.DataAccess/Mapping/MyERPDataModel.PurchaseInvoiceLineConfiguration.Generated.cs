﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/05/2019 5:48:46 PM
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

    public partial class PurchaseInvoiceLineConfiguration : EntityTypeConfiguration<PurchaseInvoiceLine>
    {

        public PurchaseInvoiceLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("purchase_invoice_line", "dbo");
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
                .Property(p => p.PostingDate)
                    .HasColumnName(@"posting_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
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
                .Property(p => p.PurchasePrice)
                    .HasColumnName(@"purchase_price")
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
                .Property(p => p.LineAmount)
                    .HasColumnName(@"line_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.PurchasePriceLCY)
                    .HasColumnName(@"purchase_price_lcy")
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
                .Property(p => p.LineAmountLCY)
                    .HasColumnName(@"line_amount_lcy")
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
                .Property(p => p.InvoiceDiscountAmountLCY)
                    .HasColumnName(@"invoice_discount_amount_lcy")
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
                .Property(p => p.UnitPriceLCY)
                    .HasColumnName(@"unit_price_lcy")
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
                .Property(p => p.AmountLCY)
                    .HasColumnName(@"amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ChargeAmount)
                    .HasColumnName(@"charge_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ChargeAmountLCY)
                    .HasColumnName(@"charge_amount_lcy")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ImportDutyAmount)
                    .HasColumnName(@"import_duty_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ImportDutyAmountLCY)
                    .HasColumnName(@"import_duty_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ExciseTaxAmount)
                    .HasColumnName(@"excise_tax_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ExciseTaxAmountLCY)
                    .HasColumnName(@"excise_tax_amount_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatBaseAmount)
                    .HasColumnName(@"vat_base_amount")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.VatId)
                    .HasColumnName(@"vat_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.VatPercentage)
                    .HasColumnName(@"vat_percentage")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.VatAmount)
                    .HasColumnName(@"vat_amount")
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
                .Property(p => p.VatAmountLCY)
                    .HasColumnName(@"vat_amount_lcy")
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
                .Property(p => p.CostPrice)
                    .HasColumnName(@"cost_price")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CostPriceQtyBase)
                    .HasColumnName(@"cost_price_qty_base")
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
                .Property(p => p.CostPriceLCY)
                    .HasColumnName(@"cost_price_lcy")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CostPriceQtyBaseLCY)
                    .HasColumnName(@"cost_price_qty_base_lcy")
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
                .Property(p => p.InventoryAccountId)
                    .HasColumnName(@"inventory_account_id")
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
                .HasOptional(p => p.Location)
                    .WithMany()
                .HasForeignKey(p => p.LocationId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Organization)
                    .WithMany()
                .HasForeignKey(p => p.OrganizationId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Client)
                    .WithMany()
                .HasForeignKey(p => p.ClientId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Vat)
                    .WithMany()
                .HasForeignKey(p => p.VatId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Item)
                    .WithMany()
                .HasForeignKey(p => p.ItemId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Uom)
                    .WithMany()
                .HasForeignKey(p => p.UomId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Job)
                    .WithMany()
                .HasForeignKey(p => p.JobId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.InventoryAccount)
                    .WithMany()
                .HasForeignKey(p => p.InventoryAccountId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
