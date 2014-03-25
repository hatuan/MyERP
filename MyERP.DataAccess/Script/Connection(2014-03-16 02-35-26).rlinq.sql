-- MyERP.DataAccess.Job
CREATE TABLE "Job" (
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "ma_kh" text NOT NULL,                  -- _dmkh
    "nh_vv1" text NOT NULL,                 -- _dmnhvv
    "nh_vv2" text NOT NULL,                 -- _dmnhvv1
    "nh_vv3" text NOT NULL,                 -- _dmnhvv2
    "tk" text NOT NULL,                     -- _dmtk
    "ghi_chu" text NOT NULL,                -- _ghi_chu
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "ma_vv" text NOT NULL,                  -- _ma_vv
    "ngay_vv1" date NOT NULL,               -- _ngay_vv1
    "ngay_vv2" date NOT NULL,               -- _ngay_vv2
    "status" text NOT NULL,                 -- _status
    "ten_vv" text NOT NULL,                 -- _ten_vv
    "ten_vv2" text NOT NULL,                -- _ten_vv2
    "tien" numeric(38,20) NOT NULL,         -- _tien
    "tien_nt" numeric(38,20) NOT NULL,      -- _tien_nt
    "user_id0" int8 NOT NULL,               -- _userinfo
    "user_id2" int8 NOT NULL,               -- _userinfo1
    CONSTRAINT "pk_Job" PRIMARY KEY ("ma_vv")
)
;

-- MyERP.DataAccess.Account
CREATE TABLE "account" (
    "account_type" int2 NOT NULL,           -- _accountType
    "code" text NOT NULL,                   -- _code
    "currency_code" text NOT NULL,          -- _currency
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "debt_account" int2 NOT NULL,           -- _debtAccount
    "level" int2 NOT NULL,                  -- _level
    "master_account" int2 NOT NULL,         -- _masterAccount
    "name" text NOT NULL,                   -- _name
    "parent_account" text NOT NULL,         -- _parentAccount
    "rowguid" uuid NOT NULL,                -- _rowguid
    "status" text NOT NULL,                 -- _status
    "user_id0" int8 NOT NULL,               -- _user0
    "user_id2" int8 NOT NULL,               -- _user2
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_account" PRIMARY KEY ("code")
)
;

-- MyERP.DataAccess.BusinessPartner
CREATE TABLE "business_partner" (
    "address" text NOT NULL,                -- _address
    "amount_limit" numeric(38,20) NOT NULL, -- _amountLimit
    "business_partner_group1" text NOT NULL, -- _businessPartnerGroup1
    "business_partner_group2" text NOT NULL, -- _businessPartnerGroup2
    "business_partner_group3" text NOT NULL, -- _businessPartnerGroup3
    "code" text NOT NULL,                   -- _code
    "comment" text NOT NULL,                -- _comment
    "contact_name" text NOT NULL,           -- _contactName
    "credit_limit" numeric(38,20) NOT NULL, -- _creditLimit
    "customer_account_code" text NOT NULL,  -- _account1
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "employee_account_code" text NOT NULL,  -- _employeeAccount
    "fax" text NOT NULL,                    -- _fax
    "home_page" text NOT NULL,              -- _homePage
    "is_customer" bool NOT NULL,            -- _isCustomer
    "is_employee" bool NOT NULL,            -- _isEmployee
    "is_vendor" bool NOT NULL,              -- _isVendor
    "e_mail" text NOT NULL,                 -- _mail
    "name" text NOT NULL,                   -- _name
    "payment_term_code" text NOT NULL,      -- _paymentTerm
    "rowguid" uuid NOT NULL,                -- _rowguid
    "telephone" text NOT NULL,              -- _telephone
    "user_id0" int8 NOT NULL,               -- _user0
    "user_id2" int8 NOT NULL,               -- _user2
    "vat_code" text NOT NULL,               -- _vatCode
    "vendor_account_code" text NOT NULL,    -- _vendorAccount
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_business_partner" PRIMARY KEY ("code")
)
;

