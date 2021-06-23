
namespace MyERP.Framework.Windows.Forms
{
    partial class BaseContainer
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
            this.baseLayoutPanel = new Wisej.Web.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // baseLayoutPanel
            // 
            this.baseLayoutPanel.ColumnCount = 3;
            this.baseLayoutPanel.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 25F));
            this.baseLayoutPanel.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 100F));
            this.baseLayoutPanel.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 25F));
            this.baseLayoutPanel.Dock = Wisej.Web.DockStyle.Fill;
            this.baseLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.baseLayoutPanel.Name = "baseLayoutPanel";
            this.baseLayoutPanel.RowCount = 3;
            this.baseLayoutPanel.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 18F));
            this.baseLayoutPanel.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 100F));
            this.baseLayoutPanel.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 18F));
            this.baseLayoutPanel.Size = new System.Drawing.Size(796, 546);
            this.baseLayoutPanel.TabIndex = 0;
            this.baseLayoutPanel.TabStop = true;
            // 
            // BaseContainer
            // 
            this.Controls.Add(this.baseLayoutPanel);
            this.Name = "BaseContainer";
            this.Size = new System.Drawing.Size(796, 546);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.TableLayoutPanel baseLayoutPanel;
    }
}
