ALTER TABLE "job" DROP CONSTRAINT "ref_job_account" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group2" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group3" CASCADE
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

-- Index 'idx_job_job_group_id3' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_job_job_group_id3" CASCADE
;

-- Index 'idx_job_job_group_id2' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_job_job_group_id2" CASCADE
;

-- Index 'idx_job_job_group_id1' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_job_job_group_id1" CASCADE
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

-- Column was read from database as: "account_id" uuid not null
-- modify column for field _dmtk
ALTER TABLE "job" ALTER COLUMN "account_id" TYPE uuid USING "account_id"::uuid
;

ALTER TABLE "job" ALTER COLUMN "account_id" DROP NOT NULL
;

-- Column was read from database as: "job_end" date not null
-- modify column for field _jobEnd
ALTER TABLE "job" ALTER COLUMN "job_end" TYPE date USING "job_end"::date
;

ALTER TABLE "job" ALTER COLUMN "job_end" DROP NOT NULL
;

-- Column was read from database as: "job_group_id1" uuid not null
-- modify column for field _jobGroup
ALTER TABLE "job" ALTER COLUMN "job_group_id1" TYPE uuid USING "job_group_id1"::uuid
;

ALTER TABLE "job" ALTER COLUMN "job_group_id1" DROP NOT NULL
;

-- Column was read from database as: "job_group_id2" uuid not null
-- modify column for field _jobGroup1
ALTER TABLE "job" ALTER COLUMN "job_group_id2" TYPE uuid USING "job_group_id2"::uuid
;

ALTER TABLE "job" ALTER COLUMN "job_group_id2" DROP NOT NULL
;

-- Column was read from database as: "job_group_id3" uuid not null
-- modify column for field _jobGroup2
ALTER TABLE "job" ALTER COLUMN "job_group_id3" TYPE uuid USING "job_group_id3"::uuid
;

ALTER TABLE "job" ALTER COLUMN "job_group_id3" DROP NOT NULL
;

-- Column was read from database as: "job_start" date not null
-- modify column for field _jobStart
ALTER TABLE "job" ALTER COLUMN "job_start" TYPE date USING "job_start"::date
;

ALTER TABLE "job" ALTER COLUMN "job_start" DROP NOT NULL
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_account" FOREIGN KEY ("account_id") REFERENCES "account"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group" FOREIGN KEY ("job_group_id1") REFERENCES "job_group"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group2" FOREIGN KEY ("job_group_id2") REFERENCES "job_group"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group3" FOREIGN KEY ("job_group_id3") REFERENCES "job_group"("id")
;

-- Index 'idx_job_job_group_id3' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_job_job_group_id3" ON "job"("job_group_id3")
;

-- Index 'idx_job_job_group_id2' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_job_job_group_id2" ON "job"("job_group_id2")
;

-- Index 'idx_job_job_group_id1' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_job_job_group_id1" ON "job"("job_group_id1")
;

