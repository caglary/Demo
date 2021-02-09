using Entities.Concrete;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Utilities
{
    public static class FormPreferences
    {
        //Form control lerinin ortak ayarları
        public static void FromSettings(Form form)
        {
            //form.Size = new System.Drawing.Size(1000, 800);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.Font = new System.Drawing.Font("Tahoma", 9);
            form.WindowState = FormWindowState.Normal;
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
            // Automatically resize the visible rows.
            //dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            // Set the DataGridView control's border.
            dgw.BorderStyle = BorderStyle.Fixed3D;
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
