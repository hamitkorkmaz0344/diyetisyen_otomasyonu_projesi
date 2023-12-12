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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        OleDbConnection con ;
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre=textBox2.Text;
            con=new OleDbConnection("Provider=Microsoft.ACE.oledb.12.0;Data Source=diyetisyen.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText="SELECT*FROM login where adsoyad='"+textBox1.Text + "' AND sifre= '" +textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read() )
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
    }
}
