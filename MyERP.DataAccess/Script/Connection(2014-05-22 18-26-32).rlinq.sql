ALTER TABLE "job" DROP CONSTRAINT "ref_job_account" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_user" CASCADE
;

ALTER TABLE "job" DROP CONSTRAINT "ref_job_user2" CASCADE
;

ALTER TABLE "job_group" DROP CONSTRAINT "ref_job_group_user" CASCADE
;

ALTER TABLE "job_group" DROP CONSTRAINT "ref_job_group_user2" CASCADE
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

-- Dropping index 'idx_job_nh_vv1' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_nh_vv1" CASCADE
;

-- Dropping index 'idx_job_nh_vv2' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_nh_vv2" CASCADE
;

-- Dropping index 'idx_job_nh_vv3' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_job_nh_vv3" CASCADE
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

-- add column for field _dmtk
ALTER TABLE "job" ADD COLUMN "account_id" uuid
;

UPDATE "job" SET "account_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "account_id" SET  NOT NULL
;

-- add column for field _amount
ALTER TABLE "job" ADD COLUMN "amount" numeric(38,20)
;

UPDATE "job" SET "amount" = 0
;

ALTER TABLE "job" ALTER COLUMN "amount" SET  NOT NULL
;

-- add column for field _amountLcy
ALTER TABLE "job" ADD COLUMN "amount_lcy" numeric(38,20)
;

UPDATE "job" SET "amount_lcy" = 0
;

ALTER TABLE "job" ALTER COLUMN "amount_lcy" SET  NOT NULL
;

-- add column for field _comment
ALTER TABLE "job" ADD COLUMN "comment" varchar
;

UPDATE "job" SET "comment" = ' '
;

ALTER TABLE "job" ALTER COLUMN "comment" SET  NOT NULL
;

-- add column for field _currencyId
ALTER TABLE "job" ADD COLUMN "currency_id" uuid
;

UPDATE "job" SET "currency_id" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "currency_id" SET  NOT NULL
;

-- add column for field _jobEnd
ALTER TABLE "job" ADD COLUMN "job_end" date
;

UPDATE "job" SET "job_end" = current_timestamp
;

ALTER TABLE "job" ALTER COLUMN "job_end" SET  NOT NULL
;

-- add column for field _jobGroup
ALTER TABLE "job" ADD COLUMN "job_group_id1" uuid
;

UPDATE "job" SET "job_group_id1" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "job_group_id1" SET  NOT NULL
;

-- add column for field _jobGroup1
ALTER TABLE "job" ADD COLUMN "job_group_id2" uuid
;

UPDATE "job" SET "job_group_id2" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "job_group_id2" SET  NOT NULL
;

-- add column for field _jobGroup2
ALTER TABLE "job" ADD COLUMN "job_group_id3" uuid
;

UPDATE "job" SET "job_group_id3" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "job_group_id3" SET  NOT NULL
;

-- add column for field _jobStart
ALTER TABLE "job" ADD COLUMN "job_start" date
;

UPDATE "job" SET "job_start" = current_timestamp
;

ALTER TABLE "job" ALTER COLUMN "job_start" SET  NOT NULL
;

-- add column for field _name
ALTER TABLE "job" ADD COLUMN "name" varchar
;

UPDATE "job" SET "name" = ' '
;

ALTER TABLE "job" ALTER COLUMN "name" SET  NOT NULL
;

-- add column for field _recCreated
ALTER TABLE "job" ADD COLUMN "rec_created" timestamp
;

UPDATE "job" SET "rec_created" = current_timestamp
;

ALTER TABLE "job" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _userinfo
ALTER TABLE "job" ADD COLUMN "rec_created_by" uuid
;

UPDATE "job" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _recModified
ALTER TABLE "job" ADD COLUMN "rec_modified" timestamp
;

UPDATE "job" SET "rec_modified" = current_timestamp
;

ALTER TABLE "job" ALTER COLUMN "rec_modified" SET  NOT NULL
;

-- add column for field _userinfo1
ALTER TABLE "job" ADD COLUMN "rec_modified_by" uuid
;

UPDATE "job" SET "rec_modified_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job" ALTER COLUMN "rec_modified_by" SET  NOT NULL
;

-- dropping unknown column "user_id2"
ALTER TABLE "job" DROP COLUMN "user_id2"
;

-- dropping unknown column "user_id0"
ALTER TABLE "job" DROP COLUMN "user_id0"
;

-- dropping unknown column "tien_nt"
ALTER TABLE "job" DROP COLUMN "tien_nt"
;

-- dropping unknown column "tien"
ALTER TABLE "job" DROP COLUMN "tien"
;

