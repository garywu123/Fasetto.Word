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
    ///     A converter that takes in the core horizontal alignment enum and converts it to WPF alignment
    /// </summary>
    public class
        HorizontalAlignmentConverter : BaseValueConverter<HorizontalAlignmentConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            return (HorizontalAlignment) value;
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