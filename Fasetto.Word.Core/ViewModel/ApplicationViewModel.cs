#region License

// author:         吴经纬
// created:        0:12
// description:

#endregion

using System;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel
{
    /// <summary>
    ///     The View Model for the whole application. Monitor the application statue.
    /// </summary>
    public class ApplicationViewModel : BasicViewModel
    {
        // 使用 private set 这样你无法手动
        /// <summary>
        ///     The current page bind to the Window Frame Content
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        ///     True if the side menu should be show.
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        ///     使用 GoToPage 的方法来切换页面，而不是通过直接赋值 CurrentPage
        ///     因为 ApplicationViewModel 有一个 SideMenuVisible 的属性，默认为 false
        ///     如果是 Login 或者 Register，我们是不用设置其为 true 的，
        ///     但是 ChatPage 我们需要设置其为 true
        ///     为了方便，我们通过 GoToPage 的方法，根据需要传入的 Page 页面来判断如何修改 ApplicationViewModel 中的属性
        /// </summary>
        /// <param name="targetPage"> The page you want to navigate to </param>
        public void GoToPage(ApplicationPage targetPage)
        {
            CurrentPage = targetPage;

            // Hide Side menu if it is not a chat page
            SideMenuVisible = targetPage == ApplicationPage.Chat;

        }
    }
}