#region License

// author:         吴经纬
// created:        15:58
// description:

#endregion

using System;
using System.Globalization;
using System.Windows;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.Icons;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     A converter that takes in a <see cref="IconType" /> and returns the
    ///
    /// string for that icon.
    /// </summary>
    public class
        IconTypeToFontAwesomeConverter : BaseValueConverter<IconTypeToFontAwesomeConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            return ((IconType) value).ToFontAwesome();
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