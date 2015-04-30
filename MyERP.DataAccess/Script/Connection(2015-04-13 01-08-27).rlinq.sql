ALTER TABLE "currency" DROP CONSTRAINT "ref_currency_client" CASCADE
;

ALTER TABLE "currency" DROP CONSTRAINT "ref_currency_organization" CASCADE
;

ALTER TABLE "currency" DROP CONSTRAINT "ref_currency_user" CASCADE
;

ALTER TABLE "currency" DROP CONSTRAINT "ref_currency_user2" CASCADE
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

-- add column for field _currency
ALTER TABLE "client" ADD COLUMN "currency_id" uuid
;

