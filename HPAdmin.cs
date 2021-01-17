using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
//using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;

namespace OSAO
{
    public partial class HPAdmin : Form
    {
        public HPAdmin()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("SERVER=160.153.128.30;PORT=3306;DATABASE=AbrahamALL;UID=OSA; PASSWORD=OSA2020;");
        //MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3308; uid=root; database=osa");
        MySqlCommand cmd = new MySqlCommand();
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
        private void HPAdmin_Load(object sender, EventArgs e)
        {
            gunaAnimateWindow1.Start();
            gunaLabel1.Text = Form3Admin.OSA;
            this.reportViewer1.RefreshReport();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            try
            {
                using (var waitform = new loarding(wait1))
                {
                    waitform.ShowDialog(this);
                }
                String SelectQuery = "Select name,Tel,email,adresse,BP from profile where OSA='" + quotes(gunaLabel1.Text) + "'";
                MySqlCommand cmd = new MySqlCommand(SelectQuery, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "Hpage");
                ReportDataSource dataSource = new ReportDataSource("DataSet1", ds.Tables[2]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Aucun accès à Internet. ERR_INTERNET_DISCONNECTED", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
 
        }
    }
}