-- MyERP.DataAccess.BusinessPartnerGroup
CREATE TABLE "business_partner_group" (
    "code" text NOT NULL,                   -- _code
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "level" int2 NOT NULL,                  -- _level
    "name" text NOT NULL,                   -- _name
    "rowguid" uuid NOT NULL,                -- _rowguid
    "status" text NOT NULL,                 -- _status
    "user_id0" int8 NOT NULL,               -- _userId0
    "user_id2" int8 NOT NULL,               -- _userId2
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_business_partner_group" PRIMARY KEY ("code")
)
;

-- MyERP.DataAccess.Currency
CREATE TABLE "currency" (
    "code" text NOT NULL,                   -- _code
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "name" text NOT NULL,                   -- _name
    "rowguid" uuid NOT NULL,                -- _rowguid
    "status" text NOT NULL,                 -- _status
    "user_id0" int8 NOT NULL,               -- _user0
    "user_id2" int8 NOT NULL,               -- _user2
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_currency" PRIMARY KEY ("code")
)
;

-- MyERP.DataAccess.JobGroup
CREATE TABLE "job_group" (
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "loai_nh" int2 NOT NULL,                -- _loai_nh
    "ma_nh" text NOT NULL,                  -- _ma_nh
    "status" text NOT NULL,                 -- _status
    "ten_nh" text NOT NULL,                 -- _ten_nh
    "ten_nh2" text NOT NULL,                -- _ten_nh2
    "user_id0" int8 NOT NULL,               -- _userinfo
    "user_id2" int8 NOT NULL,               -- _userinfo1
    CONSTRAINT "pk_job_group" PRIMARY KEY ("ma_nh")
)
;

-- MyERP.DataAccess.Organization
CREATE TABLE "organization" (
    "code" text NOT NULL,                   -- _code
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "m_ws_id" text NOT NULL,                -- _m_ws_id
    "name" text NOT NULL,                   -- _name
    "rowguid" uuid NOT NULL,                -- _rowguid
    "status" text NOT NULL,                 -- _status
    "user_id0" int8 NOT NULL,               -- _user0
    "user_id2" int8 NOT NULL,               -- _user2
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_organization" PRIMARY KEY ("code")
)
;

-- MyERP.DataAccess.PaymentTerm
CREATE TABLE "payment_term" (
    "code" text NOT NULL,                   -- _code
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "han_tt" int2 NOT NULL,                 -- _han_tt
    "han_tt_gg" int2 NOT NULL,              -- _han_tt_gg
    "name" text NOT NULL,                   -- _name
    "pt_gg" numeric(38,20) NOT NULL,        -- _pt_gg
    "rowguid" uuid NOT NULL,                -- _rowguid
    "status" text NOT NULL,                 -- _status
    "user_id0" int8 NOT NULL,               -- _userId0
    "user_id2" int8 NOT NULL,               -- _userId2
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_payment_term" PRIMARY KEY ("code")
)
;

-- MyERP.DataAccess.TransactionType
CREATE TABLE "transaction_code" (
    "ct_nxt" int2 NOT NULL,                 -- _ct_nxt
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "m_loc_nsd" int2 NOT NULL,              -- _m_loc_nsd
    "m_ma_gd" text NOT NULL,                -- _m_ma_gd
    "m_ma_nk" text NOT NULL,                -- _m_ma_nk
    "m_ngay_ct" int2 NOT NULL,              -- _m_ngay_ct
    "m_status" text NOT NULL,               -- _m_status
    "m_trung_so" int2 NOT NULL,             -- _m_trung_so
    "ma_ct" text NOT NULL,                  -- _ma_ct
    "ma_ct_in" text NOT NULL,               -- _ma_ct_in
    "ma_ct_me" text NOT NULL,               -- _ma_ct_me
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "ma_phan_he" text NOT NULL,             -- _ma_phan_he
    "so_ct" int8 NOT NULL,                  -- _so_ct
    "stt_ct_nkc" int2 NOT NULL,             -- _stt_ct_nkc
    "stt_ctntxt" int2 NOT NULL,             -- _stt_ctntxt
    "ten_ct" text NOT NULL,                 -- _ten_ct
    "ten_ct2" text NOT NULL,                -- _ten_ct2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "user_id2" int8 NOT NULL,               -- _user_id2
    CONSTRAINT "pk_transaction_code" PRIMARY KEY ("ma_ct")
)
;

