
namespace App.Forms
{
    partial class CksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CksForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgwListe = new System.Windows.Forms.DataGridView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusExcel = new System.Windows.Forms.ToolStripSplitButton();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCiftciler = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTcSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboxMahalleKoy = new System.Windows.Forms.ComboBox();
            this.btnHububatFarkOdemesi = new System.Windows.Forms.Button();
            this.btnYemBitkileri = new System.Windows.Forms.Button();
            this.btnSertifikaliTohum = new System.Windows.Forms.Button();
            this.txtKayitTarihi = new System.Windows.Forms.TextBox();
            this.txtBabaAdi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEvTelefon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIsimSoyisim = new System.Windows.Forms.TextBox();
            this.txtCepTelefon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDosyaNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListe)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgwListe);
            this.panel1.Controls.Add(this.statusStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 369);
            this.panel1.TabIndex = 2;
            // 
            // dgwListe
            // 
            this.dgwListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwListe.Location = new System.Drawing.Point(0, 0);
            this.dgwListe.Margin = new System.Windows.Forms.Padding(4);
            this.dgwListe.Name = "dgwListe";
            this.dgwListe.RowHeadersWidth = 51;
            this.dgwListe.RowTemplate.Height = 24;
            this.dgwListe.Size = new System.Drawing.Size(1081, 343);
            this.dgwListe.TabIndex = 1;
            this.dgwListe.DataSourceChanged += new System.EventHandler(this.dgwListe_DataSourceChanged);
            this.dgwListe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwListe_CellClick);
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusExcel});
            this.statusStrip2.Location = new System.Drawing.Point(0, 343);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip2.Size = new System.Drawing.Size(1081, 26);
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusExcel
            // 
            this.toolStripStatusExcel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.jsonToolStripMenuItem});
            this.toolStripStatusExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusExcel.Image")));
            this.toolStripStatusExcel.Name = "toolStripStatusExcel";
            this.toolStripStatusExcel.Size = new System.Drawing.Size(96, 24);
            this.toolStripStatusExcel.Text = "Backup";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.excelToolStripMenuItem.Text = "To Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // jsonToolStripMenuItem
            // 
            this.jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
            this.jsonToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.jsonToolStripMenuItem.Text = "To Json";
            this.jsonToolStripMenuItem.Click += new System.EventHandler(this.jsonToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnCiftciler);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lblKayitSayisi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 266);
            this.panel2.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(696, 184);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(252, 24);
            this.txtSearch.TabIndex = 13;
            // 
            // btnCiftciler
            // 
            this.btnCiftciler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCiftciler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCiftciler.Location = new System.Drawing.Point(955, 222);
            this.btnCiftciler.Margin = new System.Windows.Forms.Padding(4);
            this.btnCiftciler.Name = "btnCiftciler";
            this.btnCiftciler.Size = new System.Drawing.Size(122, 35);
            this.btnCiftciler.TabIndex = 1;
            this.btnCiftciler.Text = "Çiftçiler";
            this.btnCiftciler.UseVisualStyleBackColor = false;
            this.btnCiftciler.Click += new System.EventHandler(this.btnCiftciler_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(955, 178);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 37);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Ara";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(693, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(217, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Liste içinde arama yapmak için..";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTcSearch);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(678, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 140);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yeni Kayıt İşlemleri";
            // 
            // txtTcSearch
            // 
            this.txtTcSearch.Location = new System.Drawing.Point(18, 62);
            this.txtTcSearch.Name = "txtTcSearch";
            this.txtTcSearch.Size = new System.Drawing.Size(259, 24);
            this.txtTcSearch.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(18, 93);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "Eklemek istediğiniz Tc numarası girniz.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmboxMahalleKoy);
            this.groupBox1.Controls.Add(this.btnHububatFarkOdemesi);
            this.groupBox1.Controls.Add(this.btnYemBitkileri);
            this.groupBox1.Controls.Add(this.btnSertifikaliTohum);
            this.groupBox1.Controls.Add(this.txtKayitTarihi);
            this.groupBox1.Controls.Add(this.txtBabaAdi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtEvTelefon);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIsimSoyisim);
            this.groupBox1.Controls.Add(this.txtCepTelefon);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDosyaNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 256);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Güncelleme İşlemleri";
            // 
            // cmboxMahalleKoy
            // 
            this.cmboxMahalleKoy.FormattingEnabled = true;
            this.cmboxMahalleKoy.Location = new System.Drawing.Point(456, 44);
            this.cmboxMahalleKoy.Name = "cmboxMahalleKoy";
            this.cmboxMahalleKoy.Size = new System.Drawing.Size(180, 26);
            this.cmboxMahalleKoy.TabIndex = 4;
            // 
            // btnHububatFarkOdemesi
            // 
            this.btnHububatFarkOdemesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnHububatFarkOdemesi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHububatFarkOdemesi.Location = new System.Drawing.Point(280, 214);
            this.btnHububatFarkOdemesi.Margin = new System.Windows.Forms.Padding(4);
            this.btnHububatFarkOdemesi.Name = "btnHububatFarkOdemesi";
            this.btnHububatFarkOdemesi.Size = new System.Drawing.Size(122, 35);
            this.btnHububatFarkOdemesi.TabIndex = 1;
            this.btnHububatFarkOdemesi.Text = "Fark Odemesi";
            this.btnHububatFarkOdemesi.UseVisualStyleBackColor = false;
            this.btnHububatFarkOdemesi.Click += new System.EventHandler(this.btnHububatFarkOdemesi_Click);
            // 
            // btnYemBitkileri
            // 
            this.btnYemBitkileri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnYemBitkileri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYemBitkileri.Location = new System.Drawing.Point(410, 214);
            this.btnYemBitkileri.Margin = new System.Windows.Forms.Padding(4);
            this.btnYemBitkileri.Name = "btnYemBitkileri";
            this.btnYemBitkileri.Size = new System.Drawing.Size(122, 35);
            this.btnYemBitkileri.TabIndex = 1;
            this.btnYemBitkileri.Text = "Yem Bitkileri";
            this.btnYemBitkileri.UseVisualStyleBackColor = false;
            this.btnYemBitkileri.Click += new System.EventHandler(this.btnYemBitkileri_Click);
            // 
            // btnSertifikaliTohum
            // 
            this.btnSertifikaliTohum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSertifikaliTohum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSertifikaliTohum.Location = new System.Drawing.Point(540, 214);
            this.btnSertifikaliTohum.Margin = new System.Windows.Forms.Padding(4);
            this.btnSertifikaliTohum.Name = "btnSertifikaliTohum";
            this.btnSertifikaliTohum.Size = new System.Drawing.Size(122, 35);
            this.btnSertifikaliTohum.TabIndex = 1;
            this.btnSertifikaliTohum.Text = "Sertifikalı T.";
            this.btnSertifikaliTohum.UseVisualStyleBackColor = false;
            this.btnSertifikaliTohum.Click += new System.EventHandler(this.btnSertifikaliTohum_Click);
            // 
            // txtKayitTarihi
            // 
            this.txtKayitTarihi.Location = new System.Drawing.Point(456, 140);
            this.txtKayitTarihi.Margin = new System.Windows.Forms.Padding(4);
            this.txtKayitTarihi.Name = "txtKayitTarihi";
            this.txtKayitTarihi.Size = new System.Drawing.Size(180, 24);
            this.txtKayitTarihi.TabIndex = 7;
            // 
            // txtBabaAdi
            // 
            this.txtBabaAdi.Location = new System.Drawing.Point(104, 140);
            this.txtBabaAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtBabaAdi.Name = "txtBabaAdi";
            this.txtBabaAdi.Size = new System.Drawing.Size(203, 24);
            this.txtBabaAdi.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Kayıt Tarihi:";
            // 
            // txtEvTelefon
            // 
            this.txtEvTelefon.Location = new System.Drawing.Point(456, 109);
            this.txtEvTelefon.Margin = new System.Windows.Forms.Padding(4);
            this.txtEvTelefon.Name = "txtEvTelefon";
            this.txtEvTelefon.Size = new System.Drawing.Size(180, 24);
            this.txtEvTelefon.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Baba Adı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ev Telefon:";
            // 
            // txtIsimSoyisim
            // 
            this.txtIsimSoyisim.Location = new System.Drawing.Point(104, 109);
            this.txtIsimSoyisim.Margin = new System.Windows.Forms.Padding(4);
            this.txtIsimSoyisim.Name = "txtIsimSoyisim";
            this.txtIsimSoyisim.Size = new System.Drawing.Size(203, 24);
            this.txtIsimSoyisim.TabIndex = 2;
            // 
            // txtCepTelefon
            // 
            this.txtCepTelefon.Location = new System.Drawing.Point(456, 77);
            this.txtCepTelefon.Margin = new System.Windows.Forms.Padding(4);
            this.txtCepTelefon.Name = "txtCepTelefon";
            this.txtCepTelefon.Size = new System.Drawing.Size(180, 24);
            this.txtCepTelefon.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Adı Soyadı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cep Telefon:";
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(104, 77);
            this.txtTc.Margin = new System.Windows.Forms.Padding(4);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(203, 24);
            this.txtTc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tc No:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mahalle\\Köy:";
            // 
            // txtDosyaNo
            // 
            this.txtDosyaNo.Location = new System.Drawing.Point(104, 46);
            this.txtDosyaNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDosyaNo.Name = "txtDosyaNo";
            this.txtDosyaNo.Size = new System.Drawing.Size(203, 24);
            this.txtDosyaNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dosya No:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(8, 186);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 44);
            this.panel3.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutPanel1.Controls.Add(this.btnSil);
            this.flowLayoutPanel1.Controls.Add(this.btnGuncelle);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 44);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Location = new System.Drawing.Point(4, 4);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(85, 37);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Location = new System.Drawing.Point(97, 4);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(85, 37);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.AutoSize = true;
            this.lblKayitSayisi.Location = new System.Drawing.Point(679, 239);
            this.lblKayitSayisi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(23, 18);
            this.lblKayitSayisi.TabIndex = 12;
            this.lblKayitSayisi.Text = "---";
            // 
            // CksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1081, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çks Kayıt Defteri";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListe)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgwListe;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmboxMahalleKoy;
        private System.Windows.Forms.TextBox txtKayitTarihi;
        private System.Windows.Forms.TextBox txtBabaAdi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEvTelefon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIsimSoyisim;
        private System.Windows.Forms.TextBox txtCepTelefon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDosyaNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.ToolStripSplitButton toolStripStatusExcel;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTcSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCiftciler;
        private System.Windows.Forms.Button btnSertifikaliTohum;
        private System.Windows.Forms.Button btnYemBitkileri;
        private System.Windows.Forms.Button btnHububatFarkOdemesi;
    }
}

