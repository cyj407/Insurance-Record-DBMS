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
            this.btnEnter = new System.Windows.Forms.Button();
            this.rbMin = new System.Windows.Forms.RadioButton();
            this.rbSum = new System.Windows.Forms.RadioButton();
            this.rbMax = new System.Windows.Forms.RadioButton();
            this.rbAvg = new System.Windows.Forms.RadioButton();
            this.rbCnt = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAttri = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.cbGroupBy = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbOp = new System.Windows.Forms.ComboBox();
            this.tbVal = new System.Windows.Forms.TextBox();
            this.cbHaving = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(423, 280);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(112, 34);
            this.btnEnter.TabIndex = 55;
            this.btnEnter.Text = "確定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // rbMin
            // 
            this.rbMin.AutoSize = true;
            this.rbMin.Location = new System.Drawing.Point(25, 56);
            this.rbMin.Name = "rbMin";
            this.rbMin.Size = new System.Drawing.Size(105, 22);
            this.rbMin.TabIndex = 57;
            this.rbMin.TabStop = true;
            this.rbMin.Text = "找最小值";
            this.rbMin.UseVisualStyleBackColor = true;
            this.rbMin.CheckedChanged += new System.EventHandler(this.rbMin_CheckedChanged);
            // 
            // rbSum
            // 
            this.rbSum.AutoSize = true;
            this.rbSum.Location = new System.Drawing.Point(25, 112);
            this.rbSum.Name = "rbSum";
            this.rbSum.Size = new System.Drawing.Size(105, 22);
            this.rbSum.TabIndex = 58;
            this.rbSum.TabStop = true;
            this.rbSum.Text = "計算總和";
            this.rbSum.UseVisualStyleBackColor = true;
            this.rbSum.CheckedChanged += new System.EventHandler(this.rbSum_CheckedChanged);
            // 
            // rbMax
            // 
            this.rbMax.AutoSize = true;
            this.rbMax.Location = new System.Drawing.Point(25, 28);
            this.rbMax.Name = "rbMax";
            this.rbMax.Size = new System.Drawing.Size(105, 22);
            this.rbMax.TabIndex = 59;
            this.rbMax.TabStop = true;
            this.rbMax.Text = "找最大值";
            this.rbMax.UseVisualStyleBackColor = true;
            this.rbMax.CheckedChanged += new System.EventHandler(this.rbMax_CheckedChanged);
            // 
            // rbAvg
            // 
            this.rbAvg.AutoSize = true;
            this.rbAvg.Location = new System.Drawing.Point(25, 84);
            this.rbAvg.Name = "rbAvg";
            this.rbAvg.Size = new System.Drawing.Size(105, 22);
            this.rbAvg.TabIndex = 60;
            this.rbAvg.TabStop = true;
            this.rbAvg.Text = "計算平均";
            this.rbAvg.UseVisualStyleBackColor = true;
            this.rbAvg.CheckedChanged += new System.EventHandler(this.rbAvg_CheckedChanged);
            // 
            // rbCnt
            // 
            this.rbCnt.AutoSize = true;
            this.rbCnt.Location = new System.Drawing.Point(25, 140);
            this.rbCnt.Name = "rbCnt";
            this.rbCnt.Size = new System.Drawing.Size(105, 22);
            this.rbCnt.TabIndex = 62;
            this.rbCnt.TabStop = true;
            this.rbCnt.Text = "計算個數";
            this.rbCnt.UseVisualStyleBackColor = true;
            this.rbCnt.CheckedChanged += new System.EventHandler(this.rbCnt_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAvg);
            this.groupBox2.Controls.Add(this.rbCnt);
            this.groupBox2.Controls.Add(this.rbMin);
            this.groupBox2.Controls.Add(this.rbSum);
            this.groupBox2.Controls.Add(this.rbMax);
            this.groupBox2.Location = new System.Drawing.Point(33, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 175);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "第一步";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbText);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbAttri);
            this.groupBox3.Location = new System.Drawing.Point(203, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 78);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "第二步";
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(246, 38);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(0, 18);
            this.lbText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "計算";
            // 
            // cbAttri
            // 
            this.cbAttri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttri.FormattingEnabled = true;
            this.cbAttri.Location = new System.Drawing.Point(82, 33);
            this.cbAttri.Name = "cbAttri";
            this.cbAttri.Size = new System.Drawing.Size(147, 26);
            this.cbAttri.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbGroup);
            this.groupBox4.Controls.Add(this.cbGroupBy);
            this.groupBox4.Location = new System.Drawing.Point(203, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 83);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "第三步";
            // 
            // cbGroup
            // 
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(142, 36);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(157, 26);
            this.cbGroup.TabIndex = 1;
            // 
            // cbGroupBy
            // 
            this.cbGroupBy.AutoSize = true;
            this.cbGroupBy.Location = new System.Drawing.Point(16, 40);
            this.cbGroupBy.Name = "cbGroupBy";
            this.cbGroupBy.Size = new System.Drawing.Size(124, 22);
            this.cbGroupBy.TabIndex = 0;
            this.cbGroupBy.Text = "分堆根據：";
            this.cbGroupBy.UseVisualStyleBackColor = true;
            this.cbGroupBy.CheckedChanged += new System.EventHandler(this.cbGroupBy_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbHaving);
            this.groupBox5.Controls.Add(this.tbVal);
            this.groupBox5.Controls.Add(this.cbOp);
            this.groupBox5.Location = new System.Drawing.Point(33, 193);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(508, 76);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "第四步";
            // 
            // cbOp
            // 
            this.cbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOp.FormattingEnabled = true;
            this.cbOp.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "!=",
            ">=",
            "<="});
            this.cbOp.Location = new System.Drawing.Point(298, 31);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(82, 26);
            this.cbOp.TabIndex = 2;
            // 
            // tbVal
            // 
            this.tbVal.Location = new System.Drawing.Point(390, 31);
            this.tbVal.Name = "tbVal";
            this.tbVal.Size = new System.Drawing.Size(78, 29);
            this.tbVal.TabIndex = 1;
            // 
            // cbHaving
            // 
            this.cbHaving.AutoSize = true;
            this.cbHaving.Location = new System.Drawing.Point(42, 35);
            this.cbHaving.Name = "cbHaving";
            this.cbHaving.Size = new System.Drawing.Size(250, 22);
            this.cbHaving.TabIndex = 2;
            this.cbHaving.Text = "計算個數的限制條件：結果";
            this.cbHaving.UseVisualStyleBackColor = true;
            this.cbHaving.CheckedChanged += new System.EventHandler(this.cbHaving_CheckedChanged);
            // 
            // ComplexQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(562, 331);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnEnter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComplexQuery";
            this.Text = "ComplexQuery";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ComplexQuery_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.RadioButton rbMin;
        private System.Windows.Forms.RadioButton rbSum;
        private System.Windows.Forms.RadioButton rbMax;
        private System.Windows.Forms.RadioButton rbAvg;
        private System.Windows.Forms.RadioButton rbCnt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAttri;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.CheckBox cbGroupBy;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbHaving;
        private System.Windows.Forms.TextBox tbVal;
        private System.Windows.Forms.ComboBox cbOp;
    }
}