-- dropping unknown column "ten_vv2"
ALTER TABLE "job" DROP COLUMN "ten_vv2"
;

-- dropping unknown column "ten_vv"
ALTER TABLE "job" DROP COLUMN "ten_vv"
;

-- dropping unknown column "ngay_vv2"
ALTER TABLE "job" DROP COLUMN "ngay_vv2"
;

-- dropping unknown column "ngay_vv1"
ALTER TABLE "job" DROP COLUMN "ngay_vv1"
;

-- dropping unknown column "ma_nt"
ALTER TABLE "job" DROP COLUMN "ma_nt"
;

-- dropping unknown column "ghi_chu"
ALTER TABLE "job" DROP COLUMN "ghi_chu"
;

-- dropping unknown column "tk"
ALTER TABLE "job" DROP COLUMN "tk"
;

-- dropping unknown column "nh_vv3"
ALTER TABLE "job" DROP COLUMN "nh_vv3"
;

-- dropping unknown column "nh_vv2"
ALTER TABLE "job" DROP COLUMN "nh_vv2"
;

-- dropping unknown column "nh_vv1"
ALTER TABLE "job" DROP COLUMN "nh_vv1"
;

-- dropping unknown column "date2"
ALTER TABLE "job" DROP COLUMN "date2"
;

-- dropping unknown column "date0"
ALTER TABLE "job" DROP COLUMN "date0"
;

-- add column for field _level
ALTER TABLE "job_group" ADD COLUMN "level" int2
;

UPDATE "job_group" SET "level" = 0
;

ALTER TABLE "job_group" ALTER COLUMN "level" SET  NOT NULL
;

-- add column for field _name
ALTER TABLE "job_group" ADD COLUMN "name" varchar
;

UPDATE "job_group" SET "name" = ' '
;

ALTER TABLE "job_group" ALTER COLUMN "name" SET  NOT NULL
;

-- add column for field _recCreated
ALTER TABLE "job_group" ADD COLUMN "rec_created" timestamp
;

UPDATE "job_group" SET "rec_created" = current_timestamp
;

ALTER TABLE "job_group" ALTER COLUMN "rec_created" SET  NOT NULL
;

-- add column for field _userinfo
ALTER TABLE "job_group" ADD COLUMN "rec_created_by" uuid
;

UPDATE "job_group" SET "rec_created_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job_group" ALTER COLUMN "rec_created_by" SET  NOT NULL
;

-- add column for field _recModified
ALTER TABLE "job_group" ADD COLUMN "rec_modified" timestamp
;

UPDATE "job_group" SET "rec_modified" = current_timestamp
;

ALTER TABLE "job_group" ALTER COLUMN "rec_modified" SET  NOT NULL
;

-- add column for field _userinfo1
ALTER TABLE "job_group" ADD COLUMN "rec_modified_by" uuid
;

UPDATE "job_group" SET "rec_modified_by" = '00000000-0000-0000-0000-000000000000'
;

ALTER TABLE "job_group" ALTER COLUMN "rec_modified_by" SET  NOT NULL
;

-- dropping unknown column "user_id2"
ALTER TABLE "job_group" DROP COLUMN "user_id2"
;

-- dropping unknown column "user_id0"
ALTER TABLE "job_group" DROP COLUMN "user_id0"
;

-- dropping unknown column "ten_nh2"
ALTER TABLE "job_group" DROP COLUMN "ten_nh2"
;

-- dropping unknown column "ten_nh"
ALTER TABLE "job_group" DROP COLUMN "ten_nh"
;

-- dropping unknown column "loai_nh"
ALTER TABLE "job_group" DROP COLUMN "loai_nh"
;

-- dropping unknown column "date2"
ALTER TABLE "job_group" DROP COLUMN "date2"
;

-- dropping unknown column "date0"
ALTER TABLE "job_group" DROP COLUMN "date0"
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_account" FOREIGN KEY ("account_id") REFERENCES "account"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group" FOREIGN KEY ("job_group_id1") REFERENCES "job_group"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group2" FOREIGN KEY ("job_group_id2") REFERENCES "job_group"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group3" FOREIGN KEY ("job_group_id3") REFERENCES "job_group"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

-- Index 'idx_job_job_group_id1' was not detected in the database. It will be created
CREATE INDEX "idx_job_job_group_id1" ON "job"("job_group_id1")
;

-- Index 'idx_job_job_group_id2' was not detected in the database. It will be created
CREATE INDEX "idx_job_job_group_id2" ON "job"("job_group_id2")
;

-- Index 'idx_job_job_group_id3' was not detected in the database. It will be created
CREATE INDEX "idx_job_job_group_id3" ON "job"("job_group_id3")
;

