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
    public class Dealer
    {
        public Dealer() {   }

        public bool find(String name)
        {
            bool haveData = false;
            String query = string.Format("SELECT 車行 FROM DEALER WHERE 車行='{0}'", name);
            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Dealer exists");
                    haveData = true;
                    break;
                }
            }
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();

            return haveData;
        }

        public void insert(String name, String addr, String phone)
        {
            if(find(name)) { return;     }

            String query = string.Format(
                "INSERT INTO DEALER( 車行, 車行地址, 電話) VALUES ('{0}', '{1}', '{2}')",
                 name, addr, phone);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();

        }

        public void update(String name, String addr, String phone)
        {

            String query = string.Format(
                "UPDATE DEALER SET 車行地址='{0}', 電話='{1}' WHERE 車行='{2}'",
                 addr, phone, name);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

        public void delete(String name)
        {
            String query = string.Format("DELETE FROM DEALER WHERE 車行='{0}'", name);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

    }
}