-- MyERP.DataAccess.TransactionDocument
CREATE TABLE "transaction_document" (
    "date0" timestamp NOT NULL,             -- _Date0
    "date2" timestamp NOT NULL,             -- _Date2
    "ma_nt" text NOT NULL,                  -- _dmnt
    "ma_ct" text NOT NULL,                  -- _Ma_Ct
    "ma_gd" int2 NOT NULL,                  -- _Ma_Gd
    "ma_nk" text NOT NULL,                  -- _Ma_Nk
    "ngay_ct" date NOT NULL,                -- _Ngay_Ct
    "ngay_lct" date NOT NULL,               -- _Ngay_Lct
    "ngay_lo" date NOT NULL,                -- _Ngay_Lo
    "ma_dvcs" text NOT NULL,                -- _dmdvcs
    "so_ct" text NOT NULL,                  -- _So_Ct
    "so_lo" text NOT NULL,                  -- _So_Lo
    "status" text NOT NULL,                 -- _Status
    "stt_rec" text NOT NULL,                -- _Stt_Rec
    "t_ps_co_nt" numeric(38,20) NOT NULL,   -- _T_Ps_Co_Nt
    "t_ps_no" numeric(38,20) NOT NULL,      -- _T_Ps_No
    "t_ps_no_nt" numeric(38,20) NOT NULL,   -- _T_Ps_No_Nt
    "ty_gia" numeric(38,20) NOT NULL,       -- _Ty_Gia
    "user_id0" int8 NOT NULL,               -- _userinfo
    "user_id2" int8 NOT NULL,               -- _userinfo1
    CONSTRAINT "pk_transaction_document" PRIMARY KEY ("stt_rec")
)
;

-- MyERP.DataAccess.TransactionLine
CREATE TABLE "transaction_line" (
    "dien_giaii" text NOT NULL,             -- _dien_giaii
    "ma_kh_i" text NOT NULL,                -- _dmkh
    "tk_i" text NOT NULL,                   -- _dmtk
    "ma_vv_i" text NOT NULL,                -- _dmvv
    "ln" int8 NOT NULL,                     -- _ln
    "ma_ct" text NOT NULL,                  -- _ma_ct
    "ma_ku" text NOT NULL,                  -- _ma_ku
    "ma_td_i" text NOT NULL,                -- _ma_td_i
    "ngay_ct" date NOT NULL,                -- _ngay_ct
    "nh_dk" text NOT NULL,                  -- _nh_dk
    "ps_co" numeric(38,20) NOT NULL,        -- _ps_co
    "ps_co_nt" numeric(38,20) NOT NULL,     -- _ps_co_nt
    "ps_no" numeric(38,20) NOT NULL,        -- _ps_no
    "ps_no_nt" numeric(38,20) NOT NULL,     -- _ps_no_nt
    "so_ct" text NOT NULL,                  -- _so_ct
    "stt_rec" text NOT NULL,                -- _stt_rec
    CONSTRAINT "pk_transaction_line" PRIMARY KEY ("ln", "stt_rec")
)
;

