
namespace GESTIUNEANGAJATI
{
    partial class Salarii
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AfisNume = new System.Windows.Forms.DataGridView();
            this.CautaNume = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.raport = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SalariulBrut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OreLucrate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Sporuri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Concediu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Prime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AlteBonusuri = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AlteRetineri = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AfisNume)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(14)))), ((int)(((byte)(84)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1682, 56);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(14)))), ((int)(((byte)(84)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 537);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1682, 82);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "AngajatId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Introdu Nume";
            // 
            // AfisNume
            // 
            this.AfisNume.AllowUserToDeleteRows = false;
            this.AfisNume.BackgroundColor = System.Drawing.Color.White;
            this.AfisNume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AfisNume.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AfisNume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AfisNume.ColumnHeadersVisible = false;
            this.AfisNume.GridColor = System.Drawing.Color.White;
            this.AfisNume.Location = new System.Drawing.Point(210, 118);
            this.AfisNume.Name = "AfisNume";
            this.AfisNume.ReadOnly = true;
            this.AfisNume.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AfisNume.RowHeadersVisible = false;
            this.AfisNume.RowHeadersWidth = 51;
            this.AfisNume.RowTemplate.Height = 29;
            this.AfisNume.Size = new System.Drawing.Size(187, 45);
            this.AfisNume.TabIndex = 5;
            // 
            // CautaNume
            // 
            this.CautaNume.Location = new System.Drawing.Point(199, 68);
            this.CautaNume.Name = "CautaNume";
            this.CautaNume.Size = new System.Drawing.Size(210, 27);
            this.CautaNume.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(14)))), ((int)(((byte)(84)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(446, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 42);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cauta";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(14)))), ((int)(((byte)(84)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(47, 471);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 42);
            this.button2.TabIndex = 18;
            this.button2.Text = "Genereaza date";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // raport
            // 
            this.raport.Dock = System.Windows.Forms.DockStyle.Right;
            this.raport.Location = new System.Drawing.Point(671, 56);
            this.raport.Name = "raport";
            this.raport.Size = new System.Drawing.Size(1011, 481);
            this.raport.TabIndex = 20;
            this.raport.Text = "";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(14)))), ((int)(((byte)(84)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(340, 471);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 42);
            this.button3.TabIndex = 21;
            this.button3.Text = "Print fluturas";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // SalariulBrut
            // 
            this.SalariulBrut.Location = new System.Drawing.Point(187, 193);
            this.SalariulBrut.Name = "SalariulBrut";
            this.SalariulBrut.Size = new System.Drawing.Size(210, 27);
            this.SalariulBrut.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 31);
            this.label3.TabIndex = 22;
            this.label3.Text = "Salariul Brut";
            // 
            // OreLucrate
            // 
            this.OreLucrate.Location = new System.Drawing.Point(187, 234);
            this.OreLucrate.Name = "OreLucrate";
            this.OreLucrate.Size = new System.Drawing.Size(210, 27);
            this.OreLucrate.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 31);
            this.label4.TabIndex = 24;
            this.label4.Text = "Ore Lucrate";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Sporuri
            // 
            this.Sporuri.Location = new System.Drawing.Point(187, 274);
            this.Sporuri.Name = "Sporuri";
            this.Sporuri.Size = new System.Drawing.Size(210, 27);
            this.Sporuri.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 31);
            this.label5.TabIndex = 26;
            this.label5.Text = "Sporuri";
            // 
            // Concediu
            // 
            this.Concediu.Location = new System.Drawing.Point(187, 309);
            this.Concediu.Name = "Concediu";
            this.Concediu.Size = new System.Drawing.Size(210, 27);
            this.Concediu.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(24, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 31);
            this.label6.TabIndex = 28;
            this.label6.Text = "Concediu";
            // 
            // Prime
            // 
            this.Prime.Location = new System.Drawing.Point(187, 349);
            this.Prime.Name = "Prime";
            this.Prime.Size = new System.Drawing.Size(210, 27);
            this.Prime.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(24, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 31);
            this.label7.TabIndex = 30;
            this.label7.Text = "Prime";
            // 
            // AlteBonusuri
            // 
            this.AlteBonusuri.Location = new System.Drawing.Point(187, 391);
            this.AlteBonusuri.Name = "AlteBonusuri";
            this.AlteBonusuri.Size = new System.Drawing.Size(210, 27);
            this.AlteBonusuri.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(24, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 31);
            this.label8.TabIndex = 32;
            this.label8.Text = "Alte bonusuri";
            // 
            // AlteRetineri
            // 
            this.AlteRetineri.Location = new System.Drawing.Point(187, 433);
            this.AlteRetineri.Name = "AlteRetineri";
            this.AlteRetineri.Size = new System.Drawing.Size(210, 27);
            this.AlteRetineri.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(23, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 31);
            this.label9.TabIndex = 34;
            this.label9.Text = "Alte retineri";
            // 
            // Salarii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1682, 619);
            this.Controls.Add(this.AlteRetineri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AlteBonusuri);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Prime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Concediu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Sporuri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OreLucrate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SalariulBrut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.raport);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CautaNume);
            this.Controls.Add(this.AfisNume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Salarii";
            this.Text = "Salarii";
            ((System.ComponentModel.ISupportInitialize)(this.AfisNume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView AfisNume;
        private System.Windows.Forms.TextBox CautaNume;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox raport;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox SalariulBrut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OreLucrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Sporuri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Concediu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Prime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AlteBonusuri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AlteRetineri;
        private System.Windows.Forms.Label label9;
    }
}