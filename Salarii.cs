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
        private void AfisareNume()
        {
            using (SqlCommand Afisare = new SqlCommand())
            {
                Afisare.Connection = ConexiuneBaza;
                Afisare.CommandType = CommandType.Text;
                Afisare.CommandText = "SELECT Nume FROM AngajatiTbl WHERE AngajatId='" + AngajatIdTb.Text + "';";
                Afisare.Parameters.AddWithValue("@AngajatIdTb", AngajatIdTb.Text);              
                try {  
                    ConexiuneBaza.Open();
                    var a = Afisare.ExecuteScalar();
                    ConexiuneBaza.Close();
                    DatePers.Text = a.ToString();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        
        private void CalculSalariu()
        {
            double salariulbrut, salariulnet=0, orelucrate, sporuri, zileconcediu, concediu=0, 
            prime, altebonusuri, alteretineri, restdeplata=0, persoaneintretinere, deducere=0, impozitsalariu=0, contributii=0;
            salariulbrut = Convert.ToDouble(SalariulBrutTb.Text);
            orelucrate = Convert.ToDouble(OreLucrateTb.Text);
            sporuri = Convert.ToDouble(SporuriTb.Text);
            zileconcediu = Convert.ToDouble(ConcediuTb.Text);
            prime = Convert.ToDouble(PrimeTb.Text);
            altebonusuri = Convert.ToDouble(AlteBonusuriTb.Text);
            alteretineri = Convert.ToDouble(AlteRetineriTb.Text);
            persoaneintretinere = Convert.ToDouble(PersoaneIntretinereCb.Text);

            switch (persoaneintretinere)
            {
                case 1: deducere = 350 * (1 - ((salariulbrut - 1000) / 2000))*6; break;
                case 2:
                    deducere = 450 * (1 - ((salariulbrut - 1000) / 2000))*6;
                    break;
                case 3:
                    deducere = 550 * (1 - ((salariulbrut - 1000) / 2000))*6;
                    break;
                case 4:
                    deducere = 650 * (1 - ((salariulbrut - 1000) / 2000))*6;
                    break;
                default:
                    deducere = 250 * (1 - ((salariulbrut - 1000) / 2000))*6;
                    break;
            }

            if (zileconcediu == 0)
                concediu = 0;
            else concediu = zileconcediu * 150;

            if (orelucrate == 0)
                salariulbrut = 0;
            else if (orelucrate == 100)
                salariulbrut = salariulbrut + concediu + sporuri + prime + altebonusuri - alteretineri;
            else
                salariulbrut = (orelucrate *0.01 * salariulbrut) + concediu + sporuri + prime + altebonusuri - alteretineri;
                contributii = (0.1 * salariulbrut);         
                impozitsalariu = 0.1 * (salariulbrut - contributii - deducere);
                salariulnet = salariulbrut - (0.25 * salariulbrut) - (0.1 * salariulbrut) - impozitsalariu;
            
            raport.Text = " Venit brut: " + salariulbrut.ToString("N") +
                "\n Deducere: " + deducere.ToString("N") + "\n Impozitsalariu: " + impozitsalariu.ToString("N") +
                "\n Contributii: " + contributii.ToString("N") + "\n Sporuri: " + sporuri.ToString("N") + 
                "\n Prime: " + prime.ToString("N") + "\n Alte bonusuri: " + altebonusuri.ToString("N") + 
                "\n Alte retineri: " + alteretineri.ToString("N") + "\n Salariu net: " + salariulnet.ToString("N"); 
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    afisare();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            CalculSalariu();
            if (MessageBox.Show("Vrei sa adaugi date in tabela Salarii?","Adauga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            MessageBox.Show("Salariatul a fost introdus");
                            //afisare();
                            //ResetareCampuri();
                            
                            //AfisareCalculSalariu();
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Datele nu au fost introduse","Adauga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDialog.Document = printFluturas;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printFluturas.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(DatePers.Text+ "\n \n" + raport.Text, new Font("Arial", 30, FontStyle.Bold), Brushes.Black, 30, 30);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            AfisareNume();
            
        }



        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    ConexiuneBaza.Open();


        //        SqlCommand PreiaDate = new SqlCommand("SELECT Nume FROM AngajatiTbl WHERE AngajatID = @AngajatIdTb", ConexiuneBaza);
        //        PreiaDate.Parameters.AddWithValue("AngajatIdTb", int.Parse(AngajatIdTb.Text));
        //        SqlDataReader citeste = PreiaDate.ExecuteReader();                               
        //        DateAngajati.Text = citeste.GetValue(1).ToString();


        //    ConexiuneBaza.Close();
        //}
    }
}
