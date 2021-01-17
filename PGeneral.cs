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
using Google.Protobuf.WellKnownTypes;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;

namespace OSAO
{
    public partial class PGeneral : Form
    {
        public PGeneral()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; uid=root; database=commande");
        MySqlCommand cmd = new MySqlCommand();

        private void PGeneral_Load(object sender, EventArgs e)
        {
            ido();NO(); mat(); users(); clso(); categ();
            classo(); prod(); empl(); prodnow(); kitu(); pd(); pn(); cd(); catg();
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
        private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {
        }
        private void classo()
        {
            try
            {
                gunaComboBox7.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM category";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gunaComboBox7.Items.Add(dr["category"]);
                }
                con.Close(); dr.Dispose();
            }
            catch (Exception)
            {
            }
        }
        private void empl()
        {
            try
            {
                gunaComboBox3.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM description";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gunaComboBox3.Items.Add(dr["description"]);
                }
                con.Close(); dr.Dispose();
            }
            catch (Exception)
            {
            }
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
 
        }

        private void gunaCircleButton3_Click(object sender, EventArgs e)
        { 
        }

        private void gunaCircleButton5_Click(object sender, EventArgs e)
        {
          
        }

        private void gunaCircleButton5_Click_1(object sender, EventArgs e)
        {
 
        }

