#region License
// author:         吴经纬
// created:        22:41
// description:
#endregion

using System.Collections.Generic;
using System.Net.Mime;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.PopupMenu
{
    /// <summary>
    ///     A view model for any popup menus
    /// </summary>
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel()
            {
                Items = new List<MenuItemViewModel>
                {
                    new MenuItemViewModel()
                    {
                        Text = "Attach a file....",
                        Type = MenuItemType.Header
                    },

                    new MenuItemViewModel()
                    {
                        Text = "From computer",
                        Icon = IconType.File,
                    },

                    new MenuItemViewModel()
                    {
                        Text = "From pictures",
                        Icon = IconType.Picture
                    },
                }
            };
        }
    }
}