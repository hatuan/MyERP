-- Column was read from database as: "ar_ap" int2 not null
-- modify column for field _arAp
ALTER TABLE "account" ALTER COLUMN "ar_ap" TYPE bool USING "ar_ap"::bool
;

