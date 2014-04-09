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

-- Dropping index 'idx_user_name' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_user_name" CASCADE
;

-- add column for field _createdDate
ALTER TABLE "user" ADD COLUMN "created_date" timestamp
;

UPDATE "user" SET "created_date" = current_timestamp
;

ALTER TABLE "user" ALTER COLUMN "created_date" SET  NOT NULL
;

-- add column for field _email
ALTER TABLE "user" ADD COLUMN "email" text
;

UPDATE "user" SET "email" = ' '
;

ALTER TABLE "user" ALTER COLUMN "email" SET  NOT NULL
;

-- add column for field _isActivated
ALTER TABLE "user" ADD COLUMN "is_activated" bool
;

UPDATE "user" SET "is_activated" = False
;

ALTER TABLE "user" ALTER COLUMN "is_activated" SET  NOT NULL
;

-- add column for field _isLockedOut
ALTER TABLE "user" ADD COLUMN "is_locked_out" bool
;

UPDATE "user" SET "is_locked_out" = False
;

ALTER TABLE "user" ALTER COLUMN "is_locked_out" SET  NOT NULL
;

-- add column for field _lastLockedOutDate
ALTER TABLE "user" ADD COLUMN "last_locked_out_date" timestamp
;

UPDATE "user" SET "last_locked_out_date" = current_timestamp
;

ALTER TABLE "user" ALTER COLUMN "last_locked_out_date" SET  NOT NULL
;

-- add column for field _lastLockedOutReason
ALTER TABLE "user" ADD COLUMN "last_locked_out_reason" text
;

UPDATE "user" SET "last_locked_out_reason" = ' '
;

ALTER TABLE "user" ALTER COLUMN "last_locked_out_reason" SET  NOT NULL
;

-- add column for field _lastLoginDate
ALTER TABLE "user" ADD COLUMN "last_login_date" timestamp
;

UPDATE "user" SET "last_login_date" = current_timestamp
;

ALTER TABLE "user" ALTER COLUMN "last_login_date" SET  NOT NULL
;

-- add column for field _lastLoginIp
ALTER TABLE "user" ADD COLUMN "last_login_ip" text
;

UPDATE "user" SET "last_login_ip" = ' '
;

ALTER TABLE "user" ALTER COLUMN "last_login_ip" SET  NOT NULL
;

-- add column for field _lastModifiedDate
ALTER TABLE "user" ADD COLUMN "last_modified_date" timestamp
;

UPDATE "user" SET "last_modified_date" = current_timestamp
;

ALTER TABLE "user" ALTER COLUMN "last_modified_date" SET  NOT NULL
;

-- add column for field _passwordAnswer
ALTER TABLE "user" ADD COLUMN "password_answer" text
;

UPDATE "user" SET "password_answer" = ' '
;

ALTER TABLE "user" ALTER COLUMN "password_answer" SET  NOT NULL
;

-- add column for field _passwordQuestion
ALTER TABLE "user" ADD COLUMN "password_question " text
;

UPDATE "user" SET "password_question " = ' '
;

ALTER TABLE "user" ALTER COLUMN "password_question " SET  NOT NULL
;

-- dropping unknown column "status"
ALTER TABLE "user" DROP COLUMN "status"
;

-- dropping unknown column "r_search"
ALTER TABLE "user" DROP COLUMN "r_search"
;

-- dropping unknown column "r_read"
ALTER TABLE "user" DROP COLUMN "r_read"
;

-- dropping unknown column "r_print"
ALTER TABLE "user" DROP COLUMN "r_print"
;

-- dropping unknown column "r_edit"
ALTER TABLE "user" DROP COLUMN "r_edit"
;

-- dropping unknown column "r_del"
ALTER TABLE "user" DROP COLUMN "r_del"
;

-- dropping unknown column "r_add"
ALTER TABLE "user" DROP COLUMN "r_add"
;

-- dropping unknown column "r_access"
ALTER TABLE "user" DROP COLUMN "r_access"
;

-- dropping unknown column "administrator"
ALTER TABLE "user" DROP COLUMN "administrator"
;

