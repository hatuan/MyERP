
namespace MyERP.CommonUI
{
    partial class PageTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageTemplate));
            this.btnNav = new Wisej.Web.Button();
            this.lblMainPageCaption = new Wisej.Web.Label();
            this.pnlMainPage = new Wisej.Web.Panel();
            this.btnHome = new Wisej.Web.Button();
            this.btnPersonInfo = new Wisej.Web.Button();
            this.lblLoginUser = new Wisej.Web.Label();
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
            this.btnNav.Size = new System.Drawing.Size(22, 22);
            this.btnNav.TabIndex = 1;
            this.btnNav.TabStop = false;
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // lblMainPageCaption
            // 
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
            this.pnlMainPage.BackColor = System.Drawing.Color.FromName("@info");
            this.pnlMainPage.BorderStyle = Wisej.Web.BorderStyle.Solid;
            this.pnlMainPage.Controls.Add(this.lblLoginUser);
            this.pnlMainPage.Controls.Add(this.btnPersonInfo);
            this.pnlMainPage.Controls.Add(this.btnHome);
            this.pnlMainPage.Controls.Add(this.btnNav);
            this.pnlMainPage.Controls.Add(this.lblMainPageCaption);
            this.pnlMainPage.CssStyle = "box-shadow: 0px 3px 3px rgba(0, 0, 0, 0.1);";
            this.pnlMainPage.Dock = Wisej.Web.DockStyle.Top;
            this.pnlMainPage.Location = new System.Drawing.Point(0, 0);
            this.pnlMainPage.Name = "pnlMainPage";
            this.pnlMainPage.Size = new System.Drawing.Size(738, 40);
            this.pnlMainPage.TabIndex = 2;
            this.pnlMainPage.TabStop = true;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BorderStyle = Wisej.Web.BorderStyle.None;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(220, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(29, 28);
            this.btnHome.TabIndex = 2;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPersonInfo
            // 
            this.btnPersonInfo.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.btnPersonInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnPersonInfo.BorderStyle = Wisej.Web.BorderStyle.None;
            this.btnPersonInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonInfo.Image")));
            this.btnPersonInfo.Location = new System.Drawing.Point(704, 6);
            this.btnPersonInfo.Name = "btnPersonInfo";
            this.btnPersonInfo.Size = new System.Drawing.Size(25, 25);
            this.btnPersonInfo.TabIndex = 3;
            this.btnPersonInfo.TabStop = false;
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.lblLoginUser.Font = new System.Drawing.Font("windowTitle", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLoginUser.Location = new System.Drawing.Point(613, 9);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(83, 19);
            this.lblLoginUser.TabIndex = 4;
            this.lblLoginUser.Text = "LoginUser";
            this.lblLoginUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMainPage);
            this.Name = "PageTemplate";
            this.Size = new System.Drawing.Size(738, 524);
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
