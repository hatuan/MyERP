﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 4/1/2019 10:18:40 PM
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

    public partial class EInvFormTypeConfiguration : EntityTypeConfiguration<EInvFormType>
    {

        public EInvFormTypeConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("einv_form_type", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.InvoiceType)
                    .HasColumnName(@"invoice_type")
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceTypeNo)
                    .HasColumnName(@"invoice_type_no")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("varchar");
            this
                .Property(p => p.TemplateCode)
                    .HasColumnName(@"template_code")
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceForm)
                    .HasColumnName(@"invoice_form")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceSeries)
                    .HasColumnName(@"invoice_series")
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.FormFileName)
                    .HasColumnName(@"form_file_name")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.FormFile)
                    .HasColumnName(@"form_file")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.FormVars)
                    .HasColumnName(@"form_vars")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.Logo)
                    .HasColumnName(@"logo")
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.Watermark)
                    .HasColumnName(@"watermark")
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.ClientId)
                    .HasColumnName(@"client_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.OrganizationId)
                    .HasColumnName(@"organization_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Status)
                    .HasColumnName(@"status")
                    .IsRequired()
                    .HasColumnType("tinyint");
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
            // Associations:
            this
                .HasMany(p => p.EInvFormReleases)
                    .WithRequired(c => c.EInvFormType)
                .HasForeignKey(p => p.FormTypeId)
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
            OnCreated();
        }

        partial void OnCreated();

    }
}
