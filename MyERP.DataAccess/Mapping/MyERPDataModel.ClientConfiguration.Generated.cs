﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/04/2019 2:35:19 PM
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

    public partial class ClientConfiguration : EntityTypeConfiguration<Client>
    {

        public ClientConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("client", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.IsActivated)
                    .HasColumnName(@"is_activated")
                    .IsRequired()
                    .HasColumnType("bit");
            this
                .Property(p => p.CultureId)
                    .HasColumnName(@"culture_id")
                    .HasMaxLength(8)
                    .HasColumnType("varchar");
            this
                .Property(p => p.AmountDecimalPlaces)
                    .HasColumnName(@"amount_decimal_places")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.AmountRoundingPrecision)
                    .HasColumnName(@"amount_rounding_precision")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.UnitAmountDecimalPlaces)
                    .HasColumnName(@"unit_amount_decimal_places")
                    .IsRequired()
                    .HasColumnType("smallint");
            this
                .Property(p => p.UnitAmountRoundingPrecision)
                    .HasColumnName(@"unit_amount_rounding_precision")
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.CurrencyLcyId)
                    .HasColumnName(@"currency_lcy_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.TaxCode)
                    .HasColumnName(@"tax_code")
                    .HasMaxLength(14)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Address)
                    .HasColumnName(@"address")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.AddressTransition)
                    .HasColumnName(@"address_transition")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Telephone)
                    .HasColumnName(@"telephone")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Email)
                    .HasColumnName(@"email")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Website)
                    .HasColumnName(@"website")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Image)
                    .HasColumnName(@"image")
                    .HasColumnType("varbinary");
            this
                .Property(p => p.RepresentativeName)
                    .HasColumnName(@"representative_name")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.RepresentativePosition)
                    .HasColumnName(@"representative_position")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.ContactName)
                    .HasColumnName(@"contact_name")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Mobilephone)
                    .HasColumnName(@"mobilephone")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.TaxAuthoritiesId)
                    .HasColumnName(@"tax_authorities_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedAt)
                    .HasColumnName(@"rec_created_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .HasColumnType("datetime2");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasMany(p => p.Organizations)
                    .WithRequired(c => c.Client)
                .HasForeignKey(p => p.ClientId)
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
            this
                .HasOptional(p => p.CurrencyLcy)
                    .WithMany()
                .HasForeignKey(p => p.CurrencyLcyId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
