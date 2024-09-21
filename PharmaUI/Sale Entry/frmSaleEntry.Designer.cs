namespace PharmaUI
{
    partial class frmSaleEntry
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
            this.dtSaleDate = new System.Windows.Forms.MaskedTextBox();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.txtSalesManCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSaleManName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDueBills = new System.Windows.Forms.Label();
            this.lblFRate = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lblTotalSchemeAmt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalDiscountAmt = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalTaxAmount = new System.Windows.Forms.Label();
            this.lblTotalNetAmount = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPacking = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblItemAmount = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblSaleTypeCode = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblCaseQuantity = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblScheme = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIsHalf = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSurharge = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblHalf = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.errFrmSaleEntry = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDueBillAmount = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLBRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblLBDis = new System.Windows.Forms.Label();
            this.lblLBSpLDis = new System.Windows.Forms.Label();
            this.lblLBTax = new System.Windows.Forms.Label();
            this.lblLBBatch = new System.Windows.Forms.Label();
            this.lblLBScheme = new System.Windows.Forms.Label();
            this.lblLBDate = new System.Windows.Forms.Label();
            this.cbxSaleFormType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxSaleType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmSaleEntry)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtSaleDate
            // 
            this.dtSaleDate.Location = new System.Drawing.Point(97, 57);
            this.dtSaleDate.Mask = "00/00/0000";
            this.dtSaleDate.Name = "dtSaleDate";
            this.dtSaleDate.Size = new System.Drawing.Size(100, 20);
            this.dtSaleDate.TabIndex = 7;
            this.dtSaleDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(13, 60);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(30, 13);
            this.lblPurchaseDate.TabIndex = 5;
            this.lblPurchaseDate.Text = "Date";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(349, 57);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(146, 20);
            this.txtCustomerCode.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(510, 60);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerName.TabIndex = 13;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(9, 86);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNumber.TabIndex = 14;
            this.lblInvoiceNumber.Text = "Invoice Number";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(97, 83);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(146, 20);
            this.txtInvoiceNumber.TabIndex = 9;
            // 
            // txtSalesManCode
            // 
            this.txtSalesManCode.Location = new System.Drawing.Point(349, 83);
            this.txtSalesManCode.Name = "txtSalesManCode";
            this.txtSalesManCode.Size = new System.Drawing.Size(146, 20);
            this.txtSalesManCode.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sales Man";
            // 
            // lblSaleManName
            // 
            this.lblSaleManName.AutoSize = true;
            this.lblSaleManName.Location = new System.Drawing.Point(510, 86);
            this.lblSaleManName.Name = "lblSaleManName";
            this.lblSaleManName.Size = new System.Drawing.Size(0, 13);
            this.lblSaleManName.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1037, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 48);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(776, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Due Bills";
            // 
            // lblDueBills
            // 
            this.lblDueBills.AutoSize = true;
            this.lblDueBills.Location = new System.Drawing.Point(844, 60);
            this.lblDueBills.Name = "lblDueBills";
            this.lblDueBills.Size = new System.Drawing.Size(48, 13);
            this.lblDueBills.TabIndex = 26;
            this.lblDueBills.Text = "Due Bills";
            // 
            // lblFRate
            // 
            this.lblFRate.AutoSize = true;
            this.lblFRate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblFRate.Location = new System.Drawing.Point(674, 60);
            this.lblFRate.Name = "lblFRate";
            this.lblFRate.Size = new System.Drawing.Size(39, 13);
            this.lblFRate.TabIndex = 27;
            this.lblFRate.Text = "F.Rate";
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
            this.dgvLineItem.Location = new System.Drawing.Point(8, 116);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLineItem.Size = new System.Drawing.Size(1116, 202);
            this.dgvLineItem.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label42, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalSchemeAmt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalDiscountAmt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalAmount, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalTaxAmount, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalNetAmount, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 321);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 30);
            this.tableLayoutPanel1.TabIndex = 130;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 38);
            this.label5.TabIndex = 124;
            this.label5.Text = "Scheme Amount";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(892, 4);
            this.label42.Margin = new System.Windows.Forms.Padding(3);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 38);
            this.label42.TabIndex = 128;
            this.label42.Text = "Total Amount";
            // 
            // lblTotalSchemeAmt
            // 
            this.lblTotalSchemeAmt.AutoSize = true;
            this.lblTotalSchemeAmt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSchemeAmt.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalSchemeAmt.Location = new System.Drawing.Point(115, 4);
            this.lblTotalSchemeAmt.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalSchemeAmt.Name = "lblTotalSchemeAmt";
            this.lblTotalSchemeAmt.Size = new System.Drawing.Size(32, 19);
            this.lblTotalSchemeAmt.TabIndex = 116;
            this.lblTotalSchemeAmt.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(226, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 38);
            this.label6.TabIndex = 125;
            this.label6.Text = "Discount Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(670, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 38);
            this.label8.TabIndex = 127;
            this.label8.Text = "Invoice Amount";
            // 
            // lblTotalDiscountAmt
            // 
            this.lblTotalDiscountAmt.AutoSize = true;
            this.lblTotalDiscountAmt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscountAmt.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalDiscountAmt.Location = new System.Drawing.Point(337, 4);
            this.lblTotalDiscountAmt.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalDiscountAmt.Name = "lblTotalDiscountAmt";
            this.lblTotalDiscountAmt.Size = new System.Drawing.Size(32, 19);
            this.lblTotalDiscountAmt.TabIndex = 117;
            this.lblTotalDiscountAmt.Text = "0.0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(1003, 4);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalAmount.TabIndex = 123;
            this.lblTotalAmount.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(448, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 126;
            this.label7.Text = "Tax Amount";
            // 
            // lblTotalTaxAmount
            // 
            this.lblTotalTaxAmount.AutoSize = true;
            this.lblTotalTaxAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTaxAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalTaxAmount.Location = new System.Drawing.Point(559, 4);
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
            this.lblTotalNetAmount.Location = new System.Drawing.Point(781, 4);
            this.lblTotalNetAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalNetAmount.Name = "lblTotalNetAmount";
            this.lblTotalNetAmount.Size = new System.Drawing.Size(32, 19);
            this.lblTotalNetAmount.TabIndex = 121;
            this.lblTotalNetAmount.Text = "0.0";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 14;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBalance, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPacking, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblItemAmount, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label23, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSaleTypeCode, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label25, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCaseQuantity, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.label33, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblScheme, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 12, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblIsHalf, 13, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSurharge, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label13, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblHalf, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label37, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTaxRate, 7, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 352);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1116, 50);
            this.tableLayoutPanel2.TabIndex = 131;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 4);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 17);
            this.label17.TabIndex = 150;
            this.label17.Text = "Balance";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Blue;
            this.lblBalance.Location = new System.Drawing.Point(95, 4);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(3);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(18, 17);
            this.lblBalance.TabIndex = 124;
            this.lblBalance.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(188, 4);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 17);
            this.label19.TabIndex = 151;
            this.label19.Text = "Packing";
            // 
            // lblPacking
            // 
            this.lblPacking.AutoSize = true;
            this.lblPacking.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacking.ForeColor = System.Drawing.Color.Blue;
            this.lblPacking.Location = new System.Drawing.Point(249, 4);
            this.lblPacking.Margin = new System.Windows.Forms.Padding(3);
            this.lblPacking.Name = "lblPacking";
            this.lblPacking.Size = new System.Drawing.Size(32, 17);
            this.lblPacking.TabIndex = 126;
            this.lblPacking.Text = "0.0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(496, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 149;
            this.label15.Text = "Item Amount";
            // 
            // lblItemAmount
            // 
            this.lblItemAmount.AutoSize = true;
            this.lblItemAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblItemAmount.Location = new System.Drawing.Point(557, 4);
            this.lblItemAmount.Margin = new System.Windows.Forms.Padding(3);
            this.lblItemAmount.Name = "lblItemAmount";
            this.lblItemAmount.Size = new System.Drawing.Size(32, 17);
            this.lblItemAmount.TabIndex = 122;
            this.lblItemAmount.Text = "0.0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(342, 4);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 17);
            this.label23.TabIndex = 153;
            this.label23.Text = "Sale Type";
            // 
            // lblSaleTypeCode
            // 
            this.lblSaleTypeCode.AutoSize = true;
            this.lblSaleTypeCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleTypeCode.ForeColor = System.Drawing.Color.Blue;
            this.lblSaleTypeCode.Location = new System.Drawing.Point(403, 4);
            this.lblSaleTypeCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblSaleTypeCode.Name = "lblSaleTypeCode";
            this.lblSaleTypeCode.Size = new System.Drawing.Size(61, 17);
            this.lblSaleTypeCode.TabIndex = 130;
            this.lblSaleTypeCode.Text = "Sale 01";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(650, 4);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 17);
            this.label25.TabIndex = 154;
            this.label25.Text = "Case Quantity";
            // 
            // lblCaseQuantity
            // 
            this.lblCaseQuantity.AutoSize = true;
            this.lblCaseQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseQuantity.ForeColor = System.Drawing.Color.Blue;
            this.lblCaseQuantity.Location = new System.Drawing.Point(711, 4);
            this.lblCaseQuantity.Margin = new System.Windows.Forms.Padding(3);
            this.lblCaseQuantity.Name = "lblCaseQuantity";
            this.lblCaseQuantity.Size = new System.Drawing.Size(18, 17);
            this.lblCaseQuantity.TabIndex = 132;
            this.lblCaseQuantity.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(804, 4);
            this.label33.Margin = new System.Windows.Forms.Padding(3);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 17);
            this.label33.TabIndex = 158;
            this.label33.Text = "Scheme";
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheme.ForeColor = System.Drawing.Color.Blue;
            this.lblScheme.Location = new System.Drawing.Point(865, 4);
            this.lblScheme.Margin = new System.Windows.Forms.Padding(3);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(32, 17);
            this.lblScheme.TabIndex = 140;
            this.lblScheme.Text = "0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(958, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 17);
            this.label10.TabIndex = 165;
            this.label10.Text = "Half";
            // 
            // lblIsHalf
            // 
            this.lblIsHalf.AutoSize = true;
            this.lblIsHalf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsHalf.ForeColor = System.Drawing.Color.Blue;
            this.lblIsHalf.Location = new System.Drawing.Point(1019, 4);
            this.lblIsHalf.Margin = new System.Windows.Forms.Padding(3);
            this.lblIsHalf.Name = "lblIsHalf";
            this.lblIsHalf.Size = new System.Drawing.Size(32, 17);
            this.lblIsHalf.TabIndex = 166;
            this.lblIsHalf.Text = "0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 18);
            this.label11.TabIndex = 161;
            this.label11.Text = "Discount (%)";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscount.Location = new System.Drawing.Point(95, 28);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(3);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(32, 18);
            this.lblDiscount.TabIndex = 162;
            this.lblDiscount.Text = "0.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 18);
            this.label9.TabIndex = 163;
            this.label9.Text = "SC (%)";
            // 
            // lblSurharge
            // 
            this.lblSurharge.AutoSize = true;
            this.lblSurharge.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurharge.ForeColor = System.Drawing.Color.Blue;
            this.lblSurharge.Location = new System.Drawing.Point(249, 28);
            this.lblSurharge.Margin = new System.Windows.Forms.Padding(3);
            this.lblSurharge.Name = "lblSurharge";
            this.lblSurharge.Size = new System.Drawing.Size(32, 18);
            this.lblSurharge.TabIndex = 164;
            this.lblSurharge.Text = "0.0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(342, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 18);
            this.label13.TabIndex = 171;
            this.label13.Text = "Half (%)";
            // 
            // lblHalf
            // 
            this.lblHalf.AutoSize = true;
            this.lblHalf.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalf.ForeColor = System.Drawing.Color.Blue;
            this.lblHalf.Location = new System.Drawing.Point(403, 28);
            this.lblHalf.Margin = new System.Windows.Forms.Padding(3);
            this.lblHalf.Name = "lblHalf";
            this.lblHalf.Size = new System.Drawing.Size(32, 18);
            this.lblHalf.TabIndex = 172;
            this.lblHalf.Text = "0.0";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(496, 28);
            this.label37.Margin = new System.Windows.Forms.Padding(3);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 18);
            this.label37.TabIndex = 160;
            this.label37.Text = "Tax (%)";
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxRate.ForeColor = System.Drawing.Color.Blue;
            this.lblTaxRate.Location = new System.Drawing.Point(557, 28);
            this.lblTaxRate.Margin = new System.Windows.Forms.Padding(3);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(32, 18);
            this.lblTaxRate.TabIndex = 144;
            this.lblTaxRate.Text = "0.0";
            // 
            // errFrmSaleEntry
            // 
            this.errFrmSaleEntry.ContainerControl = this;
            // 
            // lblDueBillAmount
            // 
            this.lblDueBillAmount.AutoSize = true;
            this.lblDueBillAmount.Location = new System.Drawing.Point(919, 60);
            this.lblDueBillAmount.Name = "lblDueBillAmount";
            this.lblDueBillAmount.Size = new System.Drawing.Size(48, 13);
            this.lblDueBillAmount.TabIndex = 132;
            this.lblDueBillAmount.Text = "Due Bills";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 14;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.Controls.Add(this.lblLBRate, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label16, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label18, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.label20, 10, 0);
            this.tableLayoutPanel3.Controls.Add(this.label21, 12, 0);
            this.tableLayoutPanel3.Controls.Add(this.label24, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLBDis, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLBSpLDis, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLBTax, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLBBatch, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLBScheme, 11, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLBDate, 13, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 404);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1116, 30);
            this.tableLayoutPanel3.TabIndex = 133;
            // 
            // lblLBRate
            // 
            this.lblLBRate.AutoSize = true;
            this.lblLBRate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBRate.ForeColor = System.Drawing.Color.Blue;
            this.lblLBRate.Location = new System.Drawing.Point(95, 4);
            this.lblLBRate.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBRate.Name = "lblLBRate";
            this.lblLBRate.Size = new System.Drawing.Size(32, 19);
            this.lblLBRate.TabIndex = 163;
            this.lblLBRate.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 151;
            this.label4.Text = "Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(342, 4);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 38);
            this.label14.TabIndex = 153;
            this.label14.Text = "Spl Dis";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(496, 4);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 19);
            this.label16.TabIndex = 154;
            this.label16.Text = "Tax";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(650, 4);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 19);
            this.label18.TabIndex = 155;
            this.label18.Text = "Batch";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(804, 4);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 38);
            this.label20.TabIndex = 156;
            this.label20.Text = "Scheme";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(958, 4);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 19);
            this.label21.TabIndex = 157;
            this.label21.Text = "Date";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(249, 4);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 19);
            this.label24.TabIndex = 164;
            this.label24.Text = "0.0";
            // 
            // lblLBDis
            // 
            this.lblLBDis.AutoSize = true;
            this.lblLBDis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBDis.Location = new System.Drawing.Point(188, 4);
            this.lblLBDis.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBDis.Name = "lblLBDis";
            this.lblLBDis.Size = new System.Drawing.Size(53, 38);
            this.lblLBDis.TabIndex = 152;
            this.lblLBDis.Text = "Dis(%)";
            // 
            // lblLBSpLDis
            // 
            this.lblLBSpLDis.AutoSize = true;
            this.lblLBSpLDis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBSpLDis.ForeColor = System.Drawing.Color.Blue;
            this.lblLBSpLDis.Location = new System.Drawing.Point(403, 4);
            this.lblLBSpLDis.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBSpLDis.Name = "lblLBSpLDis";
            this.lblLBSpLDis.Size = new System.Drawing.Size(32, 19);
            this.lblLBSpLDis.TabIndex = 165;
            this.lblLBSpLDis.Text = "0.0";
            // 
            // lblLBTax
            // 
            this.lblLBTax.AutoSize = true;
            this.lblLBTax.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBTax.ForeColor = System.Drawing.Color.Blue;
            this.lblLBTax.Location = new System.Drawing.Point(557, 4);
            this.lblLBTax.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBTax.Name = "lblLBTax";
            this.lblLBTax.Size = new System.Drawing.Size(32, 19);
            this.lblLBTax.TabIndex = 166;
            this.lblLBTax.Text = "0.0";
            // 
            // lblLBBatch
            // 
            this.lblLBBatch.AutoSize = true;
            this.lblLBBatch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBBatch.ForeColor = System.Drawing.Color.Blue;
            this.lblLBBatch.Location = new System.Drawing.Point(711, 4);
            this.lblLBBatch.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBBatch.Name = "lblLBBatch";
            this.lblLBBatch.Size = new System.Drawing.Size(32, 19);
            this.lblLBBatch.TabIndex = 167;
            this.lblLBBatch.Text = "0.0";
            // 
            // lblLBScheme
            // 
            this.lblLBScheme.AutoSize = true;
            this.lblLBScheme.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBScheme.ForeColor = System.Drawing.Color.Blue;
            this.lblLBScheme.Location = new System.Drawing.Point(865, 4);
            this.lblLBScheme.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBScheme.Name = "lblLBScheme";
            this.lblLBScheme.Size = new System.Drawing.Size(32, 19);
            this.lblLBScheme.TabIndex = 168;
            this.lblLBScheme.Text = "0.0";
            // 
            // lblLBDate
            // 
            this.lblLBDate.AutoSize = true;
            this.lblLBDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBDate.ForeColor = System.Drawing.Color.Blue;
            this.lblLBDate.Location = new System.Drawing.Point(1019, 4);
            this.lblLBDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblLBDate.Name = "lblLBDate";
            this.lblLBDate.Size = new System.Drawing.Size(32, 19);
            this.lblLBDate.TabIndex = 169;
            this.lblLBDate.Text = "0.0";
            // 
            // cbxSaleFormType
            // 
            this.cbxSaleFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaleFormType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSaleFormType.FormattingEnabled = true;
            this.cbxSaleFormType.Location = new System.Drawing.Point(898, 83);
            this.cbxSaleFormType.Name = "cbxSaleFormType";
            this.cbxSaleFormType.Size = new System.Drawing.Size(132, 21);
            this.cbxSaleFormType.TabIndex = 12;
            this.cbxSaleFormType.Visible = false;
            this.cbxSaleFormType.SelectedIndexChanged += new System.EventHandler(this.cbxSaleFormType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(685, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 134;
            this.label12.Text = "Sales Type";
            // 
            // cbxSaleType
            // 
            this.cbxSaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaleType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSaleType.FormattingEnabled = true;
            this.cbxSaleType.Location = new System.Drawing.Point(746, 83);
            this.cbxSaleType.Name = "cbxSaleType";
            this.cbxSaleType.Size = new System.Drawing.Size(146, 21);
            this.cbxSaleType.TabIndex = 11;
            this.cbxSaleType.SelectedIndexChanged += new System.EventHandler(this.cbxSaleType_SelectedIndexChanged);
            // 
            // frmSaleEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 449);
            this.ControlBox = false;
            this.Controls.Add(this.cbxSaleType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbxSaleFormType);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.lblDueBillAmount);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.lblFRate);
            this.Controls.Add(this.lblDueBills);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSaleManName);
            this.Controls.Add(this.txtSalesManCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInvoiceNumber);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.dtSaleDate);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaleEntry";
            this.Text = "frmSaleEntry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSaleEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmSaleEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSaleEntry_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errFrmSaleEntry)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox dtSaleDate;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.TextBox txtSalesManCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaleManName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDueBills;
        private System.Windows.Forms.Label lblFRate;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblTotalSchemeAmt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalDiscountAmt;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalTaxAmount;
        private System.Windows.Forms.Label lblTotalNetAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPacking;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblCaseQuantity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblItemAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSurharge;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblSaleTypeCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIsHalf;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblHalf;
        private System.Windows.Forms.ErrorProvider errFrmSaleEntry;
        private System.Windows.Forms.Label lblDueBillAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLBRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLBDis;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblLBSpLDis;
        private System.Windows.Forms.Label lblLBTax;
        private System.Windows.Forms.Label lblLBBatch;
        private System.Windows.Forms.Label lblLBScheme;
        private System.Windows.Forms.Label lblLBDate;
        private System.Windows.Forms.ComboBox cbxSaleFormType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxSaleType;
    }
}