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

    public partial class ItemLedgerEntryConfiguration : EntityTypeConfiguration<ItemLedgerEntry>
    {

        public ItemLedgerEntryConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("item_ledger_entry", "dbo");
            // Property:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            OnCreated();
        }

        partial void OnCreated();

    }
}
