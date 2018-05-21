﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 05/21/2018 1:35:44 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Entity.Core;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace MyERP.DataAccess
{
    public partial class EntitiesModel : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new EntitiesModel object.
        /// </summary>
        public EntitiesModel() :
                base(@"name=Connection")
        {
            Configure();
        }

        /// <summary>
        /// Initializes a new EntitiesModel object using the connection string found in the 'EntitiesModel' section of the application configuration file.
        /// </summary>
        public EntitiesModel(string nameOrConnectionString) :
                base(nameOrConnectionString)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new EntitiesModel object.
        /// </summary>
        public EntitiesModel(DbConnection existingConnection, bool contextOwnsConnection) :
                base(existingConnection, contextOwnsConnection)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new EntitiesModel object.
        /// </summary>
        public EntitiesModel(ObjectContext objectContext, bool dbContextOwnsObjectContext) :
                base(objectContext, dbContextOwnsObjectContext)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new EntitiesModel object.
        /// </summary>
        public EntitiesModel(string nameOrConnectionString, DbCompiledModel model) :
                base(nameOrConnectionString, model)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new EntitiesModel object.
        /// </summary>
        public EntitiesModel(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) :
                base(existingConnection, model, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Mapping.UserConfiguration());
            modelBuilder.Configurations.Add(new Mapping.ClientConfiguration());
            modelBuilder.Configurations.Add(new Mapping.CurrencyConfiguration());
            modelBuilder.Configurations.Add(new Mapping.OrganizationConfiguration());
            modelBuilder.Configurations.Add(new Mapping.RoleConfiguration());
            modelBuilder.Configurations.Add(new Mapping.UserInRoleConfiguration());
            modelBuilder.Configurations.Add(new Mapping.UomConfiguration());
            modelBuilder.Configurations.Add(new Mapping.ItemConfiguration());
            modelBuilder.Configurations.Add(new Mapping.ItemUomConfiguration());
            modelBuilder.Configurations.Add(new Mapping.ItemGroupConfiguration());
            modelBuilder.Configurations.Add(new Mapping.BusinessPartnerGroupConfiguration());
            modelBuilder.Configurations.Add(new Mapping.BusinessPartnerConfiguration());
            modelBuilder.Configurations.Add(new Mapping.SalesHeaderConfiguration());
            modelBuilder.Configurations.Add(new Mapping.SalesLineConfiguration());
            modelBuilder.Configurations.Add(new Mapping.PosHeaderConfiguration());
            modelBuilder.Configurations.Add(new Mapping.PosLineConfiguration());

            #region Disabled conventions


            #endregion

        }

    
        /// <summary>
        /// There are no comments for User in the schema.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
    
        /// <summary>
        /// There are no comments for Client in the schema.
        /// </summary>
        public virtual DbSet<Client> Clients { get; set; }
    
        /// <summary>
        /// There are no comments for Currency in the schema.
        /// </summary>
        public virtual DbSet<Currency> Currencies { get; set; }
    
        /// <summary>
        /// There are no comments for Organization in the schema.
        /// </summary>
        public virtual DbSet<Organization> Organizations { get; set; }
    
        /// <summary>
        /// There are no comments for Role in the schema.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }
    
        /// <summary>
        /// There are no comments for UserInRole in the schema.
        /// </summary>
        public virtual DbSet<UserInRole> UserInRoles { get; set; }
    
        /// <summary>
        /// There are no comments for Uom in the schema.
        /// </summary>
        public virtual DbSet<Uom> Uoms { get; set; }
    
        /// <summary>
        /// There are no comments for Item in the schema.
        /// </summary>
        public virtual DbSet<Item> Items { get; set; }
    
        /// <summary>
        /// There are no comments for ItemUom in the schema.
        /// </summary>
        public virtual DbSet<ItemUom> ItemUoms { get; set; }
    
        /// <summary>
        /// There are no comments for ItemGroup in the schema.
        /// </summary>
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
    
        /// <summary>
        /// There are no comments for BusinessPartnerGroup in the schema.
        /// </summary>
        public virtual DbSet<BusinessPartnerGroup> BusinessPartnerGroups { get; set; }
    
        /// <summary>
        /// There are no comments for BusinessPartner in the schema.
        /// </summary>
        public virtual DbSet<BusinessPartner> BusinessPartners { get; set; }
    
        /// <summary>
        /// There are no comments for SalesHeader in the schema.
        /// </summary>
        public virtual DbSet<SalesHeader> SalesHeaders { get; set; }
    
        /// <summary>
        /// There are no comments for SalesLine in the schema.
        /// </summary>
        public virtual DbSet<SalesLine> SalesLines { get; set; }
    
        /// <summary>
        /// There are no comments for PosHeader in the schema.
        /// </summary>
        public virtual DbSet<PosHeader> PosHeaders { get; set; }
    
        /// <summary>
        /// There are no comments for PosLine in the schema.
        /// </summary>
        public virtual DbSet<PosLine> PosLines { get; set; }
    }
}
