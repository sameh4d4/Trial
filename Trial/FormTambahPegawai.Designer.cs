namespace Trial
{
    partial class FormTambahPegawai
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
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.textBoxJenisBarang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIDPenjual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxIDBarang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.buttonKeluar.Location = new System.Drawing.Point(180, 291);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(127, 44);
            this.buttonKeluar.TabIndex = 6;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimpan.Font = new System.Drawing.Font("Open Sans Semibold", 12F);
            this.buttonSimpan.Location = new System.Drawing.Point(337, 291);
            this.buttonSimpan.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(127, 44);
            this.buttonSimpan.TabIndex = 5;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // textBoxJenisBarang
            // 
            this.textBoxJenisBarang.Location = new System.Drawing.Point(167, 105);
            this.textBoxJenisBarang.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxJenisBarang.Name = "textBoxJenisBarang";
            this.textBoxJenisBarang.Size = new System.Drawing.Size(245, 22);
            this.textBoxJenisBarang.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 27);
            this.label7.TabIndex = 9;
            this.label7.Text = "Role:";
            // 
            // textBoxIDPenjual
            // 
            this.textBoxIDPenjual.Location = new System.Drawing.Point(167, 68);
            this.textBoxIDPenjual.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIDPenjual.Name = "textBoxIDPenjual";
            this.textBoxIDPenjual.Size = new System.Drawing.Size(245, 22);
            this.textBoxIDPenjual.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 27);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nama";
            // 
            // textBoxIDBarang
            // 
            this.textBoxIDBarang.Location = new System.Drawing.Point(167, 27);
            this.textBoxIDBarang.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIDBarang.Name = "textBoxIDBarang";
            this.textBoxIDBarang.Size = new System.Drawing.Size(245, 22);
            this.textBoxIDBarang.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.textBoxJenisBarang);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxIDPenjual);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxIDBarang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 210);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "TAMBAH PEGAWAI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTambahPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 347);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormTambahPegawai";
            this.Text = "FormTambahPegawai";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.TextBox textBoxJenisBarang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIDPenjual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxIDBarang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}