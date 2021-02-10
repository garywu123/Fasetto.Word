#region License
// author:         吴经纬
// created:        19:20
// description:
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WPF_Advanced.Directory.Data;

namespace WPF_Advanced.TreeView
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (DirectoryItemType) value;
            var img = "Resource/file.png";
            switch (type)
            {
                case DirectoryItemType.Drive:
                    img = "Resource/driver.png";
                    break;
                case DirectoryItemType.File:
                    img = "Resource/file.png";
                    break;
                case DirectoryItemType.Folder:
                    img = "Resource/folder-open.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{img}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HeaderConverter
    {
        public void RunTest()
        {
            
        }
    }

}