/**************************** USER ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_name' AND objects.name = 'dbo.user')
BEGIN
	DROP INDEX idx_user_name ON dbo."user"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_client_id' AND objects.name = 'dbo.user')
BEGIN
	DROP INDEX idx_user_client_id ON dbo."user"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_organization_id' AND objects.name = 'dbo.user')
BEGIN
	DROP INDEX idx_user_organization_id ON dbo."user"
END
GO

/**************************** ROLE ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_role_client_id' AND objects.name = 'dbo.role')
BEGIN
	DROP INDEX idx_role_client_id ON dbo."role"
END
GO

/**************************** USER_IN_ROLE ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_in_role_role_id' AND objects.name = 'dbo.user_in_role')
BEGIN
	DROP INDEX idx_user_in_role_role_id ON dbo.user_in_role
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_user_in_role_user_id' AND objects.name = 'dbo.user_in_role')
BEGIN
	DROP INDEX idx_user_in_role_user_id ON dbo.user_in_role;
END
GO

/**************************** CLIENT ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_client_currency_lcy_id' AND objects.name = 'client')
BEGIN
	DROP INDEX idx_client_currency_lcy_id ON dbo.client
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_client_rec_created_by' AND objects.name = 'client')
BEGIN
	DROP INDEX idx_client_rec_created_by ON dbo.client
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_client_rec_modified_by' AND objects.name = 'client')
BEGIN
	DROP INDEX idx_client_rec_modified_by ON dbo.client
END
GO

/**************************** ORGANIZATION ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_code' AND objects.name = 'organization')
BEGIN
	DROP INDEX idx_organization_code ON dbo.organization
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_client_id' AND objects.name = 'organization')
BEGIN
	DROP INDEX idx_organization_client_id ON dbo.organization
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_rec_created_by' AND objects.name = 'organization')
BEGIN
	DROP INDEX idx_organization_rec_created_by ON dbo.organization
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_organization_rec_modified_by' AND objects.name = 'organization')
BEGIN
	DROP INDEX idx_organization_rec_modified_by ON dbo.organization
END
GO

/**************************** CURRENCY ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_code' AND objects.name = 'currency')
BEGIN
	DROP INDEX idx_currency_code ON dbo.currency
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_client_id' AND objects.name = 'currency')
BEGIN
	DROP INDEX idx_currency_client_id ON dbo.currency 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_organization_id' AND objects.name = 'currency')
BEGIN
	DROP INDEX idx_currency_organization_id ON dbo.currency 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_rec_created_by' AND objects.name = 'currency')
BEGIN
	DROP INDEX idx_currency_rec_created_by ON dbo.currency 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_currency_rec_modified_by' AND objects.name = 'currency')
BEGIN
	DROP INDEX idx_currency_rec_modified_by ON dbo.currency 
END
GO

/**************************** OPTION ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_client_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_client_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_organization_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_organization_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_rec_created_by' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_rec_created_by ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_rec_modified_by' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_rec_modified_by ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_pos_location_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_sales_pos_location_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_pos_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_sales_pos_sequence_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_order_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_sales_order_sequence_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_shipment_seq_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_sales_shipment_seq_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_sales_invoice_seq_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_sales_invoice_seq_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_purch_order_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_purch_order_sequence_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_purch_receive_seq_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_purch_receive_seq_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_purch_invoice_seq_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_purch_invoice_seq_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_one_time_business_partner_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_one_time_business_partner_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_general_ledger_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_general_ledger_sequence_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_cash_receipt_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_cash_receipt_sequence_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_cash_payment_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_cash_payment_sequence_id ON dbo."option"
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_bank_receipt_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_bank_receipt_sequence_id ON dbo."option" 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_option_bank_checkque_sequence_id' AND objects.name = 'option')
BEGIN
	DROP INDEX idx_option_bank_checkque_sequence_id ON dbo."option"
END
GO

/**************************** REPORT ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_report_rep_id' AND objects.name = 'report')
BEGIN
	DROP INDEX idx_report_rep_id ON dbo.report
END
GO

/**************************** NOSEQUENCE ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_code' AND objects.name = 'no_sequence')
BEGIN
	DROP INDEX idx_no_sequence_code ON dbo.no_sequence
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_client_id' AND objects.name = 'no_sequence')
BEGIN
	DROP INDEX idx_no_sequence_client_id ON dbo.no_sequence
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_organization_id' AND objects.name = 'no_sequence')
BEGIN
	DROP INDEX idx_no_sequence_organization_id ON dbo.no_sequence
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_rec_created_by' AND objects.name = 'no_sequence')
BEGIN
	DROP INDEX idx_no_sequence_rec_created_by ON dbo.no_sequence 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_rec_modified_by' AND objects.name = 'no_sequence')
BEGIN
	DROP INDEX idx_no_sequence_rec_modified_by ON dbo.no_sequence 
END
GO

/**************************** NOSEQUENCELINE ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_no_sequence_id' AND objects.name = 'no_sequence_line')
BEGIN
	DROP INDEX idx_no_sequence_line_no_sequence_id ON dbo.no_sequence_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_client_id' AND objects.name = 'no_sequence_line')
BEGIN
	DROP INDEX idx_no_sequence_line_client_id ON dbo.no_sequence_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_organization_id' AND objects.name = 'no_sequence_line')
BEGIN
	DROP INDEX idx_no_sequence_line_organization_id ON dbo.no_sequence_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_rec_created_by' AND objects.name = 'no_sequence_line')
BEGIN
	DROP INDEX idx_no_sequence_line_rec_created_by ON dbo.no_sequence_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_no_sequence_line_rec_modified_by' AND objects.name = 'no_sequence_line')
BEGIN
	DROP INDEX idx_no_sequence_line_rec_modified_by ON dbo.no_sequence_line
END
GO

/**************************** ACCOUNT ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_code' AND objects.name = 'account')
BEGIN
	DROP INDEX idx_account_code ON dbo.account 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_client_id' AND objects.name = 'account')
BEGIN
	DROP INDEX idx_account_client_id ON dbo.account 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_organization_id' AND objects.name = 'account')
BEGIN
	DROP INDEX idx_account_organization_id ON dbo.account 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_rec_created_by' AND objects.name = 'account')
BEGIN
	DROP INDEX idx_account_rec_created_by ON dbo.account 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_rec_modified_by' AND objects.name = 'account')
BEGIN
	DROP INDEX idx_account_rec_modified_by ON dbo.account 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_account_parent_id' AND objects.name = 'account')
BEGIN
	DROP INDEX idx_account_parent_id ON dbo.account
END
GO

/**************************** BusinessPartner ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_code' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_code ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_client_id' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_client_id ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_organization_id' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_organization_id ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_rec_created_by' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_rec_created_by ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_rec_modified_by' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_rec_modified_by ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_id' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_price_group_id ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_id1' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_group_id1 ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_id2' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_group_id2 ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_id3' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_group_id3 ON dbo.business_partner 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_disc_group_id' AND objects.name = 'business_partner')
BEGIN
	DROP INDEX idx_business_partner_disc_group_id ON dbo.business_partner
END
GO

/**************************** business_partner_discount_group ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_code' AND objects.name = 'business_partner_discount_group')
BEGIN
	DROP INDEX idx_business_partner_discount_group_code ON dbo.business_partner_discount_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_client_id' AND objects.name = 'business_partner_discount_group')
BEGIN
	DROP INDEX idx_business_partner_discount_group_client_id ON dbo.business_partner_discount_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_organization_id' AND objects.name = 'business_partner_discount_group')
BEGIN
	DROP INDEX idx_business_partner_discount_group_organization_id ON dbo.business_partner_discount_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_rec_created_by' AND objects.name = 'business_partner_discount_group')
BEGIN
	DROP INDEX idx_business_partner_discount_group_rec_created_by ON dbo.business_partner_discount_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_discount_group_rec_modified_by' AND objects.name = 'business_partner_discount_group')
BEGIN
	DROP INDEX idx_business_partner_discount_group_rec_modified_by ON dbo.business_partner_discount_group 
END
GO

/**************************** business_partner_group ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_code' AND objects.name = 'business_partner_group')
BEGIN
	DROP INDEX idx_business_partner_group_code ON dbo.business_partner_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_client_id' AND objects.name = 'business_partner_group')
BEGIN
	DROP INDEX idx_business_partner_group_client_id ON dbo.business_partner_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_organization_id' AND objects.name = 'business_partner_group')
BEGIN
	DROP INDEX idx_business_partner_group_organization_id ON dbo.business_partner_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_rec_created_by' AND objects.name = 'business_partner_group')
BEGIN
	DROP INDEX idx_business_partner_group_rec_created_by ON dbo.business_partner_group
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_group_rec_modified_by' AND objects.name = 'business_partner_group')
BEGIN
	DROP INDEX idx_business_partner_group_rec_modified_by ON dbo.business_partner_group 
END
GO

/**************************** business_partner_price_group ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_code' AND objects.name = 'business_partner_price_group')
BEGIN
	DROP INDEX idx_business_partner_price_group_code ON dbo.business_partner_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_client_id' AND objects.name = 'business_partner_price_group')
BEGIN
	DROP INDEX idx_business_partner_price_group_client_id ON dbo.business_partner_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_organization_id' AND objects.name = 'business_partner_price_group')
BEGIN
	DROP INDEX idx_business_partner_price_group_organization_id ON dbo.business_partner_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_rec_created_by' AND objects.name = 'business_partner_price_group')
BEGIN
	DROP INDEX idx_business_partner_price_group_rec_created_by ON dbo.business_partner_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_business_partner_price_group_rec_modified_by' AND objects.name = 'business_partner_price_group')
BEGIN
	DROP INDEX idx_business_partner_price_group_rec_modified_by ON dbo.business_partner_price_group 
END
GO

/**************************** cash_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_client_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_client_id ON dbo.cash_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_organization_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_organization_id ON dbo.cash_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_rec_created_by' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_rec_created_by ON dbo.cash_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_rec_modified_by' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_rec_modified_by ON dbo.cash_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_doc_sequence_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_doc_sequence_id ON dbo.cash_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_doc_sub_type' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_doc_sub_type ON dbo.cash_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_document_no' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_document_no ON dbo.cash_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_document_date' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_document_date ON dbo.cash_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_posting_date' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_posting_date ON dbo.cash_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_business_partner_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_business_partner_id ON dbo.cash_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_business_partner_contact_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_business_partner_contact_id ON dbo.cash_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_account_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_account_id ON dbo.cash_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_header_currency_id' AND objects.name = 'cash_header')
BEGIN
	DROP INDEX idx_cash_header_currency_id ON dbo.cash_header 
END
GO


/**************************** cash_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_client_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_client_id ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_organization_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_organization_id ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_cash_header_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_cash_header_id ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_document_no' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_document_no ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_posting_date' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_posting_date ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_business_partner_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_business_partner_id ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_corresp_account_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_corresp_account_id ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_job_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_job_id ON dbo.cash_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_accounts_payable_ledger_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_accounts_payable_ledger_id ON dbo.cash_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_cash_line_accounts_receivable_ledger_id' AND objects.name = 'cash_line')
BEGIN
	DROP INDEX idx_cash_line_accounts_receivable_ledger_id ON dbo.cash_line 
END
GO

/**************************** einv_form_release ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_client_id' AND objects.name = 'einv_form_release')
BEGIN
	DROP INDEX idx_einv_form_release_client_id ON dbo.einv_form_release
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_organization_id' AND objects.name = 'einv_form_release')
BEGIN
	DROP INDEX idx_einv_form_release_organization_id ON dbo.einv_form_release 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_rec_created_by' AND objects.name = 'einv_form_release')
BEGIN
	DROP INDEX idx_einv_form_release_rec_created_by ON dbo.einv_form_release 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_rec_modified_by' AND objects.name = 'einv_form_release')
BEGIN
	DROP INDEX idx_einv_form_release_rec_modified_by ON dbo.einv_form_release 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_release_form_type_id' AND objects.name = 'einv_form_release')
BEGIN
	DROP INDEX idx_einv_form_release_form_type_id ON dbo.einv_form_release 
END
GO

/**************************** einv_form_type ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_client_id' AND objects.name = 'einv_form_type')
BEGIN
	DROP INDEX idx_einv_form_type_client_id ON dbo.einv_form_type 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_organization_id' AND objects.name = 'einv_form_type')
BEGIN
	DROP INDEX idx_einv_form_type_organization_id ON dbo.einv_form_type 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_rec_created_by' AND objects.name = 'einv_form_type')
BEGIN
	DROP INDEX idx_einv_form_type_rec_created_by ON dbo.einv_form_type 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einv_form_type_rec_modified_by' AND objects.name = 'einv_form_type')
BEGIN
	DROP INDEX idx_einv_form_type_rec_modified_by ON dbo.einv_form_type 
END
GO

/**************************** einvoice_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_client_id' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_client_id ON dbo.einvoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_organization_id' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_organization_id ON dbo.einvoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_rec_created_by' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_rec_created_by ON dbo.einvoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_rec_modified_by' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_rec_modified_by ON dbo.einvoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_form_type_id' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_form_type_id ON dbo.einvoice_header 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_invoice_number' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_invoice_number ON dbo.einvoice_header 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_invoice_issued_date' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_invoice_issued_date ON dbo.einvoice_header 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_currency_id' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_currency_id ON dbo.einvoice_header 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_buyer_id' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_buyer_id ON dbo.einvoice_header 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_buyer_tax_code' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_buyer_tax_code ON dbo.einvoice_header 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_header_reservation_code' AND objects.name = 'einvoice_header')
BEGIN
	DROP INDEX idx_einvoice_header_reservation_code ON dbo.einvoice_header 
END

/**************************** einvoice_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_client_id' AND objects.name = 'einvoice_line')
BEGIN
	DROP INDEX idx_einvoice_line_client_id ON dbo.einvoice_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_organization_id' AND objects.name = 'einvoice_line')
BEGIN
	DROP INDEX idx_einvoice_line_organization_id ON dbo.einvoice_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_einvoice_header_id' AND objects.name = 'einvoice_line')
BEGIN
	DROP INDEX idx_einvoice_line_einvoice_header_id ON dbo.einvoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_item_id' AND objects.name = 'einvoice_line')
BEGIN
	DROP INDEX idx_einvoice_line_item_id ON dbo.einvoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_unit_id' AND objects.name = 'einvoice_line')
BEGIN
	DROP INDEX idx_einvoice_line_unit_id ON dbo.einvoice_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_line_vat_id' AND objects.name = 'einvoice_line')
BEGIN
	DROP INDEX idx_einvoice_line_vat_id ON dbo.einvoice_line 
END
GO

/**************************** einvoice_signed ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_client_id' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_client_id ON dbo.einvoice_signed 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_organization_id' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_organization_id ON dbo.einvoice_signed 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_rec_created_by' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_rec_created_by ON dbo.einvoice_signed
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_rec_modified_by' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_rec_modified_by ON dbo.einvoice_signed 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_form_type_id' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_form_type_id ON dbo.einvoice_signed 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_invoice_series' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_invoice_series ON dbo.einvoice_signed
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_invoice_number' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_invoice_number ON dbo.einvoice_signed 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_invoice_issued_date' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_invoice_issued_date ON dbo.einvoice_signed 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_signed_date' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_signed_date ON dbo.einvoice_signed 
END

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_einvoice_signed_buyer_tax_code' AND objects.name = 'einvoice_signed')
BEGIN
	DROP INDEX idx_einvoice_signed_buyer_tax_code ON dbo.einvoice_signed 
END

/**************************** general_journal_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_client_id' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_client_id ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_organization_id' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_organization_id ON dbo.general_journal_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_rec_created_by' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_rec_created_by ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_rec_modified_by' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_rec_modified_by ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_doc_sub_type' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_doc_sub_type ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_doc_sequence_id' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_doc_sequence_id ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_document_no' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_document_no ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_document_date' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_document_date ON dbo.general_journal_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_posting_date' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_posting_date ON dbo.general_journal_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_currency_id' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_currency_id ON dbo.general_journal_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_header_currency_id' AND objects.name = 'general_journal_header')
BEGIN
	DROP INDEX idx_general_journal_header_currency_id ON dbo.general_journal_header
END
GO

/**************************** general_journal_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_client_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_client_id ON dbo.general_journal_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_organization_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_organization_id ON dbo.general_journal_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_general_journal_header_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_general_journal_header_id ON dbo.general_journal_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_account_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_account_id ON dbo.general_journal_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_document_no' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_document_no ON dbo.general_journal_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_posting_date' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_posting_date ON dbo.general_journal_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_business_partner_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_business_partner_id ON dbo.general_journal_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_job_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_job_id ON dbo.general_journal_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_general_journal_line_fix_asset_id' AND objects.name = 'general_journal_line')
BEGIN
	DROP INDEX idx_general_journal_line_fix_asset_id ON dbo.general_journal_line
END
GO

/**************************** item ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_client_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_client_id ON dbo.item
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_organization_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_organization_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_rec_created_by' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_rec_created_by ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_rec_modified_by' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_rec_modified_by ON dbo.item
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_code' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_code ON dbo.item
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_base_uom_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_base_uom_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_group_id1' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_item_group_id1 ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_group_id2' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_item_group_id2 ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_group_id3' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_item_group_id3 ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_discount_group_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_purch_vendor_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_purch_vendor_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_uom_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_sales_uom_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_purch_uom_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_purch_uom_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_vat_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_vat_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_inventory_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_inventory_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_sales_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_cogs_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_cogs_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_internal_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_sales_internal_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_return_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_sales_return_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_wip_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_wip_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_sales_discount_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_sales_discount_account_id ON dbo.item
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_cogs_diff_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_cogs_diff_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_consignment_account_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_consignment_account_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_routing_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_routing_id ON dbo.item 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_bom_id' AND objects.name = 'item')
BEGIN
	DROP INDEX idx_item_bom_id ON dbo.item 
END
GO

/**************************** item_discount_group ********************************************/
IF  EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_client_id' AND objects.name = 'item_discount_group')
BEGIN
	DROP INDEX idx_item_discount_group_client_id ON dbo.item_discount_group
