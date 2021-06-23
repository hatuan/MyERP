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
    public partial class NoSequence : INotifyPropertyChanging, INotifyPropertyChanged
    {

        public NoSequence()
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

        [Required()]
        public virtual byte DefaultNo
        {
            get
            {
                return _DefaultNo;
            }
            set
            {
                if (_DefaultNo != value)
                {
                    this.OnDefaultNoChanging(value);
                    OnPropertyChanging("DefaultNo");
                    _DefaultNo = value;
                    this.OnDefaultNoChanged();
                    OnPropertyChanged("DefaultNo");
                }
            }
        }
        private byte _DefaultNo;

        [Required()]
        public virtual byte ManualNo
        {
            get
            {
                return _ManualNo;
            }
            set
            {
                if (_ManualNo != value)
                {
                    this.OnManualNoChanging(value);
                    OnPropertyChanging("ManualNo");
                    _ManualNo = value;
                    this.OnManualNoChanged();
                    OnPropertyChanged("ManualNo");
                }
            }
        }
        private byte _ManualNo;

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
        public virtual MyERP.DataAccess.Enum.DefaultMasterStatusType Status
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
        private MyERP.DataAccess.Enum.DefaultMasterStatusType _Status;

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

        #endregion

        #region Navigation Properties

        public virtual ICollection<NoSequenceLine> NoSequenceLines { get; set; }
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
        partial void OnDefaultNoChanging(byte value);
        partial void OnDefaultNoChanged();
        partial void OnManualNoChanging(byte value);
        partial void OnManualNoChanged();
        partial void OnClientIdChanging(long value);
        partial void OnClientIdChanged();
        partial void OnOrganizationIdChanging(long value);
        partial void OnOrganizationIdChanged();
        partial void OnStatusChanging(MyERP.DataAccess.Enum.DefaultMasterStatusType value);
        partial void OnStatusChanged();
        partial void OnVersionChanging(long value);
        partial void OnVersionChanged();
        partial void OnRecCreatedByChanging(long value);
        partial void OnRecCreatedByChanged();
        partial void OnRecCreatedAtChanging(global::System.DateTime value);
        partial void OnRecCreatedAtChanged();
        partial void OnRecModifiedByChanging(long value);
        partial void OnRecModifiedByChanged();
        partial void OnRecModifiedAtChanging(global::System.DateTime value);
        partial void OnRecModifiedAtChanged();
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
