using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace GESTIUNEANGAJATI
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
        }
        SqlConnection ConexiuneBaza = new SqlConnection(@"Server=tcp:gestionareangajati.database.windows.net,1433;Initial Catalog=gestionareangajati;Persist Security Info=False;User ID=Ovidiu;Password=Gioada69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        private string CriptareParola(string cript)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cript));
            byte[] Generare = md5.Hash;
            StringBuilder ParolaCriptata = new StringBuilder();
            for (int i=1;i<Generare.Length;i++)
            {
                ParolaCriptata.Append(Generare[i].ToString("x2"));
            }
            return ParolaCriptata.ToString(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PassTextBox.Text == "" || UserTextBox.Text == "")
            {
                MessageBox.Show("Introdu Nume de Utilizator si Parola");
            }
            else
            {
                using (SqlCommand Verificare = new SqlCommand())
                {

                    Verificare.Connection = ConexiuneBaza;
                    Verificare.CommandType = CommandType.Text;
                    Verificare.CommandText = "SELECT Nume, Parola FROM Utilizatori WHERE Nume='" + UserTextBox.Text + "';";
                    Verificare.Parameters.AddWithValue("@UserTextBox", UserTextBox.Text);
                    Verificare.Parameters.AddWithValue("@PassTextBox", PassTextBox.Text);

                    try
                    {
                        ConexiuneBaza.Open();
                        //Verificare.ExecuteNonQuery();
                        string name = "";
                        string pass = "";
                        var db = Verificare.ExecuteReader();
                        while (db.Read())
                        {
                            name =(string)db[0];
                            pass =(string)db[1];
                        }
                        db.Close();                        

                        ConexiuneBaza.Close();
                        //Apel functie criptare parola
                        
                        string parolacript = "";
                        parolacript = PassTextBox.Text;
                        string rez = CriptareParola(parolacript);


                        if (rez == pass && UserTextBox.Text == name)
                        {
                            this.Hide();
                            Acasa PagPrincipala = new Acasa();
                            PagPrincipala.Show();
                            MessageBox.Show("Logare cu succes");
                        }
                        else if (rez != pass || UserTextBox.Text != name)
                            
                        {
                            MessageBox.Show("Date logare incorecte");
                           
                        }

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }

            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Guest PagGuest = new Guest();
            PagGuest.Show();
        }
    }
    
}
