using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_Mission_4
{
    class ConnexionSql
    {
        public bool Login(string username, string password)
        {
            MySqlConnection con = new MySqlConnection("host=localhost;username=DUBOST;password=mdubost;database=DUBOST");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM visiteur WHERE login='" + username + "' and mdp='" + password + ";");

            cmd.Connection = con;

            con.Open(); // Here is the line where I got this message >> Unable to connect to any of the specified MySQL hosts.

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() != false)
            {

                if (reader.IsDBNull(0) == true)
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }

                else
                {

                    cmd.Connection.Close();

                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }

            }

            else
            {
                return false;
            }

        }

    }
}
    
