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

-- add column for field _client_Id
ALTER TABLE "business_partner_group" ADD COLUMN "client_id" uuid
;

UPDATE "business_partner_group" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner_group" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization_Id
ALTER TABLE "business_partner_group" ADD COLUMN "organization_id" uuid
;

UPDATE "business_partner_group" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner_group" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _client_Id
ALTER TABLE "job" ADD COLUMN "client_id" uuid
;

UPDATE "job" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization_Id
ALTER TABLE "job" ADD COLUMN "organization_id" uuid
;

UPDATE "job" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _client_Id
ALTER TABLE "job_group" ADD COLUMN "client_id" uuid
;

UPDATE "job_group" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job_group" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization_Id
ALTER TABLE "job_group" ADD COLUMN "organization_id" uuid
;

UPDATE "job_group" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job_group" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _client_Id
ALTER TABLE "payment_term" ADD COLUMN "client_id" uuid
;

UPDATE "payment_term" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "payment_term" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization_Id
ALTER TABLE "payment_term" ADD COLUMN "organization_id" uuid
;

UPDATE "payment_term" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "payment_term" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _client_Id
ALTER TABLE "session" ADD COLUMN "client_id" uuid
;

UPDATE "session" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "session" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _client_Id
ALTER TABLE "transaction_document" ADD COLUMN "client_id" uuid
;

UPDATE "transaction_document" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "transaction_document" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organizaion_Id
ALTER TABLE "transaction_document" ADD COLUMN "organizaion_id" uuid
;

UPDATE "transaction_document" SET "organizaion_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "transaction_document" ALTER COLUMN "organizaion_id" SET  NOT NULL
;

-- add column for field _client_Id
ALTER TABLE "transaction_line" ADD COLUMN "client_id" uuid
;

UPDATE "transaction_line" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "transaction_line" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization_Id
ALTER TABLE "transaction_line" ADD COLUMN "organization_id" uuid
;

UPDATE "transaction_line" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "transaction_line" ALTER COLUMN "organization_id" SET  NOT NULL
;

