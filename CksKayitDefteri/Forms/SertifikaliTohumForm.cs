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
    public partial class SertifikaliTohumForm : Form
    {
        SertifikaliTohumManager _bll;
        CksDal _cksDal;
        SertifikaliTohum st;
        Cks _cksKayit;
        UrunManager _urunManager;
        FirmaManager _firmaManager;
        public SertifikaliTohumForm(string TcNo)
        {
            InitializeComponent();
            _bll = new SertifikaliTohumManager();
            _cksDal = new CksDal();
            _cksKayit = _cksDal.Get(TcNo);
            _urunManager = new UrunManager();

            _firmaManager = new FirmaManager();
        }
        private void SertifikaliTohumForm_Load(object sender, EventArgs e)
        {


            Utilities.ErrorHandle._try(() =>
            {
                lblCiftciBilgi.Text = $"{_cksKayit.Tc} ---> {_cksKayit.IsimSoyisim} ";
                TumListe();
                Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });
                dgwListe.Tag = 0;

                //comboBox ayarları
                Utilities.FormPreferences.ComboxSetUrun(cmbNewUrunAdi, _urunManager.GetAll());
                Utilities.FormPreferences.ComboxSetUrun(cmbUpdateUrun, _urunManager.GetAll());
                Utilities.FormPreferences.ComboxSetFirma(cmbNewFirmaAdi, _firmaManager.GetAll());
                Utilities.FormPreferences.ComboxSetFirma(cmbUpdateFirmaAdi, _firmaManager.GetAll());

                this.Text = $"Sertifikalı Tohum Kayıt Formu  -  Toplam Kayıt Sayısı: {dgwListe.RowCount}";
                ComboBoxFillData();

            });

        }
        private void dgwListe_DataSourceChanged(object sender, EventArgs e)
        {
            this.Text = $"Sertifikalı Tohum Kayıt Formu  -  Toplam Kayıt Sayısı: {dgwListe.RowCount}";

        }



        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int rowIndex = dgwListe.CurrentRow.Index;
                //datagrid tag içerisinde ıd tutuyoruz.
                var id = dgwListe.Rows[rowIndex].Cells[0].Value;
                dgwListe.Tag = Convert.ToInt32(id);
                st = _bll.GetAll().Where(I => I.Id == Convert.ToInt32(id)).FirstOrDefault();
                InsertToFormForUpdateEntity(st);
            });


        }

        private void InsertToFormForUpdateEntity(SertifikaliTohum st)
        {

            txtUpdateDosyaNo.Text = st.SertifikaliDosyaNo.ToString();
            txtUpdateMuracaatTarihi.Text = st.MuracaatTarihi;
            txtUpdateSertifikaNo.Text = st.SertifikaNo;
            txtUpdateFaturaNo.Text = st.FaturaNo;
            txtUpdateFaturaTarihi.Text = st.FaturaTarihi;
            //cmbUpdateFirmaAdi.Text = _firmaManager.GetAll().Where(I => I.Id == st.FirmaId).FirstOrDefault().FirmaAdi;
            cmbUpdateFirmaAdi.SelectedValue = st.FirmaId;

            //cmbUpdateUrun.Text = _urunManager.GetAll().Where(I => I.Id == st.Id).FirstOrDefault().UrunAdi;
            cmbUpdateUrun.SelectedValue = st.UrunId;
            txtUpdateMiktarı.Text = st.Miktari;
            txtUpdateBirimFiyati.Text = st.BirimFiyati;

            txtUpdateNot.Text = st.Not;

        }

        private void ComboBoxFillData()
        {
            cmbUpdateUrun.DataSource = _urunManager.GetAll();
            cmbUpdateUrun.DisplayMember = "UrunAdi";
            cmbUpdateFirmaAdi.DataSource = _firmaManager.GetAll();
            cmbUpdateFirmaAdi.DisplayMember = "FirmaAdi";
        }

        private void TumListe()
        {
            Utilities.ErrorHandle._try(() => { dgwListe.DataSource = _bll.GetAllDataTable(_cksKayit.Tc); });

        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                var entity = CreateEntityForAdd();
                _bll.Add(entity);
                TumListe();
            });


        }
        SertifikaliTohum CreateEntityForAdd()
        {
            st = new SertifikaliTohum();

            st.CksId = _cksKayit.Id;
            st.MuracaatTarihi = txtNewMuracaatTarihi.Text;
            st.SertifikaliDosyaNo = string.IsNullOrEmpty(txtNewDosyaNo.Text) ? 0 : Convert.ToInt32(txtNewDosyaNo.Text);
            st.SertifikaNo = txtNewSertifikaNo.Text;
            st.FaturaNo = txtNewFaturaNo.Text;
            st.FaturaTarihi = txtNewFaturaTarihi.Text;

            st.FirmaId = Convert.ToInt32(cmbNewFirmaAdi.SelectedValue);

            st.UrunId = Convert.ToInt32(cmbNewUrunAdi.SelectedValue);
            st.Miktari = txtNewMiktari.Text;

            st.BirimFiyati = txtNewBirimFiyati.Text;


            return st;
        }



        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
               
                st = _bll.GetAll().Where(I => I.Id == Convert.ToInt32((int)dgwListe.Tag)).FirstOrDefault();

                st.SertifikaliDosyaNo = Convert.ToInt32(txtUpdateDosyaNo.Text);
                st.MuracaatTarihi = txtUpdateMuracaatTarihi.Text;
                st.SertifikaNo = txtUpdateSertifikaNo.Text;
                st.FaturaNo = txtUpdateFaturaNo.Text;
                st.FaturaTarihi = txtUpdateFaturaTarihi.Text;
                st.FirmaId = Convert.ToInt32(cmbUpdateFirmaAdi.SelectedValue);

                st.UrunId = Convert.ToInt32(cmbUpdateUrun.SelectedValue);

                st.Miktari = txtUpdateMiktarı.Text;
                st.BirimFiyati = txtUpdateBirimFiyati.Text;
                st.Not = txtUpdateNot.Text;

                int result = _bll.Update(st);
                if (result > 0)
                {
                    TumListe();

                    Utilities.Mesaj.MessageBoxInformation("Güncellme işlemi başarılı");
                }
            });


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if ((int)dgwListe.Tag == 0) throw new Exception("Silinecek öğe seçiniz.");

                Utilities.Question.IfYes(() =>
                {
                    st = _bll.GetById((int)dgwListe.Tag);
                    int result = _bll.Delete(st);
                    if (result > 0)
                    {
                        TumListe();
                        Utilities.Mesaj.MessageBoxInformation("Kayıt Silindi.");
                        ClearFormAfterDelete();
                        dgwListe.Tag = 0;
                    }
                }, "Kaydı silmek istiyor munuz?");

            });

        }

        private void ClearFormAfterDelete()
        {
            txtUpdateDosyaNo.Text = "";
            txtUpdateMuracaatTarihi.Text = "";
            txtUpdateSertifikaNo.Text = "";
            txtUpdateFaturaNo.Text = "";
            txtUpdateFaturaTarihi.Text = "";
            cmbUpdateFirmaAdi.Text = "";
            cmbUpdateUrun.Text = "";
            txtUpdateMiktarı.Text = "";
            txtUpdateBirimFiyati.Text = "";
            txtUpdateNot.Text = "";
        }


    }
}
