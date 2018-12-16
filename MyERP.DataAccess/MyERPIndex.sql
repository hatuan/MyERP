/* account table */
CREATE UNIQUE INDEX idx_account_code ON account (code, client_id);