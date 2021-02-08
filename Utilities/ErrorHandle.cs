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
            catch (FormatException e)
            {
                Utilities.Mesaj.MessageBoxWarning("Yanlış formatta veri girdiniz. Girdiğiniz verileri kontrol edin.");
            }
            catch (Exception exception)
            {
                mesajVer(mesaj, exception);
            }


            void mesajVer(string text, Exception exception)
            {
                if (!string.IsNullOrEmpty(text))
                    Mesaj.MessageBoxError(text);
                else
                {
                    Exception ie = exception.InnerException;
                    if (ie != null)
                    {
                       
                        Mesaj.MessageBoxError($"GetType: {exception.GetType().Name}  --inner type:{ie.GetType().Name}\nMesaj: {exception.Message}--inner message:{ie.Message}\nStackTrace: {exception.StackTrace} --inner stacktrace:{ie.StackTrace}");
                    }
                    else
                    {
                        Mesaj.MessageBoxError($"Mesaj: {exception.Message}\nStackTrace: {exception.StackTrace}\nGetType: {exception.GetType().Name}");
                    }
                    
                }



            }
        }
    }
}
