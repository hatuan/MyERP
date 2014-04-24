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

-- add column for field _currencyExchangeRate
ALTER TABLE "general_journal_line" ADD COLUMN "currency_exchange_rate" numeric(38,20)
;

UPDATE "general_journal_line" SET "currency_exchange_rate" = 0
;

ALTER TABLE "general_journal_line" ALTER COLUMN "currency_exchange_rate" SET  NOT NULL
;

-- add column for field _currencyId
ALTER TABLE "general_journal_line" ADD COLUMN "currency_id" uuid
;

UPDATE "general_journal_line" SET "currency_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "general_journal_line" ALTER COLUMN "currency_id" SET  NOT NULL
;

-- add column for field _documentCreated
ALTER TABLE "general_journal_line" ADD COLUMN "document_created_date" date
;

UPDATE "general_journal_line" SET "document_created_date" = current_timestamp
;

ALTER TABLE "general_journal_line" ALTER COLUMN "document_created_date" SET  NOT NULL
;

-- add column for field _documentNo
ALTER TABLE "general_journal_line" ADD COLUMN "document_no" text
;

UPDATE "general_journal_line" SET "document_no" = ' '
;

ALTER TABLE "general_journal_line" ALTER COLUMN "document_no" SET  NOT NULL
;

-- add column for field _documentPosted
ALTER TABLE "general_journal_line" ADD COLUMN "document_posted_date" date
;

UPDATE "general_journal_line" SET "document_posted_date" = current_timestamp
;

ALTER TABLE "general_journal_line" ALTER COLUMN "document_posted_date" SET  NOT NULL
;

-- add column for field _documentType
ALTER TABLE "general_journal_line" ADD COLUMN "document_type" text
;

UPDATE "general_journal_line" SET "document_type" = ' '
;

ALTER TABLE "general_journal_line" ALTER COLUMN "document_type" SET  NOT NULL
;

-- add column for field _recCreated
ALTER TABLE "general_journal_line" ADD COLUMN "rec_created" timestamp
;

UPDATE "general_journal_line" SET "rec_created" = current_timestamp
;

ALTER TABLE "general_journal_line" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _user
ALTER TABLE "general_journal_line" ADD COLUMN "rec_created_by" uuid
;

UPDATE "general_journal_line" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "general_journal_line" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _recModified
ALTER TABLE "general_journal_line" ADD COLUMN "rec_modified" timestamp
;

UPDATE "general_journal_line" SET "rec_modified" = current_timestamp
;

ALTER TABLE "general_journal_line" ALTER COLUMN "rec_modified" SET  NOT NULL
;

-- add column for field _user1
ALTER TABLE "general_journal_line" ADD COLUMN "rec_modified_by" uuid
;

UPDATE "general_journal_line" SET "rec_modified_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "general_journal_line" ALTER COLUMN "rec_modified_by" SET  NOT NULL
;

-- add column for field _transactionType
ALTER TABLE "general_journal_line" ADD COLUMN "transaction_type" int4
;

UPDATE "general_journal_line" SET "transaction_type" = 0
;

ALTER TABLE "general_journal_line" ALTER COLUMN "transaction_type" SET  NOT NULL
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "general_journal_line" ADD CONSTRAINT "ref_general_journal_line_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

