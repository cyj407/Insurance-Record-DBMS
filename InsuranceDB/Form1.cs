﻿using System;
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

        // save the key from all entities
        private long curOwner_id = -1, curWarrant_id = -1, curFee_id = -1;
        private String curLicen, curDealer;

        private String curTable;

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
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        
        private void hideCols()
        {
            
            if(dataGridView1.Columns["經銷商"] != null && dataGridView1.Columns["車行"] != null)
            {
                dataGridView1.Columns["經銷商"].Visible = false;
            }
            if (dataGridView1.Columns["FeeID"] != null && dataGridView1.Columns["FID"] != null)
            {
                dataGridView1.Columns["FID"].Visible = false;
            }
            if (dataGridView1.Columns["OwnerID"] != null && dataGridView1.Columns["OID"] != null)
            {
                dataGridView1.Columns["OID"].Visible = false;
            }
            if (dataGridView1.Columns["License"] != null && dataGridView1.Columns["車牌號碼"] != null)
            {
                dataGridView1.Columns["License"].Visible = false;
            }
            if (dataGridView1.Columns["WarrantyID"] != null && dataGridView1.Columns["WID"] != null)
            {
                dataGridView1.Columns["WID"].Visible = false;
            }

        }

        private void loadAllData(String query)
        {
            // show the updated data
            if(query == "")
            {
                curTable = "";
                btnDelete.Enabled = true;

                query = "SELECT * FROM OWNER, VEHICLE, WARRANTY, FEE, DEALER, INSURE ";
                query += " WHERE OWNER.OID = INSURE.OwnerID AND ";
                query += " VEHICLE.車主 = OWNER.OID AND ";
                query += " VEHICLE.車牌號碼 = INSURE.License AND ";
                query += "VEHICLE.FeeID = FEE.FID AND ";
                query += " DEALER.車行 = VEHICLE.經銷商 AND ";
                query += " WARRANTY.WID = INSURE.WarrantyID";
            }
            else {
                if(curTable != "OWNER" && curTable != "VEHICLE" && curTable != "DEALER" &&
                curTable != "WARRANTY" && curTable != "INSURE" && curTable != "FEE") {
                    curTable = "WRONG";
                }
                btnDelete.Enabled = false;
            }

            Console.WriteLine(curTable);

            MySqlCommand cmd = new MySqlCommand(query, connection);
            try {
                connection.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;

                // hide some join elements
                if(curTable == "") {
                    hideCols();
                }

                da.Update(dt);
                connection.Close();
            } catch {
                MessageBox.Show("SQL語法錯誤！\n", "ERROR");
            }
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
            cbVehicleType.SelectedIndex = 1;
            dtDate.Value = DateTime.Today.Date;
            tbName.Text = tbAddress.Text = "";
            tbLicense.Text = tbBrand.Text = "";
            tbCost.Text = tbPrice.Text = "";
            rbMale.Checked = rbFemale.Checked = false;
            rbFree.Checked = rbForce.Checked = false;
            rbCreditCard.Checked = rbCash.Checked = false;

            // when no input exists -> turn off update button
            btnUpdate.Enabled = false;
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

            // check not duplicate
            bool exists = false;
            String query = " SELECT * FROM OWNER, VEHICLE, WARRANTY, INSURE ";
            query += " WHERE OID=OwnerID AND 車牌號碼=License AND 車主=OID AND WID=WarrantyID AND";
            query += string.Format(
                " 保險種類='{0}' AND 姓名='{1}' AND 性別='{2}' AND 地址='{3}' AND 車牌號碼='{4}' "
                , warranty_t, owner_n, owner_g, owner_a, vehicle_l);
            
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    exists = true;
                    break;
                }
            }
            cmd.ExecuteNonQuery();
            connection.Close();

            if(exists) {
                MessageBox.Show("此資料已存在，無法再次加入。", "WARNING");
            }
            else {
                // insert to all entity and relationship // fee no needs to add
                _owner.insert(owner_n, owner_g, owner_a);
                _vehicle.insert(vehicle_t, vehicle_l, vehicle_b, dealer_n, curFee_id, _owner.getID());
                _warranty.insert(warranty_t, warranty_d, warranty_p, warranty_c, warranty_pay);
                _dealer.insert(dealer_n, dealer_a, dealer_p);
                _insure.insert(_owner.getID(), vehicle_l, _warranty.getID());
            }

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
            
            curTable = entity;
            loadAllData(query);

        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // check all be filled in
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
            _vehicle.update(vehicle_t, vehicle_l, vehicle_b, dealer_n, curFee_id, curOwner_id);
            _warranty.update(warranty_t, warranty_d, warranty_p, warranty_c, warranty_pay, curWarrant_id);
            _dealer.update(dealer_n, dealer_a, dealer_p);

            // show the updated data
            loadAllData("");
            clearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   
            foreach (DataGridViewRow data in dataGridView1.SelectedRows)
            {
                // get current row
                curOwner_id = long.Parse(data.Cells["OID"].Value.ToString());
                curLicen = data.Cells["車牌號碼"].Value.ToString();
                curWarrant_id = long.Parse(data.Cells["WID"].Value.ToString());

                // check delete owner or not
                bool deleteOwner = true;
                String query = String.Format(
                    "SELECT COUNT(*) FROM INSURE WHERE OwnerID='{0}'", curOwner_id);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(int.Parse(reader["COUNT(*)"].ToString()) > 1)
                        {
                            deleteOwner = false;
                            break;
                        }
                    }
                }
                cmd.ExecuteNonQuery();
                connection.Close();

                // check delete vehicle or not
                bool deleteVeh = true;
                query = String.Format(
                    "SELECT COUNT(*) FROM INSURE WHERE License='{0}'", curLicen);
                cmd = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(int.Parse(reader["COUNT(*)"].ToString()) > 1)
                        {
                            deleteVeh = false;
                            break;
                        }
                    }
                }
                cmd.ExecuteNonQuery();
                connection.Close();

                if(deleteOwner) {
                    Console.WriteLine("delete owner");
                    _owner.delete(curOwner_id);
                }
                if(deleteVeh) {
                    Console.WriteLine("delete vehicle");
                    _vehicle.delete(curLicen);
                }
                _warranty.delete(curWarrant_id);
            }

            // finish delete and turn off the button
            btnDelete.Enabled = false;

            // show the updated data
            loadAllData("");
         
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
                    query += " WHERE OWNER.OID = INSURE.OwnerID ";
                    query += " AND OWNER.OID = VEHICLE.車主 ";
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
                    query += " FEE.FID = VEHICLE.FeeID AND FEE.牌照稅=0)";
                    break;

                case(3):
                    query += " SELECT * FROM OWNER ";
                    query += " WHERE OWNER.OID IN ( SELECT VEHICLE.車主 FROM VEHICLE ";
                    query += " WHERE VEHICLE.廠牌='光陽' )";
                    break;

                case(4):
                    query += " SELECT * FROM VEHICLE ";
                    query += " WHERE VEHICLE.經銷商 NOT IN ( SELECT DEALER.車行 FROM DEALER ";
                    query += " WHERE DEALER.車行地址 LIKE '%永康區%' ) ";
                    break;

                default:        // "-" -> search month
                    break;
            }
            loadAllData(query);
        }

        private void btnComplex_Click(object sender, EventArgs e)
        {
            ComplexQuery cq = new ComplexQuery(transfer);
            cq.Show();
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            String year = DateTime.Now.Year.ToString();
            String month = cbMonth.SelectedItem.ToString();
            DateTime firstDay = DateTime.Parse(year + "-" + month + "-1");
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);
            String query = "";

            query = "SELECT * FROM OWNER, VEHICLE, WARRANTY, FEE, DEALER, INSURE ";
            query += " WHERE OWNER.OID = INSURE.OwnerID AND ";
            query += " VEHICLE.車主 = OWNER.OID AND ";
            query += " VEHICLE.車牌號碼 = INSURE.License AND ";
            query += "VEHICLE.FeeID = FEE.FID AND ";
            query += " DEALER.車行 = VEHICLE.經銷商 AND ";
            query += " WARRANTY.WID = INSURE.WarrantyID AND ";
            query += string.Format(" WARRANTY.保險到期日 between '{0}' AND '{1}'", firstDay, lastDay);

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
            // CAN pass value to the input section
            if(curTable == "" || curTable == "DEALER" || curTable == "FEE")
            {
                // enable modify when double click
                btnUpdate.Enabled = true;

                // save the invisible data (ex: OwnerID, InsuranceID... )
                curOwner_id = (getValue("OID") == "") ? curOwner_id : long.Parse(getValue("OID"));
                curLicen = (getValue("車牌號碼") == "") ? curLicen : getValue("車牌號碼");
                curDealer = (getValue("車行") == "") ? curDealer : getValue("車行");
                curWarrant_id = (getValue("WID") == "") ? curWarrant_id : long.Parse(getValue("WID"));
                curFee_id = (getValue("FID") == "") ? curFee_id : long.Parse(getValue("FID"));

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
        }


    }
}