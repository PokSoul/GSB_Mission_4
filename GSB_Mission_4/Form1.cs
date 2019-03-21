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
    public partial class Form1 : Form
    {
        ConnexionSql connect;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect = ConnexionSql.getInstance("10.30.0.113", "DUBOST", "DUBOST", "mdubost");
            connect.openConnection();
            afficher();
            
        }

        public void afficher()
        {

            MySqlCommand oCom = connect.reqExec("select * from visiteur");


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

                /* dr[0] = reader.GetString(0);
                 dr[1] = reader.GetString(1);
                 dr[2] = reader.GetString(2);*/

                dt.Rows.Add(dr);



            }

            // pour mettre la table sur un datagridView :
            dataGridView1.DataSource = dt;

            reader.Close();

        }

    }
}
