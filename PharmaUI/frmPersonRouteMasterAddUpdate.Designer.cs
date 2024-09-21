namespace PharmaUI
{
    partial class frmPersonRouteMasterAddUpdate
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPersonRouteName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonRouteCode = new System.Windows.Forms.TextBox();
            this.lblAccNo = new System.Windows.Forms.Label();
            this.cbPersonRouteType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(209, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(101, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 48);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPersonRouteName
            // 
            this.tbPersonRouteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbPersonRouteName.Location = new System.Drawing.Point(189, 135);
            this.tbPersonRouteName.Name = "tbPersonRouteName";
            this.tbPersonRouteName.Size = new System.Drawing.Size(212, 23);
            this.tbPersonRouteName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Person/Route Name";
            // 
            // txtPersonRouteCode
            // 
            this.txtPersonRouteCode.Enabled = false;
            this.txtPersonRouteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonRouteCode.Location = new System.Drawing.Point(189, 93);
            this.txtPersonRouteCode.Name = "txtPersonRouteCode";
            this.txtPersonRouteCode.ReadOnly = true;
            this.txtPersonRouteCode.Size = new System.Drawing.Size(212, 23);
            this.txtPersonRouteCode.TabIndex = 2;
            // 
            // lblAccNo
            // 
            this.lblAccNo.AutoSize = true;
            this.lblAccNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccNo.Location = new System.Drawing.Point(35, 95);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(113, 19);
            this.lblAccNo.TabIndex = 29;
            this.lblAccNo.Text = "Account Number";
            // 
            // cbPersonRouteType
            // 
            this.cbPersonRouteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonRouteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPersonRouteType.FormattingEnabled = true;
            this.cbPersonRouteType.Location = new System.Drawing.Point(189, 56);
            this.cbPersonRouteType.Name = "cbPersonRouteType";
            this.cbPersonRouteType.Size = new System.Drawing.Size(212, 24);
            this.cbPersonRouteType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Person/Route Type";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(189, 175);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(212, 21);
            this.cbxStatus.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Status";
            // 
            // frmPersonRouteMasterAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 300);
            this.ControlBox = false;
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbPersonRouteName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPersonRouteCode);
            this.Controls.Add(this.lblAccNo);
            this.Controls.Add(this.cbPersonRouteType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPersonRouteMasterAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPersonRouteMasterAddUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPersonRouteName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersonRouteCode;
        private System.Windows.Forms.Label lblAccNo;
        private System.Windows.Forms.ComboBox cbPersonRouteType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label2;
    }
}