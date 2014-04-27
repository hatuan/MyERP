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

-- Column was read from database as: "code" varchar(255) null
-- modify column for field _code
UPDATE "no_series"
   SET "code" = ' '
 WHERE "code" IS NULL
;

ALTER TABLE "no_series" ALTER COLUMN "code" TYPE varchar USING "code"::varchar
;

ALTER TABLE "no_series" ALTER COLUMN "code" SET NOT NULL
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_job" FOREIGN KEY ("job_id") REFERENCES "job"("id")
;

