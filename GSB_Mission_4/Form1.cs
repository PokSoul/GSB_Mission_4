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

namespace GSB_Mission_4
{
    /// <summary>
    /// Formulaire de test permettant de visualiser les changements effectués par les requêtes
    /// </summary>
    public partial class Form1 : Form
    {
        ConnexionSql connect;

        /// <summary>
        /// Initialisation du formulaire
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affichage du formulaire et initialisation de la connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            connect = ConnexionSql.getInstance("10.30.0.113", "DUBOST", "DUBOST", "mdubost");
            /* +---------+-------------+-----------------+
               |         | Lycée       | Maison          |
               +---------+-------------+-----------------+
               | Adresse | 10.30.0.113 | slam.siolms.pro |
               +---------+-------------+-----------------+ */

            afficher();
        }

        /// <summary>
        /// Affichage des données de la table FicheFrais dans une grille (DataGridView)
        /// </summary>
        public void afficher()
        {
            connect.closeConnection();
            connect.openConnection();

            DataTable dt = new DataTable();
            MySqlCommand oCom = connect.reqExec("select * from fichefrais");
            MySqlDataReader reader = oCom.ExecuteReader();
            for (int i = 0; i <= reader.FieldCount - 1; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();

                for (int i = 0; i <= reader.FieldCount - 1; i++)
                {
                    dr[i] = reader.GetValue(i);
                }

                dt.Rows.Add(dr);
            }

            // Pour mettre la table sur un DataGridView :
            dataGridView1.DataSource = dt;
            reader.Close();

            connect.closeConnection();
        }

        /// <summary>
        /// Minuteur permettant d'effectuer les requêtes à interval régulier et donné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                connect.openConnection();

                GestionDate gd = new GestionDate();
                MySqlCommand msc;

                if (/*Convert.ToInt16(gd.currentDay()) == 10*/ true)
                {
                    msc = connect.reqExec(@"UPDATE fichefrais
                                            SET idEtat = 'CL'
                                            WHERE mois = " + gd.currentYear() + gd.previousMonth());
                    msc.ExecuteNonQuery();
                    connect.closeConnection();
                }

                if (Convert.ToInt16(gd.currentDay()) == 20)
                {
                    msc = connect.reqExec(@"UPDATE fichefrais
                                            SET idEtat = 'RB'
                                            WHERE idEtat = 'VA'
                                            AND mois = " + gd.currentYear() + gd.previousMonth());
                    msc.ExecuteNonQuery();
                    connect.closeConnection();
                }

                connect.closeConnection();
                afficher();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Méthode d'affichage du contenu de la cellule sélectionnée par un double clic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            int j = dataGridView1.CurrentCell.ColumnIndex;
            MessageBox.Show(dataGridView1[j, i].Value.ToString());
        }
    }
}
