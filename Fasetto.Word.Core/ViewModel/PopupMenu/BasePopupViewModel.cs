#region License
// author:         吴经纬
// created:        22:41
// description:
#endregion

using System.Net.Mime;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.PopupMenu
{
    /// <summary>
    ///     A view model for any popup menus
    /// </summary>
    public class BasePopupViewModel : BasicViewModel
    {
        #region Properties

        /// <summary>
        /// Background color of bubble content control
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// The alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public  MenuViewModel Content { get; set; }

        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            //Set default values
            // TODO: Move colors into Core and make use of it here
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}