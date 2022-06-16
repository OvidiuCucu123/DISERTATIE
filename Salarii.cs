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
        SqlConnection ConexiuneBaza = new SqlConnection(@"Server=tcp:gestionareangajati.database.windows.net,1433;Initial Catalog=gestionareangajati;Persist Security Info=False;User ID=Ovidiu;Password=Gioada69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            if (SalariulBrutTb.Text == "" || OreLucrateTb.Text == "" || SporuriTb.Text == "" || ConcediuTb.Text == "")
            {
                MessageBox.Show("Date insuficiente");
            }
            else
            {
                using (SqlCommand Adaugare = new SqlCommand())
                {
                    Adaugare.Connection = ConexiuneBaza;
                    Adaugare.CommandType = CommandType.Text;
                    Adaugare.CommandText = "INSERT into Table (SalariulBrut, OreLucrate, Sporuri, Concediu, Prime, AlteBonusuri, AlteRetineri) VALUES (@SalariulBrutTb, @OreLucrateTb, @SporuriTb, @ConcediuTb, @PrimeTb, @AlteBonusuriTb, @AlteRetineriTb)";
                 
                    Adaugare.Parameters.AddWithValue("@SalariulBrutTb", SalariulBrutTb.Text);
                    Adaugare.Parameters.AddWithValue("@OreLucrateTb", OreLucrateTb.Text);
                    Adaugare.Parameters.AddWithValue("@SporuriTb", SporuriTb.Text);
                    Adaugare.Parameters.AddWithValue("@ConcediuTb", ConcediuTb.Text);
                    Adaugare.Parameters.AddWithValue("@PrimeTb", PrimeTb.Text);
                    Adaugare.Parameters.AddWithValue("@AlteBonusuriTb", AlteBonusuriTb.Text);
                    Adaugare.Parameters.AddWithValue("@AlteRetineriTb", AlteRetineriTb.Text);
                    try
                    {
                        ConexiuneBaza.Open();
                        Adaugare.ExecuteNonQuery();
                        ConexiuneBaza.Close();
                        MessageBox.Show("Angajatul a fost introdus");
                        //afisare();
                        //ResetareCampuri();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
