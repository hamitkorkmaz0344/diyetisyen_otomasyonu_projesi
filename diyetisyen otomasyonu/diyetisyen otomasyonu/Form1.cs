using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace diyetisyen_otomasyonu
{
    public partial class Form1 : Form
    {
        string baglantı = "Provider=Microsoft.ACE.oledb.12.0;Data Source=diyetisyen.accdb";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.textBox1 != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.textBox1;
                textBox2.Text = Properties.Settings.Default.textBox2;
            }
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;
            con = new OleDbConnection(baglantı);
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT*FROM login where adsoyad='" + textBox1.Text + "' AND sifre= '" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("bilgileriniz hatalı tekrar deneyiniz");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)

        {
            if (checkBox2.Checked)
            {
                Properties.Settings.Default.textBox1 = textBox1.Text;
                Properties.Settings.Default.textBox2 = textBox2.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void Şifremi_unuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        string sifre;

        private void button3_Click(object sender, EventArgs e)
        {


            using (OleDbConnection con = new OleDbConnection(baglantı))
            {
                con.Open();
                string tc = txt_tcNo.Text;
                string sorgu = $"SELECT sifre FROM login WHERE tc = '{tc}'";
                using (OleDbCommand cmd = new OleDbCommand(sorgu, con))
                {
                  //  cmd.Parameters.AddWithValue("@tc", tc);
                    using (OleDbDataReader oku = cmd.ExecuteReader())
                    {
                        if (oku.Read())
                        {
                            sifre = oku["sifre"].ToString();
                            MessageBox.Show("SİFRENİZ " + sifre);
                        }
                        else
                        {
                            MessageBox.Show(" HATA");
                        }
                        
                    }
                }
            }
        }

        private void sifregir_TextChanged(object sender, EventArgs e)
        {
            sifregir.Visible = false;
        }
    }
}
