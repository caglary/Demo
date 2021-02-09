using App.Business;
using CksKayitDefteri.Business;
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
    public partial class DestekListesiForm : Form
    {
        YemBitkileriManager _yemManager;
        SertifikaliTohumManager _sertifikaliTohumManager;
        HububatFarkOdemesiManager _hububatManager;
        BasilanButon _basilanButon;
        DataTable _yemListe;
        DataTable _hububatListe;
        DataTable _sertifikaliListe;
        string queryYem = "SELECT Cks.DosyaNo, Cks.Tc , Cks.IsimSoyisim, YemBitkileri.YemDosyaNo, YemBitkileri.AraziMahalleKoy, YemBitkileri.Ada, YemBitkileri.Parsel, Urunler.UrunAdi, YemBitkileri.MuracaatAlani, YemBitkileri.EkilisYili, YemBitkileri.TespitEdilenAlan, YemBitkileri.KontrolTarihi, YemBitkileri.KontrolEdenler, YemBitkileri.Note, YemBitkileri.MuracaatTarihi  from YemBitkileri INNER join Cks on YemBitkileri.CksId=Cks.Id INNER join Urunler on YemBitkileri.UrunId=Urunler.Id ORDER by YemBitkileri.YemDosyaNo DESC";
        string queryHububat = "SELECT cks.DosyaNo, cks.Tc, Cks.IsimSoyisim, HububatFarkOdemesi.HububatDosyaNo, Firmalar.FirmaAdi, HububatFarkOdemesi.FaturaTarih, HububatFarkOdemesi.FaturaNo, urunler.UrunAdi, HububatFarkOdemesi.Miktar, HububatFarkOdemesi.Fiyat, HububatFarkOdemesi.Tutar, HububatFarkOdemesi.Note from HububatFarkOdemesi INNER join Cks on Cks.Id=HububatFarkOdemesi.CksId inner join Firmalar on firmalar.Id=HububatFarkOdemesi.FirmaId inner join urunler on Urunler.Id=HububatFarkOdemesi.UrunId order by HububatFarkOdemesi.HububatDosyaNo DESC";
        string querySertifikali = "SELECT cks.DosyaNo, cks.Tc, cks.IsimSoyisim, SertifikaliTohum.SertifikaliDosyaNo, SertifikaliTohum.SertifikaNo, Firmalar.FirmaAdi, SertifikaliTohum.FaturaNo, SertifikaliTohum.FaturaTarihi, Urunler.UrunAdi, SertifikaliTohum.Miktari, SertifikaliTohum.BirimFiyati, SertifikaliTohum.ToplamMaliyet, SertifikaliTohum.Note, SertifikaliTohum.MuracaatTarihi from SertifikaliTohum INNER join cks on cks.Id=SertifikaliTohum.CksId inner join firmalar on firmalar.Id=SertifikaliTohum.FirmaId inner join Urunler on Urunler.Id=SertifikaliTohum.UrunId order by SertifikaliTohum.SertifikaliDosyaNo DESC";
        public DestekListesiForm()
        {
            InitializeComponent();
            _yemManager = new YemBitkileriManager();
            _sertifikaliTohumManager = new SertifikaliTohumManager();
            _hububatManager = new HububatFarkOdemesiManager();
            _yemListe = _yemManager.GetAllByQuery(queryYem);
            _hububatListe = _hububatManager.GetAllByQuery(queryHububat);
            _sertifikaliListe = _sertifikaliTohumManager.GetAllByQuery(querySertifikali);
        }
        private void DestekListesiForm_Load(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FromSettings(this);
            lblBaslik.BackColor = btnYem.BackColor;
            _basilanButon = BasilanButon.Yem;
            lblBaslik.Text = "Yem Bitkisi Başvuru Listesi";
            dgwListe.DataSource = _yemListe;
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dgwListe.Rows.Count.ToString()}";
        }
        private void btnYem_Click(object sender, EventArgs e)
        {
            lblBaslik.BackColor = btnYem.BackColor;
            _basilanButon = BasilanButon.Yem;
            Button btn = (Button)sender;
            lblBaslik.Text = btn.Text + " Listesi";
            dgwListe.DataSource = _yemListe;
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dgwListe.Rows.Count.ToString()}";
        }
        private void btnHububat_Click(object sender, EventArgs e)
        {
            lblBaslik.BackColor = btnHububat.BackColor;
            Button btn = (Button)sender;
            lblBaslik.Text = btn.Text + " Listesi";
            _basilanButon = BasilanButon.Hububat;
            dgwListe.DataSource = _hububatListe;
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dgwListe.Rows.Count.ToString()}";
        }
        private void btnSertifikali_Click(object sender, EventArgs e)
        {
            lblBaslik.BackColor = btnSertifikali.BackColor;
            Button btn = (Button)sender;
            lblBaslik.Text = btn.Text + " Listesi";
            _basilanButon = BasilanButon.Sertfifikali;
            dgwListe.DataSource = _sertifikaliListe;
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dgwListe.Rows.Count.ToString()}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = Utilities.FolderBrowser.Path();
            switch (_basilanButon)
            {
                case BasilanButon.Yem:
                    path = path + "\\Yem_Bitkileri_Destek_Basvuru_Listesi.xlsx";
                    Utilities.ExcelExport.GenerateExcel(_yemListe, path);
                    break;
                case BasilanButon.Hububat:
                    path = path + "\\Hububat_Fark_Odemesi_Destek_Basvuru_Listesi.xlsx";
                    Utilities.ExcelExport.GenerateExcel(_hububatListe, path);
                    break;
                case BasilanButon.Sertfifikali:
                    path = path + "\\Sertifikali_Tohum_Destek_Basvuru_Listesi.xlsx";
                    Utilities.ExcelExport.GenerateExcel(_sertifikaliListe, path);
                    break;
                default:
                    Utilities.Mesaj.MessageBoxError("Herhangi bir liste seçimi yapılamadı.");
                    break;
            }
        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string searchValue = textBox.Text.ToUpper();
            DataView dw;
            switch (_basilanButon)
            {
                case BasilanButon.Yem:
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        dw = new DataView(_yemListe);
                        dw.RowFilter = "[IsimSoyisim] Like '" + searchValue + "%'";
                        dgwListe.DataSource = dw;
                    }
                    else
                    {
                        dgwListe.DataSource = _yemListe;
                    }
                    break;
                case BasilanButon.Hububat:
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        dw = new DataView(_hububatListe);
                        dw.RowFilter = "[IsimSoyisim] Like '" + searchValue + "%'";
                        dgwListe.DataSource = dw;
                    }
                    else
                    {
                        dgwListe.DataSource = _hububatListe;
                    }
                    break;
                case BasilanButon.Sertfifikali:
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        dw = new DataView(_sertifikaliListe);
                        dw.RowFilter = "[IsimSoyisim] Like '" + searchValue + "%'";
                        dgwListe.DataSource = dw;
                    }
                    else
                    {
                        dgwListe.DataSource = _sertifikaliListe;
                    }
                    break;
            }
        }
    }
    enum BasilanButon
    {
        Yem, Sertfifikali, Hububat, Basilmadi
    }
}
