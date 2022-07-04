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
    public partial class Vizitator : Form
    {
        public Vizitator()
        {
            InitializeComponent();
        }
        SqlConnection ConexiuneBaza = new SqlConnection(@"Server=tcp:gestionareangajati.database.windows.net,1433;Initial Catalog=gestionareangajati;Persist Security Info=False;User ID=Ovidiu;Password=Gioada69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConexiuneBaza.Open();
            string interogare = "SELECT AngajatID, Nume FROM AngajatiTbl WHERE Nume like'" + NumeTb.Text + "%'";
            SqlDataAdapter preluaredate = new SqlDataAdapter(interogare, ConexiuneBaza);
            SqlCommandBuilder builder = new SqlCommandBuilder(preluaredate);
            var setaredate = new DataSet();
            preluaredate.Fill(setaredate);
            AfisareId.DataSource = setaredate.Tables[0];
            ConexiuneBaza.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AngajatIdTb.Text == "" || TipCerereCb.Text == "" || DurataCb.Text == "" || DataInceputCb.Text == "" || DataSfarsitCb.Text == "")
            {
                MessageBox.Show("Toate campurile sunt obligatorii");
            }
            else
            {
                using (SqlCommand Adaugare = new SqlCommand())
                {
                    Adaugare.Connection = ConexiuneBaza;
                    Adaugare.CommandType = CommandType.Text;
                    Adaugare.CommandText = "INSERT into Cereri (AngajatId, TipCerere, Durata, DataInceput, DataSfarsit) VALUES (@AngajatIdTb, @TipCerereCb, @DurataCb, @DataInceputCb, @DataSfarsitCb)";
                    Adaugare.Parameters.AddWithValue("@AngajatIdTb", AngajatIdTb.Text);
                    Adaugare.Parameters.AddWithValue("@TipCerereCb", TipCerereCb.Text);
                    Adaugare.Parameters.AddWithValue("@DurataCb", DurataCb.Text);
                    Adaugare.Parameters.AddWithValue("@DataInceputCb", DataInceputCb.Text);
                    Adaugare.Parameters.AddWithValue("@DataSfarsitCb", DataSfarsitCb.Text);

                    try
                    {
                        ConexiuneBaza.Open();
                        Adaugare.ExecuteNonQuery();
                        ConexiuneBaza.Close();
                        MessageBox.Show("Cererea a fost depusa");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (CerereIdform.Text == "")
            {
                MessageBox.Show("Introdu Id-ul cererii");
            }
            else
            {
                using (SqlCommand Verificare = new SqlCommand())
                {
                    Verificare.Connection = ConexiuneBaza;
                    Verificare.CommandType = CommandType.Text;
                    Verificare.CommandText = "SELECT Stare FROM Cereri WHERE CerereId='" + CerereIdform.Text + "';";
                    Verificare.Parameters.AddWithValue("@CerereIdform", CerereIdform.Text);                   

                    try
                    {
                        ConexiuneBaza.Open();
                        //Verificare.ExecuteNonQuery();
                        string name = "";
                        
                        var db = Verificare.ExecuteReader();
                        while (db.Read())
                        {
                            name = (string)db[0];
                            
                        }
                        db.Close();
                        ConexiuneBaza.Close();
                        CerereIdform.Text = name;




                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }

            }
        }
    }
}
