﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/12/2019 4:54:58 PM
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

    public partial class ItemConfiguration : EntityTypeConfiguration<Item>
    {

        public ItemConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("item", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.Code)
                    .HasColumnName(@"code")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.BaseUomId)
                    .HasColumnName(@"base_uom_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.UnitCost)
                    .HasColumnName(@"unit_cost")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.UnitPrice)
                    .HasColumnName(@"unit_price")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CostingMethod)
                    .HasColumnName(@"costing_method")
                    .HasColumnType("tinyint");
            this
                .Property(p => p.ItemDiscountGroupId)
                    .HasColumnName(@"item_discount_group_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ItemGroupId1)
                    .HasColumnName(@"item_group_id1")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ItemGroupId2)
                    .HasColumnName(@"item_group_id2")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ItemGroupId3)
                    .HasColumnName(@"item_group_id3")
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchVendorId)
                    .HasColumnName(@"purch_vendor_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesUomId)
                    .HasColumnName(@"sales_uom_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.PurchUomId)
                    .HasColumnName(@"purch_uom_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.VatId)
                    .HasColumnName(@"vat_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.InventoryAccountId)
                    .HasColumnName(@"inventory_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ConsignmentAccountId)
                    .HasColumnName(@"consignment_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesAccountId)
                    .HasColumnName(@"sales_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesInternalAccountId)
                    .HasColumnName(@"sales_internal_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesReturnAccountId)
                    .HasColumnName(@"sales_return_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesDiscountAccountId)
                    .HasColumnName(@"sales_discount_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.COGSAccountId)
                    .HasColumnName(@"cogs_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.COGSDiffAccountId)
                    .HasColumnName(@"cogs_diff_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.WIPAccountId)
                    .HasColumnName(@"wip_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ReplenishmentSystem)
                    .HasColumnName(@"replenishment_system")
                    .HasColumnType("tinyint");
            this
                .Property(p => p.LeadTimeCalc)
                    .HasColumnName(@"lead_time_calc")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.ReorderingPolicy)
                    .HasColumnName(@"reordering_policy")
                    .HasColumnType("tinyint");
            this
                .Property(p => p.IncludeInventory)
                    .HasColumnName(@"include_inventory")
                    .HasColumnType("bit");
            this
                .Property(p => p.ReorderCycle)
                    .HasColumnName(@"reorder_cycle")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.SafetyLeadTime)
                    .HasColumnName(@"safety_lead_time")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.SafetyStockQty)
                    .HasColumnName(@"safety_stock_qty")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ReorderPoint)
                    .HasColumnName(@"reorder_point")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.MaximumInventory)
                    .HasColumnName(@"maximum_inventory")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.ReorderQty)
                    .HasColumnName(@"reorder_qty")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.MinimumOrderQty)
                    .HasColumnName(@"minimum_order_qty")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.MaximumOrderQty)
                    .HasColumnName(@"maximum_order_qty")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.OrderMultiple)
                    .HasColumnName(@"order_multiple")
                    .HasColumnType("tinyint");
            this
                .Property(p => p.ManufacturingPolicy)
                    .HasColumnName(@"manufacturing_policy")
                    .HasColumnType("tinyint");
            this
                .Property(p => p.RoutingId)
                    .HasColumnName(@"routing_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BomId)
                    .HasColumnName(@"bom_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.FlushingMethod)
                    .HasColumnName(@"flushing_method")
                    .HasColumnType("tinyint");
            this
                .Property(p => p.Scrap)
                    .HasColumnName(@"scrap")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.LotSize)
                    .HasColumnName(@"lot_size")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.LowLevelCode)
                    .HasColumnName(@"low_level_code")
                    .HasColumnType("tinyint");
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
                    .HasColumnType("smallint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasMany(p => p.ItemUoms)
                    .WithRequired(c => c.Item)
                .HasForeignKey(p => p.ItemId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.BaseUom)
                    .WithMany()
                .HasForeignKey(p => p.BaseUomId)
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
                .HasOptional(p => p.ItemGroup1)
                    .WithMany()
                .HasForeignKey(p => p.ItemGroupId1)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.ItemGroup2)
                    .WithMany()
                .HasForeignKey(p => p.ItemGroupId2)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.ItemGroup3)
                    .WithMany()
                .HasForeignKey(p => p.ItemGroupId3)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.SalesUom)
                    .WithMany()
                .HasForeignKey(p => p.SalesUomId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.PurchUom)
                    .WithMany()
                .HasForeignKey(p => p.PurchUomId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.PurchVendor)
                    .WithMany()
                .HasForeignKey(p => p.PurchVendorId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.ItemDiscountGroup)
                    .WithMany()
                .HasForeignKey(p => p.ItemDiscountGroupId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Vat)
                    .WithMany()
                .HasForeignKey(p => p.VatId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.InventoryAccount)
                    .WithMany()
                .HasForeignKey(p => p.InventoryAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.ConsignmentAccount)
                    .WithMany()
                .HasForeignKey(p => p.ConsignmentAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesAccount)
                    .WithMany()
                .HasForeignKey(p => p.SalesAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesInternalAccount)
                    .WithMany()
                .HasForeignKey(p => p.SalesInternalAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesReturnAccount)
                    .WithMany()
                .HasForeignKey(p => p.SalesReturnAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.SalesDiscountAccount)
                    .WithMany()
                .HasForeignKey(p => p.SalesDiscountAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.COGSAccount)
                    .WithMany()
                .HasForeignKey(p => p.COGSAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.COGSDiffAccount)
                    .WithMany()
                .HasForeignKey(p => p.COGSDiffAccountId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.WIPAccount)
                    .WithMany()
                .HasForeignKey(p => p.WIPAccountId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
