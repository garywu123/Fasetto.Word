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
        TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            var time = (DateTimeOffset) value;

            // If it is not read....
            if (time==DateTimeOffset.MinValue)
            {
                return string.Empty;
            }

            // If it is today. // Otherwise, return a full date
            if (time == DateTimeOffset.UtcNow.Date)
            {
                return $"Read {time.ToLocalTime():HH:mm}";
            }

            return $"Read {time.ToLocalTime():HH:mm, MMM yyyy}";
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