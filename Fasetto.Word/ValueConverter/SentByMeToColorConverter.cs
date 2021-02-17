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
    ///     将 bool 转为 Alignment 对齐，如果是 SentByMe，那么就对齐右边
    ///     如果不是，则对其左边
    /// </summary>
    public class
        SentByMeToColorConverter : BaseValueConverter<SentByMeToColorConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            return value != null && (bool) value
                ? Application.Current.FindResource("WordVeryLightBlueBrush")
                : Application.Current.FindResource("ForegroundLightBrush");
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