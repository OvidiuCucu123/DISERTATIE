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
    public partial class Angajat : Form
    {

        public Angajat()
        {
            InitializeComponent();
        }
        SqlConnection ConexiuneBaza = new SqlConnection(@"Server=tcp:gestionareangajati.database.windows.net,1433;Initial Catalog=gestionareangajati;Persist Security Info=False;User ID=Ovidiu;Password=Gioada69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AngajatIdTb.Text == "" || NumeTb.Text == "" || AdresaTb.Text == "" || TelefonTb.Text == "" || DataAngajareCb.Text == "" || FunctiaCb.Text == "" || DepartamentCb.Text == "")
            {
                MessageBox.Show("Toate campurile sunt obligatorii");
            }
            else
            {
                using (SqlCommand Adaugare = new SqlCommand())
                {
                    Adaugare.Connection = ConexiuneBaza;
                    Adaugare.CommandType = CommandType.Text;
                    Adaugare.CommandText = "INSERT into AngajatiTbl (AngajatID, Nume, Adresa, Telefon, DataAngajare, Functia, Departament) VALUES (@AngajatIdTb, @NumeTb, @AdresaTb, @TelefonTb, @DataAngajareCb, @FunctiaCb, @DepartamentCb)";
                    Adaugare.Parameters.AddWithValue("@AngajatIdTb", AngajatIdTb.Text);
                    Adaugare.Parameters.AddWithValue("@NumeTb", NumeTb.Text);
                    Adaugare.Parameters.AddWithValue("@AdresaTb", AdresaTb.Text);
                    Adaugare.Parameters.AddWithValue("@TelefonTb", TelefonTb.Text);
                    Adaugare.Parameters.AddWithValue("@DataAngajareCb", DataAngajareCb.Text);
                    Adaugare.Parameters.AddWithValue("@FunctiaCb", FunctiaCb.Text);
                    Adaugare.Parameters.AddWithValue("@DepartamentCb", DepartamentCb.Text);
                    try
                    {
                        ConexiuneBaza.Open();
                        Adaugare.ExecuteNonQuery();
                        ConexiuneBaza.Close();
                        MessageBox.Show("Angajatul a fost introdus");
                        afisare();
                        ResetareCampuri();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void AngajatIdTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void afisare()
        {
            ConexiuneBaza.Open();
            string interogare = "SELECT * FROM AngajatiTbl";
            SqlDataAdapter sda = new SqlDataAdapter(interogare, ConexiuneBaza);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AfisDate.DataSource = ds.Tables[0];
            ConexiuneBaza.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (AngajatIdTb.Text == "")
            {
                MessageBox.Show("Introdu Id angajat");
            }
            else
            {
                using (SqlCommand stergere = new SqlCommand())
                {
                    stergere.Connection = ConexiuneBaza;
                    stergere.CommandType = CommandType.Text;
                    stergere.CommandText = "DELETE FROM AngajatiTbl WHERE AngajatID='" + AngajatIdTb.Text + "';";
                    try
                    {
                        ConexiuneBaza.Open();
                        stergere.ExecuteNonQuery();
                        ConexiuneBaza.Close();
                        MessageBox.Show("Angajatul a fost sters");
                        afisare();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }

            }
        }

        private void Angajat_Load(object sender, EventArgs e)
        {
            afisare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand Modificare = new SqlCommand("UPDATE AngajatiTbl SET Nume=@NumeTb, Adresa=@AdresaTb, Telefon=@TelefonTb, DataAngajare=@DataAngajareCb, Functia=@FunctiaCb, Departament=@DepartamentCb WHERE AngajatID=@AngajatIdTb", ConexiuneBaza);
            {
                Modificare.CommandType = CommandType.Text;
                Modificare.Parameters.AddWithValue("@NumeTb", NumeTb.Text);
                Modificare.Parameters.AddWithValue("@AdresaTb", AdresaTb.Text);
                Modificare.Parameters.AddWithValue("@TelefonTb", TelefonTb.Text);
                Modificare.Parameters.AddWithValue("@DataAngajareCb", DataAngajareCb.Text);
                Modificare.Parameters.AddWithValue("@FunctiaCb", FunctiaCb.Text);
                Modificare.Parameters.AddWithValue("@DepartamentCb", DepartamentCb.Text);
                Modificare.Parameters.AddWithValue("@AngajatIdTb", AngajatIdTb.Text);

                try
                {
                    ConexiuneBaza.Open();
                    Modificare.ExecuteNonQuery();
                    ConexiuneBaza.Close();
                    MessageBox.Show("Angajatulul a fost actualizat");
                    afisare();
                    ResetareCampuri();

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetareCampuri();

        }

        private void ResetareCampuri()
        {
            AngajatIdTb.Clear();
            NumeTb.Clear();
            AdresaTb.Clear();
            TelefonTb.Clear();
            NumeTb.Focus();
        }

        private void AfisDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AngajatIdTb.Text = AfisDate.SelectedRows[0].Cells[0].Value.ToString();
            NumeTb.Text = AfisDate.SelectedRows[0].Cells[1].Value.ToString();
            AdresaTb.Text = AfisDate.SelectedRows[0].Cells[2].Value.ToString();
            TelefonTb.Text = AfisDate.SelectedRows[0].Cells[3].Value.ToString();
            DataAngajareCb.Text = AfisDate.SelectedRows[0].Cells[4].Value.ToString();
            FunctiaCb.Text = AfisDate.SelectedRows[0].Cells[5].Value.ToString();
            DepartamentCb.Text = AfisDate.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConexiuneBaza.Open();
            string interogare = "SELECT * FROM AngajatiTbl WHERE Nume like'"+NumeTb.Text+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(interogare, ConexiuneBaza);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AfisDate.DataSource = ds.Tables[0];
            ConexiuneBaza.Close();
        }
    }
}