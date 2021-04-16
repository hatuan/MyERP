
namespace MyERP.Web
{
    partial class LoginPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            this.lblUsername = new Wisej.Web.Label();
            this.txtUserName = new Wisej.Web.TextBox();
            this.txtPassword = new Wisej.Web.TextBox();
            this.lblPassword = new Wisej.Web.Label();
            this.btnLogin = new Wisej.Web.Button();
            this.picLogo = new Wisej.Web.PictureBox();
            this.panel1 = new Wisej.Web.Panel();
            this.tableLayoutPanel1 = new Wisej.Web.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(23, 184);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(64, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.txtUserName.CharacterCasing = Wisej.Web.CharacterCasing.Upper;
            this.txtUserName.Location = new System.Drawing.Point(100, 181);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(128, 22);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.txtPassword.Location = new System.Drawing.Point(100, 211);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(128, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(23, 214);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(100, 243);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(64, 27);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = Wisej.Web.ImageLayout.BestFit;
            this.picLogo.Location = new System.Drawing.Point(23, 67);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(252, 87);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.CssStyle = "box-shadow: 3px 3px 5px rgba(0, 0, 0, 0.1);";
            this.panel1.Location = new System.Drawing.Point(223, 98);
            this.panel1.Name = "panel1";
            this.panel1.ShowCloseButton = false;
            this.panel1.Size = new System.Drawing.Size(291, 328);
            this.panel1.TabIndex = 5;
            this.panel1.TabStop = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 297F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = Wisej.Web.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 48.28F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 334F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 48.28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 524);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // LoginPage
            // 
            this.Accelerators = new Wisej.Web.Keys[] {
        Wisej.Web.Keys.Enter};
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromName("@window");
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(738, 524);
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.Activated += new System.EventHandler(this.LoginPage_Activated);
            this.Accelerator += new Wisej.Web.AcceleratorEventHandler(this.LoginPage_Accelerator);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label lblUsername;
        private Wisej.Web.TextBox txtUserName;
        private Wisej.Web.TextBox txtPassword;
        private Wisej.Web.Label lblPassword;
        private Wisej.Web.Button btnLogin;
        private Wisej.Web.PictureBox picLogo;
        private Wisej.Web.Panel panel1;
        private Wisej.Web.TableLayoutPanel tableLayoutPanel1;
    }
}
