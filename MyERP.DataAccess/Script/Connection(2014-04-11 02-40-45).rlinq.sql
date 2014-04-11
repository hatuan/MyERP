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

-- MyERP.DataAccess.Client
CREATE TABLE "client" (
    "id" uuid NOT NULL,                     -- _id
    "is_activated" bool NOT NULL,           -- _isActivated
    "name" varchar NOT NULL,                -- _name
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_client" PRIMARY KEY ("id")
)
;

-- add column for field _clientId
ALTER TABLE "organization" ADD COLUMN "client_id" uuid
;

UPDATE "organization" SET "client_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "organization" ALTER COLUMN "client_id" SET  NOT NULL
;

-- add column for field _recCreated
ALTER TABLE "organization" ADD COLUMN "rec_created" timestamp
;

UPDATE "organization" SET "rec_created" = current_timestamp
;

ALTER TABLE "organization" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _recCreatedByUser
ALTER TABLE "organization" ADD COLUMN "rec_created_by" uuid
;

UPDATE "organization" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "organization" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _recModified
ALTER TABLE "organization" ADD COLUMN "rec_modified" timestamp
;

UPDATE "organization" SET "rec_modified" = current_timestamp
;

ALTER TABLE "organization" ALTER COLUMN "rec_modified" SET  NOT NULL
;

-- add column for field _recModifiedByUser
ALTER TABLE "organization" ADD COLUMN "rec_modified_by" uuid
;

UPDATE "organization" SET "rec_modified_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "organization" ALTER COLUMN "rec_modified_by" SET  NOT NULL
;

-- dropping unknown column "user_id2"
ALTER TABLE "organization" DROP COLUMN "user_id2"
;

-- dropping unknown column "user_id0"
ALTER TABLE "organization" DROP COLUMN "user_id0"
;

-- dropping unknown column "m_ws_id"
ALTER TABLE "organization" DROP COLUMN "m_ws_id"
;

-- dropping unknown column "date2"
ALTER TABLE "organization" DROP COLUMN "date2"
;

-- dropping unknown column "date0"
ALTER TABLE "organization" DROP COLUMN "date0"
;

ALTER TABLE "client" ADD CONSTRAINT "ref_client_organization" FOREIGN KEY ("id") REFERENCES "organization"("id")
;

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

