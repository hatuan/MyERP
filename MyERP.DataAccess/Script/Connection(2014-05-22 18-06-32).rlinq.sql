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

-- Dropping index 'idx_job_nh_vv1' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_nh_vv1" CASCADE
;

-- Dropping index 'idx_job_nh_vv2' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_nh_vv2" CASCADE
;

-- Dropping index 'idx_job_nh_vv3' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_nh_vv3" CASCADE
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

-- Column was read from database as: "nh_vv1" varchar not null
-- modify column for field _nh_vv1
ALTER TABLE "job" ALTER COLUMN "nh_vv1" TYPE uuid USING "nh_vv1"::uuid
;

-- Column was read from database as: "nh_vv2" varchar not null
-- modify column for field _nh_vv2
ALTER TABLE "job" ALTER COLUMN "nh_vv2" TYPE uuid USING "nh_vv2"::uuid
;

-- Column was read from database as: "nh_vv3" varchar not null
-- modify column for field _nh_vv3
ALTER TABLE "job" ALTER COLUMN "nh_vv3" TYPE uuid USING "nh_vv3"::uuid
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group2" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group3" CASCADE
;

ALTER TABLE "job_group" DROP CONSTRAINT "pk_job_group" CASCADE
;

-- add column for field _id
ALTER TABLE "job_group" ADD COLUMN "id" uuid
;

UPDATE "job_group" SET "id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job_group" ALTER COLUMN "id" SET  NOT NULL
;

-- add column for field _version
ALTER TABLE "job_group" ADD COLUMN "version" int8
;

UPDATE "job_group" SET "version" = 0
;

ALTER TABLE "job_group" ALTER COLUMN "version" SET  NOT NULL
;

ALTER TABLE "job_group" ADD CONSTRAINT "pk_job_group" PRIMARY KEY ("id")
;

