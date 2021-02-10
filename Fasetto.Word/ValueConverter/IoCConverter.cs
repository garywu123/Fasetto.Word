#region License

// author:         吴经纬
// created:        10:49
// description:

#endregion

using System;
using System.Diagnostics;
using System.Globalization;
using Fasetto.Word.Core.IoC;
using Fasetto.Word.Core.ViewModel;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     Converts a string name to a service pulled from the IoC container
    /// </summary>
    public class
        IoCConverter : BaseValueConverter<
            IoCConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            if (value == null) return null;
            // Find the appropriate page 
            switch ((string) value)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();

                default:
                    // If something wrong, automatically stop
                    Debugger.Break();
                    throw new ArgumentOutOfRangeException(
                        nameof(value), value, null);
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