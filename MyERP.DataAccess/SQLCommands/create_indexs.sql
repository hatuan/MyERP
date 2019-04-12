/**************************** USER ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_name' AND objects.name = 'user')
BEGIN
	CREATE INDEX idx_user_name ON dbo."user" ("name")
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_client_id' AND objects.name = 'user')
BEGIN
	CREATE INDEX idx_user_client_id ON dbo."user" (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_organization_id' AND objects.name = 'user')
BEGIN
	CREATE INDEX idx_user_organization_id ON dbo."user" (organization_id)
END
GO

/**************************** ROLE ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_role_client_id' AND objects.name = 'role')
BEGIN
	CREATE INDEX idx_role_client_id ON dbo."role" (client_id)
END
GO

/**************************** USER_IN_ROLE ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_in_role_role_id' AND objects.name = 'user_in_role')
BEGIN
	CREATE INDEX idx_user_in_role_role_id ON dbo.user_in_role (role_id)
END
GO


IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_in_role_user_id' AND objects.name = 'user_in_role')
BEGIN
	CREATE INDEX idx_user_in_role_user_id ON dbo.user_in_role (user_id)
END
GO


/**************************** CLIENT ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_client_currency_lcy_id' AND objects.name = 'client')
BEGIN
	CREATE INDEX idx_client_currency_lcy_id ON dbo.client (currency_lcy_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_client_rec_created_by' AND objects.name = 'client')
BEGIN
	CREATE INDEX idx_client_rec_created_by ON dbo.client (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_client_rec_modified_by' AND objects.name = 'client')
BEGIN
	CREATE INDEX idx_client_rec_modified_by ON dbo.client (rec_modified_by)
END
GO

/**************************** ORGANIZATION ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_code' AND objects.name = 'organization')
BEGIN
	CREATE UNIQUE INDEX idx_organization_code ON dbo.organization (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_client_id' AND objects.name = 'organization')
BEGIN
	CREATE INDEX idx_organization_client_id ON dbo.organization (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_rec_created_by' AND objects.name = 'organization')
BEGIN
	CREATE INDEX idx_organization_rec_created_by ON dbo.organization (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_rec_modified_by' AND objects.name = 'organization')
BEGIN
	CREATE INDEX idx_organization_rec_modified_by ON dbo.organization (rec_modified_by)
END
GO

/**************************** CURRENCY ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_code' AND objects.name = 'currency')
BEGIN
	CREATE UNIQUE INDEX idx_currency_code ON dbo.currency (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_client_id' AND objects.name = 'currency')
BEGIN
	CREATE INDEX idx_currency_client_id ON dbo.currency (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_organization_id' AND objects.name = 'currency')
BEGIN
	CREATE INDEX idx_currency_organization_id ON dbo.currency (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_rec_created_by' AND objects.name = 'currency')
BEGIN
	CREATE INDEX idx_currency_rec_created_by ON dbo.currency (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_rec_modified_by' AND objects.name = 'currency')
BEGIN
	CREATE INDEX idx_currency_rec_modified_by ON dbo.currency (rec_modified_by)
END
GO

/**************************** OPTION ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_client_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_client_id ON dbo."option" (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_organization_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_organization_id ON dbo."option" (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_rec_created_by' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_rec_created_by ON dbo."option" (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_rec_modified_by' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_rec_modified_by ON dbo."option" (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_pos_location_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_sales_pos_location_id ON dbo."option" (sales_pos_location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_pos_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_sales_pos_sequence_id ON dbo."option" (sales_pos_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_order_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_sales_order_sequence_id ON dbo."option" (sales_order_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_shipment_seq_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_sales_shipment_seq_id ON dbo."option" (sales_shipment_seq_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_invoice_seq_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_sales_invoice_seq_id ON dbo."option" (sales_invoice_seq_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_purch_order_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_purch_order_sequence_id ON dbo."option" (purch_order_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_purch_receive_seq_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_purch_receive_seq_id ON dbo."option" (purch_receive_seq_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_purch_invoice_seq_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_purch_invoice_seq_id ON dbo."option" (purch_invoice_seq_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_one_time_business_partner_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_one_time_business_partner_id ON dbo."option" (one_time_business_partner_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_general_ledger_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_general_ledger_sequence_id ON dbo."option" (general_ledger_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_cash_receipt_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_cash_receipt_sequence_id ON dbo."option" (cash_receipt_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_cash_payment_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_cash_payment_sequence_id ON dbo."option" (cash_payment_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_bank_receipt_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_bank_receipt_sequence_id ON dbo."option" (bank_receipt_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_bank_checkque_sequence_id' AND objects.name = 'option')
BEGIN
	CREATE INDEX idx_option_bank_checkque_sequence_id ON dbo."option" (bank_checkque_sequence_id)
END
GO

/**************************** REPORT ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_report_rep_id' AND objects.name = 'report')
BEGIN
	CREATE INDEX idx_report_rep_id ON dbo.report (rep_id)
END
GO

/**************************** NOSEQUENCE ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_code' AND objects.name = 'no_sequence')
BEGIN
	CREATE UNIQUE INDEX idx_no_sequence_code ON dbo.no_sequence (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_client_id' AND objects.name = 'no_sequence')
BEGIN
	CREATE INDEX idx_no_sequence_client_id ON dbo.no_sequence (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_organization_id' AND objects.name = 'no_sequence')
BEGIN
	CREATE INDEX idx_no_sequence_organization_id ON dbo.no_sequence (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_rec_created_by' AND objects.name = 'no_sequence')
BEGIN
	CREATE INDEX idx_no_sequence_rec_created_by ON dbo.no_sequence (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_rec_modified_by' AND objects.name = 'no_sequence')
BEGIN
	CREATE INDEX idx_no_sequence_rec_modified_by ON dbo.no_sequence (rec_modified_by)
END
GO

/**************************** NOSEQUENCELINE ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_no_sequence_id' AND objects.name = 'no_sequence_line')
BEGIN
	CREATE INDEX idx_no_sequence_line_no_sequence_id ON dbo.no_sequence_line (no_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_client_id' AND objects.name = 'no_sequence_line')
BEGIN
	CREATE INDEX idx_no_sequence_line_client_id ON dbo.no_sequence_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_organization_id' AND objects.name = 'no_sequence_line')
BEGIN
	CREATE INDEX idx_no_sequence_line_organization_id ON dbo.no_sequence_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_rec_created_by' AND objects.name = 'no_sequence_line')
BEGIN
	CREATE INDEX idx_no_sequence_line_rec_created_by ON dbo.no_sequence_line (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_rec_modified_by' AND objects.name = 'no_sequence_line')
BEGIN
	CREATE INDEX idx_no_sequence_line_rec_modified_by ON dbo.no_sequence_line (rec_modified_by)
END
GO

/**************************** ACCOUNT ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_code' AND objects.name = 'account')
BEGIN
	CREATE UNIQUE INDEX idx_account_code ON dbo.account (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_client_id' AND objects.name = 'account')
BEGIN
	CREATE INDEX idx_account_client_id ON dbo.account (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_organization_id' AND objects.name = 'account')
BEGIN
	CREATE INDEX idx_account_organization_id ON dbo.account (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_rec_created_by' AND objects.name = 'account')
BEGIN
	CREATE INDEX idx_account_rec_created_by ON dbo.account (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_rec_modified_by' AND objects.name = 'account')
BEGIN
	CREATE INDEX idx_account_rec_modified_by ON dbo.account (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_parent_id' AND objects.name = 'account')
BEGIN
	CREATE INDEX idx_account_parent_id ON dbo.account (parent_id)
END
GO

/**************************** BusinessPartner ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_code' AND objects.name = 'business_partner')
BEGIN
	CREATE UNIQUE INDEX idx_business_partner_code ON dbo.business_partner (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_client_id' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_client_id ON dbo.business_partner (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_organization_id' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_organization_id ON dbo.business_partner (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_rec_created_by' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_rec_created_by ON dbo.business_partner (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_rec_modified_by' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_rec_modified_by ON dbo.business_partner (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_id' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_price_group_id ON dbo.business_partner (business_partner_price_group_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_id1' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_group_id1 ON dbo.business_partner (business_partner_group_id1)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_id2' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_group_id2 ON dbo.business_partner (business_partner_group_id2)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_id3' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_group_id3 ON dbo.business_partner (business_partner_group_id3)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_disc_group_id' AND objects.name = 'business_partner')
BEGIN
	CREATE INDEX idx_business_partner_disc_group_id ON dbo.business_partner (bus_partner_disc_group_id)
END
GO

/**************************** business_partner_discount_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_code' AND objects.name = 'business_partner_discount_group')
BEGIN
	CREATE UNIQUE INDEX idx_business_partner_discount_group_code ON dbo.business_partner_discount_group (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_client_id' AND objects.name = 'business_partner_discount_group')
BEGIN
	CREATE INDEX idx_business_partner_discount_group_client_id ON dbo.business_partner_discount_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_organization_id' AND objects.name = 'business_partner_discount_group')
BEGIN
	CREATE INDEX idx_business_partner_discount_group_organization_id ON dbo.business_partner_discount_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_rec_created_by' AND objects.name = 'business_partner_discount_group')
BEGIN
	CREATE INDEX idx_business_partner_discount_group_rec_created_by ON dbo.business_partner_discount_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_rec_modified_by' AND objects.name = 'business_partner_discount_group')
BEGIN
	CREATE INDEX idx_business_partner_discount_group_rec_modified_by ON dbo.business_partner_discount_group (rec_modified_by)
END
GO

/**************************** business_partner_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_code' AND objects.name = 'business_partner_group')
BEGIN
	CREATE UNIQUE INDEX idx_business_partner_group_code ON dbo.business_partner_group (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_client_id' AND objects.name = 'business_partner_group')
BEGIN
	CREATE INDEX idx_business_partner_group_client_id ON dbo.business_partner_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_organization_id' AND objects.name = 'business_partner_group')
BEGIN
	CREATE INDEX idx_business_partner_group_organization_id ON dbo.business_partner_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_rec_created_by' AND objects.name = 'business_partner_group')
BEGIN
	CREATE INDEX idx_business_partner_group_rec_created_by ON dbo.business_partner_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_rec_modified_by' AND objects.name = 'business_partner_group')
BEGIN
	CREATE INDEX idx_business_partner_group_rec_modified_by ON dbo.business_partner_group (rec_modified_by)
END
GO

/**************************** business_partner_price_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_code' AND objects.name = 'business_partner_price_group')
BEGIN
	CREATE UNIQUE INDEX idx_business_partner_price_group_code ON dbo.business_partner_price_group (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_client_id' AND objects.name = 'business_partner_price_group')
BEGIN
	CREATE INDEX idx_business_partner_price_group_client_id ON dbo.business_partner_price_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_organization_id' AND objects.name = 'business_partner_price_group')
BEGIN
	CREATE INDEX idx_business_partner_price_group_organization_id ON dbo.business_partner_price_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_rec_created_by' AND objects.name = 'business_partner_price_group')
BEGIN
	CREATE INDEX idx_business_partner_price_group_rec_created_by ON dbo.business_partner_price_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_rec_modified_by' AND objects.name = 'business_partner_price_group')
BEGIN
	CREATE INDEX idx_business_partner_price_group_rec_modified_by ON dbo.business_partner_price_group (rec_modified_by)
END
GO

/**************************** cash_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_client_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_client_id ON dbo.cash_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_organization_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_organization_id ON dbo.cash_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_rec_created_by' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_rec_created_by ON dbo.cash_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_rec_modified_by' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_rec_modified_by ON dbo.cash_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_doc_sequence_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_doc_sequence_id ON dbo.cash_header (doc_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_doc_sub_type' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_doc_sub_type ON dbo.cash_header (document_type, doc_sub_type)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_document_no' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_document_no ON dbo.cash_header (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_document_date' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_document_date ON dbo.cash_header (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_posting_date' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_posting_date ON dbo.cash_header (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_business_partner_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_business_partner_id ON dbo.cash_header (business_partner_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_business_partner_contact_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_business_partner_contact_id ON dbo.cash_header (business_partner_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_account_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_account_id ON dbo.cash_header (account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_currency_id' AND objects.name = 'cash_header')
BEGIN
	CREATE INDEX idx_cash_header_currency_id ON dbo.cash_header (currency_id)
END
GO

/**************************** cash_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_client_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_client_id ON dbo.cash_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_organization_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_organization_id ON dbo.cash_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_cash_header_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_cash_header_id ON dbo.cash_line (cash_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_document_no' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_document_no ON dbo.cash_line (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_posting_date' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_posting_date ON dbo.cash_line (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_business_partner_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_business_partner_id ON dbo.cash_line (business_partner_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_corresp_account_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_corresp_account_id ON dbo.cash_line (corresp_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_job_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_job_id ON dbo.cash_line (job_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_accounts_payable_ledger_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_accounts_payable_ledger_id ON dbo.cash_line (accounts_payable_ledger_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_accounts_receivable_ledger_id' AND objects.name = 'cash_line')
BEGIN
	CREATE INDEX idx_cash_line_accounts_receivable_ledger_id ON dbo.cash_line (accounts_receivable_ledger_id)
END
GO

/**************************** einv_form_release ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_client_id' AND objects.name = 'einv_form_release')
BEGIN
	CREATE INDEX idx_einv_form_release_client_id ON dbo.einv_form_release (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_organization_id' AND objects.name = 'einv_form_release')
BEGIN
	CREATE INDEX idx_einv_form_release_organization_id ON dbo.einv_form_release (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_rec_created_by' AND objects.name = 'einv_form_release')
BEGIN
	CREATE INDEX idx_einv_form_release_rec_created_by ON dbo.einv_form_release (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_rec_modified_by' AND objects.name = 'einv_form_release')
BEGIN
	CREATE INDEX idx_einv_form_release_rec_modified_by ON dbo.einv_form_release (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_form_type_id' AND objects.name = 'einv_form_release')
BEGIN
	CREATE INDEX idx_einv_form_release_form_type_id ON dbo.einv_form_release (form_type_id)
END
GO

/**************************** einv_form_type ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_client_id' AND objects.name = 'einv_form_type')
BEGIN
	CREATE INDEX idx_einv_form_type_client_id ON dbo.einv_form_type (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_organization_id' AND objects.name = 'einv_form_type')
BEGIN
	CREATE INDEX idx_einv_form_type_organization_id ON dbo.einv_form_type (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_rec_created_by' AND objects.name = 'einv_form_type')
BEGIN
	CREATE INDEX idx_einv_form_type_rec_created_by ON dbo.einv_form_type (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_rec_modified_by' AND objects.name = 'einv_form_type')
BEGIN
	CREATE INDEX idx_einv_form_type_rec_modified_by ON dbo.einv_form_type (rec_modified_by)
END
GO

/**************************** einvoice_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_client_id' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_client_id ON dbo.einvoice_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_organization_id' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_organization_id ON dbo.einvoice_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_rec_created_by' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_rec_created_by ON dbo.einvoice_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_rec_modified_by' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_rec_modified_by ON dbo.einvoice_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_form_type_id' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_form_type_id ON dbo.einvoice_header (form_type_id)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_invoice_number' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_invoice_number ON dbo.einvoice_header (invoice_number)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_invoice_issued_date' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_invoice_issued_date ON dbo.einvoice_header (invoice_issued_date)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_currency_id' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_currency_id ON dbo.einvoice_header (currency_id)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_buyer_id' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_buyer_id ON dbo.einvoice_header (buyer_id)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_buyer_tax_code' AND objects.name = 'einvoice_header')
BEGIN
	CREATE INDEX idx_einvoice_header_buyer_tax_code ON dbo.einvoice_header (buyer_tax_code)
END

/**************************** einvoice_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_client_id' AND objects.name = 'einvoice_line')
BEGIN
	CREATE INDEX idx_einvoice_line_client_id ON dbo.einvoice_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_organization_id' AND objects.name = 'einvoice_line')
BEGIN
	CREATE INDEX idx_einvoice_line_organization_id ON dbo.einvoice_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_einvoice_header_id' AND objects.name = 'einvoice_line')
BEGIN
	CREATE INDEX idx_einvoice_line_einvoice_header_id ON dbo.einvoice_line (einvoice_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_item_id' AND objects.name = 'einvoice_line')
BEGIN
	CREATE INDEX idx_einvoice_line_item_id ON dbo.einvoice_line (item_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_unit_id' AND objects.name = 'einvoice_line')
BEGIN
	CREATE INDEX idx_einvoice_line_unit_id ON dbo.einvoice_line (unit_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_vat_id' AND objects.name = 'einvoice_line')
BEGIN
	CREATE INDEX idx_einvoice_line_vat_id ON dbo.einvoice_line (vat_id)
END
GO

/**************************** einvoice_signed ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_client_id' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_client_id ON dbo.einvoice_signed (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_organization_id' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_organization_id ON dbo.einvoice_signed (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_rec_created_by' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_rec_created_by ON dbo.einvoice_signed (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_rec_modified_by' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_rec_modified_by ON dbo.einvoice_signed (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_form_type_id' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_form_type_id ON dbo.einvoice_signed (form_type_id)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_invoice_series' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_invoice_series ON dbo.einvoice_signed (invoice_series)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_invoice_number' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_invoice_number ON dbo.einvoice_signed (invoice_number)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_invoice_issued_date' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_invoice_issued_date ON dbo.einvoice_signed (invoice_issued_date)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_signed_date' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_signed_date ON dbo.einvoice_signed (signed_date)
END

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_buyer_tax_code' AND objects.name = 'einvoice_signed')
BEGIN
	CREATE INDEX idx_einvoice_signed_buyer_tax_code ON dbo.einvoice_signed (buyer_tax_code)
END

/**************************** general_journal_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_client_id' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_client_id ON dbo.general_journal_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_organization_id' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_organization_id ON dbo.general_journal_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_rec_created_by' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_rec_created_by ON dbo.general_journal_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_rec_modified_by' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_rec_modified_by ON dbo.general_journal_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_doc_sub_type' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_doc_sub_type ON dbo.general_journal_header (document_type, doc_sub_type)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_doc_sequence_id' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_doc_sequence_id ON dbo.general_journal_header (doc_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_document_no' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_document_no ON dbo.general_journal_header (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_document_date' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_document_date ON dbo.general_journal_header (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_posting_date' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_posting_date ON dbo.general_journal_header (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_currency_id' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_currency_id ON dbo.general_journal_header (currency_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_currency_id' AND objects.name = 'general_journal_header')
BEGIN
	CREATE INDEX idx_general_journal_header_currency_id ON dbo.general_journal_header (currency_id)
END
GO

/**************************** general_journal_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_client_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_client_id ON dbo.general_journal_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_organization_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_organization_id ON dbo.general_journal_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_general_journal_header_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_general_journal_header_id ON dbo.general_journal_line (general_journal_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_account_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_account_id ON dbo.general_journal_line (account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_document_no' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_document_no ON dbo.general_journal_line (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_posting_date' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_posting_date ON dbo.general_journal_line (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_business_partner_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_business_partner_id ON dbo.general_journal_line (business_partner_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_job_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_job_id ON dbo.general_journal_line (job_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_fix_asset_id' AND objects.name = 'general_journal_line')
BEGIN
	CREATE INDEX idx_general_journal_line_fix_asset_id ON dbo.general_journal_line (fix_asset_id)
END
GO

/**************************** item ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_client_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_client_id ON dbo.item (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_organization_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_organization_id ON dbo.item (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_rec_created_by' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_rec_created_by ON dbo.item (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_rec_modified_by' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_rec_modified_by ON dbo.item (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_code' AND objects.name = 'item')
BEGIN
	CREATE UNIQUE INDEX idx_item_code ON dbo.item (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_base_uom_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_base_uom_id ON dbo.item (base_uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_group_id1' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_item_group_id1 ON dbo.item (item_group_id1)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_group_id2' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_item_group_id2 ON dbo.item (item_group_id2)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_group_id3' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_item_group_id3 ON dbo.item (item_group_id3)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_discount_group_id ON dbo.item (item_discount_group_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_purch_vendor_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_purch_vendor_id ON dbo.item (purch_vendor_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_uom_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_sales_uom_id ON dbo.item (sales_uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_purch_uom_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_purch_uom_id ON dbo.item (purch_uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_vat_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_vat_id ON dbo.item (vat_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_inventory_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_inventory_account_id ON dbo.item (inventory_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_sales_account_id ON dbo.item (sales_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_cogs_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_cogs_account_id ON dbo.item (cogs_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_internal_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_sales_internal_account_id ON dbo.item (sales_internal_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_return_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_sales_return_account_id ON dbo.item (sales_return_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_wip_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_wip_account_id ON dbo.item (wip_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_discount_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_sales_discount_account_id ON dbo.item (sales_discount_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_cogs_diff_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_cogs_diff_account_id ON dbo.item (cogs_diff_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_consignment_account_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_consignment_account_id ON dbo.item (consignment_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_routing_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_routing_id ON dbo.item (routing_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_bom_id' AND objects.name = 'item')
BEGIN
	CREATE INDEX idx_item_bom_id ON dbo.item (bom_id)
END
GO

/**************************** item_discount_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_client_id' AND objects.name = 'item_discount_group')
BEGIN
	CREATE INDEX idx_item_discount_group_client_id ON dbo.item_discount_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_organization_id' AND objects.name = 'item_discount_group')
BEGIN
	CREATE INDEX idx_item_discount_group_organization_id ON dbo.item_discount_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_rec_created_by' AND objects.name = 'item_discount_group')
BEGIN
	CREATE INDEX idx_item_discount_group_rec_created_by ON dbo.item_discount_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_rec_modified_by' AND objects.name = 'item_discount_group')
BEGIN
	CREATE INDEX idx_item_discount_group_rec_modified_by ON dbo.item_discount_group (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_code' AND objects.name = 'item_discount_group')
BEGIN
	CREATE UNIQUE INDEX idx_item_discount_group_code ON dbo.item_discount_group (code, client_id)
END
GO

/**************************** item_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_client_id' AND objects.name = 'item_group')
BEGIN
	CREATE INDEX idx_item_group_client_id ON dbo.item_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_organization_id' AND objects.name = 'item_group')
BEGIN
	CREATE INDEX idx_item_group_organization_id ON dbo.item_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_created_by' AND objects.name = 'item_group')
BEGIN
	CREATE INDEX idx_item_group_rec_created_by ON dbo.item_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_modified_by' AND objects.name = 'item_group')
BEGIN
	CREATE INDEX idx_item_group_rec_modified_by ON dbo.item_group (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_code' AND objects.name = 'item_group')
BEGIN
	CREATE UNIQUE INDEX idx_item_group_code ON dbo.item_group (code, client_id)
END
GO

/**************************** item_uom ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_client_id' AND objects.name = 'item_uom')
BEGIN
	CREATE INDEX idx_item_group_client_id ON dbo.item_uom (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_organization_id' AND objects.name = 'item_uom')
BEGIN
	CREATE INDEX idx_item_group_organization_id ON dbo.item_uom (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_created_by' AND objects.name = 'item_uom')
BEGIN
	CREATE INDEX idx_item_group_rec_created_by ON dbo.item_uom (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_modified_by' AND objects.name = 'item_uom')
BEGIN
	CREATE INDEX idx_item_group_rec_modified_by ON dbo.item_uom (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_uom_id' AND objects.name = 'item_uom')
BEGIN
	CREATE INDEX idx_item_uom_id ON dbo.item_uom (uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_id' AND objects.name = 'item_uom')
BEGIN
	CREATE INDEX idx_item_item_id ON dbo.item_uom (item_id)
END
GO

/**************************** job ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_client_id' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_client_id ON dbo.job (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_organization_id' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_organization_id ON dbo.job (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_rec_created_by' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_rec_created_by ON dbo.job (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_rec_modified_by' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_rec_modified_by ON dbo.job (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_code' AND objects.name = 'job')
BEGIN
	CREATE UNIQUE INDEX idx_job_code ON dbo.job (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_job_group_id1' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_job_group_id1 ON dbo.job (job_group_id1)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_job_group_id2' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_job_group_id2 ON dbo.job (job_group_id2)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_job_group_id3' AND objects.name = 'job')
BEGIN
	CREATE INDEX idx_job_job_group_id3 ON dbo.job (job_group_id3)
END
GO

/**************************** job_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_client_id' AND objects.name = 'job_group')
BEGIN
	CREATE INDEX idx_job_group_client_id ON dbo.job_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_organization_id' AND objects.name = 'job_group')
BEGIN
	CREATE INDEX idx_job_group_organization_id ON dbo.job_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_rec_created_by' AND objects.name = 'job_group')
BEGIN
	CREATE INDEX idx_job_group_rec_created_by ON dbo.job_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_rec_modified_by' AND objects.name = 'job_group')
BEGIN
	CREATE INDEX idx_job_group_rec_modified_by ON dbo.job_group (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_code' AND objects.name = 'job_group')
BEGIN
	CREATE UNIQUE INDEX idx_job_group_code ON dbo.job_group (code, client_id)
END
GO

/**************************** location ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_client_id' AND objects.name = 'location')
BEGIN
	CREATE INDEX idx_location_client_id ON dbo.location (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_organization_id' AND objects.name = 'location')
BEGIN
	CREATE INDEX idx_location_organization_id ON dbo.location (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_rec_created_by' AND objects.name = 'location')
BEGIN
	CREATE INDEX idx_location_rec_created_by ON dbo.location (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_rec_modified_by' AND objects.name = 'location')
BEGIN
	CREATE INDEX idx_location_rec_modified_by ON dbo.location (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_code' AND objects.name = 'location')
BEGIN
	CREATE UNIQUE INDEX idx_location_code ON dbo.location (code, client_id)
END
GO

/**************************** pos_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_client_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_client_id ON dbo.pos_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_organization_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_organization_id ON dbo.pos_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_rec_created_by' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_rec_created_by ON dbo.pos_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_rec_modified_by' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_rec_modified_by ON dbo.pos_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_doc_sequence_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_doc_sequence_id ON dbo.pos_header (doc_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_document_no' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_document_no ON dbo.pos_header (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_document_date' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_document_date ON dbo.pos_header (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_sell_to_customer_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_sell_to_customer_id ON dbo.pos_header (sell_to_customer_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_sell_to_contact_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_sell_to_contact_id ON dbo.pos_header (sell_to_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_bill_to_customer_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_bill_to_customer_id ON dbo.pos_header (bill_to_customer_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_bill_to_contact_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_bill_to_contact_id ON dbo.pos_header (bill_to_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_bill_to_vat_code' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_bill_to_vat_code ON dbo.pos_header (bill_to_vat_code)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_currency_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_currency_id ON dbo.pos_header (currency_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_sales_person_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_sales_person_id ON dbo.pos_header (sales_person_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_location_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_location_id ON dbo.pos_header (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_discount_id' AND objects.name = 'pos_header')
BEGIN
	CREATE INDEX idx_pos_header_discount_id ON dbo.pos_header (discount_id)
END
GO

/**************************** pos_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_client_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_client_id ON dbo.pos_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_organization_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_organization_id ON dbo.pos_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_pos_header_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_pos_header_id ON dbo.pos_line (pos_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_item_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_item_id ON dbo.pos_line (item_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_location_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_location_id ON dbo.pos_line (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_uom_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_uom_id ON dbo.pos_line (uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_sales_price_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_sales_price_id ON dbo.pos_line (sales_price_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_vat_identifier_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_vat_identifier_id ON dbo.pos_line (vat_identifier_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_discount_id' AND objects.name = 'pos_line')
BEGIN
	CREATE INDEX idx_pos_line_discount_id ON dbo.pos_line (discount_id)
END
GO

/**************************** purchase_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_client_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_client_id ON dbo.purchase_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_organization_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_organization_id ON dbo.purchase_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_rec_created_by' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_rec_created_by ON dbo.purchase_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_rec_modified_by' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_rec_modified_by ON dbo.purchase_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_doc_sequence_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_doc_sequence_id ON dbo.purchase_header (doc_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_document_no' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_document_no ON dbo.purchase_header (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_document_date' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_document_date ON dbo.purchase_header (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_buy_from_vendor_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_buy_from_vendor_id ON dbo.purchase_header (buy_from_vendor_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_buy_from_contact_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_buy_from_contact_id ON dbo.purchase_header (buy_from_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_pay_to_vendor_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_pay_to_vendor_id ON dbo.purchase_header (pay_to_vendor_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_pay_to_contact_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_pay_to_contact_id ON dbo.purchase_header (pay_to_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_currency_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_currency_id ON dbo.purchase_header (currency_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_sales_person_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_sales_person_id ON dbo.purchase_header (sales_person_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_quote_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_quote_id ON dbo.purchase_header (quote_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_campaign_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_campaign_id ON dbo.purchase_header (campaign_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_opportunity_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_opportunity_id ON dbo.purchase_header (opportunity_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_location_id' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_location_id ON dbo.purchase_header (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_doc_sub_type' AND objects.name = 'purchase_header')
BEGIN
	CREATE INDEX idx_purchase_header_doc_sub_type ON dbo.purchase_header (document_type, doc_sub_type)
END
GO

/**************************** purchase_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_client_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_client_id ON dbo.purchase_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_organization_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_organization_id ON dbo.purchase_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_purchase_header_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_purchase_header_id ON dbo.purchase_line (purchase_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_item_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_item_id ON dbo.purchase_line (item_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_location_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_location_id ON dbo.purchase_line (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_uom_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_uom_id ON dbo.purchase_line (uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_discount_id' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_discount_id ON dbo.purchase_line (discount_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_document_no' AND objects.name = 'purchase_line')
BEGIN
	CREATE INDEX idx_purchase_line_document_no ON dbo.purchase_line (document_no)
END
GO

/**************************** purchase_invoice_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_client_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_client_id ON dbo.purchase_invoice_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_organization_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_organization_id ON dbo.purchase_invoice_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_rec_created_by' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_rec_created_by ON dbo.purchase_invoice_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_rec_modified_by' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_rec_modified_by ON dbo.purchase_invoice_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_doc_sequence_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_doc_sequence_id ON dbo.purchase_invoice_header (doc_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_document_no' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_document_no ON dbo.purchase_invoice_header (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_document_date' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_document_date ON dbo.purchase_invoice_header (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_posting_date' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_posting_date ON dbo.purchase_invoice_header (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_buy_from_vendor_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_buy_from_vendor_id ON dbo.purchase_invoice_header (buy_from_vendor_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_buy_from_contact_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_buy_from_contact_id ON dbo.purchase_invoice_header (buy_from_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_pay_to_vendor_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_pay_to_vendor_id ON dbo.purchase_invoice_header (pay_to_vendor_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_pay_to_contact_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_pay_to_contact_id ON dbo.purchase_invoice_header (pay_to_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_currency_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_currency_id ON dbo.purchase_invoice_header (currency_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_sales_person_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_sales_person_id ON dbo.purchase_invoice_header (sales_person_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_quote_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_quote_id ON dbo.purchase_invoice_header (quote_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_campaign_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_campaign_id ON dbo.purchase_invoice_header (campaign_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_opportunity_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_opportunity_id ON dbo.purchase_invoice_header (opportunity_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_location_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_location_id ON dbo.purchase_invoice_header (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_discount_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_discount_id ON dbo.purchase_invoice_header (discount_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_doc_sub_type' AND objects.name = 'purchase_invoice_header')
BEGIN
	CREATE INDEX idx_purchase_invoice_header_doc_sub_type ON dbo.purchase_invoice_header (document_type, doc_sub_type)
END
GO

/**************************** purchase_invoice_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_client_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_client_id ON dbo.purchase_invoice_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_organization_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_organization_id ON dbo.purchase_invoice_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_purchase_header_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_purchase_header_id ON dbo.purchase_invoice_line (purchase_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_item_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_item_id ON dbo.purchase_invoice_line (item_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_location_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_location_id ON dbo.purchase_invoice_line (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_uom_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_uom_id ON dbo.purchase_invoice_line (uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_discount_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_discount_id ON dbo.purchase_invoice_line (discount_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_document_no' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_document_no ON dbo.purchase_invoice_line (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_posting_date' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_posting_date ON dbo.purchase_invoice_line (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_vat_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_vat_id ON dbo.purchase_invoice_line (vat_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_inventory_account_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	CREATE INDEX idx_purchase_invoice_line_inventory_account_id ON dbo.purchase_invoice_line (inventory_account_id)
END
GO

/**************************** sales_header ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_client_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_client_id ON dbo.sales_header (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_organization_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_organization_id ON dbo.sales_header (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_rec_created_by' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_rec_created_by ON dbo.sales_header (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_rec_modified_by' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_rec_modified_by ON dbo.sales_header (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_doc_sequence_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_doc_sequence_id ON dbo.sales_header (doc_sequence_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_document_no' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_document_no ON dbo.sales_header (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_document_date' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_document_date ON dbo.sales_header (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_posting_date' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_posting_date ON dbo.sales_header (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_sell_to_customer_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_sell_to_customer_id ON dbo.sales_header (sell_to_customer_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_sell_to_contact_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_sell_to_contact_id ON dbo.sales_header (sell_to_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_bill_to_customer_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_bill_to_customer_id ON dbo.sales_header (bill_to_customer_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_bill_to_contact_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_bill_to_contact_id ON dbo.sales_header (bill_to_contact_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_currency_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_currency_id ON dbo.sales_header (currency_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_sales_person_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_sales_person_id ON dbo.sales_header (sales_person_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_quote_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_quote_id ON dbo.sales_header (quote_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_campaign_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_campaign_id ON dbo.sales_header (campaign_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_opportunity_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_opportunity_id ON dbo.sales_header (opportunity_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_location_id' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_location_id ON dbo.sales_header (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_doc_sub_type' AND objects.name = 'sales_header')
BEGIN
	CREATE INDEX idx_sales_header_doc_sub_type ON dbo.sales_header (document_type, doc_sub_type)
END
GO

/**************************** sales_line ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_client_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_client_id ON dbo.sales_line (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_organization_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_organization_id ON dbo.sales_line (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_sales_header_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_sales_header_id ON dbo.sales_line (sales_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_item_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_item_id ON dbo.sales_line (item_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_location_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_location_id ON dbo.sales_line (location_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_uom_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_uom_id ON dbo.sales_line (uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_line_discount_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_line_discount_id ON dbo.sales_line (discount_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_document_no' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_document_no ON dbo.sales_line (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_posting_date' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_posting_date ON dbo.sales_line (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_vat_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_vat_id ON dbo.sales_line (vat_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_sales_price_id' AND objects.name = 'sales_line')
BEGIN
	CREATE INDEX idx_sales_line_sales_price_id ON dbo.sales_line (sales_price_id)
END
GO

/**************************** sales_price ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_client_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_client_id ON dbo.sales_price (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_organization_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_organization_id ON dbo.sales_price (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_rec_created_by' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_rec_created_by ON dbo.sales_price (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_rec_modified_by' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_rec_modified_by ON dbo.sales_price (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_sales_price_group_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_sales_price_group_id ON dbo.sales_price (sales_price_group_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_business_partner_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_business_partner_id ON dbo.sales_price (business_partner_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_bus_partner_price_group_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_bus_partner_price_group_id ON dbo.sales_price (bus_partner_price_group_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_campaign_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_campaign_id ON dbo.sales_price (campaign_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_item_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_item_id ON dbo.sales_price (item_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_uom_id' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_uom_id ON dbo.sales_price (uom_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_starting_date' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_starting_date ON dbo.sales_price (starting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_ending_date' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_ending_date ON dbo.sales_price (ending_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_item_id_starting_date_ending_date_min_qty' AND objects.name = 'sales_price')
BEGIN
	CREATE INDEX idx_sales_price_item_id_starting_date_ending_date_min_qty ON dbo.sales_price (item_id, starting_date, ending_date, min_qty)
END
GO

/**************************** sales_price_group ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_client_id' AND objects.name = 'sales_price_group')
BEGIN
	CREATE INDEX idx_sales_price_group_client_id ON dbo.sales_price_group (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_organization_id' AND objects.name = 'sales_price_group')
BEGIN
	CREATE INDEX idx_sales_price_group_organization_id ON dbo.sales_price_group (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_rec_created_by' AND objects.name = 'sales_price_group')
BEGIN
	CREATE INDEX idx_sales_price_group_rec_created_by ON dbo.sales_price_group (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_rec_modified_by' AND objects.name = 'sales_price_group')
BEGIN
	CREATE INDEX idx_sales_price_group_rec_modified_by ON dbo.sales_price_group (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_code' AND objects.name = 'sales_price_group')
BEGIN
	CREATE UNIQUE INDEX idx_sales_price_group_code ON dbo.sales_price_group (code, client_id)
END
GO

/**************************** uom ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_client_id' AND objects.name = 'uom')
BEGIN
	CREATE INDEX idx_uom_client_id ON dbo.uom (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_organization_id' AND objects.name = 'uom')
BEGIN
	CREATE INDEX idx_uom_organization_id ON dbo.uom (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_rec_created_by' AND objects.name = 'uom')
BEGIN
	CREATE INDEX idx_uom_rec_created_by ON dbo.uom (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_rec_modified_by' AND objects.name = 'uom')
BEGIN
	CREATE INDEX idx_uom_rec_modified_by ON dbo.uom (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_code' AND objects.name = 'uom')
BEGIN
	CREATE UNIQUE INDEX idx_uom_code ON dbo.uom (code, client_id)
END
GO

/**************************** vat ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_client_id' AND objects.name = 'vat')
BEGIN
	CREATE INDEX idx_vat_client_id ON dbo.vat (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_organization_id' AND objects.name = 'vat')
BEGIN
	CREATE INDEX idx_vat_organization_id ON dbo.vat (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_rec_created_by' AND objects.name = 'vat')
BEGIN
	CREATE INDEX idx_vat_rec_created_by ON dbo.vat (rec_created_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_rec_modified_by' AND objects.name = 'vat')
BEGIN
	CREATE INDEX idx_vat_rec_modified_by ON dbo.vat (rec_modified_by)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_code' AND objects.name = 'vat')
BEGIN
	CREATE UNIQUE INDEX idx_vat_code ON dbo.vat (code, client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_account_input_vat_id' AND objects.name = 'vat')
BEGIN
	CREATE INDEX idx_vat_account_input_vat_id ON dbo.vat (account_input_vat_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_account_output_vat_id' AND objects.name = 'vat')
BEGIN
	CREATE INDEX idx_vat_account_output_vat_id ON dbo.vat (account_output_vat_id)
END
GO

/**************************** vat_entry ********************************************/
IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_client_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_client_id ON dbo.vat_entry (client_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_organization_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_organization_id ON dbo.vat_entry (organization_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_document_type' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_document_type ON dbo.vat_entry (document_type, document_sub_type)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_document_no' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_document_no ON dbo.vat_entry (document_no)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_document_date' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_document_date ON dbo.vat_entry (document_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_posting_date' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_posting_date ON dbo.vat_entry (posting_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_invoice_issued_date' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_invoice_issued_date ON dbo.vat_entry (invoice_issued_date)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_invoice_number_invoice_series' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_invoice_number_invoice_series ON dbo.vat_entry (invoice_number, invoice_series)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_business_partner_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_business_partner_id ON dbo.vat_entry (business_partner_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_tax_code' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_tax_code ON dbo.vat_entry (tax_code)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_currency_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_currency_id ON dbo.vat_entry (currency_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_vat_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_vat_id ON dbo.vat_entry (vat_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_account_vat_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_account_vat_id ON dbo.vat_entry (account_vat_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_corresp_account_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_corresp_account_id ON dbo.vat_entry (corresp_account_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_purch_header_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_purch_header_id ON dbo.vat_entry (purch_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_cash_header_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_cash_header_id ON dbo.vat_entry (cash_header_id)
END
GO

IF NOT EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_job_id' AND objects.name = 'vat_entry')
BEGIN
	CREATE INDEX idx_vat_entry_job_id ON dbo.vat_entry (job_id)
END
GO







