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

    public partial class AccountsPayableLedgerConfiguration : EntityTypeConfiguration<AccountsPayableLedger>
    {

        public AccountsPayableLedgerConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("accounts_payable_ledger", "dbo");
            // Property:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .HasColumnType("bigint");
            // Association:
            OnCreated();
        }

        partial void OnCreated();

    }
}
