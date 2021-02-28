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
        ///     The chat list items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        ///     True to show the attachment menu
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        ///     True if any popup menus are visible
        /// </summary>
        public bool AnyPopupVisible
        {
            get => AttachmentMenuVisible;
            set => AttachmentMenuVisible = value;
        }

        /// <summary>
        ///     The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentPopupMenu { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        ///     The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        ///     The command for when the area outside of any popup is clicked.
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickAwayCommand = new RelayCommand(PopupClickAwayButton);

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

        /// <summary>
        ///     When the popup click away area is clicked hide any popups
        /// </summary>
        private void PopupClickAwayButton()
        {
            // Toggle menu visibility 
            AnyPopupVisible = false;
        }

        #endregion
    }
}