-- Dropping index 'idx_account_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_code" CASCADE
;

-- Dropping index 'idx_user_name' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_user_name" CASCADE
;

ALTER TABLE "transaction_document" DROP CONSTRAINT "ref_trnsctn_dcment_organization" CASCADE
;

ALTER TABLE "organization" DROP CONSTRAINT "pk_organization" CASCADE
;

-- add column for field _id
ALTER TABLE "organization" ADD COLUMN "id" uuid
;

UPDATE "organization" SET "id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "organization" ALTER COLUMN "id" SET  NOT NULL
;

-- dropping unknown column "rowguid"
ALTER TABLE "organization" DROP COLUMN "rowguid"
;

ALTER TABLE "organization" ADD CONSTRAINT "pk_organization" PRIMARY KEY ("id")
;

-- Column was read from database as: "ma_dvcs" text not null
-- modify column for field _Ma_Dvcs
ALTER TABLE "transaction_document" ALTER COLUMN "ma_dvcs" TYPE uuid USING "ma_dvcs"::uuid
;

