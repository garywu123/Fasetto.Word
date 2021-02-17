#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.Chat
{
    /// <summary>
    ///     A view model for each chat list item
    /// </summary>
    public class ChatListItemViewModel : BasicViewModel
    {
        /// <summary>
        ///     The display name of this chart list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The latest message from this chart
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        ///     The RGB Value in HEX for the background color of the profile picture
        ///     For example FF00FF for Red and blue mixed
        /// </summary>
        public string ProfilePictureRgb { get; set; }

        /// <summary>
        ///     The new message indication bar
        /// </summary>
        public bool NewContentAvailable { get; set; } = false;

        /// <summary>
        ///     True if the item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}