-- MyERP.DataAccess.User
CREATE TABLE "user" (
    "administrator" bool NOT NULL,          -- _administrator
    "comment" text NOT NULL,                -- _comment
    "date0" timestamp NOT NULL,             -- _date0
    "date2" timestamp NOT NULL,             -- _date2
    "id" int8 NOT NULL,                     -- _id
    "password" text NOT NULL,               -- _password
    "r_access" text NOT NULL,               -- _rightAccess
    "r_add" text NOT NULL,                  -- _rightAdd
    "r_del" text NOT NULL,                  -- _rightDel
    "r_edit" text NOT NULL,                 -- _r_edit
    "r_print" text NOT NULL,                -- _r_print
    "r_read" text NOT NULL,                 -- _r_read
    "r_search" text NOT NULL,               -- _r_search
    "status" text NOT NULL,                 -- _status
    "user_display_name" text NOT NULL,      -- _userDisplayName
    "user_id0" int8 NOT NULL,               -- _userId0
    "user_id2" int8 NOT NULL,               -- _userId2
    "user_name" text NOT NULL,              -- _userName
    CONSTRAINT "pk_usr" PRIMARY KEY ("id")
)
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_business_partner" FOREIGN KEY ("ma_kh") REFERENCES "business_partner"("code")
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_job_group" FOREIGN KEY ("nh_vv1") REFERENCES "job_group"("ma_nh")
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_job_group2" FOREIGN KEY ("nh_vv2") REFERENCES "job_group"("ma_nh")
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_job_group3" FOREIGN KEY ("nh_vv3") REFERENCES "job_group"("ma_nh")
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_account" FOREIGN KEY ("tk") REFERENCES "account"("code")
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "Job" ADD CONSTRAINT "ref_Job_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_currency" FOREIGN KEY ("currency_code") REFERENCES "currency"("code")
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account" FOREIGN KEY ("customer_account_code") REFERENCES "account"("code")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_grp" FOREIGN KEY ("business_partner_group1") REFERENCES "business_partner_group"("code")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr2" FOREIGN KEY ("business_partner_group2") REFERENCES "business_partner_group"("code")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr3" FOREIGN KEY ("business_partner_group3") REFERENCES "business_partner_group"("code")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account2" FOREIGN KEY ("employee_account_code") REFERENCES "account"("code")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsness_partner_payment_term" FOREIGN KEY ("payment_term_code") REFERENCES "payment_term"("code")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_account3" FOREIGN KEY ("vendor_account_code") REFERENCES "account"("code")
;

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_trnsctn_dcment_organization" FOREIGN KEY ("ma_dvcs") REFERENCES "organization"("code")
;

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_trnsction_document_currency" FOREIGN KEY ("ma_nt") REFERENCES "currency"("code")
;

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_transaction_document_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_transaction_document_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_trnsctn_ln_business_partner" FOREIGN KEY ("ma_kh_i") REFERENCES "business_partner"("code")
;

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_transaction_line_account" FOREIGN KEY ("tk_i") REFERENCES "account"("code")
;

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_transaction_line_Job" FOREIGN KEY ("ma_vv_i") REFERENCES "Job"("ma_vv")
;

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_trnsctn_ln_trnsctn_document" FOREIGN KEY ("stt_rec") REFERENCES "transaction_document"("stt_rec")
;

-- Index 'idx_Job_nh_vv1' was not detected in the database. It will be created
CREATE INDEX "idx_Job_nh_vv1" ON "Job"("nh_vv1")
;

-- Index 'idx_Job_nh_vv2' was not detected in the database. It will be created
CREATE INDEX "idx_Job_nh_vv2" ON "Job"("nh_vv2")
;

-- Index 'idx_Job_nh_vv3' was not detected in the database. It will be created
CREATE INDEX "idx_Job_nh_vv3" ON "Job"("nh_vv3")
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_grp' was not detected in the database. It will be created
CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_grp" ON "business_partner"("business_partner_group1")
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_gr2' was not detected in the database. It will be created
CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr2" ON "business_partner"("business_partner_group2")
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_gr3' was not detected in the database. It will be created
CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr3" ON "business_partner"("business_partner_group3")
;

-- Index 'idx_transaction_line_stt_rec' was not detected in the database. It will be created
CREATE INDEX "idx_transaction_line_stt_rec" ON "transaction_line"("stt_rec")
;

