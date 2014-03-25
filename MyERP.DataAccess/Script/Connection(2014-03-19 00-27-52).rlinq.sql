-- Column was read from database as: "ar_ap" bool null
-- modify column for field _arAp
UPDATE "account"
   SET "ar_ap" = False
 WHERE "ar_ap" IS NULL
;

ALTER TABLE "account" ALTER COLUMN "ar_ap" TYPE bool USING "ar_ap"::bool
;

ALTER TABLE "account" ALTER COLUMN "ar_ap" SET NOT NULL
;

-- add column for field _parentAccount
ALTER TABLE "account" ADD COLUMN "parent_account_code" text
;

-- dropping unknown column "parent_account"
ALTER TABLE "account" DROP COLUMN "parent_account"
;

-- Index 'idx_account_parent_account_code' was not detected in the database. It will be created
CREATE INDEX "idx_account_parent_account_code" ON "account"("parent_account_code")
;

