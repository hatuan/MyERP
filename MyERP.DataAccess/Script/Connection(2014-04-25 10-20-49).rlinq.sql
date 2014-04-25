-- MyERP.DataAccess.Account
CREATE TABLE "account" (
    "version" int8 NOT NULL,                -- _version
    "status" int2 NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _user2
    "rec_created" timestamp NOT NULL,       -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _user0
    "rec_modified" timestamp NOT NULL,      -- _recCreated
    "parent_account_id" uuid,               -- _parentAccount
    "organization_id" uuid NOT NULL,        -- _organization
    "name" varchar NOT NULL,                -- _name
    "level" int2 NOT NULL,                  -- _level
    "id" uuid NOT NULL,                     -- _id
    "detail" bool NOT NULL,                 -- _detail
    "currency_id" uuid,                     -- _currency
    "code" varchar NOT NULL,                -- _code
    "client_id" uuid NOT NULL,              -- _client
    "ar_ap" bool NOT NULL,                  -- _arAp
    CONSTRAINT "pk_account" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.BusinessPartner
CREATE TABLE "business_partner" (
    "version" int8 NOT NULL,                -- _version
    "vendor_account_id" uuid NOT NULL,      -- _vendorAccount
    "vat_code" varchar NOT NULL,            -- _vatCode
    "telephone" varchar NOT NULL,           -- _telephone
    "status" int2 NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _user2
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _user0
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "payment_term_id" uuid NOT NULL,        -- _paymentTerm
    "organization_id" uuid NOT NULL,        -- _organization
    "name" varchar NOT NULL,                -- _name
    "e_mail" varchar NOT NULL,              -- _mail
    "is_vendor" bool NOT NULL,              -- _isVendor
    "is_employee" bool NOT NULL,            -- _isEmployee
    "is_customer" bool NOT NULL,            -- _isCustomer
    "id" uuid NOT NULL,                     -- _id
    "home_page" varchar NOT NULL,           -- _homePage
    "fax" varchar NOT NULL,                 -- _fax
    "employee_account_id" uuid NOT NULL,    -- _employeeAccount
    "customer_account_id" uuid NOT NULL,    -- _account1
    "credit_limit" numeric(38,20) NOT NULL, -- _creditLimit
    "contact_name" varchar NOT NULL,        -- _contactName
    "comment" varchar NOT NULL,             -- _comment
    "code" varchar NOT NULL,                -- _code
    "client_id" uuid NOT NULL,              -- _client
    "business_partner_group_id3" uuid NOT NULL, -- _businessPartnerGroup3
    "business_partner_group_id2" uuid NOT NULL, -- _businessPartnerGroup2
    "business_partner_group_id1" uuid NOT NULL, -- _businessPartnerGroup1
    "amount_limit" numeric(38,20) NOT NULL, -- _amountLimit
    "address" varchar NOT NULL,             -- _address
    CONSTRAINT "pk_business_partner" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.BusinessPartnerGroup
CREATE TABLE "business_partner_group" (
    "version" int8 NOT NULL,                -- _version
    "status" int2 NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _recModifiedBy
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _recCreatedBy
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "organization_id" uuid NOT NULL,        -- _organization
    "name" varchar NOT NULL,                -- _name
    "level" int2 NOT NULL,                  -- _level
    "id" uuid NOT NULL,                     -- _id
    "code" varchar NOT NULL,                -- _code
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_business_partner_group" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Client
CREATE TABLE "client" (
    "version" int8 NOT NULL,                -- _version
    "rec_created_by" uuid NOT NULL,         -- _user
    "rec_created" timestamp(6) NOT NULL,    -- _recCreated
    "name" varchar NOT NULL,                -- _name
    "is_activated" bool NOT NULL,           -- _isActivated
    "id" uuid NOT NULL,                     -- _id
    CONSTRAINT "pk_client" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Currency
CREATE TABLE "currency" (
    "version" int8 NOT NULL,                -- _version
    "status" int2 NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _user2
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _user0
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "organization_id" uuid NOT NULL,        -- _organization
    "name" varchar NOT NULL,                -- _name
    "id" uuid NOT NULL,                     -- _id
    "code" varchar NOT NULL,                -- _code
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_currency" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.GeneralJournalDocument
CREATE TABLE "general_journal_document" (
    "version" int8 NOT NULL,                -- _version
    "transaction_type" int4 NOT NULL,       -- _transactionType
    "total_debit_amount_lcy" numeric(38,20) NOT NULL, -- _totalDebitAmountLcy
    "total_debit_amount" numeric(38,20) NOT NULL, -- _totalDebitAmount
    "total_credit_amount_lcy" numeric(38,20) NOT NULL, -- _totalCreditAmountLcy
    "total_credit_amount" numeric(38,20) NOT NULL, -- _totalCreditAmount
    "status" int4 NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _userinfo1
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _userinfo
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "organizaion_id" uuid NOT NULL,         -- _organization
    "noseries_id" uuid NOT NULL,            -- _noSeries
    "id" uuid NOT NULL,                     -- _Stt_Rec
    "document_type" varchar NOT NULL,       -- _documentType
    "document_posted_date" date NOT NULL,   -- _documentPosted
    "document_no" varchar NOT NULL,         -- _documentNo
    "document_created_date" date NOT NULL,  -- _documentCreated
    "description" varchar NOT NULL,         -- _description
    "currency_exchange_rate" numeric(38,20) NOT NULL, -- _currencyExchangeRate
    "currency_id" uuid NOT NULL,            -- _dmnt
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_general_journal_document" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.GeneralJournalLine
CREATE TABLE "general_journal_line" (
    "version" int8 NOT NULL,                -- _version
    "transaction_type" int4 NOT NULL,       -- _transactionType
    "general_journal_document_id" uuid NOT NULL, -- _transactionDocument
    "rec_modified_by" uuid NOT NULL,        -- _user1
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _user
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "organization_id" uuid NOT NULL,        -- _organization
    "lineno" int8 NOT NULL,                 -- _lineNo
    "job_id" uuid NOT NULL,                 -- _job
    "id" uuid NOT NULL,                     -- _id
    "document_type" varchar NOT NULL,       -- _documentType
    "document_posted_date" date NOT NULL,   -- _documentPosted
    "document_no" varchar NOT NULL,         -- _documentNo
    "document_created_date" date NOT NULL,  -- _documentCreated
    "description" varchar NOT NULL,         -- _description
    "debit_amount_lcy" numeric(38,20) NOT NULL, -- _debitAmountLcy
    "debit_amount" numeric(38,20) NOT NULL, -- _debitAmount
    "currency_id" uuid NOT NULL,            -- _currencyId
    "currency_exchange_rate" numeric(38,20) NOT NULL, -- _currencyExchangeRate
    "credit_amount_lcy" numeric(38,20) NOT NULL, -- _creditAmountLcy
    "credit_amount" numeric(38,20) NOT NULL, -- _creditAmount
    "cor_account_type" varchar NOT NULL,    -- _corAccountType
    "cor_account_id" uuid NOT NULL,         -- _corAccountId
    "client_id" uuid NOT NULL,              -- _client
    "business_partner_id" uuid NOT NULL,    -- _businessPartner
    "account_type" varchar NOT NULL,        -- _accountType
    "account_id" uuid NOT NULL,             -- _accountId
    CONSTRAINT "pk_general_journal_line" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Job
CREATE TABLE "job" (
    "user_id2" uuid NOT NULL,               -- _userinfo1
    "user_id0" uuid NOT NULL,               -- _userinfo
    "tien_nt" numeric(38,20) NOT NULL,      -- _tien_nt
    "tien" numeric(38,20) NOT NULL,         -- _tien
    "ten_vv2" varchar NOT NULL,             -- _ten_vv2
    "ten_vv" varchar NOT NULL,              -- _ten_vv
    "status" int2 NOT NULL,                 -- _status
    "organization_id" uuid NOT NULL,        -- _organization
    "ngay_vv2" date NOT NULL,               -- _ngay_vv2
    "ngay_vv1" date NOT NULL,               -- _ngay_vv1
    "ma_nt" uuid NOT NULL,                  -- _ma_nt
    "id" uuid NOT NULL,                     -- _id
    "ghi_chu" varchar NOT NULL,             -- _ghi_chu
    "tk" uuid NOT NULL,                     -- _dmtk
    "nh_vv3" varchar NOT NULL,              -- _dmnhvv2
    "nh_vv2" varchar NOT NULL,              -- _dmnhvv1
    "nh_vv1" varchar NOT NULL,              -- _dmnhvv
    "business_partner_id" uuid NOT NULL,    -- _dmkh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "code" varchar NOT NULL,                -- _ma_vv
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_job" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.JobGroup
CREATE TABLE "job_group" (
    "user_id2" uuid NOT NULL,               -- _userinfo1
    "user_id0" uuid NOT NULL,               -- _userinfo
    "ten_nh2" varchar NOT NULL,             -- _ten_nh2
    "ten_nh" varchar NOT NULL,              -- _ten_nh
    "status" int2 NOT NULL,                 -- _status
    "organization_id" uuid NOT NULL,        -- _organization
    "loai_nh" int2 NOT NULL,                -- _loai_nh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "code" varchar NOT NULL,                -- _ma_nh
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_job_group" PRIMARY KEY ("code")
);

-- MyERP.DataAccess.Module
CREATE TABLE "module" (
    "name" varchar NOT NULL,                -- _name
    "id" int8 NOT NULL,                     -- _id
    "group" varchar NOT NULL,               -- _group
    "description" varchar NOT NULL,         -- _description
    "client_id" uuid NOT NULL,              -- _clientId
    CONSTRAINT "pk_mdule" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.NoSeries
CREATE TABLE "no_series" (
    "version" int8 NOT NULL,                -- _version
    "status" int2 NOT NULL,                 -- _status
    "starting_no" int4 NOT NULL,            -- _startingNo
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_modified_by" uuid NOT NULL,        -- _user
    "rec_created_by" uuid NOT NULL,         -- _user1
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "organization_id" uuid NOT NULL,        -- _organization
    "no_seq_name" varchar NOT NULL,         -- _noSeqName
    "name" varchar NOT NULL,                -- _name
    "manual" bool NOT NULL,                 -- _manual
    "is_default" bool NOT NULL,             -- _isDefault
    "id" uuid NOT NULL,                     -- _id
    "format_no" varchar NOT NULL,           -- _formatNo
    "ending_no" int4 NOT NULL,              -- _endingNo
    "current_no" int4 NOT NULL,             -- _currentNo
    "code" varchar(255),                    -- _code
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_no_series" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Organization
CREATE TABLE "organization" (
    "version" int8 NOT NULL,                -- _version
    "status" int2 NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _recModifiedByUser
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _recCreatedByUser
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "name" varchar NOT NULL,                -- _name
    "id" uuid NOT NULL,                     -- _id
    "code" varchar NOT NULL,                -- _code
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_organization" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.PaymentTerm
CREATE TABLE "payment_term" (
    "version" int8 NOT NULL,                -- _version
    "user_id2" uuid NOT NULL,               -- _userId2
    "user_id0" uuid NOT NULL,               -- _userId0
    "status" int2 NOT NULL,                 -- _status
    "pt_gg" numeric(38,20) NOT NULL,        -- _pt_gg
    "organization_id" uuid NOT NULL,        -- _organization
    "name" varchar NOT NULL,                -- _name
    "id" uuid NOT NULL,                     -- _id
    "han_tt_gg" int2 NOT NULL,              -- _han_tt_gg
    "han_tt" int2 NOT NULL,                 -- _han_tt
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "code" varchar NOT NULL,                -- _code
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_payment_term" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Session
CREATE TABLE "session" (
    "working_date" date NOT NULL,           -- _workingDate
    "warehouse_id" uuid,                    -- _warehouseId
    "user_id" uuid NOT NULL,                -- _userId
    "organization_id" uuid,                 -- _organization
    "last_time" timestamp NOT NULL,         -- _lastTime
    "id" uuid NOT NULL,                     -- _id
    "expire" bool,                          -- _expire
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_sessn" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.User
CREATE TABLE "user" (
    "password_question" varchar NOT NULL,   -- _passwordQuestion
    "password_answer" varchar NOT NULL,     -- _passwordAnswer
    "password" varchar NOT NULL,            -- _password
    "organization_id" uuid,                 -- _organization
    "name" varchar NOT NULL,                -- _name
    "last_modified_date" timestamp NOT NULL, -- _lastModifiedDate
    "last_login_ip" varchar NOT NULL,       -- _lastLoginIp
    "last_login_date" timestamp NOT NULL,   -- _lastLoginDate
    "last_locked_out_reason" varchar NOT NULL, -- _lastLockedOutReason
    "last_locked_out_date" timestamp NOT NULL, -- _lastLockedOutDate
    "is_locked_out" bool NOT NULL,          -- _isLockedOut
    "is_activated" bool NOT NULL,           -- _isActivated
    "id" uuid NOT NULL,                     -- _id
    "full_name" varchar NOT NULL,           -- _fullName
    "email" varchar NOT NULL,               -- _email
    "created_date" timestamp NOT NULL,      -- _createdDate
    "comment" varchar NOT NULL,             -- _comment
    "client_id" uuid,                       -- _client
    CONSTRAINT "pk_usr" PRIMARY KEY ("id")
);

CREATE INDEX "idx_account_parent_account_id" ON "account"("parent_account_id");

CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_grp" ON "business_partner"("business_partner_group_id3");

CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr2" ON "business_partner"("business_partner_group_id2");

CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr3" ON "business_partner"("business_partner_group_id1");

CREATE INDEX "idx_gnrl_jrnl_ln_gnrl_jrnl_dcmn" ON "general_journal_line"("general_journal_document_id");

CREATE INDEX "idx_job_nh_vv3" ON "job"("nh_vv3");

CREATE INDEX "idx_job_nh_vv2" ON "job"("nh_vv2");

CREATE INDEX "idx_job_nh_vv1" ON "job"("nh_vv1");

CREATE INDEX "idx_organization_client_id" ON "organization"("client_id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_currency" FOREIGN KEY ("currency_id") REFERENCES "currency"("id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account" FOREIGN KEY ("customer_account_id") REFERENCES "account"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_grp" FOREIGN KEY ("business_partner_group_id1") REFERENCES "business_partner_group"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr2" FOREIGN KEY ("business_partner_group_id2") REFERENCES "business_partner_group"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr3" FOREIGN KEY ("business_partner_group_id3") REFERENCES "business_partner_group"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account2" FOREIGN KEY ("employee_account_id") REFERENCES "account"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsness_partner_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsness_partner_payment_term" FOREIGN KEY ("payment_term_id") REFERENCES "payment_term"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account3" FOREIGN KEY ("vendor_account_id") REFERENCES "account"("id");

ALTER TABLE "business_partner_group" ADD CONSTRAINT "ref_bsness_partner_group_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "business_partner_group" ADD CONSTRAINT "ref_bsnss_prtnr_grp_rganization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jurnal_document_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_document_currency" FOREIGN KEY ("currency_id") REFERENCES "currency"("id");

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_dcument_no_series" FOREIGN KEY ("noseries_id") REFERENCES "no_series"("id");

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_dcmnt_rganization" FOREIGN KEY ("organizaion_id") REFERENCES "organization"("id");

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnral_journal_document_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnral_journal_document_use2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_job" FOREIGN KEY ("job_id") REFERENCES "job"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_line_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_gnrl_jrnl_dcmn" FOREIGN KEY ("general_journal_document_id") REFERENCES "general_journal_document"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_business_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group" FOREIGN KEY ("nh_vv1") REFERENCES "job_group"("code");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group2" FOREIGN KEY ("nh_vv2") REFERENCES "job_group"("code");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group3" FOREIGN KEY ("nh_vv3") REFERENCES "job_group"("code");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_account" FOREIGN KEY ("tk") REFERENCES "account"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "no_series" ADD CONSTRAINT "ref_no_series_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "no_series" ADD CONSTRAINT "ref_no_series_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "no_series" ADD CONSTRAINT "ref_no_series_user" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "no_series" ADD CONSTRAINT "ref_no_series_user2" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "payment_term" ADD CONSTRAINT "ref_payment_term_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "payment_term" ADD CONSTRAINT "ref_payment_term_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

ALTER TABLE "session" ADD CONSTRAINT "ref_session_client" FOREIGN KEY ("client_id") REFERENCES "client"("id");

ALTER TABLE "session" ADD CONSTRAINT "ref_session_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id");

