namespace PharmaUI
{
    partial class frmLineItemBriefDiscount
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblDiscount = new System.Windows.Forms.TableLayoutPanel();
            this.txtVolDiscount = new System.Windows.Forms.TextBox();
            this.txtSpecialDiscount = new System.Windows.Forms.TextBox();
            this.lblSpecialDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblVolumeDiscount = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.dtExpiry = new System.Windows.Forms.MaskedTextBox();
            this.tblDiscount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblDiscount
            // 
            this.tblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblDiscount.AutoSize = true;
            this.tblDiscount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblDiscount.ColumnCount = 6;
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblDiscount.Controls.Add(this.txtVolDiscount, 5, 0);
            this.tblDiscount.Controls.Add(this.txtSpecialDiscount, 3, 0);
            this.tblDiscount.Controls.Add(this.lblSpecialDiscount, 2, 0);
            this.tblDiscount.Controls.Add(this.txtDiscount, 1, 0);
            this.tblDiscount.Controls.Add(this.lblDiscount, 0, 0);
            this.tblDiscount.Controls.Add(this.lblVolumeDiscount, 4, 0);
            this.tblDiscount.Controls.Add(this.lblMRP, 0, 1);
            this.tblDiscount.Controls.Add(this.txtMRP, 1, 1);
            this.tblDiscount.Controls.Add(this.lblExpiry, 2, 1);
            this.tblDiscount.Controls.Add(this.dtExpiry, 3, 1);
            this.tblDiscount.Location = new System.Drawing.Point(12, 69);
            this.tblDiscount.Name = "tblDiscount";
            this.tblDiscount.RowCount = 2;
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tblDiscount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDiscount.Size = new System.Drawing.Size(678, 64);
            this.tblDiscount.TabIndex = 2;
            // 
            // txtVolDiscount
            // 
            this.txtVolDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVolDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolDiscount.Location = new System.Drawing.Point(570, 6);
            this.txtVolDiscount.Name = "txtVolDiscount";
            this.txtVolDiscount.Size = new System.Drawing.Size(97, 20);
            this.txtVolDiscount.TabIndex = 19;
            // 
            // txtSpecialDiscount
            // 
            this.txtSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSpecialDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialDiscount.Location = new System.Drawing.Point(346, 6);
            this.txtSpecialDiscount.Name = "txtSpecialDiscount";
            this.txtSpecialDiscount.Size = new System.Drawing.Size(91, 20);
            this.txtSpecialDiscount.TabIndex = 18;
            // 
            // lblSpecialDiscount
            // 
            this.lblSpecialDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSpecialDiscount.AutoSize = true;
            this.lblSpecialDiscount.Location = new System.Drawing.Point(227, 10);
            this.lblSpecialDiscount.Name = "lblSpecialDiscount";
            this.lblSpecialDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblSpecialDiscount.TabIndex = 5;
            this.lblSpecialDiscount.Text = "Special Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Location = new System.Drawing.Point(122, 6);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(91, 20);
            this.txtDiscount.TabIndex = 17;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(3, 10);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(49, 13);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Discount";
            // 
            // lblVolumeDiscount
            // 
            this.lblVolumeDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVolumeDiscount.AutoSize = true;
            this.lblVolumeDiscount.Location = new System.Drawing.Point(451, 10);
            this.lblVolumeDiscount.Name = "lblVolumeDiscount";
            this.lblVolumeDiscount.Size = new System.Drawing.Size(87, 13);
            this.lblVolumeDiscount.TabIndex = 6;
            this.lblVolumeDiscount.Text = "Volume Discount";
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(3, 42);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(31, 13);
            this.lblMRP.TabIndex = 7;
            this.lblMRP.Text = "MRP";
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Location = new System.Drawing.Point(227, 42);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(35, 13);
            this.lblExpiry.TabIndex = 9;
            this.lblExpiry.Text = "Expiry";
            // 
            // txtMRP
            // 
            this.txtMRP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Location = new System.Drawing.Point(122, 38);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(91, 20);
            this.txtMRP.TabIndex = 20;
            // 
            // dtExpiry
            // 
            this.dtExpiry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtExpiry.Location = new System.Drawing.Point(343, 38);
            this.dtExpiry.Mask = "00/00/0000";
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(97, 20);
            this.dtExpiry.TabIndex = 24;
            this.dtExpiry.ValidatingType = typeof(System.DateTime);
            // 
            // frmLineItemBriefDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 150);
            this.Controls.Add(this.tblDiscount);
            this.Name = "frmLineItemBriefDiscount";
            this.Text = "frmLineItemBriefDiscount";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchaseBookLineItemUpdate_FormClosing);
            this.Load += new System.EventHandler(this.frmLineItemBriefDiscount_Load);
            this.tblDiscount.ResumeLayout(false);
            this.tblDiscount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblDiscount;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.TextBox txtVolDiscount;
        private System.Windows.Forms.TextBox txtSpecialDiscount;
        private System.Windows.Forms.Label lblSpecialDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblVolumeDiscount;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.MaskedTextBox dtExpiry;
    }
}