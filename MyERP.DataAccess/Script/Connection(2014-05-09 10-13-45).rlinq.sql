ALTER TABLE "general_journal_document" DROP CONSTRAINT "ref_gnrl_jrnl_dcument_no_series" CASCADE
;

ALTER TABLE "general_journal_line" DROP CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" CASCADE
;

ALTER TABLE "general_journal_line" DROP CONSTRAINT "ref_general_journal_line_job" CASCADE
;

ALTER TABLE "general_journal_setup" DROP CONSTRAINT "ref_gnrl_jurnal_setup_no_series" CASCADE
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

-- MyERP.DataAccess.NumberSequence
CREATE TABLE "number_sequence" (
    "client_id" uuid NOT NULL,              -- _client
    "code" varchar NOT NULL,                -- _code
    "current_no" int4 NOT NULL,             -- _currentNo
    "ending_no" int4 NOT NULL,              -- _endingNo
    "format_no" varchar NOT NULL,           -- _formatNo
    "id" uuid NOT NULL,                     -- _id
    "is_default" bool NOT NULL,             -- _isDefault
    "manual" bool NOT NULL,                 -- _manual
    "name" varchar NOT NULL,                -- _name
    "no_seq_name" varchar NOT NULL,         -- _noSeqName
    "organization_id" uuid NOT NULL,        -- _organization
    "rec_created" timestamp NOT NULL,       -- _recCreated
    "rec_created_by" uuid NOT NULL,         -- _user1
    "rec_modified" timestamp NOT NULL,      -- _recModified
    "rec_modified_by" uuid NOT NULL,        -- _user
    "starting_no" int4 NOT NULL,            -- _startingNo
    "status" int2 NOT NULL,                 -- _status
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_number_sequence" PRIMARY KEY ("id")
)
;

ALTER TABLE "general_journal_document" ADD CONSTRAINT "ref_gnrl_jrnl_dcmnt_nmbr_sqence" FOREIGN KEY ("noseries_id") REFERENCES "number_sequence"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_gnrl_jrnl_ln_bsness_partner" FOREIGN KEY ("business_partner_id") REFERENCES "business_partner"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_job" FOREIGN KEY ("job_id") REFERENCES "job"("id")
;

ALTER TABLE "general_journal_setup" ADD CONSTRAINT "ref_gnrl_jrnl_stp_nmbr_sequence" FOREIGN KEY ("default_document_type_1_no_id") REFERENCES "number_sequence"("id")
;

ALTER TABLE "number_sequence" ADD CONSTRAINT "ref_number_sequence_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "number_sequence" ADD CONSTRAINT "ref_nmber_sequence_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "number_sequence" ADD CONSTRAINT "ref_number_sequence_user" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

ALTER TABLE "number_sequence" ADD CONSTRAINT "ref_number_sequence_user2" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

