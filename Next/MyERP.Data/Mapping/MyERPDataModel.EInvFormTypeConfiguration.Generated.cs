﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 04/21/2021 10:23:24 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace MyERP.DataAccess.Mapping
{

    public partial class EInvFormTypeConfiguration : EntityTypeConfiguration<EInvFormType>
    {

        public EInvFormTypeConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("einv_form_type", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.InvoiceName)
                    .HasColumnName(@"invoice_name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceType)
                    .HasColumnName(@"invoice_type")
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceTypeNo)
                    .HasColumnName(@"invoice_type_no")
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnType("varchar");
            this
                .Property(p => p.TemplateCode)
                    .HasColumnName(@"template_code")
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceForm)
                    .HasColumnName(@"invoice_form")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.InvoiceSeries)
                    .HasColumnName(@"invoice_series")
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.FormFileName)
                    .HasColumnName(@"form_file_name")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.FormFile)
                    .HasColumnName(@"form_file")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.SellerLegalName)
                    .HasColumnName(@"seller_legal_name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerTaxCode)
                    .HasColumnName(@"seller_tax_code")
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerAddressLine)
                    .HasColumnName(@"seller_address_line")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerPostalCode)
                    .HasColumnName(@"seller_postal_code")
                    .HasMaxLength(10)
                    .HasColumnType("varchar");
            this
                .Property(p => p.SellerDistrictName)
                    .HasColumnName(@"seller_district_name")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerCityName)
                    .HasColumnName(@"seller_city_name")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerCountryCode)
                    .HasColumnName(@"seller_country_code")
                    .HasMaxLength(2)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerPhoneNumber)
                    .HasColumnName(@"seller_phone_number")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerFaxNumber)
                    .HasColumnName(@"seller_fax_number")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerEmail)
                    .HasColumnName(@"seller_email")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerBankName)
                    .HasColumnName(@"seller_bank_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerBankAccount)
                    .HasColumnName(@"seller_bank_account")
                    .HasMaxLength(20)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerContactPersonName)
                    .HasColumnName(@"seller_contact_person_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerSignedPersonName)
                    .HasColumnName(@"seller_signed_person_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.SellerSubmittedPersonName)
                    .HasColumnName(@"seller_submitted_person_name")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Logo)
                    .HasColumnName(@"logo")
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.Watermark)
                    .HasColumnName(@"watermark")
                    .HasColumnType("nvarchar(max)");
            this
                .Property(p => p.ClientId)
                    .HasColumnName(@"client_id")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.OrganizationId)
                    .HasColumnName(@"organization_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            this
                .Property(p => p.Status)
                    .HasColumnName(@"status")
                    .IsRequired()
                    .HasColumnType("smallint");
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
            // Associations:
            this
                .HasMany(p => p.EInvFormReleases)
                    .WithRequired(c => c.EInvFormType)
                .HasForeignKey(p => p.FormTypeId)
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
