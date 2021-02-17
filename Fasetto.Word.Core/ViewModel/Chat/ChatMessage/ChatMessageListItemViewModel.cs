#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using System;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel.Chat.ChatMessage
{
    /// <summary>
    ///     A view model for each chat message thread  list item in the chat message
    ///     list thread
    /// </summary>
    public class ChatMessageListItemViewModel : BasicViewModel
    {
        /// <summary>
        ///     The display name of sender of the message
        /// </summary>
        public string SenderName { get; set; }

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
        ///     True if the item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        ///     True if this message was sent by the signed in user
        ///     如果消息是收件人发出的，那么收件人在对话列表上发出的对话泡是不应该带有 profile icon 的
        /// </summary>
        public bool SentByMe { get; set; }


        /// <summary>
        ///     The time the message was read, or <see cref="DateTimeOffset.MinValue" /> if
        ///     not read
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }


        /// <summary>
        ///     True if this message was read
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;


        /// <summary>
        ///     The time the message was sent
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }
    }
}