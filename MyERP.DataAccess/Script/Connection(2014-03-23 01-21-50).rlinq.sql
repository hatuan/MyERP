-- add column for field _fullName
ALTER TABLE "user" ADD COLUMN "full_name" text
;

UPDATE "user" SET "full_name" = ' '
;

ALTER TABLE "user" ALTER COLUMN "full_name" SET  NOT NULL
;

-- add column for field _name
ALTER TABLE "user" ADD COLUMN "name" text
;

UPDATE "user" SET "name" = ' '
;

ALTER TABLE "user" ALTER COLUMN "name" SET  NOT NULL
;

-- dropping unknown column "login_name"
ALTER TABLE "user" DROP COLUMN "login_name"
;

-- dropping unknown column "display_name"
ALTER TABLE "user" DROP COLUMN "display_name"
;

