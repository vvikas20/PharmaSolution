namespace PharmaUI
{
    partial class frmPurchaseBookTransaction
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
            this.components = new System.ComponentModel.Container();
            this.lblPurchaseType = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.cbxPurchaseType = new System.Windows.Forms.ComboBox();
            this.cbxPurchaseFormType = new System.Windows.Forms.ComboBox();
            this.errFrmPurchaseBookHeader = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtPurchaseDate = new System.Windows.Forms.MaskedTextBox();
            this.lblTotalDiscountAmt = new System.Windows.Forms.Label();
            this.lblTotalTaxAmount = new System.Windows.Forms.Label();
            this.lblTotalNetAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSaleRate = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblDiscountPercente = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSplDisAmount = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblBonus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSchemeAmount = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblTaxPercent = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblVolumeDiscountAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSplDiscountPercent = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblVolumeDis = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblTotalSchemeAmt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmPurchaseBookHeader)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPurchaseType
            // 
            this.lblPurchaseType.AutoSize = true;
            this.lblPurchaseType.Location = new System.Drawing.Point(287, 85);
            this.lblPurchaseType.Name = "lblPurchaseType";
            this.lblPurchaseType.Size = new System.Drawing.Size(79, 13);
            this.lblPurchaseType.TabIndex = 8;
            this.lblPurchaseType.Text = "Purchase Type";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(9, 85);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNumber.TabIndex = 6;
            this.lblInvoiceNumber.Text = "Invoice Number";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(97, 82);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(146, 20);
            this.txtInvoiceNumber.TabIndex = 7;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(13, 60);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(78, 13);
            this.lblPurchaseDate.TabIndex = 0;
            this.lblPurchaseDate.Text = "Purchase Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(373, 57);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(146, 20);
            this.txtSupplierCode.TabIndex = 4;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.AllowUserToOrderColumns = true;
            this.dgvLineItem.AllowUserToResizeColumns = false;
            this.dgvLineItem.AllowUserToResizeRows = false;
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvLineItem.Location = new System.Drawing.Point(12, 108);
            this.dgvLineItem.MultiSelect = false;
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLineItem.Size = new System.Drawing.Size(894, 202);
            this.dgvLineItem.TabIndex = 11;
            this.dgvLineItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLineItem_KeyDown);
            // 
            // cbxPurchaseType
            // 
            this.cbxPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPurchaseType.FormattingEnabled = true;
            this.cbxPurchaseType.Location = new System.Drawing.Point(373, 81);
            this.cbxPurchaseType.Name = "cbxPurchaseType";
            this.cbxPurchaseType.Size = new System.Drawing.Size(146, 21);
            this.cbxPurchaseType.TabIndex = 8;
            // 
            // cbxPurchaseFormType
            // 
            this.cbxPurchaseFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPurchaseFormType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPurchaseFormType.FormattingEnabled = true;
            this.cbxPurchaseFormType.Location = new System.Drawing.Point(525, 81);
            this.cbxPurchaseFormType.Name = "cbxPurchaseFormType";
            this.cbxPurchaseFormType.Size = new System.Drawing.Size(132, 21);
            this.cbxPurchaseFormType.TabIndex = 9;
            this.cbxPurchaseFormType.Visible = false;
            this.cbxPurchaseFormType.SelectedIndexChanged += new System.EventHandler(this.cbxPurchaseFormType_SelectedIndexChanged);
            // 
            // errFrmPurchaseBookHeader
            // 
            this.errFrmPurchaseBookHeader.ContainerControl = this;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(525, 60);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(0, 13);
            this.lblSupplierName.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(823, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.Location = new System.Drawing.Point(98, 57);
            this.dtPurchaseDate.Mask = "00/00/0000";
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(100, 20);
            this.dtPurchaseDate.TabIndex = 3;
            this.dtPurchaseDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblTotalDiscountAmt
            // 
            this.lblTotalDiscountAmt.AutoSize = true;
            this.lblTotalDiscountAmt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscountAmt.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalDiscountAmt.Location = new System.Drawing.Point(319, 4);
            this.lblTotalDiscountAmt.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalDiscountAmt.Name = "lblTotalDiscountAmt";
            this.lblTotalDiscountAmt.Size = new System.Drawing.Size(32, 19);
            this.lblTotalDiscountAmt.TabIndex = 117;
            this.lblTotalDiscountAmt.Text = "0.0";
            // 
            // lblTotalTaxAmount
            // 
            this.lblTotalTaxAmount.AutoSize = true;
            this.lblTotalTaxAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTaxAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalTaxAmount.Location = new System.Drawing.Point(490, 4);
            this.lblTotalTaxAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalTaxAmount.Name = "lblTotalTaxAmount";
            this.lblTotalTaxAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalTaxAmount.TabIndex = 119;
            this.lblTotalTaxAmount.Text = "0.0";
            // 
            // lblTotalNetAmount
            // 
            this.lblTotalNetAmount.AutoSize = true;
            this.lblTotalNetAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNetAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalNetAmount.Location = new System.Drawing.Point(661, 4);
            this.lblTotalNetAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalNetAmount.Name = "lblTotalNetAmount";
            this.lblTotalNetAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalNetAmount.TabIndex = 121;
            this.lblTotalNetAmount.Text = "0.0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(832, 4);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalAmount.TabIndex = 123;
            this.lblTotalAmount.Text = "0.0";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSaleRate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMRP, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label25, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscountPercente, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblInvoiceAmount, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSplDisAmount, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label23, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBonus, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSchemeAmount, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label29, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTaxPercent, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.label37, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTaxAmount, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblVolumeDiscountAmount, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSplDiscountPercent, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label14, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblVolumeDis, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label33, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscountAmount, 3, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 348);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(894, 77);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 150;
            this.label17.Text = "Sale Rate";
            // 
            // lblSaleRate
            // 
            this.lblSaleRate.AutoSize = true;
            this.lblSaleRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleRate.ForeColor = System.Drawing.Color.Blue;
            this.lblSaleRate.Location = new System.Drawing.Point(153, 3);
            this.lblSaleRate.Margin = new System.Windows.Forms.Padding(3);
            this.lblSaleRate.Name = "lblSaleRate";
            this.lblSaleRate.Size = new System.Drawing.Size(26, 13);
            this.lblSaleRate.TabIndex = 124;
            this.lblSaleRate.Text = "0.0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(226, 3);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 13);
            this.label19.TabIndex = 151;
            this.label19.Text = "MRP";
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRP.ForeColor = System.Drawing.Color.Blue;
            this.lblMRP.Location = new System.Drawing.Point(376, 3);
            this.lblMRP.Margin = new System.Windows.Forms.Padding(3);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(26, 13);
            this.lblMRP.TabIndex = 126;
            this.lblMRP.Text = "0.0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(3, 22);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 13);
            this.label25.TabIndex = 154;
            this.label25.Text = "Discount (%)";
            // 
            // lblDiscountPercente
            // 
            this.lblDiscountPercente.AutoSize = true;
            this.lblDiscountPercente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountPercente.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscountPercente.Location = new System.Drawing.Point(153, 22);
            this.lblDiscountPercente.Margin = new System.Windows.Forms.Padding(3);
            this.lblDiscountPercente.Name = "lblDiscountPercente";
            this.lblDiscountPercente.Size = new System.Drawing.Size(26, 13);
            this.lblDiscountPercente.TabIndex = 132;
            this.lblDiscountPercente.Text = "0.0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(672, 3);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 149;
            this.label15.Text = "Item Amount";
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.AutoSize = true;
            this.lblInvoiceAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblInvoiceAmount.Location = new System.Drawing.Point(822, 3);
            this.lblInvoiceAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(26, 13);
            this.lblInvoiceAmount.TabIndex = 122;
            this.lblInvoiceAmount.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(226, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "SPL Discount Amount";
            // 
            // lblSplDisAmount
            // 
            this.lblSplDisAmount.AutoSize = true;
            this.lblSplDisAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplDisAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblSplDisAmount.Location = new System.Drawing.Point(376, 41);
            this.lblSplDisAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblSplDisAmount.Name = "lblSplDisAmount";
            this.lblSplDisAmount.Size = new System.Drawing.Size(26, 13);
            this.lblSplDisAmount.TabIndex = 164;
            this.lblSplDisAmount.Text = "0.0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(449, 3);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 153;
            this.label23.Text = "Bonus";
            // 
            // lblBonus
            // 
            this.lblBonus.AutoSize = true;
            this.lblBonus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonus.ForeColor = System.Drawing.Color.Blue;
            this.lblBonus.Location = new System.Drawing.Point(599, 3);
            this.lblBonus.Margin = new System.Windows.Forms.Padding(3);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(15, 13);
            this.lblBonus.TabIndex = 130;
            this.lblBonus.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(449, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 165;
            this.label10.Text = "Scheme Discount Amount";
            // 
            // lblSchemeAmount
            // 
            this.lblSchemeAmount.AutoSize = true;
            this.lblSchemeAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchemeAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblSchemeAmount.Location = new System.Drawing.Point(599, 22);
            this.lblSchemeAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblSchemeAmount.Name = "lblSchemeAmount";
            this.lblSchemeAmount.Size = new System.Drawing.Size(26, 13);
            this.lblSchemeAmount.TabIndex = 166;
            this.lblSchemeAmount.Text = "0.0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(672, 22);
            this.label29.Margin = new System.Windows.Forms.Padding(3);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 13);
            this.label29.TabIndex = 156;
            this.label29.Text = "Tax Rate (%)";
            // 
            // lblTaxPercent
            // 
            this.lblTaxPercent.AutoSize = true;
            this.lblTaxPercent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxPercent.ForeColor = System.Drawing.Color.Blue;
            this.lblTaxPercent.Location = new System.Drawing.Point(822, 22);
            this.lblTaxPercent.Margin = new System.Windows.Forms.Padding(3);
            this.lblTaxPercent.Name = "lblTaxPercent";
            this.lblTaxPercent.Size = new System.Drawing.Size(26, 13);
            this.lblTaxPercent.TabIndex = 136;
            this.lblTaxPercent.Text = "0.0";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(672, 41);
            this.label37.Margin = new System.Windows.Forms.Padding(3);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(77, 13);
            this.label37.TabIndex = 160;
            this.label37.Text = "Tax Amount";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTaxAmount.Location = new System.Drawing.Point(822, 41);
            this.lblTaxAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(26, 13);
            this.lblTaxAmount.TabIndex = 144;
            this.lblTaxAmount.Text = "0.0";
            // 
            // lblVolumeDiscountAmount
            // 
            this.lblVolumeDiscountAmount.AutoSize = true;
            this.lblVolumeDiscountAmount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeDiscountAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblVolumeDiscountAmount.Location = new System.Drawing.Point(376, 60);
            this.lblVolumeDiscountAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblVolumeDiscountAmount.Name = "lblVolumeDiscountAmount";
            this.lblVolumeDiscountAmount.Size = new System.Drawing.Size(28, 14);
            this.lblVolumeDiscountAmount.TabIndex = 170;
            this.lblVolumeDiscountAmount.Text = "0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 161;
            this.label3.Text = "SPL Discount (%)";
            // 
            // lblSplDiscountPercent
            // 
            this.lblSplDiscountPercent.AutoSize = true;
            this.lblSplDiscountPercent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSplDiscountPercent.ForeColor = System.Drawing.Color.Blue;
            this.lblSplDiscountPercent.Location = new System.Drawing.Point(153, 41);
            this.lblSplDiscountPercent.Margin = new System.Windows.Forms.Padding(3);
            this.lblSplDiscountPercent.Name = "lblSplDiscountPercent";
            this.lblSplDiscountPercent.Size = new System.Drawing.Size(26, 13);
            this.lblSplDiscountPercent.TabIndex = 162;
            this.lblSplDiscountPercent.Text = "0.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(226, 60);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 14);
            this.label14.TabIndex = 169;
            this.label14.Text = "Volume Discount Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 60);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 14);
            this.label12.TabIndex = 167;
            this.label12.Text = "Volume Discount";
            // 
            // lblVolumeDis
            // 
            this.lblVolumeDis.AutoSize = true;
            this.lblVolumeDis.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeDis.ForeColor = System.Drawing.Color.Blue;
            this.lblVolumeDis.Location = new System.Drawing.Point(153, 60);
            this.lblVolumeDis.Margin = new System.Windows.Forms.Padding(3);
            this.lblVolumeDis.Name = "lblVolumeDis";
            this.lblVolumeDis.Size = new System.Drawing.Size(28, 14);
            this.lblVolumeDis.TabIndex = 168;
            this.lblVolumeDis.Text = "0.0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(226, 22);
            this.label33.Margin = new System.Windows.Forms.Padding(3);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(104, 13);
            this.label33.TabIndex = 158;
            this.label33.Text = "Discount Amount";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscountAmount.Location = new System.Drawing.Point(376, 22);
            this.lblDiscountAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(26, 13);
            this.lblDiscountAmount.TabIndex = 140;
            this.lblDiscountAmount.Text = "0.0";
            // 
            // lblTotalSchemeAmt
            // 
            this.lblTotalSchemeAmt.AutoSize = true;
            this.lblTotalSchemeAmt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSchemeAmt.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalSchemeAmt.Location = new System.Drawing.Point(134, 4);
            this.lblTotalSchemeAmt.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalSchemeAmt.Name = "lblTotalSchemeAmt";
            this.lblTotalSchemeAmt.Size = new System.Drawing.Size(32, 19);
            this.lblTotalSchemeAmt.TabIndex = 116;
            this.lblTotalSchemeAmt.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 124;
            this.label2.Text = "Scheme Amount";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(191, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 125;
            this.label4.Text = "Discount Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 126;
            this.label6.Text = "Tax Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(547, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 127;
            this.label8.Text = "Invoice Amount";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(718, 4);
            this.label42.Margin = new System.Windows.Forms.Padding(3);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(91, 17);
            this.label42.TabIndex = 128;
            this.label42.Text = "Total Amount";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.72244F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.436042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.48109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.436042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.436041F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.436042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.436042F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label42, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalSchemeAmt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalDiscountAmt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalAmount, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalTaxAmount, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalNetAmount, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 312);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 30);
            this.tableLayoutPanel1.TabIndex = 129;
            // 
            // frmPurchaseBookTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 449);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.dtPurchaseDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblPurchaseType);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.cbxPurchaseType);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.cbxPurchaseFormType);
            this.Controls.Add(this.txtSupplierCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseBookTransaction";
            this.Text = "frmPurchaseBookTransaction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchaseBookTransaction_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPurchaseBookTransaction_FormClosed);
            this.Load += new System.EventHandler(this.frmPurchaseBookTransaction_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseBookTransaction_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmPurchaseBookHeader)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblPurchaseType;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.ErrorProvider errFrmPurchaseBookHeader;
        private System.Windows.Forms.ComboBox cbxPurchaseType;
        private System.Windows.Forms.ComboBox cbxPurchaseFormType;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox dtPurchaseDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalNetAmount;
        private System.Windows.Forms.Label lblTotalTaxAmount;
        private System.Windows.Forms.Label lblTotalDiscountAmt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTotalSchemeAmt;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblTaxPercent;
        private System.Windows.Forms.Label lblDiscountPercente;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblSaleRate;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSplDiscountPercent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSplDisAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSchemeAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblVolumeDis;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblVolumeDiscountAmount;
    }
}