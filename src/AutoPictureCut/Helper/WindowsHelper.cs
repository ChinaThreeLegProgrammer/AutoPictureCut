using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPictureCut.Helper
{
    public class WindowsHelper
    {
        public static string ShowDialog()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;

            }
            return null;
        }
    }

}
