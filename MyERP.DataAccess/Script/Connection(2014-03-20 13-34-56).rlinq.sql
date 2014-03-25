-- Dropping index 'idx_account_rowguid' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_rowguid" CASCADE
;

-- dropping unknown column "property1"
ALTER TABLE "account" DROP COLUMN "property1"
;

