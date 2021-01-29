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

        public SertifikaliTohumForm()
        {
            InitializeComponent();
            _bll = new SertifikaliTohumManager();
            _cksDal = new CksDal();
        }

        private void dgwListe_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void SertifikaliTohumForm_Load(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {  //datagridviewdatasource will code...
                TumListe();
                dgwListe.Tag = 0;
                int KayitSayisi = dgwListe.RowCount;
                this.Text = $"Sertifikalı Tohum Kayıt Formu  -  Toplam Kayıt Sayısı: {KayitSayisi}";
            });

        }

        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int rowIndex = dgwListe.CurrentRow.Index;
                //datagrid tag içerisinde ıd tutuyoruz.
                dgwListe.Tag = dgwListe.Rows[rowIndex].Cells["Id"].Value;
                st = _bll.GetById((int)dgwListe.Tag);
                InsertToFormForUpdateEntity(st);
            });


        }

        private void InsertToFormForUpdateEntity(SertifikaliTohum st)
        {
            txtSertifikaDosyaNo.Text = st.SertifikaliDosyaNo.ToString();
            txtMuracaatTarihi.Text = st.MuracaatTarihi;
            txtSertifikaNo.Text = st.SertifikaNo;
            txtFaturaNo.Text = st.FaturaNo;
            txtFaturaTarihi.Text = st.FaturaTarihi;
            txtFirmaAdi.Text = st.FirmaAdi;
            txtUrun.Text = st.Urun;
            txtUrunCesidi.Text = st.UrunCesidi;
            txtMiktari.Text = st.Miktari;
            txtBirimFiyati.Text = st.BirimFiyati;
            txtToplamMaliyet.Text = st.ToplamMaliyet;
        }

        private void btnTumListe_Click(object sender, EventArgs e)
        {
            TumListe();
        }

        private void TumListe()
        {
            Utilities.ErrorHandle._try(() => { dgwListe.DataSource = _bll.GetAll(); });

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
            string tc = txtNewTcNo.Text;
            st = new SertifikaliTohum();
            var ciftci = _cksDal.Get(tc);
            if (ciftci != null || ciftci.Id != 0)
            {
                st.CksId = ciftci.Id;
                st.MuracaatTarihi = txtNewMuracaatTarihi.Text;
                st.SertifikaliDosyaNo = string.IsNullOrEmpty(txtNewSertifikaliDosyaNo.Text) ? 0 : Convert.ToInt32(txtNewSertifikaliDosyaNo.Text);
                st.SertifikaNo = txtNewSertifikaNo.Text;
                st.FaturaNo = txtNewFaturaNo.Text;
                st.FaturaTarihi = txtNewFaturaTarihi.Text;
                st.FirmaAdi = txtNewFirmaAdi.Text;
                st.Urun = txtNewUrun.Text;
                st.UrunCesidi = txtNewUrunCesidi.Text;
                st.BirimFiyati = txtNewBirimFiyati.Text;
                st.Miktari = txtNewMiktari.Text;
                st.ToplamMaliyet = txtNewToplamMaliyet.Text;
            }

            return st;
        }

        private void btnTcAra_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                string tc = txtNewTcNo.Text;
                var ciftci = _cksDal.Get(tc);
                if (ciftci == null || ciftci.Id == 0)
                    throw new Exception("Aradığınız tc Cks kayıt defteri içerisinde yoktur.");
                else
                    lblIsim.Text = $"{ciftci.IsimSoyisim}\nCks Dosya No:{ciftci.DosyaNo}";
            });

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                st = _bll.GetById((int)dgwListe.Tag);
                st.SertifikaliDosyaNo = Convert.ToInt32(txtSertifikaDosyaNo.Text);
                st.MuracaatTarihi = txtMuracaatTarihi.Text;
                st.SertifikaNo = txtSertifikaNo.Text;
                st.FaturaNo = txtFaturaNo.Text;
                st.FaturaTarihi = txtFaturaTarihi.Text;
                st.FirmaAdi = txtFirmaAdi.Text;
                st.Urun = txtUrun.Text;
                st.UrunCesidi = txtUrunCesidi.Text;
                st.Miktari = txtMiktari.Text;
                st.BirimFiyati = txtBirimFiyati.Text;
                st.ToplamMaliyet = txtToplamMaliyet.Text;

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
                st = _bll.GetById((int)dgwListe.Tag);
                int result = _bll.Delete(st);
                if (result > 0)
                {
                    TumListe();
                    Utilities.Mesaj.MessageBoxInformation("Kayıt Silindi.");
                    ClearFormAfterDelete();
                }
            });

        }

        private void ClearFormAfterDelete()
        {
            txtSertifikaDosyaNo.Text = "";
            txtMuracaatTarihi.Text = "";
            txtSertifikaNo.Text = "";
            txtFaturaNo.Text = "";
            txtFaturaTarihi.Text = "";
            txtFirmaAdi.Text = "";
            txtUrun.Text = "";
            txtUrunCesidi.Text = "";
            txtMiktari.Text = "";
            txtBirimFiyati.Text = "";
            txtToplamMaliyet.Text = "";
        }

        private void btnKayitGetir_Click(object sender, EventArgs e)
        {
            string tc = txtSearchTcNo.Text;
            if (tc.Length==11)
            {
                dgwListe.DataSource= _bll.Get(tc);
            }
            else
            {
                Utilities.Mesaj.MessageBoxWarning("Tc Numarasını kontrol ediniz.");
            }
        }
    }
}
