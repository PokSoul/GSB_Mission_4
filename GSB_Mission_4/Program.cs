using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GSB_Mission_4
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            ConnexionSql MySqlConnection = ConnexionSql.getInstance("10.30.0.113", "DUBOST", "DUBOST", "mdubost");
            MySqlConnection.reqExec("SELECT mois FROM fichefrais WHERE id = ?");
        }
    }
}
