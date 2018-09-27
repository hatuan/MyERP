﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/27/2018 8:53:02 PM
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

    public partial class ReportConfiguration : EntityTypeConfiguration<Report>
    {

        public ReportConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("report", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.RepId)
                    .HasColumnName(@"rep_id")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.RepNo)
                    .HasColumnName(@"rep_no")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Text)
                    .HasColumnName(@"text")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Title)
                    .HasColumnName(@"title")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.FileName)
                    .HasColumnName(@"file_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Blob)
                    .HasColumnName(@"blob")
                    .HasColumnType("nvarchar(max)");
            OnCreated();
        }

        partial void OnCreated();

    }
}
