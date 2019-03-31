﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/31/2019 10:21:23 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyERP.DataAccess
{

    /// <summary>
    /// There are no comments for MyERP.DataAccess.User in the schema.
    /// </summary>
    public partial class User    {

        public User()
        {
          this.Version = 1;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FullName in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string FullName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Email
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActivated in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual bool IsActivated
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsEmailConfirmed in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual bool IsEmailConfirmed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmailConfirmationCode in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string EmailConfirmationCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PasswordQuestion in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string PasswordQuestion
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PasswordAnswer in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string PasswordAnswer
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Password in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Password
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Salt in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string Salt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganizationId in the schema.
        /// </summary>
        public virtual long? OrganizationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClientId in the schema.
        /// </summary>
        public virtual long? ClientId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CultureUiId in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        public virtual string CultureUiId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Comment in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string Comment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime CreatedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastModifiedDate in the schema.
        /// </summary>
        public virtual global::System.DateTime? LastModifiedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastLoginIp in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string LastLoginIp
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastLoginDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime LastLoginDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsLockedOut in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual bool IsLockedOut
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastLockedOutReason in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public virtual string LastLockedOutReason
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastLockedOutDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime LastLockedOutDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastPasswordChangedDate in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual global::System.DateTime LastPasswordChangedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Version in the schema.
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual long Version
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Roles in the schema.
        /// </summary>
        public virtual ICollection<UserInRole> Roles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organization in the schema.
        /// </summary>
        public virtual Organization Organization
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Client in the schema.
        /// </summary>
        public virtual Client Client
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
