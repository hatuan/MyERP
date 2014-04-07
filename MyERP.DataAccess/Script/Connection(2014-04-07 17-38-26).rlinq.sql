ALTER TABLE "transaction_document" DROP CONSTRAINT "ref_transaction_document_user" CASCADE
;

ALTER TABLE "transaction_document" DROP CONSTRAINT "ref_transaction_document_user2" CASCADE
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

-- dropping table "user"
DROP TABLE "user"
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user_detail" FOREIGN KEY ("rec_created_by") REFERENCES "user_detail"("id")
;

ALTER TABLE "account" ADD CONSTRAINT "ref_account_user_detail2" FOREIGN KEY ("rec_modified_by") REFERENCES "user_detail"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsiness_partner_user_detail" FOREIGN KEY ("user_id0") REFERENCES "user_detail"("id")
;

ALTER TABLE "business_partner" ADD CONSTRAINT "ref_bsiness_partner_user_detai2" FOREIGN KEY ("user_id2") REFERENCES "user_detail"("id")
;

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user_detail" FOREIGN KEY ("rec_created_by") REFERENCES "user_detail"("id")
;

ALTER TABLE "currency" ADD CONSTRAINT "ref_currency_user_detail2" FOREIGN KEY ("rec_modified_by") REFERENCES "user_detail"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user_detail" FOREIGN KEY ("user_id0") REFERENCES "user_detail"("id")
;

ALTER TABLE "job" ADD CONSTRAINT "ref_job_user_detail2" FOREIGN KEY ("user_id2") REFERENCES "user_detail"("id")
;

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user_detail" FOREIGN KEY ("user_id0") REFERENCES "user_detail"("id")
;

ALTER TABLE "job_group" ADD CONSTRAINT "ref_job_group_user_detail2" FOREIGN KEY ("user_id2") REFERENCES "user_detail"("id")
;

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user_detail" FOREIGN KEY ("user_id0") REFERENCES "user_detail"("id")
;

ALTER TABLE "organization" ADD CONSTRAINT "ref_organization_user_detail2" FOREIGN KEY ("user_id2") REFERENCES "user_detail"("id")
;

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_trnsctn_dcument_user_detail" FOREIGN KEY ("user_id0") REFERENCES "user_detail"("id")
;

ALTER TABLE "transaction_document" ADD CONSTRAINT "ref_trnsctn_dcument_user_detai2" FOREIGN KEY ("user_id2") REFERENCES "user_detail"("id")
;

