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

    public partial class TransferShipmentHeaderConfiguration : EntityTypeConfiguration<TransferShipmentHeader>
    {

        public TransferShipmentHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("transfer_shipment_header", "dbo");
            // Property:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            // Association:
            this
                .HasMany(p => p.TransferShipmentLines)
                    .WithRequired(c => c.TransferShipmentHeader)
                .HasForeignKey(p => p.TransferShipmentHeaderId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
