ALTER TABLE "general_journal_line" DROP CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" CASCADE
;

ALTER TABLE "general_journal_line" DROP CONSTRAINT "ref_general_journal_line_job" CASCADE
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

-- Dropping index 'idx_general_journal_document_client' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_document_client" CASCADE
;

-- Dropping index 'idx_general_journal_document_no' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_document_no" CASCADE
;

-- Dropping index 'idx_general_journal_document_organization' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_document_organization" CASCADE
;

-- Dropping index 'idx_general_journal_document_posted' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_document_posted" CASCADE
;

-- Dropping index 'idx_general_journal_line_client' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_line_client" CASCADE
;

-- Dropping index 'idx_general_journal_line_document_no' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_line_document_no" CASCADE
;

-- Dropping index 'idx_general_journal_line_no' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_line_no" CASCADE
;

-- Dropping index 'idx_general_journal_line_organization' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_line_organization" CASCADE
;

-- Dropping index 'idx_general_journal_line_posted' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_line_posted" CASCADE
;

-- Dropping index 'idx_general_journal_setup_organization_id' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_general_journal_setup_organization_id" CASCADE
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

-- MyERP.DataAccess.CurrencyConvertRate
CREATE TABLE "currency_convert_rate" (
    "client_id" uuid NOT NULL,              -- _client
    "conversion_rate_type" int2 NOT NULL,   -- _conversionRateType
    "currency_id" uuid NOT NULL,            -- _currency
    "currency_id_to" uuid NOT NULL,         -- _currency1
    "divide_rate" int4 NOT NULL,            -- _divideRate
    "id" uuid NOT NULL,                     -- _id
    "multiply_rate" int4 NOT NULL,          -- _multiplyRate
    "organization_id" uuid NOT NULL,        -- _organization
    "rec_created" timestamp(6) NOT NULL,    -- _recCreated
    "rec_created_by" uuid NOT NULL,         -- _user
    "rec_modified" timestamp(6) NOT NULL,   -- _recModified
    "rec_modified_by" uuid NOT NULL,        -- _user1
    "status" int2 NOT NULL,                 -- _status
    "valid_from" date(6) NOT NULL,          -- _validFrom
    "valid_to" date(6) NOT NULL,            -- _validTo
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_currency_convert_rate" PRIMARY KEY ("id")
)
;

-- Column was read from database as: "business_partner_id" uuid not null
-- modify column for field _businessPartner
ALTER TABLE "general_journal_line" ALTER COLUMN "business_partner_id" TYPE uuid USING "business_partner_id"::uuid
;

ALTER TABLE "general_journal_line" ALTER COLUMN "business_partner_id" DROP NOT NULL
;

-- Column was read from database as: "fix_asset_id" uuid not null
-- modify column for field _fixAssetId
ALTER TABLE "general_journal_line" ALTER COLUMN "fix_asset_id" TYPE uuid USING "fix_asset_id"::uuid
;

ALTER TABLE "general_journal_line" ALTER COLUMN "fix_asset_id" DROP NOT NULL
;

-- Column was read from database as: "job_id" uuid not null
-- modify column for field _job
ALTER TABLE "general_journal_line" ALTER COLUMN "job_id" TYPE uuid USING "job_id"::uuid
;

ALTER TABLE "general_journal_line" ALTER COLUMN "job_id" DROP NOT NULL
;

ALTER TABLE "currency_convert_rate" ADD CONSTRAINT "ref_crrency_convert_rate_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "currency_convert_rate" ADD CONSTRAINT "ref_crrncy_cnvert_rate_currency" FOREIGN KEY ("currency_id") REFERENCES "currency"("id")
;

ALTER TABLE "currency_convert_rate" ADD CONSTRAINT "ref_crrncy_cnvert_rate_currenc2" FOREIGN KEY ("currency_id_to") REFERENCES "currency"("id")
;

ALTER TABLE "currency_convert_rate" ADD CONSTRAINT "ref_crrncy_cnvrt_rt_rganization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "currency_convert_rate" ADD CONSTRAINT "ref_currency_convert_rate_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "currency_convert_rate" ADD CONSTRAINT "ref_currency_convert_rate_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_job" FOREIGN KEY ("job_id") REFERENCES "job"("id")
;

