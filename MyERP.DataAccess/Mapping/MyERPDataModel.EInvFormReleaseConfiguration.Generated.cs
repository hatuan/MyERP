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

    public partial class EInvFormReleaseConfiguration : EntityTypeConfiguration<EInvFormRelease>
    {

        public EInvFormReleaseConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("einv_form_release", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.FormTypeId)
                    .HasColumnName(@"form_type_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.ReleaseTotal)
                    .HasColumnName(@"release_total")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(7, 0);
            this
                .Property(p => p.ReleaseFrom)
                    .HasColumnName(@"release_from")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(7, 0);
            this
                .Property(p => p.ReleaseTo)
                    .HasColumnName(@"release_to")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(7, 0);
            this
                .Property(p => p.ReleaseUsed)
                    .HasColumnName(@"release_used")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(7, 0);
            this
                .Property(p => p.ReleaseDate)
                    .HasColumnName(@"release_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.StartDate)
                    .HasColumnName(@"start_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.TaxAuthoritiesStatus)
                    .HasColumnName(@"tax_authorities_status")
                    .IsRequired()
                    .HasColumnType("tinyint");
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
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Blocked)
                    .HasColumnName(@"blocked")
                    .IsRequired()
                    .HasColumnType("bit");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedAt)
                    .HasColumnName(@"rec_created_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
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
