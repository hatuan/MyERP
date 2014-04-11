ALTER TABLE "business_partner" DROP CONSTRAINT "ref_business_partner_user" CASCADE
;

ALTER TABLE "business_partner" DROP CONSTRAINT "ref_business_partner_user2" CASCADE
;

ALTER TABLE "client" DROP CONSTRAINT "ref_client_organization" CASCADE
;

ALTER TABLE "organization" DROP CONSTRAINT "ref_organization_user" CASCADE
;

ALTER TABLE "organization" DROP CONSTRAINT "ref_organization_user2" CASCADE
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

-- add column for field _client
ALTER TABLE "account" ADD COLUMN "client_id" uuid
;

UPDATE "account" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "account" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization
ALTER TABLE "account" ADD COLUMN "organization_id" uuid
;

UPDATE "account" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "account" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _client
ALTER TABLE "business_partner" ADD COLUMN "client_id" uuid
;

UPDATE "business_partner" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization
ALTER TABLE "business_partner" ADD COLUMN "organization_id" uuid
;

UPDATE "business_partner" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _recCreated
ALTER TABLE "business_partner" ADD COLUMN "rec_created" timestamp
;

UPDATE "business_partner" SET "rec_created" = current_timestamp
;

ALTER TABLE "business_partner" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _user0
ALTER TABLE "business_partner" ADD COLUMN "rec_created_by" uuid
;

UPDATE "business_partner" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _recModified
ALTER TABLE "business_partner" ADD COLUMN "rec_modified" timestamp
;

UPDATE "business_partner" SET "rec_modified" = current_timestamp
;

ALTER TABLE "business_partner" ALTER COLUMN "rec_modified" SET  NOT NULL
;

-- add column for field _user2
ALTER TABLE "business_partner" ADD COLUMN "rec_modified_by" uuid
;

UPDATE "business_partner" SET "rec_modified_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "rec_modified_by" SET  NOT NULL
;

-- dropping unknown column "user_id2"
ALTER TABLE "business_partner" DROP COLUMN "user_id2"
;

-- dropping unknown column "user_id0"
ALTER TABLE "business_partner" DROP COLUMN "user_id0"
;

-- dropping unknown column "date2"
ALTER TABLE "business_partner" DROP COLUMN "date2"
;

-- dropping unknown column "date0"
ALTER TABLE "business_partner" DROP COLUMN "date0"
;

-- add column for field _recCreated
ALTER TABLE "client" ADD COLUMN "rec_created" timestamp(6)
;

UPDATE "client" SET "rec_created" = current_timestamp
;

ALTER TABLE "client" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _user
ALTER TABLE "client" ADD COLUMN "rec_created_by" uuid
;

UPDATE "client" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "client" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _client
ALTER TABLE "currency" ADD COLUMN "client_id" uuid
;

UPDATE "currency" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "currency" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization
ALTER TABLE "currency" ADD COLUMN "organization_id" uuid
;

UPDATE "currency" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "currency" ALTER COLUMN "organization_id" SET  NOT NULL
;

-- add column for field _client
ALTER TABLE "user" ADD COLUMN "client_id" uuid
;

UPDATE "user" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "user" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _organization
ALTER TABLE "user" ADD COLUMN "organization_id" uuid
;

UPDATE "user" SET "organization_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "user" ALTER COLUMN "organization_id" SET  NOT NULL
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsness_partner_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_business_partner_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

-- Index 'idx_organization_client_id' was not detected in the database. It will be created
CREATE INDEX "idx_organization_client_id" ON "organization"("client_id")
;

