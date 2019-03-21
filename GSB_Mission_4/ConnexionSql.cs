using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GSB_Mission_4
{
    class ConnexionSql
    {
        // Variable locale pour stocker une référence vers l'instance
        private static ConnexionSql connection = null;
        private MySqlConnection mySqlCn;
        private static readonly object mylock = new object();

        private ConnexionSql(string unProvider, string uneDataBase, string unUid, string unMdp)
        {
            try
            {
                string connString;
                connString = "SERVER=" + unProvider + ";" + "DATABASE=" +
                uneDataBase + ";" + "User ID=" + unUid + ";" + "PASSWORD=" + unMdp + ";";
                try
                {
                    mySqlCn = new MySqlConnection(connString);
                }
                catch (Exception emp)
                {
                    MessageBox.Show(emp.Message);
                }
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }

        /**
         * méthode de création d'une instance de connexion si elle n'existe pas (singleton)
         */
        public static ConnexionSql getInstance(string unProvider, string uneDataBase, string unUid, string unMdp)
        {
            lock ((mylock))
            {
                try
                {
                    if (null == connection)
                    { 
                        // Premier appel
                        connection = new ConnexionSql(unProvider, uneDataBase, unUid, unMdp);
                    }
                }
                catch (Exception emp)
                {
                    MessageBox.Show(emp.Message);
                }

                return connection;
            }
        }

        /**
         * Ouverture de la connexion
         */
        public void openConnection()
        {
            try
            {
                mySqlCn.Open();
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }

        /**
         * Fermeture de la connexion
         */
        public void closeConnection()
        {
            mySqlCn.Close();
        }

        /**
         * Exécutiuon d'une requête
         */
        public MySqlCommand reqExec(string req)
        {
            MySqlCommand mysqlCom = new MySqlCommand(req, this.mySqlCn);
            return (mysqlCom);
        }
    }
}
