using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GESTIUNEANGAJATI
{
    public partial class Salarii : Form
    {
        public Salarii()
        {
            InitializeComponent();
        }
        SqlConnection ConexiuneBaza = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ovidiu\Documents\Angajati.mdf;Integrated Security=True;Connect Timeout=30");
        private void afisare()
        {
            ConexiuneBaza.Open();
            string interogare = "SELECT AngajatID FROM AngajatiTbl WHERE Nume='" + CautaNume.Text + "';";
            SqlDataAdapter sda = new SqlDataAdapter(interogare, ConexiuneBaza);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AfisNume.DataSource = ds.Tables[0];
            ConexiuneBaza.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            afisare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SalariulBrut.Text == "" || OreLucrate.Text == "" || Sporuri.Text == "" || Concediu.Text == "")
            {
                MessageBox.Show("Toate campurile sunt obligatorii");
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
