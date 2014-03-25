ALTER TABLE "transaction_line" DROP CONSTRAINT "ref_transaction_line_Job" CASCADE
;

-- dropping table "Job"
DROP TABLE "Job"
;

-- MyERP.DataAccess.Job
CREATE TABLE "job" (
    "user_id2" int8 NOT NULL,               -- _userinfo1
    "user_id0" int8 NOT NULL,               -- _userinfo
    "tien_nt" numeric(38,20) NOT NULL,      -- _tien_nt
    "tien" numeric(38,20) NOT NULL,         -- _tien
    "ten_vv2" text NOT NULL,                -- _ten_vv2
    "ten_vv" text NOT NULL,                 -- _ten_vv
    "status" text NOT NULL,                 -- _status
    "ngay_vv2" date NOT NULL,               -- _ngay_vv2
    "ngay_vv1" date NOT NULL,               -- _ngay_vv1
    "ma_vv" text NOT NULL,                  -- _ma_vv
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "ghi_chu" text NOT NULL,                -- _ghi_chu
    "tk" text NOT NULL,                     -- _dmtk
    "nh_vv3" text NOT NULL,                 -- _dmnhvv2
    "nh_vv2" text NOT NULL,                 -- _dmnhvv1
    "nh_vv1" text NOT NULL,                 -- _dmnhvv
    "ma_kh" text NOT NULL,                  -- _dmkh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_job" PRIMARY KEY ("ma_vv")
)
;

-- MyERP.DataAccess.Module
CREATE TABLE "module" (
    "name" text NOT NULL,                   -- _name
    "id" int8 NOT NULL,                     -- _id
    "group" text NOT NULL,                  -- _group
    "description" text NOT NULL,            -- _description
    CONSTRAINT "pk_mdule" PRIMARY KEY ("id")
)
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_business_partner" FOREIGN KEY ("ma_kh") REFERENCES "business_partner"("code")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group" FOREIGN KEY ("nh_vv1") REFERENCES "job_group"("ma_nh")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group2" FOREIGN KEY ("nh_vv2") REFERENCES "job_group"("ma_nh")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_job_group3" FOREIGN KEY ("nh_vv3") REFERENCES "job_group"("ma_nh")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_account" FOREIGN KEY ("tk") REFERENCES "account"("code")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user" FOREIGN KEY ("user_id0") REFERENCES "user"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user2" FOREIGN KEY ("user_id2") REFERENCES "user"("id")
;

-- Index 'idx_job_nh_vv3' was not detected in the database. It will be created
CREATE INDEX "idx_job_nh_vv3" ON "job"("nh_vv3")
;

-- Index 'idx_job_nh_vv2' was not detected in the database. It will be created
CREATE INDEX "idx_job_nh_vv2" ON "job"("nh_vv2")
;

-- Index 'idx_job_nh_vv1' was not detected in the database. It will be created
CREATE INDEX "idx_job_nh_vv1" ON "job"("nh_vv1")
;

