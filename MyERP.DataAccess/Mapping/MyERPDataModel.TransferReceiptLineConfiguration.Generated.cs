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

    public partial class TransferReceiptLineConfiguration : EntityTypeConfiguration<TransferReceiptLine>
    {

        public TransferReceiptLineConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("transfer_receipt_line", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            this
                .Property(p => p.TransferReceiptHeaderId)
                    .HasColumnName(@"transfer_receipt_header_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            OnCreated();
        }

        partial void OnCreated();

    }
}
