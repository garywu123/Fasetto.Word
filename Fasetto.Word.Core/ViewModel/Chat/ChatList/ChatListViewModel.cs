#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using System.Collections.Generic;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.Chat
{
    /// <summary>
    ///     A view model for the overview chat list
    /// </summary>
    public class ChatListViewModel : BasicViewModel
    {
        
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}