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

-- MyERP.DataAccess.GeneralJournalSetup
CREATE TABLE "general_journal_setup" (
    "client_id" uuid NOT NULL,              -- _client
    "local_currency_id" uuid NOT NULL,      -- _currency
    "default_document_type_1_no_id" uuid,   -- _noSeries
    "id" uuid NOT NULL,                     -- _id
    "lcy_exchange_rate_unit" int4 NOT NULL, -- _lcyExchangeRateUnit
    "organization_id" uuid NOT NULL,        -- _organization
    "rec_created" timestamp(6) NOT NULL,    -- _recCreated
    "rec_created_by" uuid NOT NULL,         -- _user
    "rec_modified" timestamp(6) NOT NULL,   -- _recModified
    "rec_modified_by" uuid NOT NULL,        -- _user1
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_general_journal_setup" PRIMARY KEY ("id")
)
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_gneral_journal_setup_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_gnrl_journal_setup_currency" FOREIGN KEY ("local_currency_id") REFERENCES "currency"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_gnrl_jurnal_setup_no_series" FOREIGN KEY ("default_document_type_1_no_id") REFERENCES "no_series"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_gnrl_jrnl_stup_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_general_journal_setup_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_general_journal_setup_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

