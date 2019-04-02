﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 4/2/2019 10:55:04 PM
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

    public partial class NoSequenceLineConfiguration : EntityTypeConfiguration<NoSequenceLine>
    {

        public NoSequenceLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("no_sequence_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.NoSequenceId)
                    .HasColumnName(@"no_sequence_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.LineNo)
                    .HasColumnName(@"line_no")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.StartingDate)
                    .HasColumnName(@"starting_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.StartingNo)
                    .HasColumnName(@"starting_no")
                    .IsRequired()
                    .HasColumnType("int");
            this
                .Property(p => p.EndingNo)
                    .HasColumnName(@"ending_no")
                    .IsRequired()
                    .HasColumnType("int");
            this
                .Property(p => p.CurrentNo)
                    .HasColumnName(@"current_no")
                    .IsRequired()
                    .HasColumnType("int");
            this
                .Property(p => p.FormatNo)
                    .HasColumnName(@"format_no")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.WarningNo)
                    .HasColumnName(@"warning_no")
                    .IsRequired()
                    .HasColumnType("int");
            this
                .Property(p => p.LastDateUsed)
                    .HasColumnName(@"last_date_used")
                    .HasColumnType("datetime2");
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
                .Property(p => p.Status)
                    .HasColumnName(@"status")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedAt)
                    .HasColumnName(@"rec_created_at")
                    .IsRequired()
                    .HasColumnType("datetime");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime");
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
