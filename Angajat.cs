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
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ovidiu\Documents\Angajati.mdf;Integrated Security=True;Connect Timeout=30");
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

             
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = Con;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT into AngajatiTbl (AngajatId, Nume, Adresa, Telefon, DataAngajare, Functia, Departament) VALUES (@AngajatIdTb, @NumeTb, @AdresaTb, @TelefonTb, @DataAngajareCb, @FunctiaCb, @DepartamentCb)";
                        command.Parameters.AddWithValue("@AngajatIdTb", AngajatIdTb.Text);
                        command.Parameters.AddWithValue("@NumeTb", NumeTb.Text);
                        command.Parameters.AddWithValue("@AdresaTb", AdresaTb.Text);
                        command.Parameters.AddWithValue("@TelefonTb", TelefonTb.Text);
                        command.Parameters.AddWithValue("@DataAngajareCb", DataAngajareCb.Text);
                        command.Parameters.AddWithValue("@FunctiaCb", FunctiaCb.Text);
                        command.Parameters.AddWithValue("@DepartamentCb", DepartamentCb.Text);
                        try
                        {
                            Con.Open();
                            command.ExecuteNonQuery();
                            Con.Close();
                            MessageBox.Show("Angajatul a fost introdus");
                            populate();
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
            Application.Exit();
        }

        private void AngajatIdTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM AngajatiTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AfisDate.DataSource = ds.Tables[0];
            Con.Close();
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (AngajatIdTb.Text == "")
            {
                MessageBox.Show("Introdu Id angajat");
            }
            else
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = Con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM AngajatiTbl WHERE AngajatId='" + AngajatIdTb.Text + "';";
                    try
                    {
                        Con.Open();
                        command.ExecuteNonQuery();
                        Con.Close();
                        MessageBox.Show("Angajatul a fost sters");
                        populate();
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
            populate();
        }
    }
}