        private void users()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select ido as 'NO',name as 'Nom complet',task as 'Tache',username as 'Nom utilisateur',password as 'Password' from login";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid1.DataSource = dt;
                con.Close();
                int counto = metroGrid1.RowCount;
                double countN = counto - 1;
                gunaLabel22.Text = countN.ToString();
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, vérifier vos paramètres", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaGradient2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            
        }


        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void gunaTextBox8_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void gunaCircleButton11_Click(object sender, EventArgs e)
        {
      
        }


        private void gunaTextBox9_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox4.Text == string.Empty)
                {
                    gunaCircleButton7.Visible = true;
                }
                else
                {
                    gunaCircleButton7.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from description where description='" + quotes(gunaTextBox4.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "cette description existe déjà pour une autre category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into description(description) values ('" + quotes(gunaTextBox4.Text) + "')";
                        cmd.ExecuteNonQuery();
                        con.Close(); clso(); empl();
                        MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gunaTextBox4.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, opération non réussie", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaCircleButton9_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {

            
        }
        

        private void gunaCircleButton10_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaCircleButton8_Click(object sender, EventArgs e)
        {

            
        }
        

        private void metroGrid2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gunaTextBox4.Text = metroGrid2.CurrentRow.Cells["description"].Value.ToString();
            }
            catch (Exception)
            {
                gunaTextBox4.Text = "";
            }
        }

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
           
        }
        private void ido()
        {
            try
            {
                string num = "1K223344556677889900A";
                int len = num.Length;
                string opt = string.Empty;
                int optdigit = 5;
                string final;
                int getindex;
                for (int i = 0; i < optdigit; i++)
                {
                    do
                    {
                        getindex = new Random().Next(0, len);
                        final = num.ToCharArray()[getindex].ToString();
                    }
                    while (opt.IndexOf(final) != -1);
                    opt += final;
                }
                gunaLabel17.Text = (opt); 
            }
            catch (Exception)
            { }
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
                try
            {
                if (gunaTextBox20.Text == string.Empty)
                {
                    gunaCircleButton5.Visible = true;
                }
                else if (gunaComboBox1.Text == string.Empty)
                {
                    gunaCircleButton5.Visible = false;
                    gunaCircleButton6.Visible = true;
                }
                else if (gunaTextBox19.Text == string.Empty)
                {
                    gunaCircleButton11.Visible = false;
                    gunaCircleButton4.Visible = true;
                }
                else if (gunaTextBox18.Text == string.Empty)
                {
                    gunaCircleButton4.Visible = false;
                    gunaCircleButton3.Visible = true;
                }
                else
                {
                    gunaCircleButton3.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from login where ido='" + quotes(gunaLabel18.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous modifier?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update login set name='" + quotes(gunaTextBox20.Text) + "',task='" + quotes(gunaComboBox1.Text) + "',username='" + quotes(gunaTextBox19.Text) + "',password='" + quotes(gunaTextBox18.Text) + "',ido='" + quotes(gunaLabel18.Text) + "' where ido='" + quotes(gunaLabel18.Text) + "'";
                            cmd.ExecuteNonQuery();
                            con.Close(); ido(); users();
                            MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            usero();
                        }
                        else
                        {
                            usero();
                            MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous ajouter?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into login(name,task,username,password,ido) values ('" + quotes(gunaTextBox20.Text) + "','" + quotes(gunaComboBox1.Text) + "','" + quotes(gunaTextBox19.Text) + "','" + quotes(gunaTextBox18.Text) + "','" + quotes(gunaLabel17.Text) + "')";
                            cmd.ExecuteNonQuery();
                            con.Close(); ido(); users();
                            MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            usero();
                        }
                        else
                        {
                            usero();
                            MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, VEUILLEZ VERIFIER VOS PARAMETRES", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void usero()
        {
            gunaTextBox20.Text = ""; gunaComboBox1.Text = ""; gunaTextBox18.Text = ""; gunaTextBox19.Text = ""; gunaLabel18.Text = "";
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gunaLabel18.Text = metroGrid1.CurrentRow.Cells["NO"].Value.ToString();
                gunaTextBox20.Text = metroGrid1.CurrentRow.Cells["Nom complet"].Value.ToString();
                gunaComboBox1.Text = metroGrid1.CurrentRow.Cells["Tache"].Value.ToString();
                gunaTextBox19.Text = metroGrid1.CurrentRow.Cells["Nom utilisateur"].Value.ToString();
                gunaTextBox18.Text = metroGrid1.CurrentRow.Cells["Password"].Value.ToString();
            }
            catch (Exception)
            {
                gunaLabel18.Text = ""; gunaTextBox20.Text = ""; gunaComboBox1.Text = ""; gunaTextBox19.Text = ""; gunaTextBox18.Text = "";
            }
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox20.Text == string.Empty)
                {
                    gunaCircleButton5.Visible = true;
                }
                else if (gunaComboBox1.Text == string.Empty)
                {
                    gunaCircleButton5.Visible = false;
                    gunaCircleButton6.Visible = true;
                }

                else if (gunaTextBox19.Text == string.Empty)
                {
                    gunaCircleButton11.Visible = false;
                    gunaCircleButton4.Visible = true;
                }
                else if (gunaTextBox18.Text == string.Empty)
                {
                    gunaCircleButton4.Visible = false;
                    gunaCircleButton3.Visible = true;
                }
                else
                {
                    gunaCircleButton3.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from login where ido='" + quotes(gunaLabel18.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous supprimer?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "delete from login where ido='" + quotes(gunaLabel18.Text) + "'";
                            cmd.ExecuteNonQuery();
                            con.Close(); ido(); users();
                            MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            usero();
                        }
                        else
                        {
                            usero();
                            MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "wwwwwwwwwwwww", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, VERIFIEZ VOS PARAMETRES", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaAdvenceButton13_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox5.Text == string.Empty)
                {
                    gunaCircleButton10.Visible = true;
                }
                else
                {
                    gunaCircleButton10.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from category where Category='" + quotes(gunaTextBox5.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "cette bande passante existe déjà", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into category(Category) values ('" + quotes(gunaTextBox5.Text) + "')";
                        cmd.ExecuteNonQuery();
                        con.Close(); categ(); catg();
                        MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gunaTextBox5.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, opération non réussie", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaAdvenceButton10_Click(object sender, EventArgs e)
        {
        }
        private void clso()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select description as 'DESCRIPTION' from description";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid2.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {
            }
        }
       
        private void categ()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select category as 'BANDE PASSANTE' from category";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid3.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {
            }
        }

        private void gunaAdvenceButton11_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox4.Text == string.Empty)
                {
                    gunaCircleButton7.Visible = true;
                }
                else
                {
                    gunaCircleButton7.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from description where description='" + quotes(gunaTextBox4.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from description where description='" + quotes(gunaTextBox4.Text) + "'";
                        cmd.ExecuteNonQuery();
                        con.Close(); clso(); empl();
                        MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gunaTextBox4.Text = "";
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Le numero n'existe pas", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Aucun accès à Internet. ERR_INTERNET_DISCONNECTED", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaAdvenceButton12_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaTextBox5.Text == string.Empty)
                {
                    gunaCircleButton10.Visible = true;
                }
                else
                {
                    gunaCircleButton10.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from category where Category='" + quotes(gunaTextBox5.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from category where Category='" + quotes(gunaTextBox5.Text) + "'";
                        cmd.ExecuteNonQuery();
                        con.Close(); categ(); catg();
                        MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gunaTextBox5.Text = "";
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Le category n'existe pas", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Aucun accès à Internet. ERR_INTERNET_DISCONNECTED", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroGrid3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gunaTextBox5.Text = metroGrid3.CurrentRow.Cells["BANDE PASSANTE"].Value.ToString();
            }
            catch (Exception)
            {
                gunaTextBox5.Text = "";
            }
        }

        private void gunaAdvenceButton16_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaComboBox7.Text == string.Empty)
                {
                    gunaCircleButton20.Visible = true;
                }
                else
                {
                    gunaCircleButton20.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from produit where category='" + quotes(gunaComboBox7.Text) + "' and produit='" + quotes(gunaTextBox1.Text) + "' and Prix = '" + quotes(gunaTextBox8.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous modifier?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update produit set category='" + quotes(gunaComboBox7.Text) + "',produit='" + quotes(gunaTextBox1.Text) + "',Prix='" + quotes(gunaTextBox8.Text) + "', NO='" + quotes(gunaLabel14.Text) + "' where NO='" + quotes(gunaLabel14.Text) + "'";
                            cmd.ExecuteNonQuery();
                            con.Close(); prod(); kitu();
                            MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gunaComboBox7.Text = ""; gunaLabel14.Text = ""; gunaTextBox1.Text = ""; gunaTextBox8.Text = "";
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Operation annulee", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into produit(category,produit,Prix,NO) values ('" + quotes(gunaComboBox7.Text) + "','" + quotes(gunaTextBox1.Text) + "','" + quotes(gunaTextBox8.Text) + "','" + quotes(gunaLabel9.Text) + "')";
                        cmd.ExecuteNonQuery();
                        con.Close(); prod(); NO(); kitu();
                        MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gunaComboBox7.Text = ""; gunaLabel14.Text = ""; gunaTextBox1.Text = ""; gunaTextBox8.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, VERIFIEZ LES PARAMETRES DE LA BASE DES DONNEES", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void NO()
        {
            try
            {
                string num = "1K223344556677889900A";
                int len = num.Length;
                string opt = string.Empty;
                int optdigit = 5;
                string final;
                int getindex;
                for (int i = 0; i < optdigit; i++)
                {
                    do
                    {
                        getindex = new Random().Next(0, len);
                        final = num.ToCharArray()[getindex].ToString();
                    }
                    while (opt.IndexOf(final) != -1);
                    opt += final;
                }
                gunaLabel9.Text = (opt);
            }
            catch (Exception)
            { }
        }
        public void searcho(string gunaTextBox3)
        {
            try
            {
                string searchQuery = "select NO as 'NO', category as 'BANDE PASSANTE', produit as 'CONNEXION', Prix as 'PRIX en BIF' from produit where CONCAT(category,produit, Prix) LIKE '%" + gunaTextBox3 + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(searchQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid4.DataSource = dt;
                con.Close();
                int counto = metroGrid4.RowCount;
                double countN = counto - 1;
                gunaLabel16.Text = countN.ToString();
            }
            catch (Exception)
            { }
        }

        private void gunaAdvenceButton15_Click(object sender, EventArgs e)
        {
            try
            {
                if (gunaComboBox7.Text == string.Empty)
                {
                    gunaCircleButton20.Visible = true;
                }
                else
                {
                    gunaCircleButton20.Visible = false;
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from produit where NO='" + quotes(gunaLabel14.Text) + "' and produit='" + quotes(gunaTextBox1.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from produit where NO='" + quotes(gunaLabel14.Text) + "'";
                        cmd.ExecuteNonQuery();
                        con.Close(); prod();
                        MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gunaComboBox7.Text = ""; gunaLabel14.Text = ""; gunaTextBox1.Text = "";
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Desoler, le produit n'existe pas", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Aucun accès à Internet. ERR_INTERNET_DISCONNECTED", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void gunaAdvenceButton14_Click(object sender, EventArgs e)
        {

        }
        private void prod()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select NO as 'NO', category as 'BANDE PASSANTE', produit as 'CONNEXION', Prix as 'PRIX en BIF' from produit";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid4.DataSource = dt;
                con.Close();
                int counto = metroGrid4.RowCount;
                double countN = counto - 1;
                gunaLabel16.Text = countN.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void metroGrid4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gunaLabel14.Text = metroGrid4.CurrentRow.Cells["NO"].Value.ToString();
                gunaComboBox7.Text = metroGrid4.CurrentRow.Cells["BANDE PASSANTE"].Value.ToString();
                gunaTextBox1.Text = metroGrid4.CurrentRow.Cells["CONNEXION"].Value.ToString();
                gunaTextBox8.Text = metroGrid4.CurrentRow.Cells["PRIX en BIF"].Value.ToString();
            }
            catch (Exception)
            {
                gunaComboBox7.Text = ""; gunaLabel14.Text = ""; gunaTextBox1.Text = ""; gunaTextBox8.Text = "";
            }
        }

        private void gunaAdvenceButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton19_Click(object sender, EventArgs e)
        {
           
        }
        

        private void gunaAdvenceButton20_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaCircleButton13_Click(object sender, EventArgs e)
        {
            try
            {
                using (var waitform = new loarding(wait1))
                {
                    waitform.ShowDialog(this);
                }
                classo();
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Aucun accès à Internet. ERR_INTERNET_DISCONNECTED", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaCircleButton12_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton18_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceButton17_Click(object sender, EventArgs e)
        {
            
        }

        private void metroGrid5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            try
            {
                gunaLabel28.Text = metroGrid5.CurrentRow.Cells["ID"].Value.ToString();
                gunaComboBox3.Text = metroGrid5.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
                gunaTextBox2.Text = metroGrid5.CurrentRow.Cells["PRIX en BIF"].Value.ToString();
                gunaTextBox9.Text = metroGrid5.CurrentRow.Cells["CLIENT"].Value.ToString();
                gunaDateTimePicker1.Text = metroGrid5.CurrentRow.Cells["DATE ABONNEMENT"].Value.ToString();
                gunaDateTimePicker2.Text = metroGrid5.CurrentRow.Cells["DATE EXPIRATION"].Value.ToString();
                gunaComboBox4.Text = metroGrid5.CurrentRow.Cells["MODE PAIEMENT"].Value.ToString();
            }
            catch (Exception)
            {
                gunaComboBox12.Text = ""; gunaComboBox3.Text = ""; gunaTextBox2.Text = ""; gunaDateTimePicker1.Text = ""; gunaComboBox4.Text = "";
            } 
        }

        private void gunaAdvenceButton24_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceButton23_Click(object sender, EventArgs e)
        {
           
        }    

        private void gunaAdvenceButton22_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton27_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton26_Click(object sender, EventArgs e)
        {
            
        }

        private void metroGrid6_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        
        private void gunaAdvenceButton25_Click(object sender, EventArgs e)
        {

        }
  
       
        private void gunaCircleButton22_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaLabel37_TextChanged(object sender, EventArgs e)
        {

        }      
        private void gunaTextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton30_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaCircleButton26_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton28_Click(object sender, EventArgs e)
        {
            
        }

        private void metroGrid7_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void gunaTextBox13_TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private void gunaAdvenceButton29_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaTextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gunaGradient2Panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaTextBox15_TextChanged(object sender, EventArgs e)
        {

        }
        private void mat()
        {
            try
            {
                string num = "1K223344556677889900A";
                int len = num.Length;
                string opt = string.Empty;
                int optdigit = 4;
                string final;
                int getindex;
                for (int i = 0; i < optdigit; i++)
                {
                    do
                    {
                        getindex = new Random().Next(0, len);
                        final = num.ToCharArray()[getindex].ToString();
                    }
                    while (opt.IndexOf(final) != -1);
                    opt += final;
                }
                //gunaLabel51.Text = (opt);
            }
            catch (Exception)
            { }
        }
        
        private void gunaLabel51_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton31_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton33_Click(object sender, EventArgs e)
        {
            try
            {
               
                    using (var waitform = new loarding(wait1))
                    {
                        waitform.ShowDialog(this);
                    }
                    String SelectQuery = "Select * from commande where id='" + quotes(gunaLabel28.Text) + "'";
                    MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous modifier commande?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                           
                           
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "update commande set Connexion='" + quotes(gunaComboBox12.Text) + "',Description='" + quotes(gunaComboBox3.Text) + "',Prix='" + quotes(gunaTextBox2.Text) + "',Client='" + quotes(gunaTextBox9.Text) + "',Abonnement='" + quotes(gunaDateTimePicker1.Text) + "',Expiration='" + quotes(gunaDateTimePicker2.Text) + "',Paiement='" + quotes(gunaComboBox4.Text) + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();  prodnow(); pd(); pn(); cd();
                                MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                gunaLabel34.Text = ""; gunaLabel33.Text = ""; gunaComboBox12.Text = ""; gunaComboBox12.Text = ""; gunaComboBox3.Text = ""; gunaTextBox2.Text = ""; gunaComboBox4.Text = ""; gunaDateTimePicker1.Text = ""; gunaTextBox9.Text = "";

                    }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gunaLabel34.Text = ""; gunaLabel33.Text = ""; gunaComboBox12.Text = ""; gunaComboBox12.Text = ""; gunaComboBox3.Text = ""; gunaTextBox2.Text = ""; gunaComboBox4.Text = ""; gunaDateTimePicker1.Text = ""; gunaTextBox9.Text = "";
                    }
                    }
                    else
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez-vous enregistrer la commande?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            
                              
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "insert into commande(Connexion,Description,Prix,Client,Abonnement,Expiration,Paiement) values ('" + quotes(gunaComboBox12.Text) + "','" + quotes(gunaComboBox3.Text) + "','" + quotes(gunaTextBox2.Text) + "','" + quotes(gunaTextBox9.Text) + "','" + quotes(gunaDateTimePicker1.Text) + "','" + quotes(gunaDateTimePicker2.Text) + "','" + quotes(gunaComboBox4.Text) + "')";
                                cmd.ExecuteNonQuery();
                                con.Close(); newstock(); prodnow();
                                MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gunaLabel34.Text = ""; gunaLabel33.Text = ""; gunaComboBox12.Text = ""; gunaComboBox12.Text = ""; gunaComboBox3.Text = ""; gunaTextBox2.Text = ""; gunaComboBox4.Text = ""; gunaDateTimePicker1.Text = ""; gunaTextBox9.Text = "";


                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gunaLabel34.Text = ""; gunaLabel33.Text = ""; gunaComboBox12.Text = ""; gunaComboBox12.Text = ""; gunaComboBox3.Text = ""; gunaTextBox2.Text = ""; gunaComboBox4.Text = ""; gunaDateTimePicker1.Text = ""; gunaTextBox9.Text = "";
                    }
                    }
                
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erreur, Vérifiez les paramètres de la base des données", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void newstock()
        {
            //try
            //{
            //    string newst = "En cours";
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "insert into newstock(NO,produit,Qte,dato,etat) values ('" + quotes(gunaLabel34.Text) + "','" + quotes(gunaComboBox12.Text) + "','" + quotes(gunaTextBox24.Text) + "'et,'" + quotes(newst) + "')";
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (Exception)
            //{ }
        }

        private void metroGrid8_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gunaLabel14.Text = metroGrid8.CurrentRow.Cells["NO"].Value.ToString();
                gunaComboBox3.Text = metroGrid8.CurrentRow.Cells["BANDE PASSANTE"].Value.ToString();
                gunaComboBox12.Text = metroGrid8.CurrentRow.Cells["CONNEXION"].Value.ToString();
                gunaTextBox2.Text = metroGrid8.CurrentRow.Cells["PRIX en BIF"].Value.ToString();
            }
            catch (Exception)
            {
                gunaComboBox3.Text = ""; gunaLabel14.Text = ""; gunaComboBox12.Text = ""; gunaTextBox2.Text = "";
            }
        }

        private void gunaAdvenceButton31_Click(object sender, EventArgs e)
        {
            
        }
        private void prodnow()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select NO as 'NO', category as 'BANDE PASSANTE', produit as 'CONNEXION', Prix as 'PRIX en BIF' from produit";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid8.DataSource = dt;
                con.Close();
                int counto = metroGrid4.RowCount;
                double countN = counto - 1;
                gunaLabel16.Text = countN.ToString();
            }
            catch (Exception)
            {
            }
        }
        public void Produi(string gunaTextBox7)
        {
            try
            {
                string searchQuery = "select NO as 'NO', category as 'BANDE PASSANTE', produit as 'CONNEXION', Prix as 'PRIX en BIF' from produit where CONCAT(category,produit, Prix) LIKE '%" + gunaTextBox7 + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(searchQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid8.DataSource = dt;
                con.Close();
                int counto = metroGrid8.RowCount;
               double countN = counto - 1;
                gunaLabel54.Text = countN.ToString();
            }
            catch (Exception)
            { }
        }
        public void com(String gunaTextBox10)
        {
            try
            {
                string searchQuery = "select id as 'ID', Connexion as 'CONNEXION', Description as 'DESCRIPTION', Prix as 'PRIX en BIF',Client as 'CLIENT', Abonnement as 'DATE ABONNEMENT', Expiration as 'DATE EXPIRATION', Paiement as 'MODE PAIEMENT' from commande where CONCAT(Connexion,Prix, Client, Abonnement, Expiration, Paiement) LIKE '%" + gunaTextBox10 + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(searchQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid5.DataSource = dt;
                con.Close();
                int counto = metroGrid8.RowCount;
                double countN = counto - 1;
                gunaLabel54.Text = countN.ToString();
            }
            catch (Exception)
            { }
        }

       
        private void gunaAdvenceButton32_Click(object sender, EventArgs e)
        {
            try
            {
                
                 
                     using (var waitform = new loarding(wait1))
                     {
                         waitform.ShowDialog(this);
                     }
                     String SelectQuery = "Select * from commande where id='" + quotes(gunaLabel28.Text) + "'";
                     MySqlCommand cmd1 = new MySqlCommand(SelectQuery, con);
                     DataTable dt = new DataTable();
                     MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
                     da.Fill(dt);
                     int i = Convert.ToInt32(dt.Rows.Count.ToString());
                     if (i == 1)
                     {
                        if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous supprimer cette commande ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "delete from commande where id='" + quotes(gunaLabel28.Text) + "'";
                            cmd.ExecuteNonQuery();
                            con.Close(); newstockdel(); prodnow(); pd(); pn(); cd();
                            MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gunaLabel34.Text = ""; gunaLabel33.Text = ""; gunaComboBox12.Text = ""; gunaTextBox9.Text = ""; gunaTextBox8.Text = ""; gunaTextBox9.Text = "";
                        }
                        else
                        {
                           MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gunaLabel34.Text = ""; gunaLabel33.Text = ""; gunaComboBox12.Text = ""; gunaTextBox9.Text = ""; gunaTextBox8.Text = ""; gunaTextBox9.Text = "";
                      }
                   }
                  else
                  {
                        
                    }
                
            }
            catch (Exception)
            {
               MetroFramework.MetroMessageBox.Show(this, "ERREUR, VERIFIEZ VOS PARAMETRES", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void newstockdel()
        {
            //try
            //{
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "delete from newstock where NO='" + quotes(gunaLabel34.Text) + "'";
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (Exception)
            //{ }
        }

        private void gunaGradient2Panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton35_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton36_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton34_Click(object sender, EventArgs e)
        {
            
        }

        //private void metroGrid9_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    try
        //    {
        //        gunaTextBox11.Text = metroGrid9.CurrentRow.Cells["CLIENT"].Value.ToString();
        //        gunaTextBox2.Text = metroGrid9.CurrentRow.Cells["PRODUIT"].Value.ToString();
        //        gunaTextBox13.Text = metroGrid9.CurrentRow.Cells["QUANTITE"].Value.ToString();
        //       // gunaTextBox12.Text = metroGrid9.CurrentRow.Cells["NO"].Value.ToString();
        //    }
        //    catch (Exception)
        //    {
                
        //    }
        //}

        private void gunaAdvenceButton35_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaCircleButton38_Click(object sender, EventArgs e)
        {
            
        }
        private void pd()
        {
            //try
            //{
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandText = "select produit as 'PRODUIT',reste as 'QUANTITE DISPONIBLE' from magasin";
            //    cmd.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //    da.Fill(dt);
            //   // metroGrid11.DataSource = dt;
            //    con.Close();
            //}
            //catch (Exception)
            //{
            //}
        }
        private void pn()
        {
            //try
            //{
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandText = "select Client as 'CLIENT',Produit as 'PRODUIT',Quantité as 'QUANTITE' from panier";
            //    cmd.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //    da.Fill(dt);
            //  //  metroGrid9.DataSource = dt;
            //    con.Close();
            //}
            //catch (Exception)
            //{
            //}
        }

        private void cd()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select id as 'ID', Connexion as 'CONNEXION', Description as 'DESCRIPTION', Prix as 'PRIX en BIF',Client as 'CLIENT', Abonnement as 'DATE ABONNEMENT', Expiration as 'DATE EXPIRATION', Paiement as 'MODE PAIEMENT' from commande";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                metroGrid5.DataSource = dt;
                con.Close();
                int counto = metroGrid5.RowCount;
                double countN = counto - 1;
                gunaLabel16.Text = countN.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void gunaCircleButton37_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaCircleButton41_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton39_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton37_Click(object sender, EventArgs e)
        {
           
        }

        private void metroGrid11_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
               
                //gunaTextBox2.Text = metroGrid11.CurrentRow.Cells["PRODUIT"].Value.ToString();
                //gunaTextBox12.Text = metroGrid11.CurrentRow.Cells["QUANTITE DISPONIBLE"].Value.ToString();
              
            }
            catch (Exception)
            {
                
            }
        }
     

        private void gunaCircleButton43_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceButton40_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaAdvenceButton37_Click_1(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceButton39_Click_1(object sender, EventArgs e)
        {
            
        }
        

        private void gunaAdvenceButton38_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaLabel74_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaTextBox20_TextChanged(object sender, EventArgs e)
        {
            if (gunaTextBox20.Text == string.Empty)
            {
                gunaCircleButton5.Visible = true;
            }
            else if (gunaComboBox1.Text == string.Empty)
            {
                gunaCircleButton5.Visible = false;
                gunaCircleButton6.Visible = true;
            }

            else if (gunaTextBox19.Text == string.Empty)
            {
                gunaCircleButton11.Visible = false;
                gunaCircleButton4.Visible = true;
            }
            else if (gunaTextBox18.Text == string.Empty)
            {
                gunaCircleButton4.Visible = false;
                gunaCircleButton3.Visible = true;
            }
            else
            {
                gunaCircleButton3.Visible = false;
            }
        }

        private void gunaTextBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (gunaTextBox4.Text == string.Empty)
            {
                gunaCircleButton7.Visible = true;
            }
            else
            {
                gunaCircleButton7.Visible = false;
            }
        }

        private void gunaTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (gunaTextBox5.Text == string.Empty)
            {
                gunaCircleButton10.Visible = true;
            }
            else
            {
                gunaCircleButton10.Visible = false;
            }
        }

        private void gunaComboBox7_TextChanged(object sender, EventArgs e)
        {
            if (gunaComboBox7.Text == string.Empty)
            {
                gunaCircleButton20.Visible = true;
            }
            else
            {
                gunaCircleButton20.Visible = false;
            }
        }

        private void gunaComboBox5_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void gunaComboBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaComboBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaTextBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox23_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {
            searcho(gunaTextBox3.Text);
        }
        private void sho()
        {
            //try
            //{
            //    String SelectQuery = "Select * from magasin where produit='" + quotes(gunaComboBox12.Text) + "'";
            //    MySqlCommand cmd = new MySqlCommand(SelectQuery, con);
            //    DataTable dt = new DataTable();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //    da.Fill(dt);
            //    int i = Convert.ToInt32(dt.Rows.Count.ToString());
            //    if (i == 1)
            //    {
            //        gunaLabel32.Text = dt.Rows[0][1].ToString();
            //        gunaComboBox3.Text = dt.Rows[0][7].ToString();
            //        gunaTextBox6.Text = dt.Rows[0][4].ToString();
            //        gunaTextBox8.Text = dt.Rows[0][5].ToString();
            //        gunaTextBox9.Text = dt.Rows[0][6].ToString();
            //        da.Dispose();
            //    }
            //    else
            //    {
            //        gunaLabel32.Text = ""; gunaTextBox3.Text = ""; gunaTextBox6.Text = ""; gunaTextBox8.Text = ""; gunaTextBox9.Text = ""; gunaComboBox3.Text = "";
            //        //MetroFramework.MetroMessageBox.Show(this, "Le produit n'existe pas.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        private void shoview()
        {
            //try
            //{
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandText = "NO as 'NO',categorie as 'CATEGORIE',produit as 'PRODUIT',stock as 'STOCK',vendre as 'ACHAT',reste as 'REST EN STOCK',shift as 'EMPLACEMENT' from magasin where produit='" + quotes(gunaComboBox12.Text) + "'";
            //    cmd.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //    da.Fill(dt);
            //    metroGrid8.DataSource = dt;
            //    con.Close();
            //    int counto = metroGrid8.RowCount;
            //    double countN = counto - 1;
            //    gunaLabel54.Text = countN.ToString();
            //}
            //catch (Exception)
            //{
            //}
        }
        private void kitu()
        {
            try
            {
                gunaComboBox12.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM produit";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gunaComboBox12.Items.Add(dr["produit"]);
                }
                con.Close(); dr.Dispose();
            }
            catch (Exception)
            {
            }
        }

        private void catg()
        {
            try
            {
                gunaComboBox7.Items.Clear();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM category";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gunaComboBox7.Items.Add(dr["category"]);
                }
                con.Close(); dr.Dispose();
            }
            catch (Exception)
            {
            }
        }
        private void gunaComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(gunaComboBox12.Text != string.Empty)
                {
                    String SelectQuery = "Select * from produit where produit='" + quotes(gunaComboBox12.Text) + "'";
                    MySqlCommand cmd = new MySqlCommand(SelectQuery, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    int i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 1)
                    {
                        gunaLabel33.Text = dt.Rows[0][1].ToString();
                        gunaLabel34.Text = dt.Rows[0][3].ToString();
                        da.Dispose(); sho(); shoview();
                        gunaTextBox7.Text = gunaComboBox12.Text;
                    }
                    else
                    {
                        gunaLabel33.Text = ""; gunaLabel34.Text = "";
                        MetroFramework.MetroMessageBox.Show(this, "Ce Bouquet n'existe pas.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                   
                }
                else
                {
                    
                }
            }
            catch (Exception)
            {

            }
        }

        private void gunaTextBox7_TextChanged(object sender, EventArgs e)
        {
            Produi(gunaTextBox7.Text);
        }
        private void cal()
        {
            //try
            //{
            //    if(gunaTextBox24.Text == string.Empty)
            //    {
                    
            //    }
            //    else if(gunaTextBox6.Text == string.Empty)
            //    {

            //    }
            //    else
            //    {
            //        double old, news, by;
            //        old = Convert.ToDouble(gunaTextBox6.Text);
            //        news = Convert.ToDouble(gunaTextBox24.Text);
            //        by = Convert.ToDouble(gunaTextBox8.Text);
            //        double newsto = old + news;
            //        gunaTextBox10.Text = newsto.ToString();
            //        double restost = newsto - by;
            //        gunaTextBox9.Text = restost.ToString();

            //    }
            //}
            //catch(Exception)
            //{ }
        }

        private void gunaTextBox6_TextChanged_1(object sender, EventArgs e)
        {
            //if(gunaTextBox24.Text == string.Empty)
            //{
            //    gunaTextBox9.Text = gunaTextBox6.Text;
            //    gunaTextBox10.Text = gunaTextBox6.Text;
            //}
            //cal();
        }

        private void gunaTextBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gunaGradient2Panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel66_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    con.Open();
            //    cmd.Connection = con;
            //    cmd.CommandText = "select produit as 'PRODUIT',Qte as 'QUANTITE',dato as 'DATE',etat as 'ETAT' from newstock where NO='" + quotes(gunaLabel66.Text) + "'";
            //    cmd.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //    da.Fill(dt);
            //    metroGrid9.DataSource = dt;
            //    con.Close();
            //    int counto = metroGrid9.RowCount;
            //    double countN = counto - 1;
            //    gunaLabel58.Text = countN.ToString();
            //}
            //catch (Exception)
            //{ }
        }

        private void gunaCircleButton28_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaGradient2Panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            logino lg = new logino();
            lg.Show();
        }

        private void gunaLabel19_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel26_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel71_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void metroGrid9_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
            
            //try
            //{
        
            //            if (MetroFramework.MetroMessageBox.Show(this, "Voulez vous ajouter ce produit au panier?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                con.Open();
            //                cmd.Connection = con;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.CommandText = "insert into panier(Client,Produit,Quantité) values ('" + quotes(gunaTextBox11.Text) + "','" + quotes(gunaTextBox2.Text) + "','" + quotes(gunaTextBox13.Text) + "')";
            //                cmd.ExecuteNonQuery();
            //                con.Close(); pn();
            //                MetroFramework.MetroMessageBox.Show(this, "Operation avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //               // usero();
            //            }
            //            else
            //            {
            //             //   usero();
            //                MetroFramework.MetroMessageBox.Show(this, "Operation annulée", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
                  
                
            //}
            //catch (Exception)
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "Erreur, VERIFIEZ LES PARAMETRES DE LA BASE DES DONNEES", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            
        }

        private void gunaTextBox10_TextChanged(object sender, EventArgs e)
        {
           com(gunaTextBox10.Text);
        }
    }
}
