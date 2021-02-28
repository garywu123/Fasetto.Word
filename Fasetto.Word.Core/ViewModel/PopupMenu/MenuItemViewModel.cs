#region License
// author:         吴经纬
// created:        15:51
// description:
#endregion

using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.PopupMenu
{
    /// <summary>
    ///     A view model for a menu item
    /// </summary>
    public class MenuItemViewModel: BasicViewModel
    {
        /// <summary>
        /// The text to display for the menu item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The icon for this menu item.
        /// </summary>
        public IconType Icon { get; set; }

        /// <summary>
        /// The type of this menu item
        /// </summary>
        public MenuItemType Type { get; set; }
    }
}