#region License

// author:         吴经纬
// created:        10:49
// description:

#endregion

using System;
using System.Diagnostics;
using System.Globalization;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Page;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     Convert the <see cref="ApplicationPage" /> to an actual view page.
    /// </summary>
    public class
        ApplicationPageConverter : BaseValueConverter<
            ApplicationPageConverter>
    {
        public override object Convert(object value,
            Type targetType = null,
            object parameter = null,
            CultureInfo culture = null)
        {
            Debug.WriteLine(
                $"Application Page Number received by Converter: {(ApplicationPage) value}");

            // Find the appropriate page 
            switch ((ApplicationPage) value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Chat:
                    return new ChatPage();

                case ApplicationPage.Register:
                    return new RegisterPage();

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