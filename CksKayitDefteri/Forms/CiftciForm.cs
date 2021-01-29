using App.Business;
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
        ServiceCiftciler serviceCiftciler;
        string _tc;
        static Operation Islem = Operation.EklemeIslemi;
        private FormNerdenGeldi _formNerdenGeldi;
        //static Ciftci _activeCiftci = new Ciftci() { TcKimlikNo = string.Empty };
        static Ciftci _activeCiftci = null;

        public CiftciForm(string tc)
        {
            InitializeComponent();
            serviceCiftciler = new ServiceCiftciler();
            _tc = tc;
            _formNerdenGeldi = FormNerdenGeldi.CksKayitDefteri;
        }
        public CiftciForm()
        {
            InitializeComponent();
            serviceCiftciler = new ServiceCiftciler();
            _formNerdenGeldi = FormNerdenGeldi.KendiGeldi;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                if (Islem == Operation.EklemeIslemi)
                {
                    var ciftci = FormToEntity();
                    int result = serviceCiftciler.Add(ciftci);
                    if (result > 0)
                    {
                        Utilities.Mesaj.MessageBoxInformation("Kayıt Başarılı");
                        if (_formNerdenGeldi == FormNerdenGeldi.CksKayitDefteri)
                        {
                            Form f = Application.OpenForms["CksKayitDefteriForm"];
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
                    int result = serviceCiftciler.Update(ciftci);
                    //formu temizle
                    FormuTemizle();
                    //Listeyi güncelle
                    dgwList.DataSource = serviceCiftciler.GetAll().OrderByDescending(I => I.Id).ToList();

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
                Note = string.IsNullOrEmpty(txtNote.Text) ? "" : txtNote.Text

            };
            return ciftci;
        }

        private void CiftciForm_Load(object sender, EventArgs e)
        {
            txtTc.Text = _tc;
            comboBoxGender.DataSource = Utilities.RequiredLists.GenderList();
            comboBoxMaritalStatus.DataSource = Utilities.RequiredLists.MaritalStatusList();
            comboBoxVillage.DataSource = Utilities.RequiredLists.VillageNameList();
            dgwList.DataSource = serviceCiftciler.GetAll();
            Utilities.FormPreferences.DataGridSettings(dgwList, new string[] { "Id","TcKimlikNo","MotherName","Birthday","DateOfDeath","Gender"
            ,"MaritalStatus","MobilePhone","HomePhone","Email","City","Town","Note"
            });
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
                    //OpenFileDialog openFileDialog = new OpenFileDialog();
                    //openFileDialog.ShowDialog();
                    //string fileName = openFileDialog.FileName;

                    //var result = File.ReadLines(fileName);
                    //ArrayList userInfo = new ArrayList();
                    //foreach (var line in result)
                    //{
                    //    userInfo.Add(line);
                    //}

                    //userName = (string)userInfo[0];
                    //password = (string)userInfo[1];


                    FileStream fs = File.Create(path);
                    fs.Close();
                    //StreamWriter sw = new StreamWriter(path);
                    //sw.WriteLine(userName);
                    //sw.WriteLine(password);

                    //sw.Close();

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
            //txtNote.Text = person.Note;

        }

        private void dgwList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                int index = dgwList.CurrentCell.RowIndex;
                string Tc = dgwList.Rows[index].Cells["TcKimlikNo"].Value.ToString();
                _activeCiftci = serviceCiftciler.GetByTc(Tc);

            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_activeCiftci != null)
            {
                DialogResult dr = Utilities.Mesaj.MessageBoxQuestion($"{_activeCiftci.TcKimlikNo} tc nolu {_activeCiftci.NameSurname} isimli kaydı silmek istiyor musunuz?");
                if (dr == DialogResult.Yes)
                {
                    int result = serviceCiftciler.Delete(_activeCiftci);
                    _activeCiftci = null;
                    dgwList.DataSource = serviceCiftciler.GetAll();
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

                _activeCiftci = serviceCiftciler.GetByTc(Tc);
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
                txtNote.Text = _activeCiftci.Note;





                btnAdd.Text = "Güncelle";
                Islem = Operation.GuncellemeIslemi;
            });
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var datatable = Utilities.ExcelExport.ConvertToDataTable<Ciftci>(serviceCiftciler.GetAll());
            var path = Utilities.FolderBrowser.Path();
            path = path + @"\Ciftciler.xlsx";
            Task.Run(() => { Utilities.ExcelExport.GenerateExcel(datatable, path); });



        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = Utilities.FolderBrowser.Path();

            Utilities.Json.Backup<Ciftci>(serviceCiftciler.GetAll(), "Ciftciler", path);
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
