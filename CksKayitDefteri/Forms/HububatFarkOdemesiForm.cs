using App.Business;
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
    public partial class HububatFarkOdemesiForm : Form
    {
        Cks _ciftci;
        UrunManager _urunManager;
        FirmaManager _firmaManager;
        //CksManager _cksManager;
        HububatFarkOdemesiManager _bll;
        public HububatFarkOdemesiForm(Cks ciftci)
        {
            InitializeComponent();
            //_cksManager = new CksManager();
            _ciftci = ciftci;
            _bll = new HububatFarkOdemesiManager();
            _urunManager = new UrunManager();
            _firmaManager = new FirmaManager();
        }

        private void HububatFarkOdemesiForm_Load(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FromSettings(this);

            int id = _ciftci.Id;
            GetAllList();
            Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });
            Utilities.FormPreferences.ComboxSetUrun(cmbUrunAdi, _urunManager.GetAll());
            Utilities.FormPreferences.ComboxSetUrun(cmbUpdateUrunAdi, _urunManager.GetAll());
            Utilities.FormPreferences.ComboxSetFirma(cmbFirmaAdi, _firmaManager.GetAll());
            Utilities.FormPreferences.ComboxSetFirma(cmbUpdateFirmaAdi, _firmaManager.GetAll());
            dgwListe.Tag = 0;
            dgwListe.Columns[1].HeaderText = "Dosya No";
            dgwListe.Columns[2].HeaderText = "Fatura Tarihi";
            dgwListe.Columns[3].HeaderText = "Fatura No";
            dgwListe.Columns[4].HeaderText = "Ürün Adı";
            dgwListe.Columns[5].HeaderText = "Miktar";
            dgwListe.Columns[6].HeaderText = "Birim Fiyatı";
            dgwListe.Columns[7].HeaderText = "Toplam Tutar";


        }

        private void GetAllList()
        {
            dgwListe.DataSource = _bll.GetDataTable(_ciftci.Id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                HububatFarkOdemesi h = FormToEntityForAdd();
                if (h.CksId != 0)
                {
                    _bll.Add(h);
                    GetAllList();
                }




            });

        }

        private HububatFarkOdemesi FormToEntityForAdd()
        {
            HububatFarkOdemesi h = new HububatFarkOdemesi();

            if (string.IsNullOrEmpty(txtDosyaNo.Text) || string.IsNullOrEmpty(txtFaturaNo.Text) || string.IsNullOrEmpty(txtFaturaTarihi.Text) || string.IsNullOrEmpty(txtDosyaTeslimTarihi.Text) || string.IsNullOrEmpty(txtFiyat.Text) || string.IsNullOrEmpty(txtMiktar.Text))
            {
                throw new Exception("Form üzerindeki alanları hatalı doldurunuz.");

            }
            else
            {
                h.CksId = _ciftci.Id;
                h.HububatDosyaNo = Convert.ToInt32(txtDosyaNo.Text);
                h.FirmaId = (int)cmbFirmaAdi.SelectedValue;
                h.UrunId = (int)cmbUrunAdi.SelectedValue;
                h.FaturaNo = txtFaturaNo.Text;
                h.FaturaTarihi = txtFaturaTarihi.Text;
                h.MuracaatTarihi = txtDosyaTeslimTarihi.Text;
                h.Fiyat = txtFiyat.Text;
                h.Miktar = txtMiktar.Text;
                h.Not = txtNote.Text;


            }

            return h;
        }
        private HububatFarkOdemesi FormToEntityForUpdate()
        {
            HububatFarkOdemesi h = _bll.GetAll().Where(I => I.Id == Convert.ToInt32(dgwListe.Tag)).FirstOrDefault();


            h.HububatDosyaNo = Convert.ToInt32(txtUpdateDosyaNo.Text);
            h.FirmaId = (int)cmbUpdateFirmaAdi.SelectedValue;
            h.UrunId = (int)cmbUpdateUrunAdi.SelectedValue;
            h.FaturaNo = txtUpdateFaturaNo.Text;
            h.FaturaTarihi = txtUpdateFaturaTarihi.Text;
            h.MuracaatTarihi = txtUpdatedosyaTeslimTarihi.Text;
            h.Fiyat = txtUpdateFiyat.Text;
            h.Miktar = txtUpdateMiktar.Text;
            h.Not = txtUpdateNote.Text;
            return h;
        }
        private void EntityToFormForUpdate()
        {
            HububatFarkOdemesi h = _bll.GetAll().Where(I => I.Id == Convert.ToInt32(dgwListe.Tag)).FirstOrDefault();
            if (h != null)
            {
                txtUpdateDosyaNo.Text = h.HububatDosyaNo.ToString();
                txtUpdatedosyaTeslimTarihi.Text = h.MuracaatTarihi;
                txtUpdateFaturaTarihi.Text = h.FaturaTarihi;
                txtUpdateFaturaNo.Text = h.FaturaNo;
                cmbUpdateFirmaAdi.SelectedValue = h.FirmaId;
              
                cmbUpdateUrunAdi.SelectedValue = h.UrunId;
                txtUpdateFiyat.Text = h.Fiyat;
                txtUpdateMiktar.Text = h.Miktar;
                txtUpdateNote.Text = h.Not;
            }


        }

        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgwListe.CurrentRow.Index;
            //datagrid tag içerisinde ıd tutuyoruz.
            var id = dgwListe.Rows[rowIndex].Cells[0].Value;
            dgwListe.Tag = Convert.ToInt32(id);
            EntityToFormForUpdate();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                HububatFarkOdemesi h = _bll.GetAll().Where(I => I.Id == Convert.ToInt32(dgwListe.Tag)).FirstOrDefault();
                if ((int)dgwListe.Tag != 0 && h != null)
                {
                    var updatedEntity = FormToEntityForUpdate();
                    _bll.Update(updatedEntity);
                    GetAllList();
                }
                else
                {
                    Utilities.Mesaj.MessageBoxWarning("Listeden güncellemek istediğiniz kaydı seçiniz.");
                }
            });

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HububatFarkOdemesi h = _bll.GetAll().Where(I => I.Id == Convert.ToInt32(dgwListe.Tag)).FirstOrDefault();
            if ((int)dgwListe.Tag != 0 && h != null)
            {
                Utilities.Question.IfYes(() =>
                {
                    var deletedEntity = FormToEntityForUpdate();
                    _bll.Delete(deletedEntity);

                    txtUpdateDosyaNo.Text = "";
                    txtUpdatedosyaTeslimTarihi.Text = "";
                    txtUpdateFaturaNo.Text = "";
                    txtUpdateFaturaTarihi.Text = "";
                    txtUpdateFiyat.Text = "";
                    txtUpdateMiktar.Text = "";
                    txtUpdateNote.Text = "";

                    GetAllList();
                    dgwListe.Tag = 0;
                },$"{h.FaturaNo} fatura nolu kaydı silmek istiyor musunuz?");


            }
            else
            {
                Utilities.Mesaj.MessageBoxWarning("Listeden silmek istediğiniz kaydı seçiniz.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FormOpen("FirmaForm",new FirmaForm(), true);
            Utilities.FormPreferences.ComboxSetFirma(cmbFirmaAdi, _firmaManager.GetAll());
            Utilities.FormPreferences.ComboxSetFirma(cmbUpdateFirmaAdi, _firmaManager.GetAll());
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FormOpen("UrunForm", new UrunForm(), true);
            Utilities.FormPreferences.ComboxSetUrun(cmbUrunAdi, _urunManager.GetAll());
            Utilities.FormPreferences.ComboxSetUrun(cmbUpdateUrunAdi, _urunManager.GetAll());



        }

    }
}
