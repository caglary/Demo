using App.Business;
using Entities.Concrete;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class CiftciForm : Form
    {
        ServiceCiftciler serviceCiftciler;
        string _tc;
        public CiftciForm(string tc)
        {
            InitializeComponent();
            serviceCiftciler = new ServiceCiftciler();
            _tc = tc;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilities.ErrorHandle._try(() =>
            {
                var ciftci = FormToEntity();
                int result = serviceCiftciler.Add(ciftci);
                if (result > 0)
                {
                    Utilities.Mesaj.MessageBoxInformation("Kayıt Başarılı");
                    Form f= Application.OpenForms["CksKayitDefteriForm"];
                    foreach (var item in f.Controls)
                    {
                        if (item is DataGridView)
                        {
                            DataGridView dgw = (DataGridView)item;
                            ServiceCks2020 cks = new ServiceCks2020();
                            dgw.DataSource = cks.GetAll();
                            
                          
                        }
                    }
                    this.Close();
                }
            });



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
    }
}
