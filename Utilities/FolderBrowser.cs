using System.Windows.Forms;

namespace Utilities
{
    public static class FolderBrowser
    {
        public static string Path()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }
    }
}
