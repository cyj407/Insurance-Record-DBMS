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
    public class Fee
    {
        private long id;
        
        private void setID(long val)
        {
            this.id = val;
        }
        
        public Fee()
        {

        }

        public long getID()
        {
            return this.id;
        }

        public void insert(long fuel_fee, long lic_tax)
        {

            String query = string.Format("INSERT INTO FEE( 燃料費, 牌照稅) VALUES ('{0}', '{1}')",
             fuel_fee, lic_tax);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            setID(cmd.LastInsertedId);
            MainWindow.connection.Close();

        }
        public void update(long fuel_fee, long lic_tax, long id)
        {
            String query = string.Format("UPDATE FEE SET 燃料費='{0}', 牌照稅='{1}' WHERE FID='{2}'",
             fuel_fee, lic_tax, id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }
/* 
        public void delete(long id)
        {
            String query = string.Format("DELETE FROM FEE WHERE TID={0}", id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }
*/
    }
}
