#region License
// author:         吴经纬
// created:        16:39
// description:
#endregion

using System.Collections.Generic;
using Fasetto.Word.Core.DataModel;

namespace Fasetto.Word.Core.ViewModel.PopupMenu.DesignData
{
    /// <summary>
    /// The design view model for <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignViewModel : MenuViewModel
    {

        public static MenuDesignViewModel Instance => new MenuDesignViewModel();

        private MenuDesignViewModel()
        {
            Items = new List<MenuItemViewModel>()
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
            };
        }
    }
}