﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 11/03/2021 3:16:01 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    public partial class User
    {

        public User()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string Name { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string FullName { get; set; }

        [StringLength(256)]
        [Required()]
        public virtual string Email { get; set; }

        [Required()]
        public virtual bool IsActivated { get; set; }

        [Required()]
        public virtual bool IsEmailConfirmed { get; set; }

        [StringLength(512)]
        public virtual string EmailConfirmationCode { get; set; }

        [StringLength(512)]
        public virtual string PasswordQuestion { get; set; }

        [StringLength(512)]
        public virtual string PasswordAnswer { get; set; }

        [StringLength(128)]
        [Required()]
        public virtual string Password { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string Salt { get; set; }

        public virtual long? OrganizationId { get; set; }

        public virtual long? ClientId { get; set; }

        [StringLength(8)]
        public virtual string CultureUiId { get; set; }

        [StringLength(512)]
        public virtual string Comment { get; set; }

        [Required()]
        public virtual global::System.DateTime CreatedDate { get; set; }

        public virtual global::System.DateTime? LastModifiedDate { get; set; }

        [StringLength(32)]
        [Required()]
        public virtual string LastLoginIp { get; set; }

        [Required()]
        public virtual global::System.DateTime LastLoginDate { get; set; }

        [Required()]
        public virtual bool IsLockedOut { get; set; }

        [StringLength(512)]
        public virtual string LastLockedOutReason { get; set; }

        [Required()]
        public virtual global::System.DateTime LastLockedOutDate { get; set; }

        [Required()]
        public virtual global::System.DateTime LastPasswordChangedDate { get; set; }

        [Required()]
        public virtual long Version { get; set; }

        [Required()]
        public virtual bool Blocked { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<UserInRole> Roles { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Client Client { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
