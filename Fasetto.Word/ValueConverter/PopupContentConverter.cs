#region License

// author:         吴经纬
// created:        15:58
// description:

#endregion

using System;
using System.Globalization;
using System.Windows;
using Fasetto.Word.Control;
using Fasetto.Word.Core.ViewModel.PopupMenu;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     A converter that takes in a <see cref="BaseViewModel" /> and returns a
    ///     specific UI Control that should bind to that type of ViewModel
    /// </summary>
    public class
        PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            if (value is ChatAttachmentPopupMenuViewModel basePopup)
            {
                return new VerticalMenu(){DataContext = basePopup.Content};
            }

            return null;
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