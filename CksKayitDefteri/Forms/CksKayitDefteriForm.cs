﻿using App.Business;
using Entities.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class CksKayitDefteriForm : Form
    {
        ServiceCks2020 serviceCks2020;
        ServiceCiftciler serviceCiftciler;
        
        static Cks2020 ciftci = new Cks2020() { Id = -1 };
        public CksKayitDefteriForm()
        {
            InitializeComponent();
            serviceCks2020 = new ServiceCks2020();
            serviceCiftciler = new ServiceCiftciler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgwListe.DataSource = serviceCks2020.GetAll();
            Utilities.FormPreferences.DataGridSettings(dgwListe, new string[] { "Id" });
           
            formDoldur();
            cmboxMahalleKoy.DataSource = Utilities.RequiredLists.VillageNameList();
        }

        private void dgwListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int index = dgwListe.CurrentCell.RowIndex;
                string Tc = dgwListe.Rows[index].Cells["Tc"].Value.ToString();
                ciftci = serviceCks2020.GetByTc(Tc);
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
                var ciftci = serviceCiftciler.GetByTc(tc);
                if (ciftci.TcKimlikNo == null)
                {
                    CiftciForm form = new CiftciForm(tc);
                    form.ShowDialog();
                }
                else
                {
                    int dosyano = serviceCks2020.DosyaNoFactory();
                    returnValue = serviceCks2020.Add(new Cks2020
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
            dgwListe.DataSource = serviceCks2020.GetAll();
                    
            formDoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (ciftci.Id == -1) throw new Exception("Listeden silmek istediğiniz kaydı seçiniz.");
                int result = serviceCks2020.Delete(ciftci);
                if (result > 0)
                {
                    Utilities.Mesaj.MessageBoxInformation("Silme işlemi başarılı");
                    ShowList();
                    ciftci = new Cks2020() { Id = -1 };
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

                int result = serviceCks2020.Update(ciftci);
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
                var liste = serviceCks2020.GetAll().OrderBy(I => I.DosyaNo).ToList();
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
                        var list2020 = serviceCks2020.GetAll().OrderBy(I => I.DosyaNo).ToList();
                        Utilities.Json.Backup(list2020, "Cks2020",path);

                        Utilities.Mesaj.MessageBoxInformation("Backup işlemi başarılı.");
                    });

                });


            }, "Devam etmek istiyor musunuz?");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                dgwListe.DataSource= serviceCks2020.Search(txtSearch.Text);
            }
            else
            {
                dgwListe.DataSource = serviceCks2020.GetAll();
            }
        }

        private void dgwListe_DataSourceChanged(object sender, EventArgs e)
        {
            lblKayitSayisi.Text = $"Listede bulunan toplam kayıt sayısı: {dgwListe.RowCount.ToString()}";
        }
    }
}
