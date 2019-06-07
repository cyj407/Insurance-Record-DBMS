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
    public class Warranty
    {
        private long id;
        
        private void setID(long val)
        {
            this.id = val;
        }
        
        public Warranty()
        {

        }

        public long getID()
        {
            return this.id;
        }
        public void insert(String type, DateTime date, long price, long cost, String payment)
        {

            String query = string.Format(
                "INSERT INTO WARRANTY( 保險種類, 保險到期日, 保額, 保費, 付款方式) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                 type, date.ToString("yyyy-MM-dd"), price, cost, payment);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            setID(cmd.LastInsertedId);
            MainWindow.connection.Close();

        }

        public void update(String type, DateTime date, long price, long cost, String payment, long id)
        {
            String query = string.Format(
                "UPDATE WARRANTY SET 保險種類='{0}', 保險到期日='{1}', 保額='{2}', 保費='{3}', 付款方式='{4}' WHERE WID='{5}'",
             type, date.ToString("yyyy-MM-dd"), price, cost, payment, id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

        public void delete(long id)
        {
            String query = string.Format("DELETE FROM WARRANTY WHERE WID={0}", id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }
    }
}
