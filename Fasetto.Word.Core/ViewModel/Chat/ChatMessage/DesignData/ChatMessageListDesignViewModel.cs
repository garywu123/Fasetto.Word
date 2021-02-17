#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using System;
using System.Collections.Generic;
using Fasetto.Word.Core.ViewModel.Chat.DesignData;

namespace Fasetto.Word.Core.ViewModel.Chat.ChatMessage.DesignData
{
    /// <summary>
    ///     A design view model for the overview Chat Message List
    /// </summary>
    public class ChatMessageListDesignViewModel : ChatMessageListViewModel
    {
        public static ChatMessageListDesignViewModel Instance => new ChatMessageListDesignViewModel();

        public ChatMessageListDesignViewModel()
        {
            Items = new List<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "I am about to wipe the older server, we need to update the old server to windows 2016",
                    ProfilePictureRgb = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },

                new ChatMessageListItemViewModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRgb = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },

                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "The new server is up. Go to 192.168.1.1. \r\n Username is admin, password is P8ssw0rd!",
                    ProfilePictureRgb = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
            };
        }
    }
}