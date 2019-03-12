﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/11/2019 10:10:39 PM
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

    public partial class ItemJournalHeaderConfiguration : EntityTypeConfiguration<ItemJournalHeader>
    {

        public ItemJournalHeaderConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("item_journal_header", "dbo");
            // Property:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            // Association:
            this
                .HasMany(p => p.ItemJournalLines)
                    .WithRequired(c => c.ItemJournalHeader)
                .HasForeignKey(p => p.ItemJournalHeaderId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
