using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InsuranceDB
{

    // get the transfer data from the complex query
    public delegate void DataTransfer(String data);

    public partial class MainWindow : Form
    {
        public static string connectInfo = @"Server=localhost;Database=insdb;Uid=root;Pwd=";
        public static MySqlConnection connection;        

        public DataTransfer transfer;

        private Owner _owner = new Owner();
        private Vehicle _vehicle = new Vehicle();
        private Warranty _warranty = new Warranty();
        private Dealer _dealer = new Dealer();
        private Fee _fee = new Fee();
        private Insure _insure = new Insure();        // add 3-ary relationship table

        // save the key from all attribute
        private long curOwner_id = -1, curWarrant_id = -1, curFee_id = -1;
        private String curLicen, curDealer;

        //private String strEnti, strAttri, strCond;

        private String curTable;
        
        private bool canUpdate = false;
        private bool canDelete = false;

        public MainWindow()
        {
            // init GUI element
            InitializeComponent();
            transfer += new DataTransfer(ReceiveQuery);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            
            // init connection
            connection = new MySqlConnection(connectInfo);
        }

        public void ReceiveQuery(String data)
        {
            loadAllData(data);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set up combobox default value
            cbVehicleType.SelectedIndex = 1;
            cbEntity.SelectedIndex = 6;
            dtDate.MinDate = DateTime.Today;
            dtDate.Value = DateTime.Today;
            cbQuery.SelectedIndex = 0;
        }
        
        private void loadAllData(String query)
        {
            // show the updated data
            if(query == "")
            {
                query = "SELECT * FROM OWNER, VEHICLE, WARRANTY, FEE, DEALER, INSURE ";
                query += " WHERE OWNER.OID = INSURE.OwnerID AND ";
                query += " VEHICLE.車牌號碼 = INSURE.License AND ";
                query += "VEHICLE.FeeID = FEE.FID AND ";
                query += " DEALER.車行 = VEHICLE.經銷商 AND ";
                query += " WARRANTY.WID = INSURE.WarrantyID";
            }

            Console.WriteLine(query);
            
            MySqlCommand cmd = new MySqlCommand(query, connection);

            connection.Open();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            
            if(dataGridView1.Columns["經銷商"] != null)
            {
                dataGridView1.Columns["經銷商"].Visible = false;
            }
            if (dataGridView1.Columns["FeeID"] != null)
            {
                dataGridView1.Columns["FeeID"].Visible = false;
            }
            if (dataGridView1.Columns["OwnerID"] != null)
            {
                dataGridView1.Columns["OwnerID"].Visible = false;
            }
            if (dataGridView1.Columns["License"] != null)
            {
                dataGridView1.Columns["License"].Visible = false;
            }
            if (dataGridView1.Columns["WarrantyID"] != null)
            {
                dataGridView1.Columns["WarrantyID"].Visible = false;
            }

            da.Update(dt);

            connection.Close();
        }

        private bool completeData() 
        {
            String msg = "";
            if(tbName.Text == "")
            {
                msg += "請輸入姓名\n";
            }
            if(!rbMale.Checked && !rbFemale.Checked)
            {
                msg += "請選擇性別\n";
            }
            if(tbAddress.Text == "")
            {
                msg += "請輸入地址\n";
            }
            if(cbVehicleType.SelectedItem == null)
            {
                msg += "請選擇車種\n";
            }
            if(tbLicense.Text == "")
            {
                msg += "請輸入牌照\n";
            }
            if(tbBrand.Text == "")
            {
                msg += "請輸入廠牌\n";
            }
            if(!rbFree.Checked && !rbForce.Checked)
            {
                msg += "請選擇任意險或強制險\n";
            }
            if(dtDate.Value.Date == DateTime.Today)
            {
                msg += "請選擇到期日\n";
            }
            if(tbCost.Text == "")
            {
                msg += "請輸入保費\n";
            }
            if(tbPrice.Text == "")
            {
                msg += "請輸入保額\n";
            }
            if (!rbCreditCard.Checked && !rbCash.Checked)
            {
                msg += "請選擇付款方式\n";
            }
            if (tbFeeFuel.Text == "")
            {
                msg += "燃料稅金額請由稅費資料表點選\n";
            }
            if(tbTaxLic.Text == "")
            {
                msg += "牌照稅金額請由稅費資料表點選\n";
            }
            if (tbDealer.Text == "")
            {
                msg += "經銷商請由車行資料表點選\n";
            }
            if (tbPhone.Text == "")
            {
                msg += "電話請由車行資料表點選\n";
            }
            if (tbDealerAddr.Text == "")
            {
                msg += "經銷地址請由車行資料表點選\n";
            }

            // show message warning
            if (msg != "") 
            {
                MessageBox.Show(msg, "WARNING!");
                return false;
            }
            return true;
        }

        private void clearInput()
        {
            tbName.Text = "";
            rbMale.Checked = rbFemale.Checked = false;
            tbAddress.Text = "";
            cbVehicleType.SelectedIndex = 1;
            tbLicense.Text = "";
            tbBrand.Text = "";
            //tbDealer.Text = "";
            //tbPhone.Text = "";
            //tbDealerAddr.Text = "";
            rbFree.Checked = rbForce.Checked = false;
            dtDate.Value = DateTime.Today.Date;
            tbCost.Text = "";
            tbPrice.Text = "";
            rbCreditCard.Checked = rbCash.Checked = false;
            //tbFeeFuel.Text = "";
            //tbTaxLic.Text = "";

        }
       
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // check not null for all
            if(!completeData()) 
            {
                return;
            }

            // get all data from GUI
            String owner_n = tbName.Text;
            String owner_g = (rbMale.Checked) ? "男" : "女";
            String owner_a = tbAddress.Text;
            String vehicle_t = cbVehicleType.SelectedItem.ToString();
            String vehicle_l = tbLicense.Text;
            String vehicle_b = tbBrand.Text;
            String dealer_n = tbDealer.Text;
            String dealer_p = tbPhone.Text;
            String dealer_a = tbDealerAddr.Text;
            String warranty_t = (rbFree.Checked) ? "任意險" : "強制險";
            DateTime warranty_d = dtDate.Value.Date;
            long warranty_c = long.Parse(tbCost.Text);
            long warranty_p = long.Parse(tbPrice.Text);
            String warranty_pay = (rbCreditCard.Checked) ? "刷卡" : "現金";
            long fuel_fee = long.Parse(tbFeeFuel.Text);
            long lic_tax = long.Parse(tbTaxLic.Text);

            Console.WriteLine("before insert");

            // insert to all entity and relationship // fee no needs to add
            _owner.insert(owner_n, owner_g, owner_a);
            _vehicle.insert(vehicle_t, vehicle_l, vehicle_b, dealer_n, curFee_id);
            _warranty.insert(warranty_t, warranty_d, warranty_p, warranty_c, warranty_pay);
            _dealer.insert(dealer_n, dealer_a, dealer_p);
            _insure.insert(_owner.getID(), vehicle_l, _warranty.getID());
 
            loadAllData("");
            clearInput();
        }

        private String getQueryEntity(String input)
        {
            switch (input)
            {
                case ("車主資料表"):
                    return "OWNER";

                case ("車行資料表"):
                    return "DEALER";

                case ("保險資料表"):
                    return "WARRANTY";

                case ("車輛資料表"):
                    return "VEHICLE";

                case ("稅費資料表"):
                    return "FEE";

                case ("投保資料表"):
                    return "INSURE";

                default:
                    return "";
            }
        }

        private void btnSubData_Click(object sender, EventArgs e)
        {
            String entity = getQueryEntity(cbEntity.SelectedItem.ToString());
            String query = (entity == "") ? "" : ("SELECT * FROM " + entity);
            loadAllData(query);

            curTable = entity;
            if(curTable == "")
            {
                canDelete = true;
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            clearInput();
            canUpdate = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            // Check have data to modify now
            if(!canUpdate)
            {
                MessageBox.Show("無法進行更改！", "WARNING"); 
                MessageBox.Show(
                    "請先選擇左方「檢視資料表」的「全部資料」後按「顯示」。\n再從下方的資料中對要更改的資料點兩下在「插入/更新」的白框中進行更改。"
                    ,"WARNING");
                return;
            }

            if(!completeData()) {
                return;
            }

            String owner_n = tbName.Text;
            String owner_g = (rbMale.Checked) ? "男" : "女";
            String owner_a = tbAddress.Text;
            String vehicle_t = cbVehicleType.SelectedItem.ToString();
            String vehicle_l = tbLicense.Text;
            String vehicle_b = tbBrand.Text;
            String dealer_n = tbDealer.Text;
            String dealer_p = tbPhone.Text;
            String dealer_a = tbDealerAddr.Text;
            String warranty_t = (rbFree.Checked) ? "任意險" : "強制險";
            DateTime warranty_d = dtDate.Value.Date;
            long warranty_c = long.Parse(tbCost.Text);
            long warranty_p = long.Parse(tbPrice.Text);
            String warranty_pay = (rbCreditCard.Checked) ? "刷卡" : "現金";
            long fuel_fee = long.Parse(tbFeeFuel.Text);
            long lic_tax = long.Parse(tbTaxLic.Text);

            _owner.update(owner_n, owner_g, owner_a, curOwner_id);
            _vehicle.update(vehicle_t, vehicle_l, vehicle_b, dealer_n, curFee_id);
            _warranty.update(warranty_t, warranty_d, warranty_p, warranty_c, warranty_pay, curWarrant_id);
            _dealer.update(dealer_n, dealer_a, dealer_p);

            // show the updated data
            loadAllData("");
            clearInput();

            canUpdate = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(!canDelete)
            {
                MessageBox.Show("無法進行刪除！", "WARNING"); 
                MessageBox.Show(
                    "請先選擇左方「檢視資料表」的「全部資料」後按「顯示」。\n再從下方的資料中選取要刪除的資料後點擊刪除。"
                    ,"WARNING");
                return;
            }

            foreach (DataGridViewRow data in dataGridView1.SelectedRows)
            {
                curOwner_id = long.Parse(data.Cells["OID"].Value.ToString());
                curLicen = data.Cells["車牌號碼"].Value.ToString();
                curWarrant_id = long.Parse(data.Cells["WID"].Value.ToString());

                // delete data
                _owner.delete(curOwner_id);
                _vehicle.delete(curLicen);
                _warranty.delete(curWarrant_id);
            }

            // show the updated data
            loadAllData("");
            canDelete = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String query = "";
            switch(cbQuery.SelectedIndex)
            {
                case(0):
                    query += " SELECT OWNER.*, WARRANTY.*, FEE.*,";
                    query += " VEHICLE.車牌號碼, VEHICLE.車種, VEHICLE.廠牌";
                    query += " FROM OWNER, WARRANTY, VEHICLE, FEE, INSURE";
                    query += " WHERE OWNER.OID = INSURE.OwnerID";
                    query += " AND WARRANTY.WID = INSURE.WarrantyID";
                    query += " AND VEHICLE.車牌號碼 = INSURE.License";
                    query += " AND FEE.FID = VEHICLE.FeeID";
                    break;

                case(1):
                    query += " SELECT * FROM DEALER";
                    query += " WHERE NOT EXISTS ( SELECT * FROM VEHICLE WHERE ";
                    query += " VEHICLE.經銷商 = DEALER.車行 )";
                    break;

                case(2):
                    query += " SELECT * FROM VEHICLE";
                    query += " WHERE EXISTS ( SELECT * FROM FEE WHERE ";
                    query += " FEE.FID = VEHICLE.FeeID AND FEE.燃料費 )";
                    break;

                case(3):
                    query += " SELECT FEE.牌照稅 FROM FEE ";
                    query += " WHERE FEE.FID IN ( SELECT VEHICLE.FeeID FROM VEHICLE ";
                    query += " WHERE VEHICLE.車種 = '重型機車' OR VEHICLE.車種 = '輕型機車' )";
                    break;

                case(4):
                    query += " SELECT * FROM VEHICLE ";
                    query += " WHERE VEHICLE.FeeID NOT IN ( SELECT FEE.FID FROM FEE ";
                    query += " WHERE FEE.牌照稅=0 ) ";
                    break;
            }
            loadAllData(query);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            String query = rtQueryInput.Text;
            loadAllData(query);
        }

        private String getValue(String key)
        {
            if(dataGridView1.Columns[key] !=null)
            {
                return dataGridView1.SelectedRows[0].Cells[key].Value.ToString();
            }
            return "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) 
        {

            if(curTable == "FEE" && dataGridView1.ColumnCount == 3 && canUpdate)
            {
                curFee_id = (getValue("FID") == "") ? curFee_id : long.Parse(getValue("FID"));        
                tbFeeFuel.Text = (getValue("燃料費") == "") ? tbFeeFuel.Text : getValue("燃料費");
                tbTaxLic.Text = (getValue("牌照稅") == "") ? tbTaxLic.Text : getValue("牌照稅");
                return;
            }
            if(curTable == "DEALER" && dataGridView1.ColumnCount == 3 && canUpdate)
            {
                curDealer = (getValue("車行") == "") ? curDealer : getValue("車行");
                tbDealer.Text = (getValue("車行")=="") ? tbDealer.Text : getValue("車行");
                tbDealerAddr.Text = (getValue("車行地址") == "") ? tbDealerAddr.Text : getValue("車行地址");
                tbPhone.Text = (getValue("電話") == "") ? tbPhone.Text : getValue("電話");
                return;
            }

            // check show the "全部資料" table
            if(curTable == "" && getValue("OID") != "" && getValue("車牌號碼") != "" &&
             getValue("車行") != "" && getValue("WID") != "" && getValue("FID") != "")
            {
                Console.WriteLine("CURRENT TABLE : " + curTable);
                canUpdate = true;
            }
            else {
                canUpdate = false;
            }

            // save the invisible data (ex: OwnerID, InsuranceID... )
            curOwner_id = (getValue("OID") == "") ? curOwner_id : long.Parse(getValue("OID"));
            curLicen = (getValue("車牌號碼") == "") ? curLicen : getValue("車牌號碼");
            curDealer = (getValue("車行") == "") ? curDealer : getValue("車行");
            curWarrant_id = (getValue("WID") == "") ? curWarrant_id : long.Parse(getValue("WID"));
            curFee_id = (getValue("FID") == "") ? curFee_id : long.Parse(getValue("FID"));
            Console.WriteLine("current fee id : " +curFee_id);

            // save the visible data and put in the input frame
            tbName.Text = (getValue("姓名") == "") ? tbName.Text : getValue("姓名");
            if(getValue("性別") != "")
            {
                rbMale.Checked = (getValue("性別") == "男") ? true : false;
                rbFemale.Checked = (getValue("性別") == "女") ? true : false;
            }
            tbAddress.Text = (getValue("地址") == "") ? tbAddress.Text : getValue("地址");

            cbVehicleType.SelectedItem = (getValue("車種") == "") ? cbVehicleType.SelectedItem : getValue("車種");
            tbLicense.Text = (getValue("車牌號碼") == "") ? tbLicense.Text : getValue("車牌號碼"); ;
            tbBrand.Text = (getValue("廠牌") == "") ? tbBrand.Text : getValue("廠牌");

            tbDealer.Text = (getValue("車行")=="") ? tbDealer.Text : getValue("車行");
            tbDealerAddr.Text = (getValue("車行地址") == "") ? tbDealerAddr.Text : getValue("車行地址");
            tbPhone.Text = (getValue("電話") == "") ? tbPhone.Text : getValue("電話");

            if(getValue("保險種類") != "")
            {
                rbFree.Checked = (getValue("保險種類") == "任意險") ? true : false;
                rbForce.Checked = (getValue("保險種類") == "強制險") ? true : false;
            }
            dtDate.Value = (getValue("保險到期日") == "") ? dtDate.Value : DateTime.Parse(getValue("保險到期日"));
            tbPrice.Text = (getValue("保額") == "") ? tbPrice.Text : getValue("保額");
            tbCost.Text = (getValue("保費") == "") ? tbCost.Text : getValue("保費");
            if(getValue("付款方式") != "")
            {
                rbCreditCard.Checked = (getValue("付款方式") == "刷卡") ? true : false;
                rbCash.Checked = (getValue("付款方式") == "現金") ? true : false;
            }

            tbFeeFuel.Text = (getValue("燃料費") == "") ? tbFeeFuel.Text : getValue("燃料費");
            tbTaxLic.Text = (getValue("牌照稅") == "") ? tbTaxLic.Text : getValue("牌照稅");
        }

        /*
        private void btnBasicSearch_Click(object sender, EventArgs e)
        {
            String query;
            String entity = "";
            String condition = "";
            int checkedEntityNum = 0;
            strAttri = "";

            // get attributes (put it after SELECT)
            IEnumerable<CheckBox> attriSet = groupBox6.Controls.OfType<CheckBox>();
            bool firstAttri = true;
            foreach(CheckBox cb in attriSet)
            {
                if(cb.Enabled && cb.Checked)
                {
                    if(cb.Text == "*")
                    {
                        strAttri = "*";
                        break;
                    }
                    if(firstAttri)
                    {
                        strAttri = cb.Text;
                        firstAttri = false;
                    }
                    else
                    {
                        strAttri += ", " + cb.Text;
                    }
                }
            }

            // get entities (put it after FROM)
            IEnumerable<CheckBox> entiSet = groupBox5.Controls.OfType<CheckBox>();
            bool firstEnti = true;
            foreach(CheckBox cb in entiSet)
            {
                if(cb.Checked)
                {
                    ++checkedEntityNum;
                    if(firstEnti)
                    {
                        entity = getQueryEntity(cb.Text);
                        firstEnti = false;
                    }
                    else
                    {
                        entity += ", " + getQueryEntity(cb.Text);
                    }
                }
            }

            // add relationship table
            bool firstCond = true;
            if(cbOwner.Checked && cbVehicle.Checked)
            {
                condition += " WHERE Owner.OID = Vehicle.OwnerID";
                firstCond = false;

                if(cbInsurance.Checked)
                {
                    entity += ", " + "relation_ins";
                    condition += " AND " + "Owner.OID = relation_ins.OwnID";
                    condition += " AND " + "vehicle.車牌號碼 = relation_ins.License";
                    condition += " AND " + "insurance.IID = relation_ins.InsID";
                }
                if(cbTax.Checked)
                {
                    entity += ", " + "relation_tax";
                    condition += " AND " + "Owner.OID = relation_tax.OwnID";
                    condition += " AND " + "vehicle.車牌號碼 = relation_tax.License";
                    condition += " AND " + "tax.TaxID = relation_tax.TaxID";
                }
            }
            if(cbInsurance.Checked && cbPayment.Checked)
            {
                if(firstCond)
                {
                    condition += " WHERE insurance.IID = payment.InsuranceID";
                    firstCond = false;
                }
                else
                {
                    condition += " AND " + "insurance.IID = payment.InsuranceID";
                }
            }

            // get conditions
            if(dgvConstraint.RowCount > 1)
            {
                Console.WriteLine(dgvConstraint);
                for(int i = 0; i < dgvConstraint.Rows.Count - 1; ++i)
                {
                    String cond = dgvConstraint.Rows[i].Cells[0].Value.ToString();
                    cond += dgvConstraint.Rows[i].Cells[1].Value.ToString();
                    cond += "'" + dgvConstraint.Rows[i].Cells[2].Value.ToString() + "'";
                    if(firstCond)
                    {
                        condition = " WHERE " + cond;
                        firstCond = false;
                        continue;
                    }

                    condition +=  " AND " + cond;
                }
            }

            query = "SELECT " + strAttri + " FROM " + entity + condition;
            Console.WriteLine(query);

            loadAllData(query);

        }

        private void btnComplex_Click(object sender, EventArgs e)
        {
            strAttri = strEnti = strCond = "";
            // get attributes (put it after SELECT)
            IEnumerable<CheckBox> attriSet = groupBox6.Controls.OfType<CheckBox>();
            bool firstAttri = true;
            foreach (CheckBox cb in attriSet)
            {
                if (cb.Enabled && cb.Checked)
                {
                    if (cb.Text == "*")
                    {
                        strAttri = "*";
                        break;
                    }
                    if (firstAttri)
                    {
                        strAttri = cb.Text;
                        firstAttri = false;
                    }
                    else
                    {
                        strAttri += ", " + cb.Text;
                    }
                }
            }
            
            // get entities (put it after FROM)
            int checkedEntityNum = 0;
            IEnumerable<CheckBox> entiSet = groupBox5.Controls.OfType<CheckBox>();
            bool firstEnti = true;
            foreach(CheckBox cb in entiSet)
            {
                if(cb.Checked)
                {
                    ++checkedEntityNum;
                    if(firstEnti)
                    {
                        strEnti = getQueryEntity(cb.Text);
                        firstEnti = false;
                    }
                    else
                    {
                        strEnti += ", " + getQueryEntity(cb.Text);
                    }
                }
            }

            // add relationship table
            bool firstCond = true;
            if(cbOwner.Checked && cbVehicle.Checked)
            {
                strCond += "Owner.OID = Vehicle.OwnerID";
                firstCond = false;

                if(cbInsurance.Checked)
                {
                    strEnti += ", " + "relation_ins";
                    strCond += " AND " + "Owner.OID = relation_ins.OwnID";
                    strCond += " AND " + "vehicle.車牌號碼 = relation_ins.License";
                    strCond += " AND " + "insurance.IID = relation_ins.InsID";
                }
                if(cbTax.Checked)
                {
                    strEnti += ", " + "relation_tax";
                    strCond += " AND " + "Owner.OID = relation_tax.OwnID";
                    strCond += " AND " + "vehicle.車牌號碼 = relation_tax.License";
                    strCond += " AND " + "tax.TaxID = relation_tax.TaxID";
                }
            }
            if(cbInsurance.Checked && cbPayment.Checked)
            {
                if(firstCond)
                {
                    strCond += " WHERE insurance.IID = payment.InsuranceID";
                    firstCond = false;
                }
                else
                {
                    strCond += " AND " + "insurance.IID = payment.InsuranceID";
                }
            }
            
            ComplexQuery cq = new ComplexQuery(transfer, strAttri, strEnti, strCond);
            cq.Show();
        }
        */


    }
}
