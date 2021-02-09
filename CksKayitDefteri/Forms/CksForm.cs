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
        static Cks _cksKaydi = new Cks() { Id = -1 };
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
            txtAddDosyaNo.Text = _cksManager.DosyaNoFactory().ToString();
        }
        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int index = dgwListe.CurrentCell.RowIndex;
                string Tc = dgwListe.Rows[index].Cells["Tc"].Value.ToString();
                _cksKaydi = _cksManager.GetByTc(Tc);
                if (_cksKaydi==null)
                {
                    throw new Exception("Listeden kayıt seçiniz.");
                }
                txtDosyaNo.Text = _cksKaydi.DosyaNo.ToString();
                txtBabaAdi.Text = _cksKaydi.BabaAdi;
                txtCepTelefon.Text = _cksKaydi.CepTelefonu;
                txtEvTelefon.Text = _cksKaydi.EvTelefonu;
                txtIsimSoyisim.Text = _cksKaydi.IsimSoyisim;
                dtpUpdateTarih.Value  = Convert.ToDateTime( _cksKaydi.KayitTarihi);
                txtTc.Text = _cksKaydi.Tc;
                cmboxMahalleKoy.Text = _cksKaydi.KoyMahalle;
            });
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            Utilities.ErrorHandle._try(() =>
            {
                string tc = txtTcSearch.Text;
                if (tc.Length != 11) throw new Exception("Tc Numarasını kontrol ediniz.");
                var ciftci = _ciftcilerManager.GetByTc(tc);
                if (ciftci == null)
                {
                    CiftciForm form = new CiftciForm(tc);
                    form.ShowDialog();
                    //form kapandıktan sonra işleme devam edecek..
                    var kaydedilenciftci = _ciftcilerManager.GetByTc(tc);
                    Cks cks = new Cks();
                    cks.KayitTarihi = dtpAddTarih.Value.ToShortDateString();
                    cks.DosyaNo = Convert.ToInt32(txtAddDosyaNo.Text);
                    cks.BabaAdi = kaydedilenciftci.FatherName;
                    cks.CepTelefonu = kaydedilenciftci.MobilePhone;
                    cks.EvTelefonu = kaydedilenciftci.HomePhone;
                    cks.IsimSoyisim = kaydedilenciftci.NameSurname;
                    cks.KoyMahalle = kaydedilenciftci.Village;
                    cks.Tc = tc;
                    returnValue = _cksManager.Add(cks);
                    if (returnValue == 1)
                    {
                        dgwListe.DataSource = _cksManager.GetAll();
                        Utilities.Mesaj.MessageBoxInformation("Kaydettiğiniz çiftçi ÇKS listesine kaydedildi.");
                    }
                }
                else
                {
                    Cks cks = new Cks();
                    cks.KayitTarihi = dtpAddTarih.Value.ToShortDateString();
                    cks.DosyaNo =Convert.ToInt32( txtAddDosyaNo.Text);
                    cks.BabaAdi = ciftci.FatherName;
                    cks.CepTelefonu = ciftci.MobilePhone;
                    cks.EvTelefonu = ciftci.HomePhone;
                    cks.IsimSoyisim = ciftci.NameSurname;
                    cks.KoyMahalle = ciftci.Village;
                    cks.Tc = tc;
                    returnValue = _cksManager.Add(cks);
                    if (returnValue == 1)
                    {
                        dgwListe.DataSource = _cksManager.GetAll();
                        Utilities.Mesaj.MessageBoxInformation("Kayıt işlemi başarılı");
                    }
                }
            });
        }
        private void UpdateFormFill(Cks cksKaydi)
        {
            txtDosyaNo.Text = cksKaydi.DosyaNo.ToString();
            txtBabaAdi.Text = cksKaydi.BabaAdi;
            txtCepTelefon.Text = cksKaydi.CepTelefonu;
            txtEvTelefon.Text = cksKaydi.EvTelefonu;
            txtIsimSoyisim.Text = cksKaydi.IsimSoyisim;
            dtpUpdateTarih.Value =Convert.ToDateTime( cksKaydi.KayitTarihi);
            txtTc.Text = cksKaydi.Tc;
            cmboxMahalleKoy.Text = cksKaydi.KoyMahalle;
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_cksKaydi.Id == -1) throw new Exception("Listeden silmek istediğiniz kaydı seçiniz.");
                int result = _cksManager.Delete(_cksKaydi);
                if (result == 1)
                {
                    _cksKaydi = new Cks() { Id = -1 };
                    dgwListe.DataSource = _cksManager.GetAll();
                    txtBabaAdi.Text = "";
                    txtCepTelefon.Text = "";
                    txtDosyaNo.Text = "";
                    txtEvTelefon.Text = "";
                    txtIsimSoyisim.Text = "";
                    dtpUpdateTarih.Value = DateTime.Now;
                    txtTc.Text = "";
                    cmboxMahalleKoy.Text = "";
                    Utilities.Mesaj.MessageBoxInformation("Silme işlemi başarılı");
                }
            });
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_cksKaydi.Id == -1) throw new Exception("Listeden güncellemek istediğiniz kaydı seçiniz.");
                _cksKaydi.DosyaNo = Convert.ToInt32(txtDosyaNo.Text);
                _cksKaydi.Tc = txtTc.Text;
                _cksKaydi.IsimSoyisim = txtIsimSoyisim.Text;
                _cksKaydi.BabaAdi = txtBabaAdi.Text;
                _cksKaydi.KoyMahalle = cmboxMahalleKoy.Text;
                _cksKaydi.CepTelefonu = txtCepTelefon.Text;
                _cksKaydi.EvTelefonu = txtEvTelefon.Text;
                _cksKaydi.KayitTarihi = dtpUpdateTarih.Value.ToShortDateString();
                int result = _cksManager.Update(_cksKaydi);
                if (result == 1)
                {
                    dgwListe.DataSource = _cksManager.GetAll();
                    Utilities.Mesaj.MessageBoxInformation("Güncelleme işlemi başarılı");
                    UpdateFormFill(_cksKaydi);
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
                var path = location + @"\CksListesi.xlsx";
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
                        var listCks = _cksManager.GetAll().OrderBy(I => I.DosyaNo).ToList();
                        Utilities.Json.Backup(listCks, "Cks", path);
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
            txtAddDosyaNo.Text = _cksManager.DosyaNoFactory().ToString();
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
                if (_cksKaydi.Id == -1) throw new Exception("Listeden çiftçi seçiniz.");
                Form _form = new SertifikaliTohumForm(_cksKaydi.Tc);
                _form.ShowDialog();
            });
        }
        private void btnYemBitkileri_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_cksKaydi.Id == -1) throw new Exception("Listeden çiftçi seçiniz.");
                Form _form = new YemBitkileriForm(_cksKaydi.Tc);
                _form.ShowDialog();
            });
        }
        private void btnHububatFarkOdemesi_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_cksKaydi.Id == -1) throw new Exception("Listeden çiftçi seçiniz.");
                Form _form = new HububatFarkOdemesiForm(_cksKaydi);
                _form.ShowDialog();
            });
        }
        private void btnListeler_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                Form _form = new DestekListesiForm();
                _form.ShowDialog();
            });
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Database.Concrete.Sqlite.DatabaseDb db = new Database.Concrete.Sqlite.DatabaseDb();
            Utilities.Mesaj.MessageBoxInformation($"Database Info: {db._connectionString}");
        }
    }
}
