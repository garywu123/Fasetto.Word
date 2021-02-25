#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using System.Collections.Generic;
using System.Windows.Input;
using Fasetto.Word.Core.ViewModel.Base;
using Fasetto.Word.Core.ViewModel.PopupMenu;

namespace Fasetto.Word.Core.ViewModel.Chat.ChatMessage
{
    /// <summary>
    ///     A view model for the overview Chat Message List ViewModel
    /// </summary>
    public class ChatMessageListViewModel : BasicViewModel
    {

        #region Public Property

        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        /// True to show the attachment menu
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentPopupMenu { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            // make a default attach menu
            AttachmentPopupMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion
 

        #region Command Methods
        /// <summary>
        ///     When the attachment button is clicked, show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle menu visibility 
            AttachmentMenuVisible ^= true;

        }

        #endregion
    }
}