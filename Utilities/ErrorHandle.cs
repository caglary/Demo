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
                string messageText = "Yanlış formatta veri girdiniz. Girdiğiniz verileri kontrol edin.";
                Utilities.Mesaj.MessageBoxWarning(messageText);
                Utilities.Logging.Log($" {e.GetType().Name} {messageText}");
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
                    string logText = string.Empty;
                    if (ie != null)
                    {
                        logText = $"GetType:{exception.GetType().Name}\ninner GetType:{ie.GetType().Name}\nMessage: {exception.Message}\nInner message:{ie.Message}\nStackTrace: {exception.StackTrace}\nInner stacktrace:{ie.StackTrace}";
                        Mesaj.MessageBoxError($"Message: { exception.Message}\nInner message:{ ie.Message}");
                        Utilities.Logging.Log(logText) ;
                    }
                    else
                    {
                        logText = $"Mesaj: {exception.Message}\nStackTrace: {exception.StackTrace}\nGetType: {exception.GetType().Name}";
                        Mesaj.MessageBoxError($"Mesaj: {exception.Message}");
                        Utilities.Logging.Log(logText);
                    }
                }
            }
        }
    }
}