END
GO

IF  EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_organization_id' AND objects.name = 'item_discount_group')
BEGIN
	DROP INDEX idx_item_discount_group_organization_id ON dbo.item_discount_group 
END
GO

IF  EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_rec_created_by' AND objects.name = 'item_discount_group')
BEGIN
	DROP INDEX idx_item_discount_group_rec_created_by ON dbo.item_discount_group 
END
GO

IF  EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_rec_modified_by' AND objects.name = 'item_discount_group')
BEGIN
	DROP INDEX idx_item_discount_group_rec_modified_by ON dbo.item_discount_group 
END
GO

IF  EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_discount_group_code' AND objects.name = 'item_discount_group')
BEGIN
	DROP INDEX idx_item_discount_group_code ON dbo.item_discount_group
END
GO

/**************************** item_group ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_client_id' AND objects.name = 'item_group')
BEGIN
	DROP INDEX idx_item_group_client_id ON dbo.item_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_organization_id' AND objects.name = 'item_group')
BEGIN
	DROP INDEX idx_item_group_organization_id ON dbo.item_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_created_by' AND objects.name = 'item_group')
BEGIN
	DROP INDEX idx_item_group_rec_created_by ON dbo.item_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_modified_by' AND objects.name = 'item_group')
BEGIN
	DROP INDEX idx_item_group_rec_modified_by ON dbo.item_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_code' AND objects.name = 'item_group')
BEGIN
	DROP INDEX idx_item_group_code ON dbo.item_group 
END
GO

/**************************** item_uom ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_client_id' AND objects.name = 'item_uom')
BEGIN
	DROP INDEX idx_item_group_client_id ON dbo.item_uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_organization_id' AND objects.name = 'item_uom')
BEGIN
	DROP INDEX idx_item_group_organization_id ON dbo.item_uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_created_by' AND objects.name = 'item_uom')
BEGIN
	DROP INDEX idx_item_group_rec_created_by ON dbo.item_uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_group_rec_modified_by' AND objects.name = 'item_uom')
BEGIN
	DROP INDEX idx_item_group_rec_modified_by ON dbo.item_uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_uom_id' AND objects.name = 'item_uom')
BEGIN
	DROP INDEX idx_item_uom_id ON dbo.item_uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_item_item_id' AND objects.name = 'item_uom')
BEGIN
	DROP INDEX idx_item_item_id ON dbo.item_uom 
END
GO

/**************************** job ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_client_id' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_client_id ON dbo.job
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_organization_id' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_organization_id ON dbo.job 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_rec_created_by' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_rec_created_by ON dbo.job 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_rec_modified_by' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_rec_modified_by ON dbo.job 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_code' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_code ON dbo.job 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_job_group_id1' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_job_group_id1 ON dbo.job
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_job_group_id2' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_job_group_id2 ON dbo.job 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_job_group_id3' AND objects.name = 'job')
BEGIN
	DROP INDEX idx_job_job_group_id3 ON dbo.job
END
GO

/**************************** job_group ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_client_id' AND objects.name = 'job_group')
BEGIN
	DROP INDEX idx_job_group_client_id ON dbo.job_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_organization_id' AND objects.name = 'job_group')
BEGIN
	DROP INDEX idx_job_group_organization_id ON dbo.job_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_rec_created_by' AND objects.name = 'job_group')
BEGIN
	DROP INDEX idx_job_group_rec_created_by ON dbo.job_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_rec_modified_by' AND objects.name = 'job_group')
BEGIN
	DROP INDEX idx_job_group_rec_modified_by ON dbo.job_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_job_group_code' AND objects.name = 'job_group')
BEGIN
	DROP INDEX idx_job_group_code ON dbo.job_group 
END
GO

/**************************** location ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_client_id' AND objects.name = 'location')
BEGIN
	DROP INDEX idx_location_client_id ON dbo.location 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_organization_id' AND objects.name = 'location')
BEGIN
	DROP INDEX idx_location_organization_id ON dbo.location 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_rec_created_by' AND objects.name = 'location')
BEGIN
	DROP INDEX idx_location_rec_created_by ON dbo.location 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_rec_modified_by' AND objects.name = 'location')
BEGIN
	DROP INDEX idx_location_rec_modified_by ON dbo.location 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_location_code' AND objects.name = 'location')
BEGIN
	DROP INDEX idx_location_code ON dbo.location 
END
GO

/**************************** pos_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_client_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_client_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_organization_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_organization_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_rec_created_by' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_rec_created_by ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_rec_modified_by' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_rec_modified_by ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_doc_sequence_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_doc_sequence_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_document_no' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_document_no ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_document_date' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_document_date ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_sell_to_customer_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_sell_to_customer_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_sell_to_contact_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_sell_to_contact_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_bill_to_customer_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_bill_to_customer_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_bill_to_contact_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_bill_to_contact_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_bill_to_vat_code' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_bill_to_vat_code ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_currency_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_currency_id ON dbo.pos_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_sales_person_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_sales_person_id ON dbo.pos_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_location_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_location_id ON dbo.pos_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_header_discount_id' AND objects.name = 'pos_header')
BEGIN
	DROP INDEX idx_pos_header_discount_id ON dbo.pos_header 
END
GO

/**************************** pos_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_client_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_client_id ON dbo.pos_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_organization_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_organization_id ON dbo.pos_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_pos_header_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_pos_header_id ON dbo.pos_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_item_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_item_id ON dbo.pos_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_location_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_location_id ON dbo.pos_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_uom_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_uom_id ON dbo.pos_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_sales_price_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_sales_price_id ON dbo.pos_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_vat_identifier_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_vat_identifier_id ON dbo.pos_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_pos_line_discount_id' AND objects.name = 'pos_line')
BEGIN
	DROP INDEX idx_pos_line_discount_id ON dbo.pos_line 
END
GO

/**************************** purchase_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_client_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_client_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_organization_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_organization_id ON dbo.purchase_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_rec_created_by' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_rec_created_by ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_rec_modified_by' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_rec_modified_by ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_doc_sequence_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_doc_sequence_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_document_no' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_document_no ON dbo.purchase_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_document_date' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_document_date ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_buy_from_vendor_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_buy_from_vendor_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_buy_from_contact_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_buy_from_contact_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_pay_to_vendor_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_pay_to_vendor_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_pay_to_contact_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_pay_to_contact_id ON dbo.purchase_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_currency_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_currency_id ON dbo.purchase_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_sales_person_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_sales_person_id ON dbo.purchase_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_quote_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_quote_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_campaign_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_campaign_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_opportunity_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_opportunity_id ON dbo.purchase_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_location_id' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_location_id ON dbo.purchase_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_header_doc_sub_type' AND objects.name = 'purchase_header')
BEGIN
	DROP INDEX idx_purchase_header_doc_sub_type ON dbo.purchase_header
END
GO

/**************************** purchase_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_client_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_client_id ON dbo.purchase_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_organization_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_organization_id ON dbo.purchase_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_purchase_header_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_purchase_header_id ON dbo.purchase_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_item_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_item_id ON dbo.purchase_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_location_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_location_id ON dbo.purchase_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_uom_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_uom_id ON dbo.purchase_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_discount_id' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_discount_id ON dbo.purchase_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_line_document_no' AND objects.name = 'purchase_line')
BEGIN
	DROP INDEX idx_purchase_line_document_no ON dbo.purchase_line 
END
GO

/**************************** purchase_invoice_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_client_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_client_id ON dbo.purchase_invoice_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_organization_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_organization_id ON dbo.purchase_invoice_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_rec_created_by' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_rec_created_by ON dbo.purchase_invoice_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_rec_modified_by' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_rec_modified_by ON dbo.purchase_invoice_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_doc_sequence_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_doc_sequence_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_document_no' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_document_no ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_document_date' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_document_date ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_posting_date' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_posting_date ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_buy_from_vendor_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_buy_from_vendor_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_buy_from_contact_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_buy_from_contact_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_pay_to_vendor_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_pay_to_vendor_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_pay_to_contact_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_pay_to_contact_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_currency_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_currency_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_sales_person_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_sales_person_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_quote_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_quote_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_campaign_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_campaign_id ON dbo.purchase_invoice_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_opportunity_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_opportunity_id ON dbo.purchase_invoice_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_location_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_location_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_discount_id' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_discount_id ON dbo.purchase_invoice_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_header_doc_sub_type' AND objects.name = 'purchase_invoice_header')
BEGIN
	DROP INDEX idx_purchase_invoice_header_doc_sub_type ON dbo.purchase_invoice_header 
END
GO

/**************************** purchase_invoice_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_client_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_client_id ON dbo.purchase_invoice_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_organization_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_organization_id ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_purchase_header_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_purchase_header_id ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_item_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_item_id ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_location_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_location_id ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_uom_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_uom_id ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_discount_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_discount_id ON dbo.purchase_invoice_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_document_no' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_document_no ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_posting_date' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_posting_date ON dbo.purchase_invoice_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_vat_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_vat_id ON dbo.purchase_invoice_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_purchase_invoice_line_inventory_account_id' AND objects.name = 'purchase_invoice_line')
BEGIN
	DROP INDEX idx_purchase_invoice_line_inventory_account_id ON dbo.purchase_invoice_line 
END
GO

/**************************** sales_header ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_client_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_client_id ON dbo.sales_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_organization_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_organization_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_rec_created_by' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_rec_created_by ON dbo.sales_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_rec_modified_by' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_rec_modified_by ON dbo.sales_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_doc_sequence_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_doc_sequence_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_document_no' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_document_no ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_document_date' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_document_date ON dbo.sales_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_posting_date' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_posting_date ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_sell_to_customer_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_sell_to_customer_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_sell_to_contact_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_sell_to_contact_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_bill_to_customer_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_bill_to_customer_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_bill_to_contact_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_bill_to_contact_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_currency_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_currency_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_sales_person_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_sales_person_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_quote_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_quote_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_campaign_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_campaign_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_opportunity_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_opportunity_id ON dbo.sales_header 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_location_id' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_location_id ON dbo.sales_header
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_header_doc_sub_type' AND objects.name = 'sales_header')
BEGIN
	DROP INDEX idx_sales_header_doc_sub_type ON dbo.sales_header 
END
GO

/**************************** sales_line ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_client_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_client_id ON dbo.sales_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_organization_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_organization_id ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_sales_header_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_sales_header_id ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_item_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_item_id ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_location_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_location_id ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_uom_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_uom_id ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_line_discount_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_line_discount_id ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_document_no' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_document_no ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_posting_date' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_posting_date ON dbo.sales_line 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_vat_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_vat_id ON dbo.sales_line
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_line_sales_price_id' AND objects.name = 'sales_line')
BEGIN
	DROP INDEX idx_sales_line_sales_price_id ON dbo.sales_line
END
GO

/**************************** sales_price ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_client_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_client_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_organization_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_organization_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_rec_created_by' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_rec_created_by ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_rec_modified_by' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_rec_modified_by ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_sales_price_group_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_sales_price_group_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_business_partner_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_business_partner_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_bus_partner_price_group_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_bus_partner_price_group_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_campaign_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_campaign_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_item_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_item_id ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_uom_id' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_uom_id ON dbo.sales_price
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_starting_date' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_starting_date ON dbo.sales_price 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_ending_date' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_ending_date ON dbo.sales_price
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_item_id_starting_date_ending_date_min_qty' AND objects.name = 'sales_price')
BEGIN
	DROP INDEX idx_sales_price_item_id_starting_date_ending_date_min_qty ON dbo.sales_price 
END
GO


/**************************** sales_price_group ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_client_id' AND objects.name = 'sales_price_group')
BEGIN
	DROP INDEX idx_sales_price_group_client_id ON dbo.sales_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_organization_id' AND objects.name = 'sales_price_group')
BEGIN
	DROP INDEX idx_sales_price_group_organization_id ON dbo.sales_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_rec_created_by' AND objects.name = 'sales_price_group')
BEGIN
	DROP INDEX idx_sales_price_group_rec_created_by ON dbo.sales_price_group 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_rec_modified_by' AND objects.name = 'sales_price_group')
BEGIN
	DROP INDEX idx_sales_price_group_rec_modified_by ON dbo.sales_price_group
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_sales_price_group_code' AND objects.name = 'sales_price_group')
BEGIN
	DROP INDEX idx_sales_price_group_code ON dbo.sales_price_group 
END
GO

/**************************** uom ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_client_id' AND objects.name = 'uom')
BEGIN
	DROP INDEX idx_uom_client_id ON dbo.uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_organization_id' AND objects.name = 'uom')
BEGIN
	DROP INDEX idx_uom_organization_id ON dbo.uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_rec_created_by' AND objects.name = 'uom')
BEGIN
	DROP INDEX idx_uom_rec_created_by ON dbo.uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_rec_modified_by' AND objects.name = 'uom')
BEGIN
	DROP INDEX idx_uom_rec_modified_by ON dbo.uom 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_uom_code' AND objects.name = 'uom')
BEGIN
	DROP INDEX idx_uom_code ON dbo.uom 
END
GO

/**************************** vat ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_client_id' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_client_id ON dbo.vat 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_organization_id' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_organization_id ON dbo.vat 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_rec_created_by' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_rec_created_by ON dbo.vat 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_rec_modified_by' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_rec_modified_by ON dbo.vat 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_code' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_code ON dbo.vat 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_account_input_vat_id' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_account_input_vat_id ON dbo.vat
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_account_output_vat_id' AND objects.name = 'vat')
BEGIN
	DROP INDEX idx_vat_account_output_vat_id ON dbo.vat 
END
GO

/**************************** vat_entry ********************************************/
IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_client_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_client_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_organization_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_organization_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_document_type' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_document_type ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_document_no' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_document_no ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_document_date' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_document_date ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_posting_date' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_posting_date ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_invoice_issued_date' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_invoice_issued_date ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_invoice_number_invoice_series' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_invoice_number_invoice_series ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_business_partner_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_business_partner_id ON dbo.vat_entry
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_tax_code' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_tax_code ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_currency_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_currency_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_vat_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_vat_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_account_vat_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_account_vat_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_corresp_account_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_corresp_account_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_purch_header_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_purch_header_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_cash_header_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_cash_header_id ON dbo.vat_entry 
END
GO

IF EXISTS(SELECT * FROM sys.indexes indexes INNER JOIN sys.objects objects ON indexes.object_id = objects.object_id WHERE indexes.name ='idx_vat_entry_job_id' AND objects.name = 'vat_entry')
BEGIN
	DROP INDEX idx_vat_entry_job_id ON dbo.vat_entry
END
GO
