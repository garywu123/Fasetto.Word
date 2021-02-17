#region License

// author:         吴经纬
// created:        15:58
// description:

#endregion

using System;
using System.Globalization;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     将 bool 转为 visibility
    /// </summary>
    public class
        TimeToDisplayValueConverter : BaseValueConverter<TimeToDisplayValueConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            var time = (DateTimeOffset) value;

            // If it is today. // Otherwise, return a full date
            return time.ToLocalTime()
                .ToString(time.Date == DateTimeOffset.UtcNow.Date ? "HH:mm" : "HH:mm, MM yyyy");
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