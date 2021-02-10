using System.Security;
using Fasetto.Word.Core.Security;
using Fasetto.Word.Core.ViewModel;

namespace Fasetto.Word.Page
{
    /// <summary>
    ///     RegisterPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        public RegisterPage()
        {

            InitializeComponent();
        }

        public SecureString SecurePassword { get; }
    }
}