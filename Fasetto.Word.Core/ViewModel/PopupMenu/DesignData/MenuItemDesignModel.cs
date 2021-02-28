#region License
// author:         吴经纬
// created:        16:36
// description:
#endregion

using Fasetto.Word.Core.DataModel;

namespace Fasetto.Word.Core.ViewModel.PopupMenu.DesignData
{
    /// <summary>
    /// The design view model for <see cref="MenuItemViewModel"/>
    /// </summary>
    public class MenuItemDesignModel : MenuItemViewModel
    {

        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        private MenuItemDesignModel()
        {
            Text = "Hello World";

            Icon = IconType.File;
        }
    }
}