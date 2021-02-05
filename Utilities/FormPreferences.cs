using Entities.Concrete;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Utilities
{
    public static class FormPreferences
    {
        //Form control lerinin ortak ayarları
        public static void FromSettings(Form form, int whichYear = 2020)
        {
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            if (whichYear == 2021)
            {
                form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            }
            else if (whichYear == 2020)
            {
                form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            }

        }
        public static void DataGridSettings(DataGridView dgw, string[] notAppearColumnsName)
        {
            foreach (var item in notAppearColumnsName)
            {
                dgw.Columns[item].Visible = false;
            }

            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgw.MultiSelect = false;
            dgw.ReadOnly = true;

        }
        public static void FormOpen(string formName, Form form, bool withShowDialog = false)
        {
            Form f = Application.OpenForms[formName];
            if (f == null)
            {
                f = form;
                FromSettings(f);
                if (withShowDialog)
                    f.ShowDialog();
                else
                    f.Show();
            }
            else
            {
                f.Focus();
            }
        }

        public static void ComboxSetUrun(ComboBox combobox,List<Urun> listOfUruns)
        {
            combobox.DataSource = listOfUruns;
            combobox.DisplayMember = "UrunAdi";
            combobox.ValueMember = "Id";
        }
        public static void ComboxSetFirma(ComboBox combobox, List<Firma> listOfFirmas)
        {
            combobox.DataSource = listOfFirmas;
            combobox.DisplayMember = "FirmaAdi";
            combobox.ValueMember = "Id";
        }

    }
}
