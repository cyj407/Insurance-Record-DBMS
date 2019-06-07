using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsuranceDB
{
    public partial class ComplexQuery : Form
    {
        DataTransfer dataTransfer;
        private String query = "";
        private String strAttri, strEnti, strCond; 

        public ComplexQuery(DataTransfer del, String strAttri, String strEnti, String strCond)
        {
            InitializeComponent();
            dataTransfer = del;
            
            List<String> attriList = getStrList(strAttri);
            
            cbGroupBy.Items.Add("-");
            foreach(String s in attriList)
            {
                cbAggreAttri.Items.Add(s);
                cbGroupBy.Items.Add(s);
            }

            lbAttri.Text = strAttri;
            this.strAttri = strAttri;
            this.strEnti = strEnti;
            this.strCond = strCond;

            // Console.WriteLine(strAttri);
            // Console.WriteLine(strEnti);
            // Console.WriteLine(strCond);
        }

        public List<String> getStrList(String str)
        {
            String[] split = str.Split(new Char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            return split.ToList();
        }

        private void ComplexQuery_Load(object sender, EventArgs e)
        {
            cbOperation.SelectedIndex = 0;
            cbAggreOp.SelectedIndex = 0;
            cbAggreAttri.SelectedIndex = 0;
            cbGroupBy.SelectedIndex = 0;
            cbOperand.SelectedIndex = 2; 
            cbNestedOp.SelectedIndex = 0;
        }

        private void cbAggreOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = cbAggreOp.SelectedItem.ToString();
            if(cbAggreAttri.SelectedItem != null)
            {
                str += "(" + cbAggreAttri.SelectedItem.ToString() + ")";
            }
            Console.WriteLine(str);
        }

        private void cbAggreAttri_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbAggre.Text = cbAggreOp.SelectedItem.ToString() + "(" + cbAggreAttri.SelectedItem.ToString() + ")";
        }

        private String getNestedOP()
        {
            if(cbNestedOp.SelectedItem.ToString() == "存在")
            {
                return "EXISTS";
            }
            if(cbNestedOp.SelectedItem.ToString() == "不存在")
            {
                return "NOT EXISTS";
            }
            if(cbNestedOp.SelectedItem.ToString() == "滿足")
            {
                return "IN";
            }
            else
            {
                return "NOT IN";
            }
            
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            String strAggreFun = "";
            String modifyAttri;
            query = "";
            
            if(!cbNested.Checked && !cbAggre.Checked)
            {
                MessageBox.Show("請至少選擇巢狀查詢或是複雜計算其中一項！","WARNING");
                return;
            }
            else if(cbNested.Checked && !cbAggre.Checked)
            {

                String op = getNestedOP();
                if(op == "IN" || op == "NOT IN") 
                {

                    // inner operation attribute
                    String innerAttri = "";
                    IEnumerable<CheckBox> attriSet = groupBox6.Controls.OfType<CheckBox>();
                    bool firstAttri = true;
                    foreach (CheckBox cb in attriSet)
                    {
                        if (cb.Enabled && cb.Checked)
                        {
                            if (cb.Text == "*")
                            {
                                innerAttri = "*";
                                break;
                            }
                            if (firstAttri)
                            {
                                innerAttri = cb.Text;
                                firstAttri = false;
                            }
                            else
                            {
                                innerAttri += ", " + cb.Text;
                            }
                        }
                    }
                    

                    // find the foreign key of the innerAttri
                    String innerAttriFk = "";
                    List<String> list  = getStrList(innerAttri);
                    bool first = true;
                    foreach(String s in list)
                    {
                        if(first) {
                            if(s == "OwnerID") {
                                innerAttriFk += "OID";
                            }
                            else if(s == "OID") {
                                innerAttriFk += "OwnerID";
                            }
                            else if(s == "InsuranceID") {
                                innerAttriFk += "IID";
                            }
                            else if(s == "IID") {
                                innerAttriFk += "InsuranceID";
                            }
                            first = false;
                        }
                        else {
                            if(s == "OwnerID") {
                                innerAttriFk += ", OID";
                            }
                            else if(s == "OID") {
                                innerAttriFk += ", OwnerID";
                            }
                            else if(s == "InsuranceID") {
                                innerAttriFk += ", IID";
                            }
                            else if(s == "IID") {
                                innerAttriFk += ", InsuranceID";
                            }
                        }
                    }

                    query += getOperation() + strAttri + " FROM " + strEnti + " WHERE " + innerAttriFk;
                    
                    // get innerEnti
                    

                   // query += op + " ( SELECT " + innerAttri + " FROM " + innerEnti;

                    // get innerCond

                    //query += " WHERE " + innerCond + " )";
                
                }
                else        // EXISTS, NOT EXISTS 
                {

                }

            }
            else if(cbAggre.Checked && !cbNested.Checked)
            {
                String strAggreAttri = cbAggreAttri.SelectedItem.ToString();
                // ex: strAggreFun = COUNT(xxx)
                strAggreFun = cbAggreOp.SelectedItem.ToString() + "(" + strAggreAttri + ")";

                // replace the aggregation function attribute
                modifyAttri = strAttri.Replace(strAggreAttri, strAggreFun);

                query +=  getOperation() + modifyAttri + " FROM " + strEnti + " WHERE " + strCond;
                
                if(cbGroupBy.SelectedItem.ToString() != "-")
                {
                    query += " GROUP BY " + cbGroupBy.SelectedItem.ToString();
                }
                if(tbConVal.Text != "")
                {
                    String op = cbOperand.SelectedItem.ToString();
                    query += " HAVING " + strAggreFun + op + "'" + tbConVal.Text + "'";
                }

            }
            else if(cbAggre.Checked && cbNested.Checked)
            {
                // get both op
                // combine the query string
            }


            // Console.WriteLine(query);


            // transfer data back to MainWindow
            dataTransfer.Invoke(query);
            Close();

        }

        private String getOperation()
        {
            if(cbOperation.SelectedItem.ToString() == "查詢")
            {
                return "SELECT ";
            }
            else if (cbOperation.SelectedItem.ToString() == "新增")
            {
                return "INSERT INTO ";
            }
            else if (cbOperation.SelectedItem.ToString() == "修改")
            {
                return "UPDATE ";
            }
            else
            {
                return "DELETE ";
            }
        }

        private void cbOwner_CheckedChanged(object sender, EventArgs e)
        {
            cbOID.Enabled = !cbOID.Enabled;
            cbName.Enabled = !cbName.Enabled;
            cbGender.Enabled = !cbGender.Enabled;
            cbAddress.Enabled = !cbAddress.Enabled;
        }

        private void cbVehicle_CheckedChanged(object sender, EventArgs e)
        {
            cbOwnerID.Enabled = !cbOwnerID.Enabled;
            cbLicense.Enabled = !cbLicense.Enabled;
            cbBrand.Enabled = !cbBrand.Enabled;
            cbVType.Enabled = !cbVType.Enabled;
        }

        private void cbInsurance_CheckedChanged(object sender, EventArgs e)
        {
            cbIID.Enabled = !cbIID.Enabled;
            cbIType.Enabled = !cbIType.Enabled;
            cbDate.Enabled = !cbDate.Enabled;
            cbPrice.Enabled = !cbPrice.Enabled;
        }

        private void cbPayment_CheckedChanged(object sender, EventArgs e)
        {
            cbInsuranceID.Enabled = !cbInsuranceID.Enabled;
            cbPaymentID.Enabled = !cbPaymentID.Enabled;
            cbPType.Enabled = !cbPType.Enabled;
            cbCost.Enabled = !cbCost.Enabled;
        }

        private void cbTax_CheckedChanged(object sender, EventArgs e)
        {
            cbTaxID.Enabled = !cbTaxID.Enabled;
            cbFuelTax.Enabled = !cbFuelTax.Enabled;
            cbLicTax.Enabled = !cbLicTax.Enabled;
        }


    }
}
