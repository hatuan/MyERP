-- Dropping index 'idx_account_code' which is not configured in OpenAccess but exists on the database.
DROP INDEX "idx_account_code" CASCADE
;

-- MyERP.DataAccess.SaleDetail
CREATE TABLE "SaleDetail" (
    "Id" int4 NOT NULL,                     -- _id
    "ObjectID" int4 NOT NULL,               -- _objectID
    "ObjectType" varchar(255),              -- _objectType
    CONSTRAINT "pk_SaleDetail" PRIMARY KEY ("Id")
)
;

