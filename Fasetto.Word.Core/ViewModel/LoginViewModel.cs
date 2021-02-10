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
    public class LoginViewModel : BasicViewModel
    {
        #region Constructor

        /// <summary>
        ///     基础的 ViewModel
        /// </summary>
        public LoginViewModel()
        {
            // 调用 RelayParameter，传入一个需要参数的 LoginAsync 方法
            LoginCommand =
                new RelayParameterizedCommands(async parameter =>
                    await LoginAsync(parameter));

            // 调用 RelayParameter，转到注册界面
            RegisterCommand =
                new RelayCommand(async () => await RegisterAsync());
        }

        #endregion

        #region Command

        /// <summary>
        ///     The command for the LoginAsync Button
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// 
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
        public async Task LoginAsync(object parameter)
        {
            // 因为 RunCommand 是一个async方法，你没有办法将一个 LoginIsRunning 作为 ref 参数传递给它
            // 因此我们在 RunCommand 中使用了 Expression，然后将 this.LoginIsRunning 作为一个 expression
            // 传递给 RunCommand 异步方法
            await RunCommand(() => LoginIsRunning,
                async () =>
                {
                    var email = Email;
                    // IMPORTANT: Never store the password.
                    var password =
                        (parameter as IHavePassword)?.SecurePassword.Unsecure();

                    // 这个是模拟联网操作的延时
                    await Task.Delay(5000);

                    /* 为什么使用GoToPage方法 */
                    IoC.IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
                });
        }

        /// <summary>
        ///     Takes the user to register page
        /// </summary>
        public async Task RegisterAsync()
        {
            // IoC.IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            // return;

            // 通过一个依赖注入 Container，初始化一个 ApplicationViewModel
            IoC.IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            Debug.WriteLine(
                $"Current Page: {IoC.IoC.Get<ApplicationViewModel>().CurrentPage}",
                "Debug");

            /*
             下面的代码是通过获取 MainWindow 中的 dataContext，然后修改 dataContext （也就是
            MainWindowViewModel 的 CurrentPage 来实现的）。现在我们将 CurrentPage 移动到了 
            ApplicationViewModel 中。我们需要通过一个依赖注入来修改 ApplicationViewModel 中的
            CurrentPage 属性。
             var dataContext = ((Fasetto.Word.MainWindow) Application.Current.MainWindow)
                ?.DataContext;
            if (dataContext != null)
            {
                Debug.WriteLine("Get MainWindow DataContext Success.", "Debug");
            
                ((WindowViewModel)dataContext)
                    .CurrentPage = ApplicationPage.Register;
            }
            */
            await Task.Delay(500);
        }

        #endregion


        #region Private Helper

        #endregion

        #region private field

        #endregion

        #region Property

        /// <summary>
        ///     A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        /// <summary>
        ///     The user email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     The user password
        /// </summary>
        public SecureString Password { get; set; }

        #endregion
    }
}