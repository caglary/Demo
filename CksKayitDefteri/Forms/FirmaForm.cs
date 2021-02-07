using App.Business;
using Entities.Concrete;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class FirmaForm : Form
    {
        FirmaManager _bll;
        Firma _firma;
        public FirmaForm()
        {
            InitializeComponent();
            _bll = new FirmaManager();

        }

        private void FirmaForm_Load(object sender, EventArgs e)
        {
            GetAllList();
            Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });
            dgwListe.Tag = 0;
            dgwListe.Columns[1].HeaderText = "Firma/Kişi Adı";
            dgwListe.Columns[2].HeaderText = "Vergi/TC No";
            dgwListe.Columns[3].HeaderText = "Not";


        }

        private void GetAllList()
        {
            dgwListe.DataSource = _bll.GetAll();
        }

        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgwListe.CurrentRow.Index;
            //datagrid tag içerisinde ıd tutuyoruz.
            var id = dgwListe.Rows[rowIndex].Cells[0].Value;
            dgwListe.Tag = Convert.ToInt32(id);
            _firma = _bll.GetAll().Where(I => I.Id == (int)dgwListe.Tag).FirstOrDefault();
            txtUpdateCompanyName.Text = _firma.FirmaAdi;
            txtUpdateTaxNumber.Text = _firma.VergiNo;
            txtUpdateNote.Text = _firma.Not;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (!string.IsNullOrEmpty(txtAddCompanyName.Text) && !string.IsNullOrEmpty(txtAddTaxNumber.Text))
                {
                    Firma f = new Firma();
                    f.FirmaAdi = txtAddCompanyName.Text;
                    f.VergiNo = txtAddTaxNumber.Text;
                    f.Not = txtAddNote.Text;
                    int result = _bll.Add(f);
                    if (result == 1)
                    {
                        txtAddCompanyName.Text = "";
                        txtAddNote.Text = "";
                        txtAddTaxNumber.Text = "";
                        GetAllList();

                        Utilities.Mesaj.MessageBoxInformation("İşleminiz başarı ile gerçekleşti.");

                    }
                }
                else Utilities.Mesaj.MessageBoxWarning("Gerekli alanları doldurunuz.");
            });



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_firma != null)
                {
                    _firma.FirmaAdi = txtUpdateCompanyName.Text;
                    _firma.VergiNo = txtUpdateTaxNumber.Text;
                    _firma.Not = txtUpdateNote.Text;
                    int result = _bll.Update(_firma);
                    if (result == 1)
                    {
                        txtUpdateCompanyName.Text = "";
                        txtUpdateNote.Text = "";
                        txtUpdateTaxNumber.Text = "";
                        GetAllList();

                        Utilities.Mesaj.MessageBoxInformation("İşleminiz başarı ile gerçekleşti.");
                        _firma = null;


                    }
                }
                else Utilities.Mesaj.MessageBoxWarning("Listeden Kişi/Firma seçiniz.");

            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_firma != null)
                {

                    int result = _bll.Delete(_firma);
                    if (result == 1)
                    {
                        txtUpdateCompanyName.Text = "";
                        txtUpdateNote.Text = "";
                        txtUpdateTaxNumber.Text = "";
                        GetAllList();

                        Utilities.Mesaj.MessageBoxInformation("İşleminiz başarı ile gerçekleşti.");
                        _firma = null;


                    }
                }
                else Utilities.Mesaj.MessageBoxWarning("Listeden Kişi/Firma seçiniz.");

            });
        }
    }
}
