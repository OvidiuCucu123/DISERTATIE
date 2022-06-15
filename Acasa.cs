using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTIUNEANGAJATI
{
    public partial class Acasa : Form
    {
        public Acasa()
        {
            InitializeComponent();
        }

        private void Acasa_Load(object sender, EventArgs e)
        {

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
