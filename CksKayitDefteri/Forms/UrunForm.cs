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
    public partial class UrunForm : Form
    {
        UrunManager _bll;
        Urun _urun;
        public UrunForm()
        {
            InitializeComponent();
            _bll = new UrunManager();
        }
        private void UrunForm_Load(object sender, EventArgs e)
        {
            GetAllList();
            Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });
            dgwListe.Tag = 0;
            dgwListe.Columns[1].HeaderText = "Ürün Adı";
        }
        private void GetAllList()
        {
            dgwListe.DataSource = _bll.GetAll();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (!string.IsNullOrEmpty(txtAddProductName.Text))
                {
                    Urun urun = new Urun();
                    urun.UrunAdi = txtAddProductName.Text;
                    int result = _bll.Add(urun);
                    if (result == 1)
                    {
                        txtAddProductName.Text = "";
                        GetAllList();
                        Utilities.Mesaj.MessageBoxInformation("İşleminiz başarı ile gerçekleşti.");
                    }
                }
                else Utilities.Mesaj.MessageBoxWarning("Gerekli alanları doldurunuz.");
            });
        }
        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgwListe.CurrentRow.Index;
            //datagrid tag içerisinde ıd tutuyoruz.
            var id = dgwListe.Rows[rowIndex].Cells[0].Value;
            dgwListe.Tag = Convert.ToInt32(id);
            _urun = _bll.GetAll().Where(I => I.Id == (int)dgwListe.Tag).FirstOrDefault();
            txtUpdateProductName.Text = _urun.UrunAdi;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_urun != null)
                {
                    _urun.UrunAdi = txtUpdateProductName.Text;
                    int result = _bll.Update(_urun);
                    if (result == 1)
                    {
                        txtUpdateProductName.Text = "";
                        GetAllList();
                        Utilities.Mesaj.MessageBoxInformation("İşleminiz başarı ile gerçekleşti.");
                        _urun = null;
                    }
                }
                else Utilities.Mesaj.MessageBoxWarning("Listeden ürün seçiniz.");
            });
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (_urun != null)
                {
                    int result = _bll.Delete(_urun);
                    if (result == 1)
                    {
                        txtUpdateProductName.Text = "";
                        GetAllList();
                        Utilities.Mesaj.MessageBoxInformation("İşleminiz başarı ile gerçekleşti.");
                        _urun = null;
                    }
                }
                else Utilities.Mesaj.MessageBoxWarning("Listeden ürün seçiniz.");
            });
        }
    }
}
