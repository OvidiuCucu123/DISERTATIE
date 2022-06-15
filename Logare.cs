using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GESTIUNEANGAJATI
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PassTextBox.Text == "" || UserTextBox.Text == "")
            {
                MessageBox.Show("Introdu Nume de Utilizator si Parola");
            }
            else if (PassTextBox.Text == "admin" || UserTextBox.Text == "admin")
            {
                this.Hide();
                Acasa PagPrincipala = new Acasa();
                PagPrincipala.Show();
            }
            else
            {
                MessageBox.Show("Nume de Utilizator sau Parola Incorecte");
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
