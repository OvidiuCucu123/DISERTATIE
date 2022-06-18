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
            string interogare = "SELECT AngajatID FROM AngajatiTbl WHERE Nume='" + AngajatIdTb.Text + "';";
            SqlDataAdapter sda = new SqlDataAdapter(interogare, ConexiuneBaza);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            //var ds = new DataSet();
            //sda.Fill(ds);
            //AfisareID.DataSource = ds.Tables[0];
            
            ConexiuneBaza.Close();
        }
        
        private void CalculSalariu()
        {
            int salariulbrut = 0, salariulnet=0, orelucrate=0, sporuri=0, zileconcediu=0, concediu=0, prime=0, altebonusuri=0, alteretineri=0, restdeplata=0;
            salariulbrut = Convert.ToInt32(SalariulBrutTb.Text);
            orelucrate = Convert.ToInt32(OreLucrateTb.Text);
            sporuri = Convert.ToInt32(SporuriTb.Text);
            zileconcediu = Convert.ToInt32(ConcediuTb.Text);
            prime = Convert.ToInt32(PrimeTb.Text);
            altebonusuri = Convert.ToInt32(AlteBonusuriTb.Text);
            alteretineri = Convert.ToInt32(AlteRetineriTb.Text);
            
            if (zileconcediu == 0)
                concediu = 0;
            else concediu = zileconcediu * 150;
            
            if (orelucrate == 0)
                salariulbrut = 0;
            else if (orelucrate == 100) 
                salariulbrut = salariulbrut + concediu + sporuri + prime + altebonusuri - alteretineri;
            else
                salariulbrut = (orelucrate/100*salariulbrut) + concediu + sporuri + prime + altebonusuri - alteretineri;

            salariulnet = salariulbrut - (25 / 100 * salariulbrut);
            raport.Text = "salariu" + salariulbrut.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            afisare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AngajatIdTb.Text == "" || SalariulBrutTb.Text == "" || OreLucrateTb.Text == "" || SporuriTb.Text == "" || ConcediuTb.Text == "")
            {
                MessageBox.Show("Date insuficiente");
            }
            else
            {
                using (SqlCommand Adaugare = new SqlCommand())
                {
                    Adaugare.Connection = ConexiuneBaza;
                    Adaugare.CommandType = CommandType.Text;
                    Adaugare.CommandText = "INSERT into SalariiTbl (AngajatID, SalariulBrut, OreLucrate, Sporuri, Concediu, Prime, AlteBonusuri, AlteRetineri) VALUES (@AngajatIdTb, @SalariulBrutTb, @OreLucrateTb, @SporuriTb, @ConcediuTb, @PrimeTb, @AlteBonusuriTb, @AlteRetineriTb)";

                    Adaugare.Parameters.AddWithValue("@AngajatIdTb", AngajatIdTb.Text);
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
                        CalculSalariu();
                        //AfisareCalculSalariu();
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
