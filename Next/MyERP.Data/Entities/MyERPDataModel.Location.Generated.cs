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

namespace MyERP.DataAccess
{
    public partial class Location : INotifyPropertyChanging, INotifyPropertyChanged
    {

        public Location()
        {
            OnCreated();
        }

        #region Properties

        [Key]
        [Required()]
        public virtual long Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    this.OnIdChanging(value);
                    OnPropertyChanging("Id");
                    _Id = value;
                    this.OnIdChanged();
                    OnPropertyChanged("Id");
                }
            }
        }
        private long _Id;

        [StringLength(32)]
        [Required()]
        public virtual string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                if (_Code != value)
                {
                    this.OnCodeChanging(value);
                    OnPropertyChanging("Code");
                    _Code = value;
                    this.OnCodeChanged();
                    OnPropertyChanged("Code");
                }
            }
        }
        private string _Code;

        [StringLength(256)]
        [Required()]
        public virtual string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description != value)
                {
                    this.OnDescriptionChanging(value);
                    OnPropertyChanging("Description");
                    _Description = value;
                    this.OnDescriptionChanged();
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _Description;

        [StringLength(32)]
        public virtual string ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                if (_ContactName != value)
                {
                    this.OnContactNameChanging(value);
                    OnPropertyChanging("ContactName");
                    _ContactName = value;
                    this.OnContactNameChanged();
                    OnPropertyChanged("ContactName");
                }
            }
        }
        private string _ContactName;

        [StringLength(256)]
        public virtual string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (_Address != value)
                {
                    this.OnAddressChanging(value);
                    OnPropertyChanging("Address");
                    _Address = value;
                    this.OnAddressChanged();
                    OnPropertyChanged("Address");
                }
            }
        }
        private string _Address;

        [StringLength(32)]
        public virtual string Telephone
        {
            get
            {
                return _Telephone;
            }
            set
            {
                if (_Telephone != value)
                {
                    this.OnTelephoneChanging(value);
                    OnPropertyChanging("Telephone");
                    _Telephone = value;
                    this.OnTelephoneChanged();
                    OnPropertyChanged("Telephone");
                }
            }
        }
        private string _Telephone;

        [StringLength(32)]
        public virtual string Mobiphone
        {
            get
            {
                return _Mobiphone;
            }
            set
            {
                if (_Mobiphone != value)
                {
                    this.OnMobiphoneChanging(value);
                    OnPropertyChanging("Mobiphone");
                    _Mobiphone = value;
                    this.OnMobiphoneChanged();
                    OnPropertyChanged("Mobiphone");
                }
            }
        }
        private string _Mobiphone;

        [StringLength(32)]
        public virtual string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                if (_Fax != value)
                {
                    this.OnFaxChanging(value);
                    OnPropertyChanging("Fax");
                    _Fax = value;
                    this.OnFaxChanged();
                    OnPropertyChanged("Fax");
                }
            }
        }
        private string _Fax;

        [StringLength(32)]
        public virtual string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email != value)
                {
                    this.OnEmailChanging(value);
                    OnPropertyChanging("Email");
                    _Email = value;
                    this.OnEmailChanged();
                    OnPropertyChanged("Email");
                }
            }
        }
        private string _Email;

        [Required()]
        public virtual long OrganizationId
        {
            get
            {
                return _OrganizationId;
            }
            set
            {
                if (_OrganizationId != value)
                {
                    this.OnOrganizationIdChanging(value);
                    OnPropertyChanging("OrganizationId");
                    _OrganizationId = value;
                    this.OnOrganizationIdChanged();
                    OnPropertyChanged("OrganizationId");
                }
            }
        }
        private long _OrganizationId;

        [Required()]
        public virtual long ClientId
        {
            get
            {
                return _ClientId;
            }
            set
            {
                if (_ClientId != value)
                {
                    this.OnClientIdChanging(value);
                    OnPropertyChanging("ClientId");
                    _ClientId = value;
                    this.OnClientIdChanged();
                    OnPropertyChanged("ClientId");
                }
            }
        }
        private long _ClientId;

        [Required()]
        public virtual global::System.DateTime RecCreatedAt
        {
            get
            {
                return _RecCreatedAt;
            }
            set
            {
                if (_RecCreatedAt != value)
                {
                    this.OnRecCreatedAtChanging(value);
                    OnPropertyChanging("RecCreatedAt");
                    _RecCreatedAt = value;
                    this.OnRecCreatedAtChanged();
                    OnPropertyChanged("RecCreatedAt");
                }
            }
        }
        private global::System.DateTime _RecCreatedAt;

        [Required()]
        public virtual long RecCreatedBy
        {
            get
            {
                return _RecCreatedBy;
            }
            set
            {
                if (_RecCreatedBy != value)
                {
                    this.OnRecCreatedByChanging(value);
                    OnPropertyChanging("RecCreatedBy");
                    _RecCreatedBy = value;
                    this.OnRecCreatedByChanged();
                    OnPropertyChanged("RecCreatedBy");
                }
            }
        }
        private long _RecCreatedBy;

        [Required()]
        public virtual global::System.DateTime RecModifiedAt
        {
            get
            {
                return _RecModifiedAt;
            }
            set
            {
                if (_RecModifiedAt != value)
                {
                    this.OnRecModifiedAtChanging(value);
                    OnPropertyChanging("RecModifiedAt");
                    _RecModifiedAt = value;
                    this.OnRecModifiedAtChanged();
                    OnPropertyChanged("RecModifiedAt");
                }
            }
        }
        private global::System.DateTime _RecModifiedAt;

        [Required()]
        public virtual long RecModifiedBy
        {
            get
            {
                return _RecModifiedBy;
            }
            set
            {
                if (_RecModifiedBy != value)
                {
                    this.OnRecModifiedByChanging(value);
                    OnPropertyChanging("RecModifiedBy");
                    _RecModifiedBy = value;
                    this.OnRecModifiedByChanged();
                    OnPropertyChanged("RecModifiedBy");
                }
            }
        }
        private long _RecModifiedBy;

        [Required()]
        public virtual short Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (_Status != value)
                {
                    this.OnStatusChanging(value);
                    OnPropertyChanging("Status");
                    _Status = value;
                    this.OnStatusChanged();
                    OnPropertyChanged("Status");
                }
            }
        }
        private short _Status;

        [Required()]
        public virtual long Version
        {
            get
            {
                return _Version;
            }
            set
            {
                if (_Version != value)
                {
                    this.OnVersionChanging(value);
                    OnPropertyChanging("Version");
                    _Version = value;
                    this.OnVersionChanged();
                    OnPropertyChanged("Version");
                }
            }
        }
        private long _Version;

        #endregion

        #region Navigation Properties

        public virtual Client Client
        {
            get
            {
                return _Client;
            }
            set
            {
                if (_Client != value)
                {
                    this.OnClientChanging(value);
                    OnPropertyChanging("Client");
                    _Client = value;
                    this.OnClientChanged();
                    OnPropertyChanged("Client");
                }
            }
        }
        private Client _Client;
        public virtual Organization Organization
        {
            get
            {
                return _Organization;
            }
            set
            {
                if (_Organization != value)
                {
                    this.OnOrganizationChanging(value);
                    OnPropertyChanging("Organization");
                    _Organization = value;
                    this.OnOrganizationChanged();
                    OnPropertyChanged("Organization");
                }
            }
        }
        private Organization _Organization;
        public virtual User RecCreatedByUser
        {
            get
            {
                return _RecCreatedByUser;
            }
            set
            {
                if (_RecCreatedByUser != value)
                {
                    this.OnRecCreatedByUserChanging(value);
                    OnPropertyChanging("RecCreatedByUser");
                    _RecCreatedByUser = value;
                    this.OnRecCreatedByUserChanged();
                    OnPropertyChanged("RecCreatedByUser");
                }
            }
        }
        private User _RecCreatedByUser;
        public virtual User RecModifiedByUser
        {
            get
            {
                return _RecModifiedByUser;
            }
            set
            {
                if (_RecModifiedByUser != value)
                {
                    this.OnRecModifiedByUserChanging(value);
                    OnPropertyChanging("RecModifiedByUser");
                    _RecModifiedByUser = value;
                    this.OnRecModifiedByUserChanged();
                    OnPropertyChanged("RecModifiedByUser");
                }
            }
        }
        private User _RecModifiedByUser;

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnCodeChanging(string value);
        partial void OnCodeChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnTelephoneChanging(string value);
        partial void OnTelephoneChanged();
        partial void OnMobiphoneChanging(string value);
        partial void OnMobiphoneChanged();
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnOrganizationIdChanging(long value);
        partial void OnOrganizationIdChanged();
        partial void OnClientIdChanging(long value);
        partial void OnClientIdChanged();
        partial void OnRecCreatedAtChanging(global::System.DateTime value);
        partial void OnRecCreatedAtChanged();
        partial void OnRecCreatedByChanging(long value);
        partial void OnRecCreatedByChanged();
        partial void OnRecModifiedAtChanging(global::System.DateTime value);
        partial void OnRecModifiedAtChanged();
        partial void OnRecModifiedByChanging(long value);
        partial void OnRecModifiedByChanged();
        partial void OnStatusChanging(short value);
        partial void OnStatusChanged();
        partial void OnVersionChanging(long value);
        partial void OnVersionChanged();
        partial void OnClientChanging(Client value);
        partial void OnClientChanged();
        partial void OnOrganizationChanging(Organization value);
        partial void OnOrganizationChanged();
        partial void OnRecCreatedByUserChanging(User value);
        partial void OnRecCreatedByUserChanged();
        partial void OnRecModifiedByUserChanging(User value);
        partial void OnRecModifiedByUserChanged();

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanging(string propertyName) {

          if (PropertyChanging != null)
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {

          if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}
