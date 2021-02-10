#region License

// author:         吴经纬
// created:        22:52
// description:

#endregion

using System.Diagnostics;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.Security;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Core.ViewModel
{
    #region private field

    #endregion

    /// <summary>
    ///     The View Model for the register page
    /// </summary>
    public class RegisterViewModel : BasicViewModel
    {
        #region Property

        /// <summary>
        ///     A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        /// <summary>
        ///     The user email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     The user password
        /// </summary>
        public SecureString Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     注册页面的 ViewModel
        /// </summary>
        public RegisterViewModel()
        {
            // 调用 RelayCommand，传入LoginAsync 方法，切换到 Login 界面
            LoginCommand =
                new RelayCommand(async () => await LoginAsync());
            

            // 调用 RelayParameter，转到注册界面
            RegisterCommand = new RelayParameterizedCommands(async parameter =>
                await RegisterAsync(parameter));

        }

        #endregion

        #region Command

        /// <summary>
        ///     The command for the LoginAsync Button
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        ///     The register page
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Public Method

        /// <summary>
        ///     Attempts to log the user in
        /// </summary>
        /// <param name="parameter">
        ///     The password passed in from the view for the users
        ///     password
        /// </param>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            // IoC.IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            // return;

            // 通过一个依赖注入 Container，初始化一个 ApplicationViewModel
            IoC.IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            Debug.WriteLine(
                $"Current Page: {IoC.IoC.Get<ApplicationViewModel>().CurrentPage}",
                "Debug");

            await Task.Delay(500);
        }

        /// <summary>
        ///     Takes the user to register page
        /// </summary>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => RegisterIsRunning,
                async () =>
                {
                    var email = Email;
                    // IMPORTANT: Never store the password.
                    var password =
                        (parameter as IHavePassword)?.SecurePassword.Unsecure();

                    await Task.Delay(5000);
                });
        }

        #endregion

        #region Private Helper

        #endregion
    }
}