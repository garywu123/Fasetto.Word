#region License

// author:         吴经纬
// created:        16:50
// description:

#endregion

using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Animation;
using Fasetto.Word.Core.ViewModel.Base;

namespace Fasetto.Word.Page
{
    /// <summary>
    ///     The basic page for all pages to gain base functionality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Property

        /// <summary>
        ///     The animation the play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } =
            PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        ///     The animation the play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } =
            PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        ///     The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        ///     A flag to indicate if this page should animate out on load
        /// </summary>
        public bool ShouldAnimateOut { get; set; } = false;

        #endregion

        #region Constructor (For Animation)

        /// <summary>
        ///     Set the animation for all the pages derived from <see cref="BasePage" />
        /// </summary>
        public BasePage()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            // If we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            // 当 page 载入完毕以后，开始创建动画
            Loaded += BasePage_Loaded;
        }

        #endregion

        #region Method and Event Handler

        /// <summary>
        ///     Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            

            // 如果这个 Page 不要求有退出动画（通常在更换page的时候会设置前一个页面要带有退出动画）
            if (ShouldAnimateOut)
                // 在异步现场上创建动画
                await AnimateOutAsync();
            else
                await AnimateInAsync();
            /*
             * 下面这句语法有错误，因为 Task.Run 代表了另外一个线程，而非主线程
             * 而这个代码会将 storyBoard 添加到 page 上，但是子线程无法访问UI线程上的内容，所以这里会报错
             */
            // Task.Run(async()=>await AnimateInAsync());
        }

        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                // 想要让page从左边滑入，也就是说page的左边界应该在window的右边界上
                case PageAnimation.SlideAndFadeInFromRight:
                    // Start animation
                    if (Application.Current.MainWindow != null)
                        await this.SlideAndFadeInFromRightAsync(SlideSeconds * 2,
                            width: (int) Application.Current.MainWindow.Width);
                    break;
            }
        }

        // ReSharper disable once UnusedMember.Global
        public async Task AnimateOutAsync()
        {
            if (PageUnloadAnimation == PageAnimation.None) return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    if (Application.Current.MainWindow != null)
                        await this.SlideAndFadeOutToLeftAsync(SlideSeconds,
                            width: (int) Application.Current.MainWindow.Width);
                    break;
            }
        }

        #endregion
    }

    /// <summary>
    ///     Basic Page with added ViewModel support.
    /// </summary>
    /// <typeparam name="T"> The ViewModel which would associate with the page. </typeparam>
    public class BasePage<T> : BasePage
        where T : BasicViewModel, new()
    {
        private T _viewModel;

        #region Property

        /// <summary>
        ///     A view model assigned to this page
        /// </summary>
        public T ViewModel
        {
            get => _viewModel;

            set
            {
                if (Equals(_viewModel, value))
                {
                    Trace.WriteLine("Equals");
                    return;
                }

                Trace.WriteLine("Not equal, set page view model as " + value);

                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        #endregion

        #region Construct (To set the view model for the page)

        /*
         * 当 Page 刚创建的时候，其动画如果不为 None，那么先将它设置为 Collapsed
         */
        public BasePage()
        {
            // 构建page的时候载入该 viewmodel
            ViewModel = new T();
        }

        #endregion
    }
}