﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/15/2018 4:54:37 PM
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

    public partial class ItemUomConfiguration : EntityTypeConfiguration<ItemUom>
    {

        public ItemUomConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("item_uom", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.ItemId)
                    .HasColumnName(@"item_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.UomId)
                    .HasColumnName(@"uom_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.QtyPerUom)
                    .HasColumnName(@"qty_per_uom")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            // Associations:
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
