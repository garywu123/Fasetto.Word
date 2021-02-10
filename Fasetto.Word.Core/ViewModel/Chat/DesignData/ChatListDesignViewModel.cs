#region License

// author:         吴经纬
// created:        20:23
// description:

#endregion

using System.Collections.Generic;

namespace Fasetto.Word.Core.ViewModel.Chat.DesignData
{
    /// <summary>
    ///     A design view model for the overview chat list
    /// </summary>
    public class ChatListDesignViewModel : ChatListViewModel
    {
        public static ChatListDesignViewModel Instance => new ChatListDesignViewModel();

        public ChatListDesignViewModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405"
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405"
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405"
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405"
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405"
                },
                new ChatListItemViewModel
                {
                    Name = "Gary Wu",
                    Initials = "GW",
                    Message = "Gary is so awesome.",
                    ProfilePictureRgb = "00d405"
                }
            };
        }
    }
}