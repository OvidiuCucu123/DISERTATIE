using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GESTIUNEANGAJATI
{
    public partial class Acasa : Form
    {
        public Acasa()
        {
            InitializeComponent();
        }
        SqlConnection ConexiuneBaza = new SqlConnection(@"Server=tcp:gestionareangajati.database.windows.net,1433;Initial Catalog=gestionareangajati;Persist Security Info=False;User ID=Ovidiu;Password=Gioada69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        private void Acasa_Load(object sender, EventArgs e)
        {
            ArataNumarAngajati();

        }
        private void ArataNumarAngajati()
        {
            SqlCommand numara, media, cereri;
            string interogare = "SELECT COUNT(AngajatID) FROM AngajatiTbl";
            string interogare2 = "SELECT AVG(Salariulbrut) FROM SalariiTbl";
            string interogare3 = "SELECT COUNT(CerereId) FROM Cereri WHERE Stare=('Neaprobat')";

            try
            {
                ConexiuneBaza.Open();
                numara = new SqlCommand(interogare, ConexiuneBaza);
                media = new SqlCommand(interogare2, ConexiuneBaza);
                cereri = new SqlCommand(interogare3, ConexiuneBaza);
                Int32 numar_angajati = Convert.ToInt32(numara.ExecuteScalar());
                Int32 media_angajati = Convert.ToInt32(media.ExecuteScalar());
                Int32 cereri_angajati = Convert.ToInt32(cereri.ExecuteScalar());
                numara.Dispose();
                media.Dispose();
                cereri.Dispose();
                ConexiuneBaza.Close();
                NumarAngajati.Text = "In prezent aveti: " + numar_angajati.ToString() + " angajati \n" + "Media salariul brut este: " + media_angajati.ToString() + " lei \n" + "Aveti : " + cereri_angajati.ToString() + " cereri neaprobate";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private Form FereastraActiva = null;
        private void DeschideFereastraNoua(Form FereastraNoua)
        {
            if (FereastraActiva != null)
                FereastraActiva.Close();

            FereastraActiva = FereastraNoua;
            FereastraNoua.TopLevel = false;
            FereastraNoua.FormBorderStyle = FormBorderStyle.None;
            FereastraNoua.Dock = DockStyle.Fill;

            panelForme.Controls.Add(FereastraNoua);
            panelForme.Tag = FereastraNoua;

            FereastraNoua.BringToFront();
            FereastraNoua.Show();
        }

        private void buttonAngajati_Click(object sender, EventArgs e)
        {
            DeschideFereastraNoua(new Angajat());
        }

        private void buttonAcasa_Click(object sender, EventArgs e)
        {

        }

        private void buttonSalarii_Click(object sender, EventArgs e)
        {
            DeschideFereastraNoua(new Salarii());
        }

        private void buttonRapoarte_Click(object sender, EventArgs e)
        {
            //DeschideFereastraNoua(new Rapoarte());
        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logare PagLogin = new Logare();
            PagLogin.Show();
        }
        private void afisare()
        {
            ConexiuneBaza.Open();
            string interogare = "SELECT * FROM Cereri WHERE Stare=('Neaprobata')";
            SqlDataAdapter sda = new SqlDataAdapter(interogare, ConexiuneBaza);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AcasaCereri.DataSource = ds.Tables[0];
            ConexiuneBaza.Close();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            afisare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string status = "Aprobata";
            //int id_cerere = this.CerereId;
            SqlCommand Modificare = new SqlCommand("UPDATE Cereri SET Stare=@status", ConexiuneBaza);
            {
                
                Modificare.CommandType = CommandType.Text;
                Modificare.Parameters.AddWithValue("@status", status);
                //Modificare.Parameters.AddWithValue("@RetineId", RetineId.Text);
                try
                {
                    
                    ConexiuneBaza.Open();
                    Modificare.ExecuteNonQuery();
                    ConexiuneBaza.Close();
                    MessageBox.Show("Angajatulul a fost actualizat");
                    afisare();
                    //ResetareCampuri();

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Acasa();
        }

        private void AcasaCereri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //AcasaCereri.CellsCount = 7;
            RetineId.Text = AcasaCereri.SelectedRows[0].Cells[0].Value.ToString();
        }

        
    }
}