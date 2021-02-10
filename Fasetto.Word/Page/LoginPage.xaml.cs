using System.Security;
using Fasetto.Word.Core.Security;
using Fasetto.Word.Core.ViewModel;

namespace Fasetto.Word.Page
{
    /// <summary>
    ///     RegisterPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>,  IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The secure password from login page
        /// </summary>
        public SecureString SecurePassword => passwordText.SecurePassword;
    }
}