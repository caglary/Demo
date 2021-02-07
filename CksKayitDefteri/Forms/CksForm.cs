using App.Business;
using Entities.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class CksForm : Form
    {
        CksManager _cksManager;
        CiftcilerManager _ciftcilerManager;

        static Cks ciftci = new Cks() { Id = -1 };
        public CksForm()
        {
            InitializeComponent();
            _cksManager = new CksManager();
            _ciftcilerManager = new CiftcilerManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FromSettings(this);
            dgwListe.DataSource = _cksManager.GetAll();
            Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });

            formDoldur();
            cmboxMahalleKoy.DataSource = Utilities.RequiredLists.VillageNameList();
            dgwListe.Columns[1].HeaderText = "Dosya No";
            dgwListe.Columns[2].HeaderText = "Tc Numarası";
            dgwListe.Columns[3].HeaderText = "İsim";
            dgwListe.Columns[4].HeaderText = "Baba Adı";
            dgwListe.Columns[5].HeaderText = "Mahalle/Köy";
            dgwListe.Columns[6].HeaderText = "Cep Telefonu";
            dgwListe.Columns[7].HeaderText = "Ev Telefonu";
            dgwListe.Columns[8].HeaderText = "Kayıt Tarihi";
            dgwListe.Columns[9].HeaderText = "Not";





        }

        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int index = dgwListe.CurrentCell.RowIndex;
                string Tc = dgwListe.Rows[index].Cells["Tc"].Value.ToString();
                ciftci = _cksManager.GetByTc(Tc);
                formDoldur();
            });

           
        }
        void formDoldur()
        {
            txtDosyaNo.Text = ciftci.DosyaNo.ToString();
            txtBabaAdi.Text = ciftci.BabaAdi;
            txtCepTelefon.Text = ciftci.CepTelefonu;
            txtEvTelefon.Text = ciftci.EvTelefonu;
            txtIsimSoyisim.Text = ciftci.IsimSoyisim;
            txtKayitTarihi.Text = ciftci.KayitTarihi;
            txtTc.Text = ciftci.Tc;
            cmboxMahalleKoy.Text = ciftci.KoyMahalle;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            Utilities.ErrorHandle._try(() =>
            {
                string tc = txtTcSearch.Text;
                var ciftci = _ciftcilerManager.GetByTc(tc);
                if (ciftci.TcKimlikNo == null)
                {
                    CiftciForm form = new CiftciForm(tc);
                    form.ShowDialog();
                }
                else
                {
                    int dosyano = _cksManager.DosyaNoFactory();
                    returnValue = _cksManager.Add(new Cks
                    {
                        DosyaNo = dosyano,
                        BabaAdi = ciftci.FatherName,
                        CepTelefonu = ciftci.MobilePhone,
                        EvTelefonu = ciftci.HomePhone,
                        IsimSoyisim = ciftci.NameSurname,
                        KayitTarihi = DateTime.Now.ToShortDateString(),
                        KoyMahalle = ciftci.Village,
                        Tc = tc
                    });
                    ShowList();
                }
            });
            if (returnValue > 0) Utilities.Mesaj.MessageBoxInformation("Kayıt işlemi başarılı");
        }

        private void ShowList()
        {
            dgwListe.DataSource = _cksManager.GetAll();

            formDoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (ciftci.Id == -1) throw new Exception("Listeden silmek istediğiniz kaydı seçiniz.");
                int result = _cksManager.Delete(ciftci);
                if (result > 0)
                {
                    Utilities.Mesaj.MessageBoxInformation("Silme işlemi başarılı");
                    ShowList();
                    ciftci = new Cks() { Id = -1 };
                    FormTemizle();
                }

            });

        }

        private void FormTemizle()
        {
            txtBabaAdi.Text = "";
            txtCepTelefon.Text = "";
            txtDosyaNo.Text = "";
            txtEvTelefon.Text = "";
            txtIsimSoyisim.Text = "";
            txtKayitTarihi.Text = "";
            txtTc.Text = "";
            cmboxMahalleKoy.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (ciftci.Id == -1) throw new Exception("Listeden güncellemek istediğiniz kaydı seçiniz.");
                ciftci.DosyaNo = Convert.ToInt32(txtDosyaNo.Text);
                ciftci.Tc = txtTc.Text;
                ciftci.IsimSoyisim = txtIsimSoyisim.Text;
                ciftci.BabaAdi = txtBabaAdi.Text;
                ciftci.KoyMahalle = cmboxMahalleKoy.Text;
                ciftci.CepTelefonu = txtCepTelefon.Text;
                ciftci.EvTelefonu = txtEvTelefon.Text;
                ciftci.KayitTarihi = txtKayitTarihi.Text;

                int result = _cksManager.Update(ciftci);
                if (result > 0)
                {
                    Utilities.Mesaj.MessageBoxInformation("Güncelleme işlemi başarılı");
                    ShowList();
                }

            });
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.Question.IfYes(() =>
            {
                Utilities.ErrorHandle._try(() =>
            {
                var liste = _cksManager.GetAll().OrderBy(I => I.DosyaNo).ToList();
                var dataTable = Utilities.ExcelExport.ConvertToDataTable(liste);

                var location = Utilities.FolderBrowser.Path();
                var path = location + @"\CksListesi2020.xlsx";
                Task t = Task.Run(() =>
                {
                    Utilities.ExcelExport.GenerateExcel(dataTable, path);
                    MessageBox.Show($"Liste {path} adresine kaydedildi.");
                });
            });
            }, "Devam etmek istiyor musunuz?");
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.Question.IfYes(() =>
            {

                Utilities.ErrorHandle._try(() =>
                {
                    var path = Utilities.FolderBrowser.Path();
                    Task t = Task.Run(() =>
                    {
                        var list2020 = _cksManager.GetAll().OrderBy(I => I.DosyaNo).ToList();
                        Utilities.Json.Backup(list2020, "Cks2020", path);

                        Utilities.Mesaj.MessageBoxInformation("Backup işlemi başarılı.");
                    });

                });


            }, "Devam etmek istiyor musunuz?");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                dgwListe.DataSource = _cksManager.Search(txtSearch.Text);
            }
            else
            {
                dgwListe.DataSource = _cksManager.GetAll();
            }
        }

        private void dgwListe_DataSourceChanged(object sender, EventArgs e)
        {
            lblKayitSayisi.Text = $"Listede bulunan toplam kayıt sayısı: {dgwListe.RowCount.ToString()}";
        }

        private void btnCiftciler_Click(object sender, EventArgs e)
        {
            CiftciForm form = new CiftciForm();
            form.ShowDialog();
        }

        private void btnSertifikaliTohum_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (ciftci.Id == -1) throw new Exception("Listeden çiftçi seçiniz.");

                Form _form = new SertifikaliTohumForm(ciftci.Tc); 
                _form.ShowDialog();
            });

        }

        private void btnYemBitkileri_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (ciftci.Id == -1) throw new Exception("Listeden çiftçi seçiniz.");

                Form _form = new YemBitkileriForm(ciftci.Tc);
                _form.ShowDialog();
            });
        }

        private void btnHububatFarkOdemesi_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (ciftci.Id == -1) throw new Exception("Listeden çiftçi seçiniz.");

                Form _form = new HububatFarkOdemesiForm(ciftci);
                _form.ShowDialog();
            });
        }
    }
}
