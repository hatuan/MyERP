ALTER TABLE "general_journal_document" DROP CONSTRAINT "ref_gnrl_jrnl_dcmnt_nmbr_sqence" CASCADE
;

ALTER TABLE "general_journal_setup" DROP CONSTRAINT "ref_gnrl_jrnl_stp_nmbr_sequence" CASCADE
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

-- add column for field _noSeries
ALTER TABLE "general_journal_document" ADD COLUMN "number_seq_id" uuid
;

UPDATE "general_journal_document" SET "number_seq_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "general_journal_document" ALTER COLUMN "number_seq_id" SET  NOT NULL
;

-- dropping unknown column "noseries_id"
ALTER TABLE "general_journal_document" DROP COLUMN "noseries_id"
;

-- add column for field _defaultDocumentType1No
ALTER TABLE "general_journal_setup" ADD COLUMN "default_document_type_1_number_seq_id" uuid
;

UPDATE "general_journal_setup" SET "default_document_type_1_number_seq_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "general_journal_setup" ALTER COLUMN "default_document_type_1_number_seq_id" SET  NOT NULL
;

-- dropping unknown column "default_document_type_1_no_id"
ALTER TABLE "general_journal_setup" DROP COLUMN "default_document_type_1_no_id"
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_dcmnt_nmbr_sqence" FOREIGN KEY ("number_seq_id") REFERENCES "number_sequence"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_gnrl_jrnl_stp_nmbr_sequence" FOREIGN KEY ("default_document_type_1_number_seq_id") REFERENCES "number_sequence"("id")
;

