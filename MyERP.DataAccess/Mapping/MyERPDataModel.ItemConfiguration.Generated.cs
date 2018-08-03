﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/03/2018 2:56:56 PM
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
                .HasRequired(p => p.PurchVendor)
                    .WithMany()
                .HasForeignKey(p => p.PurchVendorId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.ItemDiscountGroup)
                    .WithMany()
                .HasForeignKey(p => p.ItemDiscountGroupId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
