#region License

// author:         吴经纬
// created:        15:58
// description:

#endregion

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     将一个 Hex String 转为 Color Brush
    /// </summary>
    public class
        HexToColorBrushConverter : BaseValueConverter<HexToColorBrushConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            return (SolidColorBrush) (new BrushConverter().ConvertFrom($"#{value}"));
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