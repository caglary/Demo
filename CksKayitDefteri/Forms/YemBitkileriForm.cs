using App.Business;
using CksKayitDefteri.Business;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class YemBitkileriForm : Form
    {
        Cks _cksKayit;
        YemBitkileri _yemKayit;
        CksDal _cksDal;
        YemBitkileriManager _yemManager;
        UrunManager _urunManager;
        public YemBitkileriForm(string TcNo)
        {
            InitializeComponent();
            _yemManager = new YemBitkileriManager();
            _cksDal = new CksDal();
            _cksKayit = _cksDal.Get(TcNo);
            _urunManager = new UrunManager();
        }
        private void YemBitkileriForm_Load(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FromSettings(this);

            this.Text = $"Yem Bitkileri Destekleme Başvuru Formu - ({_cksKayit.IsimSoyisim})";
            Utilities.FormPreferences.ComboxSetUrun(cmbAddUrun, _urunManager.GetAll());
            Utilities.FormPreferences.ComboxSetUrun(cmbUpdateUrun, _urunManager.GetAll());

            cmbAddMahalle.DataSource = Utilities.RequiredLists.VillageNameList();
            cmbUpdateMahalle.DataSource = Utilities.RequiredLists.VillageNameList();

            AllList();
            Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });
        }
        private void AllList()
        {
            dgwListe.DataSource = _yemManager.GetAllDataTable(_cksKayit.Id);

            //dgwListe.DataSource = _yemManager.GetByCiftci(_cksKayit.Id);
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                YemBitkileri yemBitkisiKayit = new Entities.Concrete.YemBitkileri();
                yemBitkisiKayit.CksId = _cksKayit.Id;
                yemBitkisiKayit.UrunId = Convert.ToInt32(cmbAddUrun.SelectedValue);
                yemBitkisiKayit.YemDosyaNo = Convert.ToInt32(txtAddDosyaNo.Text);
                yemBitkisiKayit.MuracaatTarihi = txtAddMuracaatTarihi.Text;
                yemBitkisiKayit.EkilisYili = txtAddEkilisYili.Text;
                yemBitkisiKayit.AraziMahalle = cmbAddMahalle.Text;
                yemBitkisiKayit.Ada = txtAddAda.Text;
                yemBitkisiKayit.Parsel = txtAddParsel.Text;
                yemBitkisiKayit.MuracaatAlani = txtAddMuracaatAlani.Text;
                yemBitkisiKayit.TespitEdilenAlan = txtAddTespitEdilenAlan.Text;
                yemBitkisiKayit.KontrolTarihi = txtAddKontroltarihi.Text;
                yemBitkisiKayit.KontrolEdenler = txtAddKontrolEdenler.Text;
                yemBitkisiKayit.Not = txtAddNot.Text;
                int result = _yemManager.Add(yemBitkisiKayit);
                if (result > 0) Utilities.Mesaj.MessageBoxInformation("Kayıt işleminiz başarılı");
                AllList();
            });
        }



        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int rowIndex = dgwListe.CurrentCell.RowIndex;
                var id = dgwListe.Rows[rowIndex].Cells[0].Value;
                var yemkayit = _yemManager.GetAll().Where(I => I.Id == Convert.ToInt32(id)).FirstOrDefault();
                _yemKayit = yemkayit;
                txtUpdateDosyaNo.Text = yemkayit.YemDosyaNo.ToString();
                txtUpdateMuracaatTarihi.Text = yemkayit.MuracaatTarihi;
                cmbUpdateUrun.SelectedValue = yemkayit.UrunId;
                txtUpdateEkilisYili.Text = yemkayit.EkilisYili;
                cmbUpdateMahalle.Text = yemkayit.AraziMahalle;
                txtUpdateAda.Text = yemkayit.Ada;
                txtUpdateParsel.Text = yemkayit.Parsel;
                txtUpdateMuracaatAlani.Text = yemkayit.MuracaatAlani;
                txtUpdateTespitEdilenAlan.Text = yemkayit.TespitEdilenAlan;
                txtUpdateKontrolTarihi.Text = yemkayit.KontrolTarihi;
                txtUpdateKontrolEdenler.Text = yemkayit.KontrolEdenler;
                txtUpdateNot.Text = yemkayit.Not;
            });

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_yemKayit != null)
                {
                    _yemKayit.YemDosyaNo = Convert.ToInt32(txtUpdateDosyaNo.Text);
                    _yemKayit.MuracaatTarihi = txtUpdateMuracaatTarihi.Text;
                    _yemKayit.UrunId = (int)cmbUpdateUrun.SelectedValue;
                    _yemKayit.EkilisYili = txtUpdateEkilisYili.Text;
                    _yemKayit.AraziMahalle = cmbUpdateMahalle.Text;
                    _yemKayit.Ada = txtUpdateAda.Text;
                    _yemKayit.Parsel = txtUpdateParsel.Text;
                    _yemKayit.MuracaatAlani = txtUpdateMuracaatAlani.Text;
                    _yemKayit.TespitEdilenAlan = txtUpdateTespitEdilenAlan.Text;
                    _yemKayit.KontrolTarihi = txtUpdateKontrolTarihi.Text;
                    _yemKayit.KontrolEdenler = txtUpdateKontrolEdenler.Text;
                    _yemKayit.Not = txtUpdateNot.Text;

                    int result = _yemManager.Update(_yemKayit);
                    if (result > 0) Utilities.Mesaj.MessageBoxInformation("Güncelleme işlemi başarılı");
                    AllList();
                }
                else throw new Exception("Listeden kayıt seçiniz.");
            });


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_yemKayit != null)
                {
                    Utilities.Question.IfYes(() =>
                    {
                        int result = _yemManager.Delete(_yemKayit);
                        if (result > 0)
                        {

                            txtUpdateDosyaNo.Text = "";
                            txtUpdateMuracaatTarihi.Text = "";
                            cmbUpdateUrun.Text = "";
                            txtUpdateEkilisYili.Text = "";
                            cmbUpdateMahalle.Text = "";
                            txtUpdateAda.Text = "";
                            txtUpdateParsel.Text = "";
                            txtUpdateMuracaatAlani.Text = "";
                            txtUpdateTespitEdilenAlan.Text = "";
                            txtUpdateKontrolTarihi.Text = "";
                            txtUpdateKontrolEdenler.Text = "";
                            txtUpdateNot.Text = "";
                            AllList();

                            Utilities.Mesaj.MessageBoxInformation("Silme işlemi başarılı");
                            _yemKayit = null;

                        }
                    },"Kaydı silmek istiyor musunuz?");


                }
                else throw new Exception("Listeden kayıt seçiniz.");
            });
        }


    }
}
