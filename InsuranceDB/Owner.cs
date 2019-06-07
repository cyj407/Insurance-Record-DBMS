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
    public class Owner
    {
        private long id;
        
        private void setID(long val)
        {
            this.id = val;
        }
        
        public Owner()
        {

        }

        public long getID()
        {
            return this.id;
        }

        public bool find(String name, String gender, String addr)
        {
            bool haveData = false;
            String query = string.Format(
                "SELECT OID FROM OWNER WHERE 姓名='{0}' AND 性別='{1}' AND 地址='{2}' ", name, gender, addr);
            Console.WriteLine(query);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Owner exists");
                    setID(long.Parse(reader["OID"].ToString()));
                    haveData = true;
                    break;
                }
            }
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
            

            return haveData;
        }

        public void insert(String name, String gender, String addr)
        {
            if(find(name, gender, addr))
            {
                return;
            }

            String query = string.Format("INSERT INTO OWNER( 姓名, 性別, 地址) VALUES ('{0}', '{1}', '{2}')",
             name, gender, addr);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            setID(cmd.LastInsertedId);

            MainWindow.connection.Close();

        }

        public void update(String name, String gender, String addr, long id)
        {
            String query = string.Format("UPDATE OWNER SET 姓名='{0}', 性別='{1}', 地址='{2}' WHERE OID='{3}'",
             name, gender, addr, id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

        public void delete(long id)
        {
            String query = string.Format("DELETE FROM OWNER WHERE OID={0}", id);

            MySqlCommand cmd = new MySqlCommand(query, MainWindow.connection);
            MainWindow.connection.Open();

            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            MainWindow.connection.Close();
        }

    }
}
