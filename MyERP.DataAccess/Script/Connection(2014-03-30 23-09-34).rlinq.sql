-- Dropping index 'idx_account_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_code" CASCADE
;

-- Dropping index 'idx_user_name' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_user_name" CASCADE
;

ALTER TABLE "transaction_line" DROP CONSTRAINT "ref_transaction_line_job" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "pk_job" CASCADE
;

-- add column for field _ma_vv
ALTER TABLE "job" ADD COLUMN "code" text
;

UPDATE "job" SET "code" = ' '
;

ALTER TABLE "job" ALTER COLUMN "code" SET  NOT NULL
;

-- dropping unknown column "ma_vv"
ALTER TABLE "job" DROP COLUMN "ma_vv"
;

ALTER TABLE "job" ADD CONSTRAINT "pk_job" PRIMARY KEY ("code")
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group2" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_job_group3" CASCADE
;

ALTER TABLE "job_group" DROP CONSTRAINT "pk_job_group" CASCADE
;

-- add column for field _ma_nh
ALTER TABLE "job_group" ADD COLUMN "code" text
;

UPDATE "job_group" SET "code" = ' '
;

ALTER TABLE "job_group" ALTER COLUMN "code" SET  NOT NULL
;

-- dropping unknown column "ma_nh"
ALTER TABLE "job_group" DROP COLUMN "ma_nh"
;

ALTER TABLE "job_group" ADD CONSTRAINT "pk_job_group" PRIMARY KEY ("code")
;

ALTER TABLE "transaction_line" ADD CONSTRAINT "ref_transaction_line_job" FOREIGN KEY ("ma_vv_i") REFERENCES "job"("code")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group" FOREIGN KEY ("nh_vv1") REFERENCES "job_group"("code")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group2" FOREIGN KEY ("nh_vv2") REFERENCES "job_group"("code")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group3" FOREIGN KEY ("nh_vv3") REFERENCES "job_group"("code")
;

