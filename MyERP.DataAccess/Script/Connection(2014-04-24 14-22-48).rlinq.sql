-- MyERP.DataAccess.Item
CREATE TABLE "Item" (
    "Id" int4 NOT NULL,
    "Id2" int4,                             -- Item._id2
    "ItemDescription" varchar(255),         -- Item._itemDescription
    CONSTRAINT "pk_Item" PRIMARY KEY ("Id")
)
;

-- MyERP.DataAccess.Object
CREATE TABLE "Object" (
    "Id" int4 NOT NULL,                     -- _id
    "nme" varchar(255),                     -- _name
    "voa_class" varchar(255),               -- <internal-class-id>
    CONSTRAINT "pk_Object" PRIMARY KEY ("Id")
)
;

-- MyERP.DataAccess.SaleDetail
CREATE TABLE "SaleDetail" (
    "Id" int4 NOT NULL,                     -- _id
    "ObjectID" int4 NOT NULL,               -- _account
    "ObjectType" varchar(255),              -- _objectType
    CONSTRAINT "pk_SaleDetail" PRIMARY KEY ("Id")
)
;

-- MyERP.DataAccess.Service
CREATE TABLE "Service" (
    "Id" int4 NOT NULL,
    "Id2" int4,                             -- Service._id2
    "ServiceDescription" varchar(255),      -- Service._serviceDescription
    CONSTRAINT "pk_Service" PRIMARY KEY ("Id")
)
;

ALTER TABLE "Item" ADD CONSTRAINT "ref_Item_Object" FOREIGN KEY ("Id") REFERENCES "Object"("Id")
;

ALTER TABLE "SaleDetail" ADD CONSTRAINT "ref_SaleDetail_Object" FOREIGN KEY ("ObjectID") REFERENCES "Object"("Id")
;

ALTER TABLE "Service" ADD CONSTRAINT "ref_Service_Object" FOREIGN KEY ("Id") REFERENCES "Object"("Id")
;

-- Index 'idx_SaleDetail_ObjectID' was not detected in the database. It will be created
CREATE INDEX "idx_SaleDetail_ObjectID" ON "SaleDetail"("ObjectID")
;

