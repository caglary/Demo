namespace App.Forms
{
    partial class DestekListesiForm
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
            this.lblBaslik = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnYem = new System.Windows.Forms.Button();
            this.btnHububat = new System.Windows.Forms.Button();
            this.btnSertifikali = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgwListe = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListe)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblBaslik);
            this.panel1.Controls.Add(this.txtArama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 154);
            this.panel1.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.Location = new System.Drawing.Point(432, 107);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(99, 32);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "label1";
            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArama.Location = new System.Drawing.Point(137, 94);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(244, 27);
            this.txtArama.TabIndex = 2;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "İsim ile Arama:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flowLayoutPanel1.Controls.Add(this.btnYem);
            this.flowLayoutPanel1.Controls.Add(this.btnHububat);
            this.flowLayoutPanel1.Controls.Add(this.btnSertifikali);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1245, 61);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnYem
            // 
            this.btnYem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnYem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYem.Location = new System.Drawing.Point(3, 3);
            this.btnYem.Name = "btnYem";
            this.btnYem.Size = new System.Drawing.Size(210, 53);
            this.btnYem.TabIndex = 0;
            this.btnYem.Text = "Yem Bitkileri Başvuru";
            this.btnYem.UseVisualStyleBackColor = false;
            this.btnYem.Click += new System.EventHandler(this.btnYem_Click);
            // 
            // btnHububat
            // 
            this.btnHububat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHububat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHububat.Location = new System.Drawing.Point(219, 3);
            this.btnHububat.Name = "btnHububat";
            this.btnHububat.Size = new System.Drawing.Size(210, 53);
            this.btnHububat.TabIndex = 0;
            this.btnHububat.Text = "Hububat Fark Odemesi Başvuru";
            this.btnHububat.UseVisualStyleBackColor = false;
            this.btnHububat.Click += new System.EventHandler(this.btnHububat_Click);
            // 
            // btnSertifikali
            // 
            this.btnSertifikali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSertifikali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSertifikali.Location = new System.Drawing.Point(435, 3);
            this.btnSertifikali.Name = "btnSertifikali";
            this.btnSertifikali.Size = new System.Drawing.Size(210, 53);
            this.btnSertifikali.TabIndex = 0;
            this.btnSertifikali.Text = "Sertifikalı Tohum Başvuru";
            this.btnSertifikali.UseVisualStyleBackColor = false;
            this.btnSertifikali.Click += new System.EventHandler(this.btnSertifikali_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgwListe);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1251, 610);
            this.panel2.TabIndex = 0;
            // 
            // dgwListe
            // 
            this.dgwListe.AllowUserToAddRows = false;
            this.dgwListe.AllowUserToDeleteRows = false;
            this.dgwListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwListe.Location = new System.Drawing.Point(0, 0);
            this.dgwListe.Name = "dgwListe";
            this.dgwListe.ReadOnly = true;
            this.dgwListe.RowHeadersWidth = 51;
            this.dgwListe.RowTemplate.Height = 24;
            this.dgwListe.Size = new System.Drawing.Size(1251, 510);
            this.dgwListe.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.lblKayitSayisi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 510);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1251, 100);
            this.panel3.TabIndex = 0;
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.AutoSize = true;
            this.lblKayitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKayitSayisi.Location = new System.Drawing.Point(3, 19);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(53, 20);
            this.lblKayitSayisi.TabIndex = 1;
            this.lblKayitSayisi.Text = "label1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(1053, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "Listeyi Excele Aktar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "*Arama işlemi yaparken büyük harflerle arama yapınız.";
            // 
            // DestekListesiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 764);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DestekListesiForm";
            this.Text = "Destek Başvuru Listeleri";
            this.Load += new System.EventHandler(this.DestekListesiForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListe)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgwListe;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnYem;
        private System.Windows.Forms.Button btnHububat;
        private System.Windows.Forms.Button btnSertifikali;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}