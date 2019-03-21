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

            // pour mettre la table sur un datagridView :
            dataGridView1.DataSource = dt;
            reader.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MySqlCommand req = connect.reqExec("SELECT mois FROM fichefrais WHERE id = {0}");
            MySqlDataReader reader = req.ExecuteReader();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            int j = dataGridView1.CurrentCell.ColumnIndex;
            MessageBox.Show(dataGridView1[j, i].Value.ToString());
        }
    }
}
