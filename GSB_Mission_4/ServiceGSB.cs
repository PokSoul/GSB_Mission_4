using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSB_Mission_4
{
    /// <summary>
    /// Service Windows de l'application GSB
    /// </summary>
    partial class ServiceGSB : ServiceBase
    {
        ConnexionSql connect;

        /// <summary>
        /// Constructeur du service (initialisation des composants et de la connexion)
        /// </summary>
        public ServiceGSB()
        {
            InitializeComponent();
            connect = ConnexionSql.getInstance("10.30.0.113", "DUBOST", "DUBOST", "mdubost");
            /* +---------+-------------+-----------------+
               |         | Lycée       | Maison          |
               +---------+-------------+-----------------+
               | Adresse | 10.30.0.113 | slam.siolms.pro |
               +---------+-------------+-----------------+ */
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        /// <summary>
        /// Minuteur du service permettant d'effectuer les requêtes à interval régulier et donné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            connect.openConnection();

            GestionDate gd = new GestionDate();
            MySqlCommand msc;

            if (Convert.ToInt16(gd.currentDay()) == 10)
            {
                msc = connect.reqExec(@"UPDATE fichefrais
                                        SET idEtat = 'CL'
                                        WHERE mois = " + gd.currentYear() + gd.previousMonth());
                msc.ExecuteNonQuery();
            }

            if (Convert.ToInt16(gd.currentDay()) == 20)
            {
                msc = connect.reqExec(@"UPDATE fichefrais
                                        SET idEtat = 'RB'
                                        WHERE idEtat = 'VA'
                                        AND mois = " + gd.currentYear() + gd.previousMonth());
                msc.ExecuteNonQuery();
            }

            connect.closeConnection();
        }
    }
}
