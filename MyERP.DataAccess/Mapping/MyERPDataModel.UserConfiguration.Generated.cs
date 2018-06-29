﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 06/29/2018 5:40:44 PM
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

    public partial class UserConfiguration : EntityTypeConfiguration<User>
    {

        public UserConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("user", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"id")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                    .HasColumnType("bigint");
            this
                .Property(p => p.Name)
                    .HasColumnName(@"name")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.FullName)
                    .HasColumnName(@"full_name")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Email)
                    .HasColumnName(@"email")
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("varchar");
            this
                .Property(p => p.IsActivated)
                    .HasColumnName(@"is_activated")
                    .IsRequired()
                    .HasColumnType("bit");
            this
                .Property(p => p.IsEmailConfirmed)
                    .HasColumnName(@"is_email_confirmed")
                    .IsRequired()
                    .HasColumnType("bit");
            this
                .Property(p => p.EmailConfirmationCode)
                    .HasColumnName(@"email_confirmation_code")
                    .HasMaxLength(512)
                    .HasColumnType("varchar");
            this
                .Property(p => p.PasswordQuestion)
                    .HasColumnName(@"password_question")
                    .HasMaxLength(512)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.PasswordAnswer)
                    .HasColumnName(@"password_answer")
                    .HasMaxLength(512)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.Password)
                    .HasColumnName(@"password")
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Salt)
                    .HasColumnName(@"salt")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.OrganizationId)
                    .HasColumnName(@"organization_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.ClientId)
                    .HasColumnName(@"client_id")
                    .HasColumnType("bigint");
            this
                .Property(p => p.CultureUiId)
                    .HasColumnName(@"culture_ui_id")
                    .HasMaxLength(8)
                    .HasColumnType("varchar");
            this
                .Property(p => p.Comment)
                    .HasColumnName(@"comment")
                    .HasMaxLength(512)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.CreatedDate)
                    .HasColumnName(@"created_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.LastModifiedDate)
                    .HasColumnName(@"last_modified_date")
                    .HasColumnType("datetime2");
            this
                .Property(p => p.LastLoginIp)
                    .HasColumnName(@"last_login_ip")
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            this
                .Property(p => p.LastLoginDate)
                    .HasColumnName(@"last_login_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.IsLockedOut)
                    .HasColumnName(@"is_locked_out")
                    .IsRequired()
                    .HasColumnType("bit");
            this
                .Property(p => p.LastLockedOutReason)
                    .HasColumnName(@"last_locked_out_reason")
                    .HasMaxLength(512)
                    .HasColumnType("nvarchar");
            this
                .Property(p => p.LastLockedOutDate)
                    .HasColumnName(@"last_locked_out_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.LastPasswordChangedDate)
                    .HasColumnName(@"last_password_changed_date")
                    .IsRequired()
                    .HasColumnType("datetime2");
            this
                .Property(p => p.Version)
                    .HasColumnName(@"version")
                    .IsRequired()
                    .HasColumnType("bigint");
            // Associations:
            this
                .HasMany(p => p.Roles)
                    .WithRequired(c => c.User)
                .HasForeignKey(p => p.UserId)
                    .WillCascadeOnDelete(false);
            this
                .HasMany(p => p.NoSequenceLines1)
                    .WithRequired(c => c.RecModifiedByUser)
                .HasForeignKey(p => p.RecModifiedBy)
                    .WillCascadeOnDelete(false);
            this
                .HasMany(p => p.Options)
                    .WithRequired(c => c.RecModifiedByUser)
                .HasForeignKey(p => p.RecModifiedBy)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Organization)
                    .WithMany()
                .HasForeignKey(p => p.OrganizationId)
                    .WillCascadeOnDelete(false);
            this
                .HasRequired(p => p.Client)
                    .WithMany()
                .HasForeignKey(p => p.ClientId)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
