﻿using App.Business;
using Entities.Concrete;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace App.Forms
{
    public partial class CiftciForm : Form
    {
        CiftcilerManager _ciftcilerManager;
        string _tc;
        static Operation Islem = Operation.EklemeIslemi;
        private FormNerdenGeldi _formNerdenGeldi;
        //static Ciftci _activeCiftci = new Ciftci() { TcKimlikNo = string.Empty };
        static Ciftci _activeCiftci = null;
        public CiftciForm(string tc)
        {
            InitializeComponent();
            _ciftcilerManager = new CiftcilerManager();
            _tc = tc;
            _formNerdenGeldi = FormNerdenGeldi.CksKayitDefteri;
        }
        public CiftciForm()
        {
            InitializeComponent();
            _ciftcilerManager = new CiftcilerManager();
            _formNerdenGeldi = FormNerdenGeldi.KendiGeldi;
        }
        private void CiftciForm_Load(object sender, EventArgs e)
        {
            Utilities.FormPreferences.FromSettings(this);
            txtTc.Text = _tc;
            comboBoxGender.DataSource = Utilities.RequiredLists.GenderList();
            comboBoxMaritalStatus.DataSource = Utilities.RequiredLists.MaritalStatusList();
            comboBoxVillage.DataSource = Utilities.RequiredLists.VillageNameList();
            dgwList.DataSource = _ciftcilerManager.GetAll();
            Utilities.FormPreferences.DataGridSettings(dgwList, new string[] { "Id","TcKimlikNo","MotherName","Birthday","DateOfDeath","Gender"
            ,"MaritalStatus","MobilePhone","HomePhone","Email","City","Town","Not" });
            dgwList.Columns[2].HeaderText = "İsim Soyisim";
            dgwList.Columns[3].HeaderText = "Baba Adı";
            dgwList.Columns[14].HeaderText = "Mahalle/Köy";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (Islem == Operation.EklemeIslemi)
                {
                    var ciftci = FormToEntity();
                    int result = _ciftcilerManager.Add(ciftci);
                    if (result > 0)
                    {
                        dgwList.DataSource = _ciftcilerManager.GetAll().OrderByDescending(I => I.Id).ToList();
                        Utilities.Mesaj.MessageBoxInformation("Kayıt Başarılı");
                        if (_formNerdenGeldi == FormNerdenGeldi.CksKayitDefteri)
                        {
                            Form f = Application.OpenForms["CksForm"];
                            foreach (var item in f.Controls)
                            {
                                if (item is DataGridView)
                                {
                                    DataGridView dgw = (DataGridView)item;
                                    CksManager cksManager = new CksManager();
                                    dgw.DataSource = cksManager.GetAll();
                                }
                            }
                            this.Close();
                        }
                    }
                }
                else if (Islem == Operation.GuncellemeIslemi)
                {
                    //guncelleme işlemi yap.
                    var ciftci = FormToEntity();
                    ciftci.Id =(int) txtTc.Tag;
                    int result = _ciftcilerManager.Update(ciftci);
                    //formu temizle
                    FormuTemizle();
                    //Listeyi güncelle
                    dgwList.DataSource = _ciftcilerManager.GetAll().OrderByDescending(I => I.Id).ToList();
                    btnAdd.Text = "Yeni Kayıt Ekle";
                    Islem = Operation.EklemeIslemi;
                }
            });
        }
        private void FormuTemizle()
        {
            foreach (var item in this.Controls)
            {
                if (item is GroupBox)
                {
                    GroupBox gb = (GroupBox)item;
                    if (gb.Name == "groupBoxCiftciIslemleri")
                    {
                        foreach (var gbControl in gb.Controls)
                        {
                            if (gbControl is TextBox)
                            {
                                TextBox textBox = (TextBox)gbControl;
                                textBox.Text = "";
                            }
                            else if (gbControl is ComboBox)
                            {
                                ComboBox comboBox = (ComboBox)gbControl;
                                comboBox.Text = "";
                            }
                        }
                    }
                }
            }
        }
        private Ciftci FormToEntity()
        {
            if (txtTc.Text.Length != 11) throw new Exception("Tc Numarasını kontrol ediniz.");
            Ciftci ciftci = new Ciftci()
            {
                TcKimlikNo = string.IsNullOrEmpty(txtTc.Text) ? "" : txtTc.Text,
                NameSurname = string.IsNullOrEmpty(txtNameSurname.Text) ? "" : txtNameSurname.Text,
                FatherName = string.IsNullOrEmpty(txtFatherName.Text) ? "" : txtFatherName.Text,
                MotherName = string.IsNullOrEmpty(txtMotherName.Text) ? "" : txtMotherName.Text,
                Birthday = string.IsNullOrEmpty(txtBirthday.Text) ? "" : txtBirthday.Text,
                DateOfDeath = string.IsNullOrEmpty(txtYearOfDeath.Text) ? "" : txtYearOfDeath.Text,
                Gender = string.IsNullOrEmpty(comboBoxGender.Text) ? "" : comboBoxGender.Text,
                MaritalStatus = string.IsNullOrEmpty(comboBoxMaritalStatus.Text) ? "" : comboBoxMaritalStatus.Text,
                MobilePhone = string.IsNullOrEmpty(txtMobilePhone.Text) ? "" : txtMobilePhone.Text,
                HomePhone = string.IsNullOrEmpty(txtHomePhone.Text) ? "" : txtHomePhone.Text,
                Email = string.IsNullOrEmpty(txtEmail.Text) ? "" : txtEmail.Text,
                City = string.IsNullOrEmpty(txtCity.Text) ? "" : txtCity.Text,
                Town = string.IsNullOrEmpty(txtTown.Text) ? "" : txtTown.Text,
                Village = string.IsNullOrEmpty(comboBoxVillage.Text) ? "" : comboBoxVillage.Text,
                Not = string.IsNullOrEmpty(txtNote.Text) ? "" : txtNote.Text
            };
            return ciftci;
        }
        private void btnTbs_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                string userName = "";
                string password = "";
                string path = Directory.GetCurrentDirectory() + "\\TbsInfo.txt";
                if (!File.Exists(path))
                {
                                        FileStream fs = File.Create(path);
                    fs.Close();
                }
                else
                {
                    var result = File.ReadLines(path);
                    ArrayList userInfo = new ArrayList();
                    foreach (var line in result)
                    {
                        userInfo.Add(line);
                    }
                    userName = (string)userInfo[0];
                    password = (string)userInfo[1];
                }
                if (txtTc.Text.Length == 11)
                {
                    if (Utilities.TbsIslemleri.driver == null)
                    {
                        Utilities.TbsIslemleri.ChromeAc();
                        Utilities.TbsIslemleri.TbsGiris(userName, password);
                    }
                    Utilities.TbsIslemleri.GerçekKişiKayitIslemleri(txtTc.Text);
                    var person = Utilities.TbsIslemleri.IsletmeBilgileri();
                    person.TcKimlikNo = txtTc.Text;
                    PersonToForm(person);
                }
            });
        }
        private void PersonToForm(Ciftci person)
        {
            txtNameSurname.Text = person.NameSurname;
            txtFatherName.Text = person.FatherName;
            txtMotherName.Text = person.MotherName;
            txtBirthday.Text = person.Birthday;
            txtYearOfDeath.Text = person.DateOfDeath;
            comboBoxGender.Text = person.Gender;
            comboBoxMaritalStatus.Text = person.MaritalStatus;
            txtMobilePhone.Text = person.MobilePhone;
            txtHomePhone.Text = person.HomePhone;
            txtEmail.Text = person.Email;
            txtCity.Text = person.City;
            txtTown.Text = person.Town;
            comboBoxVillage.Text = person.Village;
            txtNote.Text = person.Not;
        }
        private void dgwList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int index = dgwList.CurrentCell.RowIndex;
                string Tc = dgwList.Rows[index].Cells["TcKimlikNo"].Value.ToString();
                _activeCiftci = _ciftcilerManager.GetByTc(Tc);
            });
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_activeCiftci != null)
            {
                DialogResult dr = Utilities.Mesaj.MessageBoxQuestion($"{_activeCiftci.TcKimlikNo} tc nolu {_activeCiftci.NameSurname} isimli kaydı silmek istiyor musunuz?");
                if (dr == DialogResult.Yes)
                {
                    int result = _ciftcilerManager.Delete(_activeCiftci);
                    _activeCiftci = null;
                    dgwList.DataSource = _ciftcilerManager.GetAll();
                    Utilities.Mesaj.MessageBoxInformation("Silme işlemi başarılı");
                }
            }
            else
            {
                Utilities.Mesaj.MessageBoxWarning("Listeden çiftçi seçiniz.");
            }
        }
        private void dgwList_DataSourceChanged(object sender, EventArgs e)
        {
            lblKayitSayisi.Text = $"Listede bulunan toplam kayıt sayısı: {dgwList.RowCount.ToString()}";
        }
        private void dgwList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int index = dgwList.CurrentCell.RowIndex;
                string Tc = dgwList.Rows[index].Cells["TcKimlikNo"].Value.ToString();
                _activeCiftci = _ciftcilerManager.GetByTc(Tc);
                //gelen çiftçinin Id sini txttc tag içerisinde saklıyoruz....
                txtTc.Tag = (object)_activeCiftci.Id;
                txtTc.Text = _activeCiftci.TcKimlikNo;
                txtNameSurname.Text = _activeCiftci.NameSurname;
                txtFatherName.Text = _activeCiftci.FatherName;
                txtMotherName.Text = _activeCiftci.MotherName;
                txtBirthday.Text = _activeCiftci.Birthday.Substring(0, 10);
                txtYearOfDeath.Text = _activeCiftci.DateOfDeath;
                comboBoxGender.Text = _activeCiftci.Gender;
                comboBoxMaritalStatus.Text = _activeCiftci.MaritalStatus;
                txtMobilePhone.Text = _activeCiftci.MobilePhone;
                txtHomePhone.Text = _activeCiftci.HomePhone;
                txtEmail.Text = _activeCiftci.Email;
                txtCity.Text = _activeCiftci.City;
                txtTown.Text = _activeCiftci.Town;
                comboBoxVillage.Text = _activeCiftci.Village;
                txtNote.Text = _activeCiftci.Not;
                btnAdd.Text = "Güncelle";
                Islem = Operation.GuncellemeIslemi;
            });
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var datatable = Utilities.ExcelExport.ConvertToDataTable<Ciftci>(_ciftcilerManager.GetAll());
            var path = Utilities.FolderBrowser.Path();
            path = path + @"\Ciftciler.xlsx";
            Task.Run(() => { Utilities.ExcelExport.GenerateExcel(datatable, path); });
        }
        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = Utilities.FolderBrowser.Path();
            Utilities.Json.Backup<Ciftci>(_ciftcilerManager.GetAll(), "Ciftciler", path);
        }
    }
    enum Operation
    {
        EklemeIslemi, GuncellemeIslemi
    }
    enum FormNerdenGeldi
    {
        KendiGeldi, CksKayitDefteri
    }
}
