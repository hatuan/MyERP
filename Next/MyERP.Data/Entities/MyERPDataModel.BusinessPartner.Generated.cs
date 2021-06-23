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
    public partial class BusinessPartner : INotifyPropertyChanging, INotifyPropertyChanged
    {

        public BusinessPartner()
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

        public virtual long? BusinessPartnerPriceGroupId
        {
            get
            {
                return _BusinessPartnerPriceGroupId;
            }
            set
            {
                if (_BusinessPartnerPriceGroupId != value)
                {
                    this.OnBusinessPartnerPriceGroupIdChanging(value);
                    OnPropertyChanging("BusinessPartnerPriceGroupId");
                    _BusinessPartnerPriceGroupId = value;
                    this.OnBusinessPartnerPriceGroupIdChanged();
                    OnPropertyChanged("BusinessPartnerPriceGroupId");
                }
            }
        }
        private long? _BusinessPartnerPriceGroupId;

        public virtual long? BusinessPartnerGroupId1
        {
            get
            {
                return _BusinessPartnerGroupId1;
            }
            set
            {
                if (_BusinessPartnerGroupId1 != value)
                {
                    this.OnBusinessPartnerGroupId1Changing(value);
                    OnPropertyChanging("BusinessPartnerGroupId1");
                    _BusinessPartnerGroupId1 = value;
                    this.OnBusinessPartnerGroupId1Changed();
                    OnPropertyChanged("BusinessPartnerGroupId1");
                }
            }
        }
        private long? _BusinessPartnerGroupId1;

        public virtual long? BusinessPartnerGroupId2
        {
            get
            {
                return _BusinessPartnerGroupId2;
            }
            set
            {
                if (_BusinessPartnerGroupId2 != value)
                {
                    this.OnBusinessPartnerGroupId2Changing(value);
                    OnPropertyChanging("BusinessPartnerGroupId2");
                    _BusinessPartnerGroupId2 = value;
                    this.OnBusinessPartnerGroupId2Changed();
                    OnPropertyChanged("BusinessPartnerGroupId2");
                }
            }
        }
        private long? _BusinessPartnerGroupId2;

        public virtual long? BusinessPartnerGroupId3
        {
            get
            {
                return _BusinessPartnerGroupId3;
            }
            set
            {
                if (_BusinessPartnerGroupId3 != value)
                {
                    this.OnBusinessPartnerGroupId3Changing(value);
                    OnPropertyChanging("BusinessPartnerGroupId3");
                    _BusinessPartnerGroupId3 = value;
                    this.OnBusinessPartnerGroupId3Changed();
                    OnPropertyChanged("BusinessPartnerGroupId3");
                }
            }
        }
        private long? _BusinessPartnerGroupId3;

        public virtual long? BusPartnerDiscGroupId
        {
            get
            {
                return _BusPartnerDiscGroupId;
            }
            set
            {
                if (_BusPartnerDiscGroupId != value)
                {
                    this.OnBusPartnerDiscGroupIdChanging(value);
                    OnPropertyChanging("BusPartnerDiscGroupId");
                    _BusPartnerDiscGroupId = value;
                    this.OnBusPartnerDiscGroupIdChanged();
                    OnPropertyChanged("BusPartnerDiscGroupId");
                }
            }
        }
        private long? _BusPartnerDiscGroupId;

        [StringLength(32)]
        public virtual string TaxCode
        {
            get
            {
                return _TaxCode;
            }
            set
            {
                if (_TaxCode != value)
                {
                    this.OnTaxCodeChanging(value);
                    OnPropertyChanging("TaxCode");
                    _TaxCode = value;
                    this.OnTaxCodeChanged();
                    OnPropertyChanged("TaxCode");
                }
            }
        }
        private string _TaxCode;

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

        [StringLength(256)]
        public virtual string AddressTransition
        {
            get
            {
                return _AddressTransition;
            }
            set
            {
                if (_AddressTransition != value)
                {
                    this.OnAddressTransitionChanging(value);
                    OnPropertyChanging("AddressTransition");
                    _AddressTransition = value;
                    this.OnAddressTransitionChanged();
                    OnPropertyChanged("AddressTransition");
                }
            }
        }
        private string _AddressTransition;

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
        public virtual string Mobilephone
        {
            get
            {
                return _Mobilephone;
            }
            set
            {
                if (_Mobilephone != value)
                {
                    this.OnMobilephoneChanging(value);
                    OnPropertyChanging("Mobilephone");
                    _Mobilephone = value;
                    this.OnMobilephoneChanged();
                    OnPropertyChanged("Mobilephone");
                }
            }
        }
        private string _Mobilephone;

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
        public virtual string Mail
        {
            get
            {
                return _Mail;
            }
            set
            {
                if (_Mail != value)
                {
                    this.OnMailChanging(value);
                    OnPropertyChanging("Mail");
                    _Mail = value;
                    this.OnMailChanged();
                    OnPropertyChanged("Mail");
                }
            }
        }
        private string _Mail;

        [StringLength(32)]
        public virtual string Website
        {
            get
            {
                return _Website;
            }
            set
            {
                if (_Website != value)
                {
                    this.OnWebsiteChanging(value);
                    OnPropertyChanging("Website");
                    _Website = value;
                    this.OnWebsiteChanged();
                    OnPropertyChanged("Website");
                }
            }
        }
        private string _Website;

        public virtual bool? IsCustomer
        {
            get
            {
                return _IsCustomer;
            }
            set
            {
                if (_IsCustomer != value)
                {
                    this.OnIsCustomerChanging(value);
                    OnPropertyChanging("IsCustomer");
                    _IsCustomer = value;
                    this.OnIsCustomerChanged();
                    OnPropertyChanged("IsCustomer");
                }
            }
        }
        private bool? _IsCustomer;

        public virtual long? CustomerAccountId
        {
            get
            {
                return _CustomerAccountId;
            }
            set
            {
                if (_CustomerAccountId != value)
                {
                    this.OnCustomerAccountIdChanging(value);
                    OnPropertyChanging("CustomerAccountId");
                    _CustomerAccountId = value;
                    this.OnCustomerAccountIdChanged();
                    OnPropertyChanged("CustomerAccountId");
                }
            }
        }
        private long? _CustomerAccountId;

        public virtual bool? IsVendor
        {
            get
            {
                return _IsVendor;
            }
            set
            {
                if (_IsVendor != value)
                {
                    this.OnIsVendorChanging(value);
                    OnPropertyChanging("IsVendor");
                    _IsVendor = value;
                    this.OnIsVendorChanged();
                    OnPropertyChanged("IsVendor");
                }
            }
        }
        private bool? _IsVendor;

        public virtual long? VendorAccountId
        {
            get
            {
                return _VendorAccountId;
            }
            set
            {
                if (_VendorAccountId != value)
                {
                    this.OnVendorAccountIdChanging(value);
                    OnPropertyChanging("VendorAccountId");
                    _VendorAccountId = value;
                    this.OnVendorAccountIdChanged();
                    OnPropertyChanged("VendorAccountId");
                }
            }
        }
        private long? _VendorAccountId;

        public virtual bool? IsEmployee
        {
            get
            {
                return _IsEmployee;
            }
            set
            {
                if (_IsEmployee != value)
                {
                    this.OnIsEmployeeChanging(value);
                    OnPropertyChanging("IsEmployee");
                    _IsEmployee = value;
                    this.OnIsEmployeeChanged();
                    OnPropertyChanged("IsEmployee");
                }
            }
        }
        private bool? _IsEmployee;

        public virtual long? EmployeeAccountId
        {
            get
            {
                return _EmployeeAccountId;
            }
            set
            {
                if (_EmployeeAccountId != value)
                {
                    this.OnEmployeeAccountIdChanging(value);
                    OnPropertyChanging("EmployeeAccountId");
                    _EmployeeAccountId = value;
                    this.OnEmployeeAccountIdChanged();
                    OnPropertyChanged("EmployeeAccountId");
                }
            }
        }
        private long? _EmployeeAccountId;

        public virtual long? PaymentTermId
        {
            get
            {
                return _PaymentTermId;
            }
            set
            {
                if (_PaymentTermId != value)
                {
                    this.OnPaymentTermIdChanging(value);
                    OnPropertyChanging("PaymentTermId");
                    _PaymentTermId = value;
                    this.OnPaymentTermIdChanged();
                    OnPropertyChanged("PaymentTermId");
                }
            }
        }
        private long? _PaymentTermId;

        [StringLength(32)]
        public virtual string BankAccount
        {
            get
            {
                return _BankAccount;
            }
            set
            {
                if (_BankAccount != value)
                {
                    this.OnBankAccountChanging(value);
                    OnPropertyChanging("BankAccount");
                    _BankAccount = value;
                    this.OnBankAccountChanged();
                    OnPropertyChanged("BankAccount");
                }
            }
        }
        private string _BankAccount;

        [StringLength(256)]
        public virtual string BankName
        {
            get
            {
                return _BankName;
            }
            set
            {
                if (_BankName != value)
                {
                    this.OnBankNameChanging(value);
                    OnPropertyChanging("BankName");
                    _BankName = value;
                    this.OnBankNameChanged();
                    OnPropertyChanged("BankName");
                }
            }
        }
        private string _BankName;

        [StringLength(512)]
        public virtual string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                if (_Comment != value)
                {
                    this.OnCommentChanging(value);
                    OnPropertyChanging("Comment");
                    _Comment = value;
                    this.OnCommentChanged();
                    OnPropertyChanged("Comment");
                }
            }
        }
        private string _Comment;

        /// <summary>
        /// Gioi han tien cong no
        /// </summary>
        public virtual decimal? CreditLimit
        {
            get
            {
                return _CreditLimit;
            }
            set
            {
                if (_CreditLimit != value)
                {
                    this.OnCreditLimitChanging(value);
                    OnPropertyChanging("CreditLimit");
                    _CreditLimit = value;
                    this.OnCreditLimitChanged();
                    OnPropertyChanged("CreditLimit");
                }
            }
        }
        private decimal? _CreditLimit;

        /// <summary>
        /// Gioi han tien hang hoa ... tren hoa don
        /// </summary>
        public virtual decimal? AmountLimit
        {
            get
            {
                return _AmountLimit;
            }
            set
            {
                if (_AmountLimit != value)
                {
                    this.OnAmountLimitChanging(value);
                    OnPropertyChanging("AmountLimit");
                    _AmountLimit = value;
                    this.OnAmountLimitChanged();
                    OnPropertyChanged("AmountLimit");
                }
            }
        }
        private decimal? _AmountLimit;

        public virtual double? GeoLatitude
        {
            get
            {
                return _GeoLatitude;
            }
            set
            {
                if (_GeoLatitude != value)
                {
                    this.OnGeoLatitudeChanging(value);
                    OnPropertyChanging("GeoLatitude");
                    _GeoLatitude = value;
                    this.OnGeoLatitudeChanged();
                    OnPropertyChanged("GeoLatitude");
                }
            }
        }
        private double? _GeoLatitude;

        public virtual double? GeoLongitude
        {
            get
            {
                return _GeoLongitude;
            }
            set
            {
                if (_GeoLongitude != value)
                {
                    this.OnGeoLongitudeChanging(value);
                    OnPropertyChanging("GeoLongitude");
                    _GeoLongitude = value;
                    this.OnGeoLongitudeChanged();
                    OnPropertyChanged("GeoLongitude");
                }
            }
        }
        private double? _GeoLongitude;

        #endregion

        #region Navigation Properties

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
        public virtual BusinessPartnerGroup BusinessPartnerGroup1
        {
            get
            {
                return _BusinessPartnerGroup1;
            }
            set
            {
                if (_BusinessPartnerGroup1 != value)
                {
                    this.OnBusinessPartnerGroup1Changing(value);
                    OnPropertyChanging("BusinessPartnerGroup1");
                    _BusinessPartnerGroup1 = value;
                    this.OnBusinessPartnerGroup1Changed();
                    OnPropertyChanged("BusinessPartnerGroup1");
                }
            }
        }
        private BusinessPartnerGroup _BusinessPartnerGroup1;
        public virtual BusinessPartnerGroup BusinessPartnerGroup2
        {
            get
            {
                return _BusinessPartnerGroup2;
            }
            set
            {
                if (_BusinessPartnerGroup2 != value)
                {
                    this.OnBusinessPartnerGroup2Changing(value);
                    OnPropertyChanging("BusinessPartnerGroup2");
                    _BusinessPartnerGroup2 = value;
                    this.OnBusinessPartnerGroup2Changed();
                    OnPropertyChanged("BusinessPartnerGroup2");
                }
            }
        }
        private BusinessPartnerGroup _BusinessPartnerGroup2;
        public virtual BusinessPartnerGroup BusinessPartnerGroup3
        {
            get
            {
                return _BusinessPartnerGroup3;
            }
            set
            {
                if (_BusinessPartnerGroup3 != value)
                {
                    this.OnBusinessPartnerGroup3Changing(value);
                    OnPropertyChanging("BusinessPartnerGroup3");
                    _BusinessPartnerGroup3 = value;
                    this.OnBusinessPartnerGroup3Changed();
                    OnPropertyChanged("BusinessPartnerGroup3");
                }
            }
        }
        private BusinessPartnerGroup _BusinessPartnerGroup3;
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
        public virtual BusinessPartnerPriceGroup BusinessPartnerPriceGroup
        {
            get
            {
                return _BusinessPartnerPriceGroup;
            }
            set
            {
                if (_BusinessPartnerPriceGroup != value)
                {
                    this.OnBusinessPartnerPriceGroupChanging(value);
                    OnPropertyChanging("BusinessPartnerPriceGroup");
                    _BusinessPartnerPriceGroup = value;
                    this.OnBusinessPartnerPriceGroupChanged();
                    OnPropertyChanged("BusinessPartnerPriceGroup");
                }
            }
        }
        private BusinessPartnerPriceGroup _BusinessPartnerPriceGroup;
        public virtual BusinessPartnerDiscGroup BusPartnerDiscGroup
        {
            get
            {
                return _BusPartnerDiscGroup;
            }
            set
            {
                if (_BusPartnerDiscGroup != value)
                {
                    this.OnBusPartnerDiscGroupChanging(value);
                    OnPropertyChanging("BusPartnerDiscGroup");
                    _BusPartnerDiscGroup = value;
                    this.OnBusPartnerDiscGroupChanged();
                    OnPropertyChanged("BusPartnerDiscGroup");
                }
            }
        }
        private BusinessPartnerDiscGroup _BusPartnerDiscGroup;

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        partial void OnCodeChanging(string value);
        partial void OnCodeChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
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
        partial void OnStatusChanging(MyERP.DataAccess.Enum.DefaultMasterStatusType value);
        partial void OnStatusChanged();
        partial void OnVersionChanging(long value);
        partial void OnVersionChanged();
        partial void OnBusinessPartnerPriceGroupIdChanging(long? value);
        partial void OnBusinessPartnerPriceGroupIdChanged();
        partial void OnBusinessPartnerGroupId1Changing(long? value);
        partial void OnBusinessPartnerGroupId1Changed();
        partial void OnBusinessPartnerGroupId2Changing(long? value);
        partial void OnBusinessPartnerGroupId2Changed();
        partial void OnBusinessPartnerGroupId3Changing(long? value);
        partial void OnBusinessPartnerGroupId3Changed();
        partial void OnBusPartnerDiscGroupIdChanging(long? value);
        partial void OnBusPartnerDiscGroupIdChanged();
        partial void OnTaxCodeChanging(string value);
        partial void OnTaxCodeChanged();
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnAddressTransitionChanging(string value);
        partial void OnAddressTransitionChanged();
        partial void OnTelephoneChanging(string value);
        partial void OnTelephoneChanged();
        partial void OnMobilephoneChanging(string value);
        partial void OnMobilephoneChanged();
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        partial void OnMailChanging(string value);
        partial void OnMailChanged();
        partial void OnWebsiteChanging(string value);
        partial void OnWebsiteChanged();
        partial void OnIsCustomerChanging(bool? value);
        partial void OnIsCustomerChanged();
        partial void OnCustomerAccountIdChanging(long? value);
        partial void OnCustomerAccountIdChanged();
        partial void OnIsVendorChanging(bool? value);
        partial void OnIsVendorChanged();
        partial void OnVendorAccountIdChanging(long? value);
        partial void OnVendorAccountIdChanged();
        partial void OnIsEmployeeChanging(bool? value);
        partial void OnIsEmployeeChanged();
        partial void OnEmployeeAccountIdChanging(long? value);
        partial void OnEmployeeAccountIdChanged();
        partial void OnPaymentTermIdChanging(long? value);
        partial void OnPaymentTermIdChanged();
        partial void OnBankAccountChanging(string value);
        partial void OnBankAccountChanged();
        partial void OnBankNameChanging(string value);
        partial void OnBankNameChanged();
        partial void OnCommentChanging(string value);
        partial void OnCommentChanged();
        partial void OnCreditLimitChanging(decimal? value);
        partial void OnCreditLimitChanged();
        partial void OnAmountLimitChanging(decimal? value);
        partial void OnAmountLimitChanged();
        partial void OnGeoLatitudeChanging(double? value);
        partial void OnGeoLatitudeChanged();
        partial void OnGeoLongitudeChanging(double? value);
        partial void OnGeoLongitudeChanged();
        partial void OnRecCreatedByUserChanging(User value);
        partial void OnRecCreatedByUserChanged();
        partial void OnRecModifiedByUserChanging(User value);
        partial void OnRecModifiedByUserChanged();
        partial void OnBusinessPartnerGroup1Changing(BusinessPartnerGroup value);
        partial void OnBusinessPartnerGroup1Changed();
        partial void OnBusinessPartnerGroup2Changing(BusinessPartnerGroup value);
        partial void OnBusinessPartnerGroup2Changed();
        partial void OnBusinessPartnerGroup3Changing(BusinessPartnerGroup value);
        partial void OnBusinessPartnerGroup3Changed();
        partial void OnClientChanging(Client value);
        partial void OnClientChanged();
        partial void OnOrganizationChanging(Organization value);
        partial void OnOrganizationChanged();
        partial void OnBusinessPartnerPriceGroupChanging(BusinessPartnerPriceGroup value);
        partial void OnBusinessPartnerPriceGroupChanged();
        partial void OnBusPartnerDiscGroupChanging(BusinessPartnerDiscGroup value);
        partial void OnBusPartnerDiscGroupChanged();

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
