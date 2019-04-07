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
	CREATE INDEX idx_organization_code ON dbo.organization (code)
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
	CREATE INDEX idx_currency_code ON dbo.currency (code)
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

