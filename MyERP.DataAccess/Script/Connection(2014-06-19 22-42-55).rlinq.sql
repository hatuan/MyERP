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

-- MyERP.DataAccess.Role
CREATE TABLE "role" (
    "client_id" uuid NOT NULL,              -- _client
    "description" varchar NOT NULL,         -- _description
    "id" uuid NOT NULL,                     -- _id
    "name" varchar NOT NULL,                -- _name
    "organization_id" uuid NOT NULL,        -- _organization
    "rec_created_by" uuid NOT NULL,         -- _user
    "rec_created" timestamp(6) NOT NULL,    -- _recCreated
    "rec_modified" timestamp(6) NOT NULL,   -- _recModified
    "rec_modified_by" uuid NOT NULL,        -- _user1
    "status" int2 NOT NULL,                 -- _status
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_rle" PRIMARY KEY ("id")
)
;

-- MyERP.DataAccess.UserInRole
CREATE TABLE "user_in_role" (
    "id" uuid NOT NULL,                     -- _id
    "role_id" uuid NOT NULL,                -- _role
    "user_id" uuid NOT NULL,                -- _user
    "version" int8 NOT NULL,                -- _version
    CONSTRAINT "pk_user_in_role" PRIMARY KEY ("id")
)
;

ALTER TABLE "role" ADD CONSTRAINT "ref_role_client" FOREIGN KEY ("client_id") REFERENCES "client"("id")
;

ALTER TABLE "role" ADD CONSTRAINT "ref_role_organization" FOREIGN KEY ("organization_id") REFERENCES "organization"("id")
;

ALTER TABLE "role" ADD CONSTRAINT "ref_role_user" FOREIGN KEY ("rec_created_by") REFERENCES "user"("id")
;

ALTER TABLE "role" ADD CONSTRAINT "ref_role_user2" FOREIGN KEY ("rec_modified_by") REFERENCES "user"("id")
;

ALTER TABLE "user_in_role" ADD CONSTRAINT "ref_user_in_role_role" FOREIGN KEY ("role_id") REFERENCES "role"("id")
;

ALTER TABLE "user_in_role" ADD CONSTRAINT "ref_user_in_role_user" FOREIGN KEY ("user_id") REFERENCES "user"("id")
;

-- Index 'idx_UserInRole_UserId' was not detected in the database. It will be created
CREATE INDEX "idx_UserInRole_UserId" ON "user_in_role"("user_id")
;

-- Index 'idx_UserInRole_RoleId' was not detected in the database. It will be created
CREATE INDEX "idx_UserInRole_RoleId" ON "user_in_role"("role_id")
;

