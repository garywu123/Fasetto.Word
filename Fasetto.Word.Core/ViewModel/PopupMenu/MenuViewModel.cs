#region License

// author:         吴经纬
// created:        15:51
// description:

#endregion

using System.Collections.Generic;

namespace Fasetto.Word.Core.ViewModel.PopupMenu
{
    /// <summary>
    ///     The view model for menu itself
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        ///     The items in the menu
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }
    }
}