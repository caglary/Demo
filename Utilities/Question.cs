using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
   public static class Question
    {
        public static void IfYes(Action action,string mesaj)
        {
            DialogResult result= MessageBox.Show(mesaj,"Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
                action.Invoke();
        }
    }
}
