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
            SqlCommand numara;
            string interogare = "SELECT COUNT(AngajatID) FROM AngajatiTbl";
            try
            {
                ConexiuneBaza.Open();
                numara = new SqlCommand(interogare, ConexiuneBaza);
                Int32 numar_angajati = Convert.ToInt32(numara.ExecuteScalar());
                numara.Dispose();
                ConexiuneBaza.Close();
                NumarAngajati.Text = "In prezent aveti: " + numar_angajati.ToString() + " angajati";
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
    }
}