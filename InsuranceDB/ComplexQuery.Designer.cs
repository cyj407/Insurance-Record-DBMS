namespace InsuranceDB
{
    partial class ComplexQuery
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
            this.tbConVal = new System.Windows.Forms.TextBox();
            this.cbNestedOp = new System.Windows.Forms.ComboBox();
            this.cbOperand = new System.Windows.Forms.ComboBox();
            this.cbAggreOp = new System.Windows.Forms.ComboBox();
            this.cbGroupBy = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbInsuranceID = new System.Windows.Forms.CheckBox();
            this.cbIType = new System.Windows.Forms.CheckBox();
            this.cbOwnerID = new System.Windows.Forms.CheckBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.cbFuelTax = new System.Windows.Forms.CheckBox();
            this.cbLicTax = new System.Windows.Forms.CheckBox();
            this.cbPaymentID = new System.Windows.Forms.CheckBox();
            this.cbPrice = new System.Windows.Forms.CheckBox();
            this.cbPType = new System.Windows.Forms.CheckBox();
            this.cbBrand = new System.Windows.Forms.CheckBox();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.cbTaxID = new System.Windows.Forms.CheckBox();
            this.cbVType = new System.Windows.Forms.CheckBox();
            this.cbLicense = new System.Windows.Forms.CheckBox();
            this.cbCost = new System.Windows.Forms.CheckBox();
            this.cbIID = new System.Windows.Forms.CheckBox();
            this.cbAddress = new System.Windows.Forms.CheckBox();
            this.cbGender = new System.Windows.Forms.CheckBox();
            this.cbName = new System.Windows.Forms.CheckBox();
            this.cbOID = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTax = new System.Windows.Forms.CheckBox();
            this.cbInsurance = new System.Windows.Forms.CheckBox();
            this.cbVehicle = new System.Windows.Forms.CheckBox();
            this.cbPayment = new System.Windows.Forms.CheckBox();
            this.cbOwner = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvConstraint = new System.Windows.Forms.DataGridView();
            this.attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbAggre = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAggre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAggreAttri = new System.Windows.Forms.ComboBox();
            this.lbAttri = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbNested = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraint)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConVal
            // 
            this.tbConVal.Location = new System.Drawing.Point(392, 104);
            this.tbConVal.MaxLength = 100000;
            this.tbConVal.Name = "tbConVal";
            this.tbConVal.Size = new System.Drawing.Size(107, 29);
            this.tbConVal.TabIndex = 53;
            // 
            // cbNestedOp
            // 
            this.cbNestedOp.AutoCompleteCustomSource.AddRange(new string[] {
            "包含(IN)",
            "不包含(NOT IN)",
            "存在(EXISTS)",
            "不存在(NOT EXISTS)"});
            this.cbNestedOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNestedOp.FormattingEnabled = true;
            this.cbNestedOp.Items.AddRange(new object[] {
            "存在",
            "不存在",
            "滿足",
            "不滿足"});
            this.cbNestedOp.Location = new System.Drawing.Point(147, 24);
            this.cbNestedOp.Name = "cbNestedOp";
            this.cbNestedOp.Size = new System.Drawing.Size(113, 26);
            this.cbNestedOp.TabIndex = 45;
            // 
            // cbOperand
            // 
            this.cbOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperand.FormattingEnabled = true;
            this.cbOperand.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<="});
            this.cbOperand.Location = new System.Drawing.Point(337, 105);
            this.cbOperand.Name = "cbOperand";
            this.cbOperand.Size = new System.Drawing.Size(47, 26);
            this.cbOperand.TabIndex = 52;
            // 
            // cbAggreOp
            // 
            this.cbAggreOp.AutoCompleteCustomSource.AddRange(new string[] {
            "滿足",
            "不滿足",
            "存在",
            "不存在"});
            this.cbAggreOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAggreOp.FormattingEnabled = true;
            this.cbAggreOp.Items.AddRange(new object[] {
            "COUNT",
            "SUM",
            "MAX",
            "MIN",
            "AVG"});
            this.cbAggreOp.Location = new System.Drawing.Point(146, 26);
            this.cbAggreOp.Name = "cbAggreOp";
            this.cbAggreOp.Size = new System.Drawing.Size(128, 26);
            this.cbAggreOp.TabIndex = 47;
            this.cbAggreOp.SelectedIndexChanged += new System.EventHandler(this.cbAggreOp_SelectedIndexChanged);
            // 
            // cbGroupBy
            // 
            this.cbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupBy.FormattingEnabled = true;
            this.cbGroupBy.Location = new System.Drawing.Point(73, 66);
            this.cbGroupBy.Name = "cbGroupBy";
            this.cbGroupBy.Size = new System.Drawing.Size(147, 26);
            this.cbGroupBy.TabIndex = 50;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 18);
            this.label21.TabIndex = 48;
            this.label21.Text = "根據";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 109);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 18);
            this.label22.TabIndex = 49;
            this.label22.Text = "計算結果限制：";
            // 
            // cbOperation
            // 
            this.cbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Items.AddRange(new object[] {
            "查詢",
            "新增",
            "修改",
            "刪除"});
            this.cbOperation.Location = new System.Drawing.Point(22, 17);
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(122, 26);
            this.cbOperation.TabIndex = 43;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(1160, 553);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(112, 34);
            this.btnEnter.TabIndex = 55;
            this.btnEnter.Text = "送出";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 56;
            this.label1.Text = "所有";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbInsuranceID);
            this.groupBox6.Controls.Add(this.cbIType);
            this.groupBox6.Controls.Add(this.cbOwnerID);
            this.groupBox6.Controls.Add(this.cbAll);
            this.groupBox6.Controls.Add(this.cbFuelTax);
            this.groupBox6.Controls.Add(this.cbLicTax);
            this.groupBox6.Controls.Add(this.cbPaymentID);
            this.groupBox6.Controls.Add(this.cbPrice);
            this.groupBox6.Controls.Add(this.cbPType);
            this.groupBox6.Controls.Add(this.cbBrand);
            this.groupBox6.Controls.Add(this.cbDate);
            this.groupBox6.Controls.Add(this.cbTaxID);
            this.groupBox6.Controls.Add(this.cbVType);
            this.groupBox6.Controls.Add(this.cbLicense);
            this.groupBox6.Controls.Add(this.cbCost);
            this.groupBox6.Controls.Add(this.cbIID);
            this.groupBox6.Controls.Add(this.cbAddress);
            this.groupBox6.Controls.Add(this.cbGender);
            this.groupBox6.Controls.Add(this.cbName);
            this.groupBox6.Controls.Add(this.cbOID);
            this.groupBox6.Location = new System.Drawing.Point(7, 114);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(399, 173);
            this.groupBox6.TabIndex = 58;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "屬性資料";
            // 
            // cbInsuranceID
            // 
            this.cbInsuranceID.AutoSize = true;
            this.cbInsuranceID.Location = new System.Drawing.Point(12, 112);
            this.cbInsuranceID.Name = "cbInsuranceID";
            this.cbInsuranceID.Size = new System.Drawing.Size(119, 22);
            this.cbInsuranceID.TabIndex = 48;
            this.cbInsuranceID.Text = "InsuranceID";
            this.cbInsuranceID.UseVisualStyleBackColor = true;
            // 
            // cbIType
            // 
            this.cbIType.AutoSize = true;
            this.cbIType.Location = new System.Drawing.Point(12, 84);
            this.cbIType.Name = "cbIType";
            this.cbIType.Size = new System.Drawing.Size(106, 22);
            this.cbIType.TabIndex = 40;
            this.cbIType.Text = "保險種類";
            this.cbIType.UseVisualStyleBackColor = true;
            // 
            // cbOwnerID
            // 
            this.cbOwnerID.AutoSize = true;
            this.cbOwnerID.Location = new System.Drawing.Point(159, 55);
            this.cbOwnerID.Name = "cbOwnerID";
            this.cbOwnerID.Size = new System.Drawing.Size(98, 22);
            this.cbOwnerID.TabIndex = 47;
            this.cbOwnerID.Text = "OwnerID";
            this.cbOwnerID.UseVisualStyleBackColor = true;
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(350, 139);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(42, 22);
            this.cbAll.TabIndex = 46;
            this.cbAll.Text = "*";
            this.cbAll.UseVisualStyleBackColor = true;
            // 
            // cbFuelTax
            // 
            this.cbFuelTax.AutoSize = true;
            this.cbFuelTax.Location = new System.Drawing.Point(193, 140);
            this.cbFuelTax.Name = "cbFuelTax";
            this.cbFuelTax.Size = new System.Drawing.Size(88, 22);
            this.cbFuelTax.TabIndex = 44;
            this.cbFuelTax.Text = "燃料稅";
            this.cbFuelTax.UseVisualStyleBackColor = true;
            // 
            // cbLicTax
            // 
            this.cbLicTax.AutoSize = true;
            this.cbLicTax.Location = new System.Drawing.Point(96, 140);
            this.cbLicTax.Name = "cbLicTax";
            this.cbLicTax.Size = new System.Drawing.Size(88, 22);
            this.cbLicTax.TabIndex = 45;
            this.cbLicTax.Text = "牌照稅";
            this.cbLicTax.UseVisualStyleBackColor = true;
            // 
            // cbPaymentID
            // 
            this.cbPaymentID.AutoSize = true;
            this.cbPaymentID.Location = new System.Drawing.Point(137, 112);
            this.cbPaymentID.Name = "cbPaymentID";
            this.cbPaymentID.Size = new System.Drawing.Size(111, 22);
            this.cbPaymentID.TabIndex = 39;
            this.cbPaymentID.Text = "PaymentID";
            this.cbPaymentID.UseVisualStyleBackColor = true;
            // 
            // cbPrice
            // 
            this.cbPrice.AutoSize = true;
            this.cbPrice.Location = new System.Drawing.Point(124, 84);
            this.cbPrice.Name = "cbPrice";
            this.cbPrice.Size = new System.Drawing.Size(70, 22);
            this.cbPrice.TabIndex = 41;
            this.cbPrice.Text = "保額";
            this.cbPrice.UseVisualStyleBackColor = true;
            // 
            // cbPType
            // 
            this.cbPType.AutoSize = true;
            this.cbPType.Location = new System.Drawing.Point(203, 84);
            this.cbPType.Name = "cbPType";
            this.cbPType.Size = new System.Drawing.Size(106, 22);
            this.cbPType.TabIndex = 40;
            this.cbPType.Text = "付款方式";
            this.cbPType.UseVisualStyleBackColor = true;
            // 
            // cbBrand
            // 
            this.cbBrand.AutoSize = true;
            this.cbBrand.Location = new System.Drawing.Point(85, 55);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(70, 22);
            this.cbBrand.TabIndex = 41;
            this.cbBrand.Text = "廠牌";
            this.cbBrand.UseVisualStyleBackColor = true;
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Location = new System.Drawing.Point(325, 55);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(70, 22);
            this.cbDate.TabIndex = 42;
            this.cbDate.Text = "保期";
            this.cbDate.UseVisualStyleBackColor = true;
            // 
            // cbTaxID
            // 
            this.cbTaxID.AutoSize = true;
            this.cbTaxID.Location = new System.Drawing.Point(12, 140);
            this.cbTaxID.Name = "cbTaxID";
            this.cbTaxID.Size = new System.Drawing.Size(78, 22);
            this.cbTaxID.TabIndex = 43;
            this.cbTaxID.Text = "TaxID";
            this.cbTaxID.UseVisualStyleBackColor = true;
            // 
            // cbVType
            // 
            this.cbVType.AutoSize = true;
            this.cbVType.Location = new System.Drawing.Point(12, 55);
            this.cbVType.Name = "cbVType";
            this.cbVType.Size = new System.Drawing.Size(70, 22);
            this.cbVType.TabIndex = 40;
            this.cbVType.Text = "車種";
            this.cbVType.UseVisualStyleBackColor = true;
            // 
            // cbLicense
            // 
            this.cbLicense.AutoSize = true;
            this.cbLicense.Location = new System.Drawing.Point(287, 28);
            this.cbLicense.Name = "cbLicense";
            this.cbLicense.Size = new System.Drawing.Size(106, 22);
            this.cbLicense.TabIndex = 39;
            this.cbLicense.Text = "車牌號碼";
            this.cbLicense.UseVisualStyleBackColor = true;
            // 
            // cbCost
            // 
            this.cbCost.AutoSize = true;
            this.cbCost.Location = new System.Drawing.Point(315, 84);
            this.cbCost.Name = "cbCost";
            this.cbCost.Size = new System.Drawing.Size(70, 22);
            this.cbCost.TabIndex = 41;
            this.cbCost.Text = "保費";
            this.cbCost.UseVisualStyleBackColor = true;
            // 
            // cbIID
            // 
            this.cbIID.AutoSize = true;
            this.cbIID.Location = new System.Drawing.Point(261, 55);
            this.cbIID.Name = "cbIID";
            this.cbIID.Size = new System.Drawing.Size(58, 22);
            this.cbIID.TabIndex = 39;
            this.cbIID.Text = "IID";
            this.cbIID.UseVisualStyleBackColor = true;
            // 
            // cbAddress
            // 
            this.cbAddress.AutoSize = true;
            this.cbAddress.Location = new System.Drawing.Point(217, 28);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(70, 22);
            this.cbAddress.TabIndex = 38;
            this.cbAddress.Text = "地址";
            this.cbAddress.UseVisualStyleBackColor = true;
            // 
            // cbGender
            // 
            this.cbGender.AutoSize = true;
            this.cbGender.Location = new System.Drawing.Point(146, 28);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(70, 22);
            this.cbGender.TabIndex = 37;
            this.cbGender.Text = "性別";
            this.cbGender.UseVisualStyleBackColor = true;
            // 
            // cbName
            // 
            this.cbName.AutoSize = true;
            this.cbName.Location = new System.Drawing.Point(76, 28);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(70, 22);
            this.cbName.TabIndex = 36;
            this.cbName.Text = "姓名";
            this.cbName.UseVisualStyleBackColor = true;
            // 
            // cbOID
            // 
            this.cbOID.AutoSize = true;
            this.cbOID.Location = new System.Drawing.Point(12, 28);
            this.cbOID.Name = "cbOID";
            this.cbOID.Size = new System.Drawing.Size(64, 22);
            this.cbOID.TabIndex = 35;
            this.cbOID.Text = "OID";
            this.cbOID.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTax);
            this.groupBox5.Controls.Add(this.cbInsurance);
            this.groupBox5.Controls.Add(this.cbVehicle);
            this.groupBox5.Controls.Add(this.cbPayment);
            this.groupBox5.Controls.Add(this.cbOwner);
            this.groupBox5.Location = new System.Drawing.Point(7, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(630, 53);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            // 
            // cbTax
            // 
            this.cbTax.AutoSize = true;
            this.cbTax.Checked = true;
            this.cbTax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTax.Location = new System.Drawing.Point(539, 24);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(78, 22);
            this.cbTax.TabIndex = 34;
            this.cbTax.Text = "稅Tax";
            this.cbTax.UseVisualStyleBackColor = true;
            this.cbTax.CheckedChanged += new System.EventHandler(this.cbTax_CheckedChanged);
            // 
            // cbInsurance
            // 
            this.cbInsurance.AutoSize = true;
            this.cbInsurance.Checked = true;
            this.cbInsurance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInsurance.Location = new System.Drawing.Point(254, 24);
            this.cbInsurance.Name = "cbInsurance";
            this.cbInsurance.Size = new System.Drawing.Size(137, 22);
            this.cbInsurance.TabIndex = 33;
            this.cbInsurance.Text = "保險Insurance";
            this.cbInsurance.UseVisualStyleBackColor = true;
            this.cbInsurance.CheckedChanged += new System.EventHandler(this.cbInsurance_CheckedChanged);
            // 
            // cbVehicle
            // 
            this.cbVehicle.AutoSize = true;
            this.cbVehicle.Checked = true;
            this.cbVehicle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVehicle.Location = new System.Drawing.Point(120, 24);
            this.cbVehicle.Name = "cbVehicle";
            this.cbVehicle.Size = new System.Drawing.Size(124, 22);
            this.cbVehicle.TabIndex = 32;
            this.cbVehicle.Text = "車輛Vehicle";
            this.cbVehicle.UseVisualStyleBackColor = true;
            this.cbVehicle.CheckedChanged += new System.EventHandler(this.cbVehicle_CheckedChanged);
            // 
            // cbPayment
            // 
            this.cbPayment.AutoSize = true;
            this.cbPayment.Checked = true;
            this.cbPayment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPayment.Location = new System.Drawing.Point(401, 24);
            this.cbPayment.Name = "cbPayment";
            this.cbPayment.Size = new System.Drawing.Size(129, 22);
            this.cbPayment.TabIndex = 31;
            this.cbPayment.Text = "付款Payment";
            this.cbPayment.UseVisualStyleBackColor = true;
            this.cbPayment.CheckedChanged += new System.EventHandler(this.cbPayment_CheckedChanged);
            // 
            // cbOwner
            // 
            this.cbOwner.AutoSize = true;
            this.cbOwner.Checked = true;
            this.cbOwner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOwner.Location = new System.Drawing.Point(12, 24);
            this.cbOwner.Name = "cbOwner";
            this.cbOwner.Size = new System.Drawing.Size(98, 22);
            this.cbOwner.TabIndex = 30;
            this.cbOwner.Text = "人Owner";
            this.cbOwner.UseVisualStyleBackColor = true;
            this.cbOwner.CheckedChanged += new System.EventHandler(this.cbOwner_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgvConstraint);
            this.groupBox7.Location = new System.Drawing.Point(36, 334);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(356, 174);
            this.groupBox7.TabIndex = 60;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "限制";
            // 
            // dgvConstraint
            // 
            this.dgvConstraint.AllowUserToResizeColumns = false;
            this.dgvConstraint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstraint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attribute,
            this.operand,
            this.value});
            this.dgvConstraint.Location = new System.Drawing.Point(4, 24);
            this.dgvConstraint.Name = "dgvConstraint";
            this.dgvConstraint.RowTemplate.Height = 31;
            this.dgvConstraint.Size = new System.Drawing.Size(347, 145);
            this.dgvConstraint.TabIndex = 33;
            // 
            // attribute
            // 
            this.attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.attribute.HeaderText = "屬性";
            this.attribute.Name = "attribute";
            this.attribute.ToolTipText = "輸入上一層表格包含的屬性";
            this.attribute.Width = 80;
            // 
            // operand
            // 
            this.operand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.operand.HeaderText = "運算子";
            this.operand.Name = "operand";
            this.operand.ToolTipText = "輸入=,>,<,>=,<=";
            this.operand.Width = 98;
            // 
            // value
            // 
            this.value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.value.HeaderText = "條件值";
            this.value.Name = "value";
            this.value.ToolTipText = "根據屬性型態輸入字串或數字";
            this.value.Width = 98;
            // 
            // cbAggre
            // 
            this.cbAggre.AutoSize = true;
            this.cbAggre.Location = new System.Drawing.Point(16, 29);
            this.cbAggre.Name = "cbAggre";
            this.cbAggre.Size = new System.Drawing.Size(124, 22);
            this.cbAggre.TabIndex = 61;
            this.cbAggre.Text = "複雜計算：";
            this.cbAggre.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "分組    (GROUP BY)";
            // 
            // tbAggre
            // 
            this.tbAggre.Enabled = false;
            this.tbAggre.Location = new System.Drawing.Point(158, 104);
            this.tbAggre.MaxLength = 100000;
            this.tbAggre.Name = "tbAggre";
            this.tbAggre.Size = new System.Drawing.Size(172, 29);
            this.tbAggre.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 64;
            this.label3.Text = "(HAVING)";
            // 
            // cbAggreAttri
            // 
            this.cbAggreAttri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAggreAttri.FormattingEnabled = true;
            this.cbAggreAttri.Location = new System.Drawing.Point(284, 26);
            this.cbAggreAttri.Name = "cbAggreAttri";
            this.cbAggreAttri.Size = new System.Drawing.Size(147, 26);
            this.cbAggreAttri.TabIndex = 65;
            this.cbAggreAttri.SelectedIndexChanged += new System.EventHandler(this.cbAggreAttri_SelectedIndexChanged);
            // 
            // lbAttri
            // 
            this.lbAttri.AutoSize = true;
            this.lbAttri.Location = new System.Drawing.Point(207, 20);
            this.lbAttri.Name = "lbAttri";
            this.lbAttri.Size = new System.Drawing.Size(26, 18);
            this.lbAttri.TabIndex = 66;
            this.lbAttri.Text = "無";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAggreAttri);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbGroupBy);
            this.groupBox1.Controls.Add(this.tbAggre);
            this.groupBox1.Controls.Add(this.cbAggreOp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbOperand);
            this.groupBox1.Controls.Add(this.cbAggre);
            this.groupBox1.Controls.Add(this.tbConVal);
            this.groupBox1.Location = new System.Drawing.Point(627, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 147);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbNested);
            this.groupBox2.Controls.Add(this.cbNestedOp);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Location = new System.Drawing.Point(22, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 549);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "項目中的";
            // 
            // cbNested
            // 
            this.cbNested.AutoSize = true;
            this.cbNested.Location = new System.Drawing.Point(16, 28);
            this.cbNested.Name = "cbNested";
            this.cbNested.Size = new System.Drawing.Size(124, 22);
            this.cbNested.TabIndex = 66;
            this.cbNested.Text = "巢狀查詢：";
            this.cbNested.UseVisualStyleBackColor = true;
            // 
            // ComplexQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1294, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbAttri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.cbOperation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComplexQuery";
            this.Text = "ComplexQuery";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ComplexQuery_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraint)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbOperand;
        private System.Windows.Forms.ComboBox cbAggreOp;
        private System.Windows.Forms.ComboBox cbGroupBy;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbOperation;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ComboBox cbNestedOp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbInsuranceID;
        private System.Windows.Forms.CheckBox cbIType;
        private System.Windows.Forms.CheckBox cbOwnerID;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.CheckBox cbFuelTax;
        private System.Windows.Forms.CheckBox cbLicTax;
        private System.Windows.Forms.CheckBox cbPaymentID;
        private System.Windows.Forms.CheckBox cbPrice;
        private System.Windows.Forms.CheckBox cbPType;
        private System.Windows.Forms.CheckBox cbBrand;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.CheckBox cbTaxID;
        private System.Windows.Forms.CheckBox cbVType;
        private System.Windows.Forms.CheckBox cbLicense;
        private System.Windows.Forms.CheckBox cbCost;
        private System.Windows.Forms.CheckBox cbIID;
        private System.Windows.Forms.CheckBox cbAddress;
        private System.Windows.Forms.CheckBox cbGender;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.CheckBox cbOID;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbTax;
        private System.Windows.Forms.CheckBox cbInsurance;
        private System.Windows.Forms.CheckBox cbVehicle;
        private System.Windows.Forms.CheckBox cbPayment;
        private System.Windows.Forms.CheckBox cbOwner;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvConstraint;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn operand;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.CheckBox cbAggre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAggre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAggreAttri;
        private System.Windows.Forms.Label lbAttri;
        private System.Windows.Forms.TextBox tbConVal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbNested;
    }
}