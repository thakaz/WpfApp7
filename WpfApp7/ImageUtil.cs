using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp7
{
    static class ImageUtil
    {
        static public BitmapImage FileToBitmapImage()
        {
            BitmapImage bi = null;

            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "画像を選択";

                if (dialog.ShowDialog() != true)
                {
                    return bi;
                }

                using (var fs = File.OpenRead(dialog.FileName))
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = fs;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                }

            }
            catch
            {
                bi = null;
            }

            return bi;

        }
    }
}
