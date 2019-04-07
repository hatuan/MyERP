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