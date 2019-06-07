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
    public class Insure
    {
        public Insure() {   }

        public void insert(long o_id, String v_lic, long w_id)
        {
            String query = string.Format(
                "INSERT INTO INSURE(OwnerID, License, WarrantyID) VALUES ('{0}', '{1}', '{2}')", 
            o_id, v_lic, w_id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();

        }

    }
}
