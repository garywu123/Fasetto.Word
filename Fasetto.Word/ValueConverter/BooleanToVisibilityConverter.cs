#region License

// author:         吴经纬
// created:        15:58
// description:

#endregion

using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     将 bool 转为 visibility
    /// </summary>
    public class
        BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            if (parameter == null)
            {
                return value != null && (bool) value ? Visibility.Hidden : Visibility.Visible;
            }
            else
            {
                return value != null && (bool)value ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public override object ConvertBack(object value,
                                           Type targetType,
                                           object parameter,
                                           CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}