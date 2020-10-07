namespace Trial
{
    partial class FormHapusProduk
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
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIDBarang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxDeskripsi = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxJenisBarang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIDPenjual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStok = new System.Windows.Forms.TextBox();
            this.textBoxHarga = new System.Windows.Forms.TextBox();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.buttonKeluar.Location = new System.Drawing.Point(151, 371);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(94, 36);
            this.buttonKeluar.TabIndex = 7;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // buttonHapus
            // 
            this.buttonHapus.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHapus.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.buttonHapus.Location = new System.Drawing.Point(282, 371);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Size = new System.Drawing.Size(75, 36);
            this.buttonHapus.TabIndex = 6;
            this.buttonHapus.Text = "HAPUS";
            this.buttonHapus.UseVisualStyleBackColor = false;
            this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "HAPUS PRODUK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxIDBarang
            // 
            this.textBoxIDBarang.Location = new System.Drawing.Point(127, 22);
            this.textBoxIDBarang.Name = "textBoxIDBarang";
            this.textBoxIDBarang.Size = new System.Drawing.Size(185, 20);
            this.textBoxIDBarang.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label2.Location = new System.Drawing.Point(17, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Barang:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.richTextBoxDeskripsi);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxJenisBarang);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxIDPenjual);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxStok);
            this.panel1.Controls.Add(this.textBoxHarga);
            this.panel1.Controls.Add(this.textBoxNama);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxIDBarang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 311);
            this.panel1.TabIndex = 5;
            // 
            // richTextBoxDeskripsi
            // 
            this.richTextBoxDeskripsi.Location = new System.Drawing.Point(127, 196);
            this.richTextBoxDeskripsi.Name = "richTextBoxDeskripsi";
            this.richTextBoxDeskripsi.Size = new System.Drawing.Size(185, 74);
            this.richTextBoxDeskripsi.TabIndex = 25;
            this.richTextBoxDeskripsi.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label8.Location = new System.Drawing.Point(17, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "Deskripsi:";
            // 
            // textBoxJenisBarang
            // 
            this.textBoxJenisBarang.Location = new System.Drawing.Point(127, 83);
            this.textBoxJenisBarang.Name = "textBoxJenisBarang";
            this.textBoxJenisBarang.Size = new System.Drawing.Size(185, 20);
            this.textBoxJenisBarang.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label7.Location = new System.Drawing.Point(17, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 22);
            this.label7.TabIndex = 22;
            this.label7.Text = "Jenis Barang:";
            // 
            // textBoxIDPenjual
            // 
            this.textBoxIDPenjual.Location = new System.Drawing.Point(127, 53);
            this.textBoxIDPenjual.Name = "textBoxIDPenjual";
            this.textBoxIDPenjual.Size = new System.Drawing.Size(185, 20);
            this.textBoxIDPenjual.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label6.Location = new System.Drawing.Point(17, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Penjual:";
            // 
            // textBoxStok
            // 
            this.textBoxStok.Location = new System.Drawing.Point(127, 140);
            this.textBoxStok.Name = "textBoxStok";
            this.textBoxStok.Size = new System.Drawing.Size(185, 20);
            this.textBoxStok.TabIndex = 19;
            // 
            // textBoxHarga
            // 
            this.textBoxHarga.Location = new System.Drawing.Point(127, 170);
            this.textBoxHarga.Name = "textBoxHarga";
            this.textBoxHarga.Size = new System.Drawing.Size(185, 20);
            this.textBoxHarga.TabIndex = 18;
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(127, 109);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(185, 20);
            this.textBoxNama.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label5.Location = new System.Drawing.Point(17, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 22);
            this.label5.TabIndex = 16;
            this.label5.Text = "Stok:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label4.Location = new System.Drawing.Point(17, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 22);
            this.label4.TabIndex = 15;
            this.label4.Text = "Harga:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.label3.Location = new System.Drawing.Point(17, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nama:";
            // 
            // FormHapusProduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(372, 423);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonHapus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FormHapusProduk";
            this.Text = "FormHapusProduk";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonHapus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIDBarang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxDeskripsi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxJenisBarang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIDPenjual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStok;
        private System.Windows.Forms.TextBox textBoxHarga;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}