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
    partial class ServiceGSB : ServiceBase
    {
        ConnexionSql connect;

        public ServiceGSB()
        {
            InitializeComponent();
            connect = ConnexionSql.getInstance("10.30.0.113", "DUBOST", "DUBOST", "mdubost");
        }

        protected override void OnStart(string[] args)
        {
            // TODO: ajoutez ici le code pour démarrer votre service.
        }

        protected override void OnStop()
        {
            // TODO: ajoutez ici le code pour effectuer les destructions nécessaires à l'arrêt de votre service.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            connect.openConnection();

            GestionDate gd = new GestionDate();
            MySqlCommand msc;

            if (/*Convert.ToInt16(gd.currentDay()) == 10*/true)
            {
                msc = connect.reqExec("UPDATE fichefrais SET idEtat = 'CL' WHERE mois = " + gd.currentYear() + gd.previousMonth());
                msc.ExecuteNonQuery();
            }

            if (Convert.ToInt16(gd.currentDay()) == 20)
            {
                msc = connect.reqExec("UPDATE fichefrais SET idEtat = 'RB' WHERE mois = " + gd.currentYear() + gd.previousMonth());
                msc.ExecuteNonQuery();
            }

            connect.closeConnection();
        }
    }
}
