#region License

// author:         吴经纬
// created:        20:35
// description:

#endregion

using System;
using Fasetto.Word.Core.ViewModel.Chat.DesignData;

namespace Fasetto.Word.Core.ViewModel.Chat.ChatMessage.DesignData
{
    /// <summary>
    ///     The design time data for a <see cref="ChatMessageListItemViewModel" />
    /// </summary>
    public class ChatMessageListItemDesignViewModel : ChatMessageListItemViewModel
    {
        /// <summary>
        ///     SingleTone 单例
        /// </summary>
        public static ChatMessageListItemDesignViewModel Instance => new ChatMessageListItemDesignViewModel();

        /// <summary>
        ///     Default constructor with some default data
        /// </summary>
        public ChatMessageListItemDesignViewModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            Message = "The is awesome. I like it very much. Please do it fast. ";
            ProfilePictureRgb = "ff0000";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }
    }
}