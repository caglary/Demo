using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public static class ErrorHandle
    {
        public static void _try(Action action, string mesaj = null)
        {
            try
            {
                action.Invoke();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                mesajVer(mesaj, exception);
            }
            catch (Exception exception)
            {
                if (exception.Message== "Input string was not in a correct format.")
                {
                    mesajVer("Uygun olmayan bir veri girişi yapmayak istediniz.\nGirdiğiniz verileri kontrol ediniz.", exception);

                }
                else mesajVer(mesaj, exception);
             

            }

            void mesajVer(string text, Exception exception)
            {
                if (!string.IsNullOrEmpty(text))
                    Mesaj.MessageBoxError(text);
                else                
                    Mesaj.MessageBoxError(exception.Message);
             

            }
        }
    }
}
