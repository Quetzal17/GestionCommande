using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OSAO
{
    public partial class Form3Admin : Form
    {
        public static String OSA;
        public static String USER;
        public static String CAY;
        public Form3Admin()
        {
            try
            {
                Thread t = new Thread(new ThreadStart(Splash));
                t.Start();
                InitializeComponent();
                string str = string.Empty;
                for (int i = 0; i < 100000; i++)
                {
                    str += i.ToString();
                }
                t.Abort();
            }
            catch (Exception)
            {

            }
        }
       
        MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; uid=root; database=stock");
        MySqlCommand cmd = new MySqlCommand();

        void Splash()
        {
            try
            {
                SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
                // frm.Font = (Font.FontFamily.Name="OSA Apps");
                frm.AppName = "Gestion de Stock";
               
                Application.Run(frm);
            }
            catch (Exception)
            {
            }
        }
        private void Form3Admin_Load(object sender, EventArgs e)
        {

            prodnow();
        }
        private void prodnow()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select NO as 'NO',produit as 'PRODUIT',stock as 'STOCK',vendre as 'ACHAT',reste as 'REST EN STOCK',shift as 'EMPLACEMENT' from magasin";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid8.DataSource = dt;
                con.Close();
                int counto = metroGrid8.RowCount;
                double countN = counto - 1;
                gunaLabel6.Text = countN.ToString();
            }
            catch (Exception)
            {
            }
        }
        public void Produi(string gunaTextBox7)
        {
            try
            {
                string searchQuery = "select NO as 'NO',produit as 'PRODUIT',stock as 'STOCK',vendre as 'ACHAT',reste as 'REST EN STOCK',shift as 'EMPLACEMENT' from magasin where CONCAT(produit,shift,stock,reste) LIKE '%" + gunaTextBox7 + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(searchQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid8.DataSource = dt;
                con.Close();
                int counto = metroGrid8.RowCount;
                double countN = counto - 1;
                gunaLabel6.Text = countN.ToString();
            }
            catch (Exception)
            { }
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

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
           
        }
        
        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
 
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            logino lg = new logino();
            lg.Show();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
   
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            OSA = gunaLabel1.Text;
            USER = gunaLabel2.Text;
            PGeneral ado = new OSAO.PGeneral();
            ado.gunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_VER_NEGATIVE;
            ado.ShowDialog();
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
    
        }

        private void gunaShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton13_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton15_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton17_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton16_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton18_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaButton14_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox7_TextChanged(object sender, EventArgs e)
        {
            if(gunaTextBox7.Text == String.Empty)
            {
                gunaPictureBox1.Visible = true;
            }
            else {
                gunaPictureBox1.Visible = false;
                Produi(gunaTextBox7.Text);
            }
        }

        private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            Commentaire com = new Commentaire();
            com.Show(this);
        }
    }
}
