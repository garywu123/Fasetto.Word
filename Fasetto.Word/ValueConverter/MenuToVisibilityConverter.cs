﻿#region License

// author:         吴经纬
// created:        15:58
// description:

#endregion

using System;
using System.Globalization;
using System.Windows;
using Fasetto.Word.Core.DataModel;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    ///     A converter that takes in a <see cref="MenuItemType" /> and returns a
    ///     <see cref="Visibility" /> based on the given Parameter being the same as
    ///     the menu item type
    /// </summary>
    public class
        MenuToVisibilityConverter : BaseValueConverter<MenuToVisibilityConverter>
    {
        public override object Convert(object value,
                                       Type targetType,
                                       object parameter,
                                       CultureInfo culture)
        {
            // If we have no parameter return invisible
            if (parameter == null) return Visibility.Collapsed;
            // Try and convert parameter string to enum
            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;
            // return visible if the parameter matches the type
            return (MenuItemType) value == type ? Visibility.Visible : Visibility.Collapsed;
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