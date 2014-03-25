-- add column for field _arAp
ALTER TABLE "account" ADD COLUMN "ar_ap" int2
;

UPDATE "account" SET "ar_ap" = 0
;

ALTER TABLE "account" ALTER COLUMN "ar_ap" SET  NOT NULL
;

-- add column for field _detail
ALTER TABLE "account" ADD COLUMN "detail" bool
;

UPDATE "account" SET "detail" = False
;

ALTER TABLE "account" ALTER COLUMN "detail" SET  NOT NULL
;

-- Column was read from database as: "parent_account" text not null
-- modify column for field _parentAccount
ALTER TABLE "account" ALTER COLUMN "parent_account" TYPE text USING "parent_account"::text
;

ALTER TABLE "account" ALTER COLUMN "parent_account" DROP NOT NULL
;

-- dropping unknown column "account_type"
ALTER TABLE "account" DROP COLUMN "account_type"
;

-- dropping unknown column "debt_account"
ALTER TABLE "account" DROP COLUMN "debt_account"
;

-- dropping unknown column "master_account"
ALTER TABLE "account" DROP COLUMN "master_account"
;

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_transaction_line_job" FOREIGN KEY ("ma_vv_i") REFERENCES "job"("ma_vv")
;

