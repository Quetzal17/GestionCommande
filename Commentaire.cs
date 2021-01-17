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

namespace OSAO
{
    public partial class Commentaire : Form
    {
        public Commentaire()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; uid=root; database=stock");
        MySqlCommand cmd = new MySqlCommand();

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox1.Text == string.Empty)
                {
                    gunaCircleButton10.Visible = true;
                }
                else
                {
                    gunaCircleButton10.Visible = false;
                    //using (var waitform = new loarding(wait1))
                    //{
                    //    waitform.ShowDialog(this);
                    //}
                    //String SelectQuery = "Select * from commentaire where Commentaire='" + quotes(gunaTextBox1.Text) + "'";
                    //MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    //DataTable dt = new DataTable();
                    //MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    //da.Fill(dt);
                    //int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    //if (i == 1)
                    //{
                    //    MetroFramework.MetroMessageBox.Show(this, "SVP, Ce message aurait déjà été poster", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    con.Open();
                    //    cmd.Connection = con;
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.CommandText = "insert into commentaire(Commentaire) values ('" + quotes(gunaTextBox1.Text) + "')";
                    //    cmd.ExecuteNonQuery();
                    //    con.Close();
                    //    //categ(); catg();
                    //    MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    gunaTextBox1.Text = "";
                    //}
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, opération non réussie", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaCircleButton10_Click(object sender, EventArgs e)
        {

        }

        private void Commentaire_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
           // display();
        }
    }
}
