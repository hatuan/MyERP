﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/24/2019 10:23:05 PM
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

    public partial class TransferReceiptHeaderConfiguration : EntityTypeConfiguration<TransferReceiptHeader>
    {

        public TransferReceiptHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("transfer_receipt_header", "dbo");
            // Property:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            // Association:
            this
                .HasMany(p => p.TransferReceiptLines)
                    .WithRequired(c => c.TransferReceiptHeader)
                .HasForeignKey(p => p.TransferReceiptHeaderId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
