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
        private Enum curAggre;

        public enum Aggregate {
            MIN = 0, MAX, COUNT, SUM, AVG
        }

        public ComplexQuery(DataTransfer df)
        {
            InitializeComponent();
            this.dataTransfer = df;
        }
        
        private void ComplexQuery_Load(object sender, EventArgs e)
        {
            cbOp.SelectedIndex = 0;
        }
        
        private String getAggreEntity(String input)
        {
            if(input == "保費" || input == "保險到期日")
            {
                return "WARRANTY.";
            }
            if(input == "燃料費" || input == "牌照稅")
            {
                return "FEE.";
            }
            return "";
        }
        private bool completeQuery()
        {
            String msg = "";
            if(!rbAvg.Checked && !rbMin.Checked && !rbMax.Checked &&
             !rbSum.Checked && !rbCnt.Checked)
            {
                msg += "請在第一步中選擇一項\n";
            }
            if(cbAttri.SelectedItem.ToString() == "")
            {
                msg += "請在第二步中選擇要計算的屬性\n";
            }
            
            if(msg != "")
            {
                MessageBox.Show(msg, "WARNING");
                return false;
            }

            return true;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(!completeQuery())
            {
                return;
            }

            if(cbHaving.Checked && tbVal.Text == "")
            {
                MessageBox.Show("請在第四步輸入數值！","WARNING");
                return;
            }

            // compute query string
            String entity = getAggreEntity(cbAttri.SelectedItem.ToString());
            String aggreFunc = (cbAttri.SelectedItem.ToString() != "全部") ? 
                curAggre.ToString() + "(" + cbAttri.SelectedItem.ToString() + ")" 
                : "COUNT(*)";

            query += " SELECT OWNER.OID, OWNER.性別, OWNER.地址,";
            query += " VEHICLE.車牌號碼, VEHICLE.車種, VEHICLE.廠牌,";
            query += " WARRANTY.WID, WARRANTY.保險種類, WARRANTY.保額,";
            query += " WARRANTY.保險到期日, WARRANTY.保費, WARRANTY.付款方式,";
            query += " FEE.燃料費, FEE.牌照稅, DEALER.車行";
            
            if(cbAttri.SelectedItem.ToString() == "全部")
            {
                query += ", COUNT(*) ";
            }
            else {
                query = query.Replace(entity + cbAttri.SelectedItem.ToString(), aggreFunc);
            }
            
            query += " FROM OWNER, VEHICLE, WARRANTY, FEE, DEALER, INSURE ";
            
            query += " WHERE OWNER.OID = INSURE.OwnerID AND ";
            query += " VEHICLE.車牌號碼 = INSURE.License AND ";
            query += " VEHICLE.FeeID = FEE.FID AND ";
            query += " DEALER.車行 = VEHICLE.經銷商 AND ";
            query += " WARRANTY.WID = INSURE.WarrantyID ";

            if(cbGroupBy.Checked)
            {
                query += " GROUP BY " + cbGroup.SelectedItem.ToString();
            }
            
            if(cbHaving.Checked)
            {
                query += " HAVING COUNT(*) " 
                    + cbOp.SelectedItem.ToString() + "'" + tbVal.Text + "'";
            }

            Console.WriteLine(query);         

            // transfer data back to MainWindow
            dataTransfer.Invoke(query);
            Close();
        }

        private void rbMax_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMax.Checked == false)
            {
                return;
            }

            curAggre = Aggregate.MAX;
            lbText.Text = "的最大值";
            cbAttri.Items.Clear();
            cbAttri.Items.Add("保費");
            cbAttri.Items.Add("保險到期日");

            cbAttri.SelectedIndex = 0;
        }

        private void rbMin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMin.Checked == false)
            {
                return;
            }
            
            curAggre = Aggregate.MIN;
            lbText.Text = "的最小值";
            cbAttri.Items.Clear();
            cbAttri.Items.Add("保費");
            cbAttri.Items.Add("保險到期日");
            cbAttri.SelectedIndex = 0;
        }

        private void rbAvg_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAvg.Checked == false)
            {
                return;
            }

            curAggre = Aggregate.AVG;
            lbText.Text = "的平均值";
            cbAttri.Items.Clear();
            cbAttri.Items.Add("保費");
            cbAttri.Items.Add("燃料費");
            cbAttri.Items.Add("牌照稅");
            cbAttri.SelectedIndex = 0;
        }

        private void rbSum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSum.Checked == false)
            {
                return;
            }
            
            curAggre = Aggregate.SUM;
            lbText.Text = "的總和";
            cbAttri.Items.Clear();
            cbAttri.Items.Add("保費");
            cbAttri.Items.Add("燃料費");
            cbAttri.Items.Add("牌照稅");
            cbAttri.SelectedIndex = 0;
        }

        private void rbCnt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCnt.Checked == false)
            {
                return;
            }

            curAggre = Aggregate.COUNT;
            lbText.Text = "的數量";
            cbAttri.Items.Clear();
            cbAttri.Items.Add("全部");            // COUNT(*)
            cbAttri.SelectedIndex = 0;
        }

        private void cbGroupBy_CheckedChanged(object sender, EventArgs e)
        {
            cbGroup.Items.Clear();
            if(((CheckBox)sender).Checked == true)
            {
                cbGroup.Items.Add("性別");
                cbGroup.Items.Add("保險種類");
                cbGroup.Items.Add("付款方式");
                cbGroup.Items.Add("車種");
                cbGroup.Items.Add("廠牌");
                cbGroup.SelectedIndex = 0;
            }

        }

        private void cbHaving_CheckedChanged(object sender, EventArgs e)
        {
            if(!curAggre.Equals(Aggregate.COUNT))
            {
                cbHaving.Checked = false;
                MessageBox.Show("只有選擇計算個數才能勾選此選項！", "WARNING");
            }
        }
    }
}
