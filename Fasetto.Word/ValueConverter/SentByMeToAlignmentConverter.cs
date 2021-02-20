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
        SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            if (parameter == null)
                return value != null && (bool) value
                    ? HorizontalAlignment.Right
                    : HorizontalAlignment.Left;

            return value != null && (bool) value
                ? HorizontalAlignment.Left
                : HorizontalAlignment.Right;
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