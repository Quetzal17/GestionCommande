using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OSAO
{
    public partial class logino : Form
    {
        public static String OSA;
        public static String USER;
        public static String CAY;

        public static String ido; public static String namo;
        public logino()
        {
            InitializeComponent();
        }

        
        MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; uid=root; database=commande");
        MySqlCommand cmd = new MySqlCommand();
        private void logino_Load(object sender, EventArgs e)
        {
            gunaAnimateWindow1.Start();
        }
        private String quotes(String str)
        {
            return str.Replace("'", "''");
        }
        void wait1()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(3);
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            
        }


        private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox1.Text == string.Empty)
                {
                    gunaCircleButton1.Visible = true;
                }
                else if (gunaTextBox2.Text == string.Empty)
                {
                    gunaCircleButton1.Visible = false;
                    gunaCircleButton2.Visible = true;
                }
                else
                {
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from login where username='" + quotes(gunaTextBox1.Text) + "' and password='" + quotes(gunaTextBox2.Text) + "'";
                    MySqlCommand cmd = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        this.Hide();
                        PGeneral ado = new PGeneral();
                        ado.ShowDialog();
                    }                      
                    else
                    {
                        gunaLabel4.Text = ""; gunaLabel3.Text = "";
                        MetroFramework.MetroMessageBox.Show(this, "Authentification inconnu", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur d'authentification", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        { //next

        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        { //previous

        }

        private void gunaCirclePictureBox5_Click(object sender, EventArgs e)
        {
             gunaTextBox1.Text = ""; gunaTextBox2.Text = ""; gunaLabel4.Text = "";
        }

        private void gunaMediumRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
    
        }

        private void gunaTextBox11_TextChanged(object sender, EventArgs e)
        {


        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text == string.Empty)
            {
                gunaCircleButton1.Visible = true;
            }
            else if (gunaTextBox2.Text == string.Empty)
            {
                gunaCircleButton1.Visible = false;
                gunaCircleButton2.Visible = true;
            }
            else
            {
                gunaCircleButton2.Visible = false;
            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
