-- Dropping index 'idx_account_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_code" CASCADE
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_gr3' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr3" CASCADE
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_gr2' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr2" CASCADE
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_grp' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_bsnss_prtnr_bsnss_prtnr_grp" CASCADE
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

-- add column for field _businessPartnerGroup1
ALTER TABLE "business_partner" ADD COLUMN "business_partner_group_id1" uuid
;

UPDATE "business_partner" SET "business_partner_group_id1" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "business_partner_group_id1" SET  NOT NULL
;

-- add column for field _businessPartnerGroup2
ALTER TABLE "business_partner" ADD COLUMN "business_partner_group_id2" uuid
;

UPDATE "business_partner" SET "business_partner_group_id2" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "business_partner_group_id2" SET  NOT NULL
;

-- add column for field _businessPartnerGroup3
ALTER TABLE "business_partner" ADD COLUMN "business_partner_group_id3" uuid
;

UPDATE "business_partner" SET "business_partner_group_id3" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner" ALTER COLUMN "business_partner_group_id3" SET  NOT NULL
;

-- dropping unknown column "business_partner_group3"
ALTER TABLE "business_partner" DROP COLUMN "business_partner_group3"
;

-- dropping unknown column "business_partner_group2"
ALTER TABLE "business_partner" DROP COLUMN "business_partner_group2"
;

-- dropping unknown column "business_partner_group1"
ALTER TABLE "business_partner" DROP COLUMN "business_partner_group1"
;

ALTER TABLE "business_partner" DROP CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr2" CASCADE
;

ALTER TABLE "business_partner" DROP CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr3" CASCADE
;

ALTER TABLE "business_partner" DROP CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_grp" CASCADE
;

ALTER TABLE "business_partner_group" DROP CONSTRAINT "pk_business_partner_group" CASCADE
;

-- add column for field _id
ALTER TABLE "business_partner_group" ADD COLUMN "id" uuid
;

UPDATE "business_partner_group" SET "id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner_group" ALTER COLUMN "id" SET  NOT NULL
;

-- add column for field _recCreated
ALTER TABLE "business_partner_group" ADD COLUMN "rec_created" timestamp
;

UPDATE "business_partner_group" SET "rec_created" = current_timestamp
;

ALTER TABLE "business_partner_group" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _recCreatedBy
ALTER TABLE "business_partner_group" ADD COLUMN "rec_created_by" uuid
;

UPDATE "business_partner_group" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner_group" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _recModified
ALTER TABLE "business_partner_group" ADD COLUMN "rec_modified" timestamp
;

UPDATE "business_partner_group" SET "rec_modified" = current_timestamp
;

ALTER TABLE "business_partner_group" ALTER COLUMN "rec_modified" SET  NOT NULL
;

-- add column for field _recModifiedBy
ALTER TABLE "business_partner_group" ADD COLUMN "rec_modified_by" uuid
;

UPDATE "business_partner_group" SET "rec_modified_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "business_partner_group" ALTER COLUMN "rec_modified_by" SET  NOT NULL
;

-- dropping unknown column "user_id2"
ALTER TABLE "business_partner_group" DROP COLUMN "user_id2"
;

-- dropping unknown column "user_id0"
ALTER TABLE "business_partner_group" DROP COLUMN "user_id0"
;

-- dropping unknown column "rowguid"
ALTER TABLE "business_partner_group" DROP COLUMN "rowguid"
;

-- dropping unknown column "date2"
ALTER TABLE "business_partner_group" DROP COLUMN "date2"
;

-- dropping unknown column "date0"
ALTER TABLE "business_partner_group" DROP COLUMN "date0"
;

ALTER TABLE "business_partner_group" ADD CONSTRAINT "pk_business_partner_group" PRIMARY KEY ("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_grp" FOREIGN KEY ("business_partner_group_id1") REFERENCES "business_partner_group"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr2" FOREIGN KEY ("business_partner_group_id2") REFERENCES "business_partner_group"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsnss_prtnr_bsnss_prtnr_gr3" FOREIGN KEY ("business_partner_group_id3") REFERENCES "business_partner_group"("id")
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_gr3' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr3" ON "business_partner"("business_partner_group_id3")
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_gr2' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_gr2" ON "business_partner"("business_partner_group_id2")
;

-- Index 'idx_bsnss_prtnr_bsnss_prtnr_grp' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_bsnss_prtnr_bsnss_prtnr_grp" ON "business_partner"("business_partner_group_id1")
;

