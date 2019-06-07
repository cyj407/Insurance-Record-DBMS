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
    public class Vehicle
    {
        public Vehicle() {   }

        public bool find(String lic)
        {
            bool haveData = false;
            String query = string.Format("SELECT 車牌號碼 FROM VEHICLE WHERE 車牌號碼='{0}'", lic);
            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Vehicle exists");
                    haveData = true;
                    break;
                }
            }
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();

            return haveData;
        }

        public void insert(String type, String lic, String brand, String dealer, long t_id)
        {
            if(find(lic))   {   return;    }

            String query = string.Format(
                "INSERT INTO VEHICLE( 車種, 車牌號碼, 廠牌, 經銷商,  FeeID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                 type, lic, brand, dealer, t_id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();

        }

        public void update(String type, String lic, String brand, String dealer, long t_id)
        {
            String query = string.Format(
                "UPDATE VEHICLE SET 車種='{0}', 廠牌='{1}', 經銷商='{2}', FeeID='{3}' WHERE 車牌號碼='{4}'",
             type, brand, dealer, t_id, lic);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

        public void delete(String lic)
        {
            String query = string.Format("DELETE FROM VEHICLE WHERE 車牌號碼='{0}'", lic);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

    }
}
