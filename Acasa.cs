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
        private Form FormaActiva = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (FormaActiva != null)
                FormaActiva.Close();
            FormaActiva = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForme.Controls.Add(childForm);
            panelForme.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonAngajati_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Angajat());
        }
    }
}
