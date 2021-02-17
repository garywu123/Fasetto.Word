#region License

// author:         吴经纬
// created:        20:35
// description:

#endregion

namespace Fasetto.Word.Core.ViewModel.Chat.ChatList.DesignData
{
    /// <summary>
    ///     The design time data for a <see cref="ChatListItemViewModel" />
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        /// <summary>
        ///     SingleTone 单例
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        /// <summary>
        ///     Default constructor with some default data
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "The is awesome. I like it very much. Please do it fast. ";
            ProfilePictureRgb = "ff0000";
        }
    }
}