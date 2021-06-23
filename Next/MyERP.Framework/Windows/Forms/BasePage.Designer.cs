
namespace MyERP.Framework.Windows.Forms
{
    partial class BasePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePage));
            this.btnNav = new Wisej.Web.Button();
            this.lblMainPageCaption = new Wisej.Web.Label();
            this.pnlMainPage = new Wisej.Web.Panel();
            this.lblLoginUser = new Wisej.Web.Label();
            this.btnPersonInfo = new Wisej.Web.Button();
            this.btnHome = new Wisej.Web.Button();
            this.pnlMainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNav
            // 
            this.btnNav.BackColor = System.Drawing.Color.Transparent;
            this.btnNav.BorderStyle = Wisej.Web.BorderStyle.None;
            this.btnNav.Image = ((System.Drawing.Image)(resources.GetObject("btnNav.Image")));
            this.btnNav.Location = new System.Drawing.Point(8, 7);
            this.btnNav.Name = "btnNav";
            this.btnNav.Size = new System.Drawing.Size(23, 23);
            this.btnNav.TabIndex = 1;
            this.btnNav.TabStop = false;
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // lblMainPageCaption
            // 
            this.lblMainPageCaption.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.lblMainPageCaption.AutoSize = true;
            this.lblMainPageCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblMainPageCaption.Font = new System.Drawing.Font("windowTitle", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblMainPageCaption.Location = new System.Drawing.Point(35, 9);
            this.lblMainPageCaption.Name = "lblMainPageCaption";
            this.lblMainPageCaption.Size = new System.Drawing.Size(183, 19);
            this.lblMainPageCaption.TabIndex = 0;
            this.lblMainPageCaption.Text = "Next Business Solution";
            // 
            // pnlMainPage
            // 
            this.pnlMainPage.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainPage.Controls.Add(this.lblLoginUser);
            this.pnlMainPage.Controls.Add(this.btnPersonInfo);
            this.pnlMainPage.Controls.Add(this.btnHome);
            this.pnlMainPage.Controls.Add(this.btnNav);
            this.pnlMainPage.Controls.Add(this.lblMainPageCaption);
            this.pnlMainPage.CssStyle = "box-shadow: 0px 3px 3px rgba(0, 0, 0, 0.1);";
            this.pnlMainPage.Dock = Wisej.Web.DockStyle.Top;
            this.pnlMainPage.Location = new System.Drawing.Point(0, 0);
            this.pnlMainPage.Name = "pnlMainPage";
            this.pnlMainPage.Size = new System.Drawing.Size(1273, 40);
            this.pnlMainPage.TabIndex = 2;
            this.pnlMainPage.TabStop = true;
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.lblLoginUser.Font = new System.Drawing.Font("windowTitle", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLoginUser.Location = new System.Drawing.Point(1150, 9);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(83, 19);
            this.lblLoginUser.TabIndex = 4;
            this.lblLoginUser.Text = "LoginUser";
            this.lblLoginUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPersonInfo
            // 
            this.btnPersonInfo.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.btnPersonInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnPersonInfo.BorderStyle = Wisej.Web.BorderStyle.None;
            this.btnPersonInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonInfo.Image")));
            this.btnPersonInfo.Location = new System.Drawing.Point(1241, 6);
            this.btnPersonInfo.Name = "btnPersonInfo";
            this.btnPersonInfo.Size = new System.Drawing.Size(25, 25);
            this.btnPersonInfo.TabIndex = 3;
            this.btnPersonInfo.TabStop = false;
            this.btnPersonInfo.Click += new System.EventHandler(this.btnPersonInfo_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BorderStyle = Wisej.Web.BorderStyle.None;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(223, 7);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(23, 23);
            this.btnHome.TabIndex = 2;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // BasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(140, 211, 255);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pnlMainPage);
            this.Name = "BasePage";
            this.Size = new System.Drawing.Size(1273, 675);
            this.Load += new System.EventHandler(this.PageTemplate_Load);
            this.pnlMainPage.ResumeLayout(false);
            this.pnlMainPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button btnNav;
        private Wisej.Web.Label lblMainPageCaption;
        private Wisej.Web.Panel pnlMainPage;
        private Wisej.Web.Button btnHome;
        private Wisej.Web.Label lblLoginUser;
        private Wisej.Web.Button btnPersonInfo;
    }
}
