﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/02/2018 10:26:06 AM
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

    public partial class SalesPriceConfiguration : EntityTypeConfiguration<SalesPrice>
    {

        public SalesPriceConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("sales_price", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesPriceGroupId)
                    .HasColumnName(@"sales_price_group_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.SalesType)
                    .HasColumnName(@"sales_type")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.BusinessPartnerId)
                    .HasColumnName(@"business_partner_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusPartnerPriceGroupId)
                    .HasColumnName(@"bus_partner_price_group_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CampaignId)
                    .HasColumnName(@"campaign_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ItemId)
                    .HasColumnName(@"item_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.UomId)
                    .HasColumnName(@"uom_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.StartingDate)
                    .HasColumnName(@"starting_date")
                    .IsRequired()
                    .HasColumnType("datetime");
            this
                .Property(p => p.MinQty)
                    .HasColumnName(@"min_qty")
                    .IsRequired()
                    .HasColumnType("decimal");
            this
                .Property(p => p.UnitPrice)
                    .HasColumnName(@"unit_price")
                    .IsRequired()
                    .HasColumnType("decimal");
            this
                .Property(p => p.EndingDate)
                    .HasColumnName(@"ending_date")
                    .HasColumnType("datetime");
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
                    .HasColumnType("datetime");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasRequired(p => p.Item)
                    .WithMany()
                .HasForeignKey(p => p.ItemId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.Uom)
                    .WithMany()
                .HasForeignKey(p => p.UomId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BusPartnerPriceGroup)
                    .WithMany()
                .HasForeignKey(p => p.BusPartnerPriceGroupId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BusinessPartner)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
