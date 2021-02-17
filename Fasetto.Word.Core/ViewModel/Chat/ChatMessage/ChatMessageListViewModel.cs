#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using System.Collections.Generic;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.Chat.ChatMessage
{
    /// <summary>
    ///     A view model for the overview Chat Message List ViewModel
    /// </summary>
    public class ChatMessageListViewModel : BasicViewModel
    {
        
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}