ALTER TABLE "transaction_line" DROP CONSTRAINT "ref_trnsctn_ln_trnsctn_document" CASCADE
;

-- Dropping index 'idx_account_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_code" CASCADE
;

-- Dropping index 'idx_business_partner_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_business_partner_code" CASCADE
;

-- Dropping index 'idx_business_partner_group_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_business_partner_group_code" CASCADE
;

-- Dropping index 'idx_currency_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_currency_code" CASCADE
;

-- Dropping index 'idx_job_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_code" CASCADE
;

-- Dropping index 'idx_job_group_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_group_code" CASCADE
;

-- Dropping index 'idx_organization_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_organization_code" CASCADE
;

-- Dropping index 'idx_payment_term_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_payment_term_code" CASCADE
;

-- Dropping index 'idx_user_email' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_user_email" CASCADE
;

-- Dropping index 'idx_user_name' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_user_name" CASCADE
;

-- dropping table "transaction_document"
DROP TABLE "transaction_document"
;

-- dropping table "transaction_line"
DROP TABLE "transaction_line"
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_business_partner" CASCADE
;

ALTER TABLE "transaction_line" DROP CONSTRAINT "ref_trnsctn_ln_business_partner" CASCADE
;

ALTER TABLE "business_partner" DROP CONSTRAINT "pk_business_partner" CASCADE
;

-- add column for field _id
ALTER TABLE "business_partner" ADD COLUMN "id" uuid
;

UPDATE "business_partner" SET "id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "id" SET  NOT NULL
;

-- dropping unknown column "rowguid"
ALTER TABLE "business_partner" DROP COLUMN "rowguid"
;

ALTER TABLE "business_partner" ADD CONSTRAINT "pk_business_partner" PRIMARY KEY ("id")
;

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
    "id" uuid NOT NULL,                     -- _Stt_Rec
    "document_type" text NOT NULL,          -- _documentType
    "document_posted_date" date NOT NULL,   -- _documentPosted
    "document_noseries_id" uuid NOT NULL,   -- _documentNoSeriesId
    "document_no" text NOT NULL,            -- _documentNo
    "document_created_date" date NOT NULL,  -- _documentCreated
    "currency_exchange_rate" int4(38,20) NOT NULL, -- _currencyExchangeRate
    "currency_id" uuid NOT NULL,            -- _dmnt
    "client_id" uuid NOT NULL,              -- _client
    CONSTRAINT "pk_general_journal_document" PRIMARY KEY ("id")
)
;

-- MyERP.DataAccess.GeneralJournalLine
CREATE TABLE "general_journal_line" (
    "version" int8 NOT NULL,                -- _version
    "general_journal_document_id" uuid NOT NULL, -- _ph11
    "organization_id" uuid NOT NULL,        -- _organization
    "lineno" int8 NOT NULL,                 -- _lineNo
    "job_id" uuid NOT NULL,                 -- _dmvv
    "id" uuid NOT NULL,                     -- _id
    "description" text NOT NULL,            -- _description
    "debit_amount_lcy" numeric(38,20) NOT NULL, -- _debitAmountLcy
    "debit_amount" numeric(38,20) NOT NULL, -- _debitAmount
    "credit_amount_lcy" numeric(38,20) NOT NULL, -- _creditAmountLcy
    "credit_amount" numeric(38,20) NOT NULL, -- _creditAmount
    "cor_account_type" text NOT NULL,       -- _corAccountType
    "cor_account_id" uuid NOT NULL,         -- _corAccountId
    "client_id" uuid NOT NULL,              -- _client
    "business_partner_id" uuid NOT NULL,    -- _dmkh
    "account_type" text NOT NULL,           -- _accountType
    "account_id" uuid NOT NULL,             -- _accountId
    CONSTRAINT "pk_general_journal_line" PRIMARY KEY ("id")
)
;

ALTER TABLE "transaction_line" DROP CONSTRAINT "ref_transaction_line_job" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "pk_job" CASCADE
;

-- add column for field _id
ALTER TABLE "job" ADD COLUMN "id" uuid
;

UPDATE "job" SET "id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "id" SET  NOT NULL
;

-- add column for field _dmkh
ALTER TABLE "job" ADD COLUMN "business_partner_id" uuid
;

UPDATE "job" SET "business_partner_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "business_partner_id" SET  NOT NULL
;

-- dropping unknown column "ma_kh"
ALTER TABLE "job" DROP COLUMN "ma_kh"
;

ALTER TABLE "job" ADD CONSTRAINT "pk_job" PRIMARY KEY ("id")
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jurnal_document_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_document_currency" FOREIGN KEY ("currency_id") REFERENCES "currency"("id")
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_dcmnt_rganization" FOREIGN KEY ("organizaion_id") REFERENCES "organization"("id")
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnral_journal_document_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnral_journal_document_use2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_job" FOREIGN KEY ("job_id") REFERENCES "job"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_line_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_gnrl_jrnl_dcmn" FOREIGN KEY ("general_journal_document_id") REFERENCES "general_journal_document"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_business_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id")
;

ALTER TABLE "session" ADD CONSTRAINT "ref_session_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "session" ADD CONSTRAINT "ref_session_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

-- Index 'idx_gnrl_jrnl_ln_gnrl_jrnl_dcmn' was not detected in the database. It will be created
CREATE INDEX "idx_gnrl_jrnl_ln_gnrl_jrnl_dcmn" ON "general_journal_line"("general_journal_document_id")
;

