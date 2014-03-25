-- MyERP.DataAccess.Account
CREATE TABLE "account" (
    "version" int8 NOT NULL,                -- _version
    "status" text NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _user2
    "rec_created" timestamp NOT NULL,       -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _user0
    "rec_modified" timestamp NOT NULL,      -- _recCreated
    "parent_account_id" uuid,               -- _parentAccount
    "name" text NOT NULL,                   -- _name
    "level" int2 NOT NULL,                  -- _level
    "id" uuid NOT NULL,                     -- _id
    "detail" bool NOT NULL,                 -- _detail
    "currency_id" uuid NOT NULL,            -- _currency
    "code" text NOT NULL,                   -- _code
    "ar_ap" bool NOT NULL,                  -- _arAp
    CONSTRAINT "pk_account" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.BusinessPartner
CREATE TABLE "business_partner" (
    "version" int8 NOT NULL,                -- _version
    "vendor_account_id" uuid NOT NULL,      -- _vendorAccount
    "vat_code" text NOT NULL,               -- _vatCode
    "user_id2" uuid NOT NULL,               -- _user2
    "user_id0" uuid NOT NULL,               -- _user0
    "telephone" text NOT NULL,              -- _telephone
    "rowguid" uuid NOT NULL,                -- _rowguid
    "payment_term_code" text NOT NULL,      -- _paymentTerm
    "name" text NOT NULL,                   -- _name
    "e_mail" text NOT NULL,                 -- _mail
    "is_vendor" bool NOT NULL,              -- _isVendor
    "is_employee" bool NOT NULL,            -- _isEmployee
    "is_customer" bool NOT NULL,            -- _isCustomer
    "home_page" text NOT NULL,              -- _homePage
    "fax" text NOT NULL,                    -- _fax
    "employee_account_id" uuid NOT NULL,    -- _employeeAccount
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "customer_account_id" uuid NOT NULL,    -- _account1
    "credit_limit" numeric(38,20) NOT NULL, -- _creditLimit
    "contact_name" text NOT NULL,           -- _contactName
    "comment" text NOT NULL,                -- _comment
    "code" text NOT NULL,                   -- _code
    "business_partner_group3" text NOT NULL, -- _businessPartnerGroup3
    "business_partner_group2" text NOT NULL, -- _businessPartnerGroup2
    "business_partner_group1" text NOT NULL, -- _businessPartnerGroup1
    "amount_limit" numeric(38,20) NOT NULL, -- _amountLimit
    "address" text NOT NULL,                -- _address
    CONSTRAINT "pk_business_partner" PRIMARY KEY ("code")
);

-- MyERP.DataAccess.BusinessPartnerGroup
CREATE TABLE "business_partner_group" (
    "version" int8 NOT NULL,                -- _version
    "user_id2" uuid NOT NULL,               -- _userId2
    "user_id0" uuid NOT NULL,               -- _userId0
    "status" text NOT NULL,                 -- _status
    "rowguid" uuid NOT NULL,                -- _rowguid
    "name" text NOT NULL,                   -- _name
    "level" int2 NOT NULL,                  -- _level
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "code" text NOT NULL,                   -- _code
    CONSTRAINT "pk_business_partner_group" PRIMARY KEY ("code")
);

-- MyERP.DataAccess.Currency
CREATE TABLE "currency" (
    "version" int8 NOT NULL,                -- _version
    "status" text NOT NULL,                 -- _status
    "rec_modified_by" uuid NOT NULL,        -- _user2
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_created_by" uuid NOT NULL,         -- _user0
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "name" text NOT NULL,                   -- _name
    "id" uuid NOT NULL,                     -- _id
    "code" text NOT NULL,                   -- _code
    CONSTRAINT "pk_currency" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Job
CREATE TABLE "job" (
    "user_id2" uuid NOT NULL,               -- _userinfo1
    "user_id0" uuid NOT NULL,               -- _userinfo
    "tien_nt" numeric(38,20) NOT NULL,      -- _tien_nt
    "tien" numeric(38,20) NOT NULL,         -- _tien
    "ten_vv2" text NOT NULL,                -- _ten_vv2
    "ten_vv" text NOT NULL,                 -- _ten_vv
    "status" text NOT NULL,                 -- _status
    "ngay_vv2" date NOT NULL,               -- _ngay_vv2
    "ngay_vv1" date NOT NULL,               -- _ngay_vv1
    "ma_vv" text NOT NULL,                  -- _ma_vv
    "ma_nt" uuid NOT NULL,                  -- _ma_nt
    "ghi_chu" text NOT NULL,                -- _ghi_chu
    "tk" uuid NOT NULL,                     -- _dmtk
    "nh_vv3" text NOT NULL,                 -- _dmnhvv2
    "nh_vv2" text NOT NULL,                 -- _dmnhvv1
    "nh_vv1" text NOT NULL,                 -- _dmnhvv
    "ma_kh" text NOT NULL,                  -- _dmkh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_job" PRIMARY KEY ("ma_vv")
);

-- MyERP.DataAccess.JobGroup
CREATE TABLE "job_group" (
    "user_id2" uuid NOT NULL,               -- _userinfo1
    "user_id0" uuid NOT NULL,               -- _userinfo
    "ten_nh2" text NOT NULL,                -- _ten_nh2
    "ten_nh" text NOT NULL,                 -- _ten_nh
    "status" text NOT NULL,                 -- _status
    "ma_nh" text NOT NULL,                  -- _ma_nh
    "loai_nh" int2 NOT NULL,                -- _loai_nh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_job_group" PRIMARY KEY ("ma_nh")
);

-- MyERP.DataAccess.Module
CREATE TABLE "module" (
    "name" text NOT NULL,                   -- _name
    "id" int8 NOT NULL,                     -- _id
    "group" text NOT NULL,                  -- _group
    "description" text NOT NULL,            -- _description
    CONSTRAINT "pk_mdule" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Organization
CREATE TABLE "organization" (
    "version" int8 NOT NULL,                -- _version
    "user_id2" uuid NOT NULL,               -- _user2
    "user_id0" uuid NOT NULL,               -- _user0
    "status" text NOT NULL,                 -- _status
    "rowguid" uuid NOT NULL,                -- _rowguid
    "name" text NOT NULL,                   -- _name
    "m_ws_id" text NOT NULL,                -- _m_ws_id
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "code" text NOT NULL,                   -- _code
    CONSTRAINT "pk_organization" PRIMARY KEY ("code")
);

-- MyERP.DataAccess.PaymentTerm
CREATE TABLE "payment_term" (
    "version" int8 NOT NULL,                -- _version
    "user_id2" uuid NOT NULL,               -- _userId2
    "user_id0" uuid NOT NULL,               -- _userId0
    "status" text NOT NULL,                 -- _status
    "rowguid" uuid NOT NULL,                -- _rowguid
    "pt_gg" numeric(38,20) NOT NULL,        -- _pt_gg
    "name" text NOT NULL,                   -- _name
    "han_tt_gg" int2 NOT NULL,              -- _han_tt_gg
    "han_tt" int2 NOT NULL,                 -- _han_tt
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "code" text NOT NULL,                   -- _code
    CONSTRAINT "pk_payment_term" PRIMARY KEY ("code")
);

-- MyERP.DataAccess.TransactionType
CREATE TABLE "transaction_code" (
    "user_id2" int8 NOT NULL,               -- _user_id2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "ten_ct2" text NOT NULL,                -- _ten_ct2
    "ten_ct" text NOT NULL,                 -- _ten_ct
    "stt_ctntxt" int2 NOT NULL,             -- _stt_ctntxt
    "stt_ct_nkc" int2 NOT NULL,             -- _stt_ct_nkc
    "so_ct" int8 NOT NULL,                  -- _so_ct
    "ma_phan_he" text NOT NULL,             -- _ma_phan_he
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "ma_ct_me" text NOT NULL,               -- _ma_ct_me
    "ma_ct_in" text NOT NULL,               -- _ma_ct_in
    "ma_ct" text NOT NULL,                  -- _ma_ct
    "m_trung_so" int2 NOT NULL,             -- _m_trung_so
    "m_status" text NOT NULL,               -- _m_status
    "m_ngay_ct" int2 NOT NULL,              -- _m_ngay_ct
    "m_ma_nk" text NOT NULL,                -- _m_ma_nk
    "m_ma_gd" text NOT NULL,                -- _m_ma_gd
    "m_loc_nsd" int2 NOT NULL,              -- _m_loc_nsd
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "ct_nxt" int2 NOT NULL,                 -- _ct_nxt
    CONSTRAINT "pk_transaction_code" PRIMARY KEY ("ma_ct")
);

-- MyERP.DataAccess.TransactionDocument
CREATE TABLE "transaction_document" (
    "user_id2" uuid NOT NULL,               -- _userinfo1
    "user_id0" uuid NOT NULL,               -- _userinfo
    "ty_gia" numeric(38,20) NOT NULL,       -- _Ty_Gia
    "t_ps_no_nt" numeric(38,20) NOT NULL,   -- _T_Ps_No_Nt
    "t_ps_no" numeric(38,20) NOT NULL,      -- _T_Ps_No
    "t_ps_co_nt" numeric(38,20) NOT NULL,   -- _T_Ps_Co_Nt
    "stt_rec" text NOT NULL,                -- _Stt_Rec
    "status" text NOT NULL,                 -- _Status
    "so_lo" text NOT NULL,                  -- _So_Lo
    "so_ct" text NOT NULL,                  -- _So_Ct
    "ma_dvcs" text NOT NULL,                -- _dmdvcs
    "ngay_lo" date NOT NULL,                -- _Ngay_Lo
    "ngay_lct" date NOT NULL,               -- _Ngay_Lct
    "ngay_ct" date NOT NULL,                -- _Ngay_Ct
    "ma_nk" text NOT NULL,                  -- _Ma_Nk
    "ma_gd" int2 NOT NULL,                  -- _Ma_Gd
    "ma_ct" text NOT NULL,                  -- _Ma_Ct
    "date2" timestamp NOT NULL,             -- _Date2
    "date0" timestamp NOT NULL,             -- _Date0
    "ma_nt" uuid NOT NULL,                  -- _dmnt
    CONSTRAINT "pk_transaction_document" PRIMARY KEY ("stt_rec")
);

-- MyERP.DataAccess.TransactionLine
CREATE TABLE "transaction_line" (
    "tk_i" text NOT NULL,                   -- _tk_i
    "stt_rec" text NOT NULL,                -- _stt_rec
    "so_ct" text NOT NULL,                  -- _so_ct
    "ps_no_nt" numeric(38,20) NOT NULL,     -- _ps_no_nt
    "ps_no" numeric(38,20) NOT NULL,        -- _ps_no
    "ps_co_nt" numeric(38,20) NOT NULL,     -- _ps_co_nt
    "ps_co" numeric(38,20) NOT NULL,        -- _ps_co
    "nh_dk" text NOT NULL,                  -- _nh_dk
    "ngay_ct" date NOT NULL,                -- _ngay_ct
    "ma_td_i" text NOT NULL,                -- _ma_td_i
    "ma_ku" text NOT NULL,                  -- _ma_ku
    "ma_ct" text NOT NULL,                  -- _ma_ct
    "ln" int8 NOT NULL,                     -- _ln
    "ma_vv_i" text NOT NULL,                -- _dmvv
    "dien_giaii" text NOT NULL,             -- _dien_giaii
    "ma_kh_i" text NOT NULL,                -- _dmkh
    CONSTRAINT "pk_transaction_line" PRIMARY KEY ("ln", "stt_rec")
);

-- MyERP.DataAccess.User
CREATE TABLE "user" (
    "status" text NOT NULL,                 -- _status
    "r_search" text NOT NULL,               -- _r_search
    "r_read" text NOT NULL,                 -- _r_read
    "r_print" text NOT NULL,                -- _r_print
    "r_edit" text NOT NULL,                 -- _r_edit
    "r_del" text NOT NULL,                  -- _rightDel
    "r_add" text NOT NULL,                  -- _rightAdd
    "r_access" text NOT NULL,               -- _rightAccess
    "password" text NOT NULL,               -- _password
    "login_name" text NOT NULL,             -- _loginName
    "id" uuid NOT NULL,                     -- _id
    "display_name" text NOT NULL,           -- _displayName
    "comment" text NOT NULL,                -- _comment
    "administrator" bool NOT NULL,          -- _administrator
    CONSTRAINT "pk_usr" PRIMARY KEY ("id")
);

CREATE INDEX "idx_account_parent_account_id" ON "account"("parent_account_id");

CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_grp" ON "business_partner"("business_partner_group3");

CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr2" ON "business_partner"("business_partner_group2");

CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr3" ON "business_partner"("business_partner_group1");

CREATE INDEX "idx_job_nh_vv3" ON "job"("nh_vv3");

CREATE INDEX "idx_job_nh_vv2" ON "job"("nh_vv2");

CREATE INDEX "idx_job_nh_vv1" ON "job"("nh_vv1");

CREATE INDEX "idx_transaction_line_stt_rec" ON "transaction_line"("stt_rec");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_currency" FOREIGN KEY ("currency_id") REFERENCES "currency"("id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account" FOREIGN KEY ("customer_account_id") REFERENCES "account"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_grp" FOREIGN KEY ("business_partner_group1") REFERENCES "business_partner_group"("code");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr2" FOREIGN KEY ("business_partner_group2") REFERENCES "business_partner_group"("code");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr3" FOREIGN KEY ("business_partner_group3") REFERENCES "business_partner_group"("code");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account2" FOREIGN KEY ("employee_account_id") REFERENCES "account"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsness_partner_payment_term" FOREIGN KEY ("payment_term_code") REFERENCES "payment_term"("code");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account3" FOREIGN KEY ("vendor_account_id") REFERENCES "account"("id");

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id");

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_business_partner" FOREIGN KEY ("ma_kh") REFERENCES "business_partner"("code");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group" FOREIGN KEY ("nh_vv1") REFERENCES "job_group"("ma_nh");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group2" FOREIGN KEY ("nh_vv2") REFERENCES "job_group"("ma_nh");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group3" FOREIGN KEY ("nh_vv3") REFERENCES "job_group"("ma_nh");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_account" FOREIGN KEY ("tk") REFERENCES "account"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_trnsctn_dcment_organization" FOREIGN KEY ("ma_dvcs") REFERENCES "organization"("code");

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_trnsction_document_currency" FOREIGN KEY ("ma_nt") REFERENCES "currency"("id");

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_transaction_document_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id");

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_transaction_document_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id");

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_trnsctn_ln_business_partner" FOREIGN KEY ("ma_kh_i") REFERENCES "business_partner"("code");

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_transaction_line_job" FOREIGN KEY ("ma_vv_i") REFERENCES "job"("ma_vv");

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_trnsctn_ln_trnsctn_document" FOREIGN KEY ("stt_rec") REFERENCES "transaction_document"("stt_rec");

