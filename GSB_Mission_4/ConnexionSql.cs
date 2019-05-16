using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GSB_Mission_4
{
    /// <summary>
    /// Classe de connexion à la base de données
    /// </summary>
    public class ConnexionSql
    {
        private static ConnexionSql connection = null;
        private MySqlConnection mySqlCn;
        private static readonly object mylock = new object();

        /// <summary>
        /// Constructeur privé de la classe ConnexionSql (Singleton)
        /// </summary>
        /// <param name="unProvider"></param>
        /// <param name="uneDataBase"></param>
        /// <param name="unUid"></param>
        /// <param name="unMdp"></param>
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

        /// <summary>
        /// Méthode de création d'une instance de connexion si elle n'existe pas (Singleton)
        /// </summary>
        /// <param name="unProvider"></param>
        /// <param name="uneDataBase"></param>
        /// <param name="unUid"></param>
        /// <param name="unMdp"></param>
        /// <returns></returns>
        public static ConnexionSql getInstance(string unProvider, string uneDataBase, string unUid, string unMdp)
        {
            lock ((mylock))
            {
                try
                {
                    if (connection == null)
                        connection = new ConnexionSql(unProvider, uneDataBase, unUid, unMdp);
                }
                catch (Exception emp)
                {
                    MessageBox.Show(emp.Message);
                }

                return connection;
            }
        }

        /// <summary>
        /// Méthode d'ouverture de la connexion
        /// </summary>
        public void openConnection()
        {
            try
            {
                if (mySqlCn.State == System.Data.ConnectionState.Closed)
                    mySqlCn.Open();
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }

        /// <summary>
        /// Méthode de fermeture de la connexion
        /// </summary>
        public void closeConnection()
        {
            if (mySqlCn.State == System.Data.ConnectionState.Open)
                mySqlCn.Close();
        }

        /// <summary>
        /// Méthode d'exécution d'une requête
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MySqlCommand reqExec(string req)
        {
            MySqlCommand mysqlCom = new MySqlCommand(req, this.mySqlCn);
            return (mysqlCom);
        }
    }
}
