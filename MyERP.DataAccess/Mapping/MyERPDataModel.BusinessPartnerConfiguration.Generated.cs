﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/23/2018 9:16:36 AM
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

    public partial class BusinessPartnerConfiguration : EntityTypeConfiguration<BusinessPartner>
    {

        public BusinessPartnerConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("business_partner", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.Code)
                    .HasColumnName(@"code")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Description)
                    .HasColumnName(@"description")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.OrganizationId)
                    .HasColumnName(@"organization_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.ClientId)
                    .HasColumnName(@"client_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecCreatedAt)
                    .HasColumnName(@"rec_created_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.RecCreatedBy)
                    .HasColumnName(@"rec_created_by")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.RecModifiedAt)
                    .HasColumnName(@"rec_modified_at")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.RecModifiedBy)
                    .HasColumnName(@"rec_modified_by")
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
                .Property(p => p.BusinessPartnerPriceGroupId)
                    .HasColumnName(@"business_partner_price_group_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusinessPartnerGroupId1)
                    .HasColumnName(@"business_partner_group_id1")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusinessPartnerGroupId2)
                    .HasColumnName(@"business_partner_group_id2")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusinessPartnerGroupId3)
                    .HasColumnName(@"business_partner_group_id3")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BusPartnerDiscGroupId)
                    .HasColumnName(@"bus_partner_disc_group_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.VatCode)
                    .HasColumnName(@"vat_code")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.ContactName)
                    .HasColumnName(@"contact_name")
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
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
                .Property(p => p.Mobilephone)
                    .HasColumnName(@"mobilephone")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Fax)
                    .HasColumnName(@"fax")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Mail)
                    .HasColumnName(@"mail")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Website)
                    .HasColumnName(@"website")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.IsCustomer)
                    .HasColumnName(@"is_customer")
                    .HasColumnType("bit");
            this
                .Property(p => p.CustomerAccountId)
                    .HasColumnName(@"customer_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.IsVendor)
                    .HasColumnName(@"is_vendor")
                    .HasColumnType("bit");
            this
                .Property(p => p.VendorAccountId)
                    .HasColumnName(@"vendor_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.IsEmployee)
                    .HasColumnName(@"is_employee")
                    .HasColumnType("bit");
            this
                .Property(p => p.EmployeeAccountId)
                    .HasColumnName(@"employee_account_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.PaymentTermId)
                    .HasColumnName(@"payment_term_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.BankAccount)
                    .HasColumnName(@"bank_account")
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.BankName)
                    .HasColumnName(@"bank_name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Comment)
                    .HasColumnName(@"comment")
                    .HasMaxLength(512)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.CreditLimit)
                    .HasColumnName(@"credit_limit")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.AmountLimit)
                    .HasColumnName(@"amount_limit")
                    .HasColumnType("decimal")
                    .HasPrecision(38, 20);
            this
                .Property(p => p.GeoLatitude)
                    .HasColumnName(@"geo_latitude")
                    .HasColumnType("float");
            this
                .Property(p => p.GeoLongitude)
                    .HasColumnName(@"geo_longitude")
                    .HasColumnType("float");
            // Associations:
            this
                .HasMany(p => p.PosHeaders1)
                    .WithRequired(c => c.BillToCustomer)
                .HasForeignKey(p => p.BillToCustomerId)
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
                .HasOptional(p => p.BusinessPartnerGroup1)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerGroupId1)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BusinessPartnerGroup2)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerGroupId2)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BusinessPartnerGroup3)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerGroupId3)
                    .WillCascadeOnDelete(false);
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
                .HasOptional(p => p.BusinessPartnerPriceGroup)
                    .WithMany()
                .HasForeignKey(p => p.BusinessPartnerPriceGroupId)
                    .WillCascadeOnDelete(false);
            this
                .HasOptional(p => p.BusPartnerDiscGroup)
                    .WithMany()
                .HasForeignKey(p => p.BusPartnerDiscGroupId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
