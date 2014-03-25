-- Index 'idx_account_parent_account_id' was detected in the database but with a different configuration. It will be recreated
DROP INDEX "idx_account_parent_account_id" CASCADE
;

-- Dropping index 'idx_account_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_code" CASCADE
;

-- Dropping index 'idx_user_name' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_user_name" CASCADE
;

-- Column was read from database as: "parent_account_id" uuid not null
-- modify column for field _parentAccount
ALTER TABLE "account" ALTER COLUMN "parent_account_id" TYPE uuid USING "parent_account_id"::uuid
;

ALTER TABLE "account" ALTER COLUMN "parent_account_id" DROP NOT NULL
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "account" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- add column for field _status
ALTER TABLE "business_partner" ADD COLUMN "status" int2
;

UPDATE "business_partner" SET "status" = 0
;

ALTER TABLE "business_partner" ALTER COLUMN "status" SET  NOT NULL
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "business_partner_group" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "currency" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "job" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "job_group" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "organization" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "payment_term" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _Status
ALTER TABLE "transaction_document" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Column was read from database as: "status" text not null
-- modify column for field _status
ALTER TABLE "user" ALTER COLUMN "status" TYPE int2 USING "status"::int2
;

-- Index 'idx_account_parent_account_id' was detected in the database but with a different configuration. It will be recreated
CREATE INDEX "idx_account_parent_account_id" ON "account"("parent_account_id")
;

