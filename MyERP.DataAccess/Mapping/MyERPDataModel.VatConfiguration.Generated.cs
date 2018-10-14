﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 10/13/2018 6:20:15 PM
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

    public partial class VatConfiguration : EntityTypeConfiguration<Vat>
    {

        public VatConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("vat", "dbo");
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
                .Property(p => p.VatPercentage)
                    .HasColumnName(@"vat_percentage")
                    .IsRequired()
                    .HasColumnType("tinyint");
            this
                .Property(p => p.AccountInputVatId)
                    .HasColumnName(@"account_input_vat_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.AccountOutputVatId)
                    .HasColumnName(@"account_output_vat_id")
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
                    .HasColumnType("tinyint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasRequired(p => p.AccountInputVat)
                    .WithMany()
                .HasForeignKey(p => p.AccountInputVatId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.AccountOutputVat)
                    .WithMany()
                .HasForeignKey(p => p.AccountOutputVatId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
