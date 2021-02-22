using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core.IoC;
using Fasetto.Word.Core.ViewModel;
using Fasetto.Word.Page;
using Fasetto.Word.ValueConverter;

namespace Fasetto.Word.Control
{
    /// <summary>
    ///     Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Property

        /// <summary>
        ///     Register <see cref="CurrentPage" /> as dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage),
                typeof(PageHost),
                new UIPropertyMetadata(CurrentPagePropertyChanged));

        /// <summary>
        ///     The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage) GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        #endregion

        #region Construct

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            // if we are in design mode, show current page
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.NewPage.Content =
                    (BasePage) new ApplicationPageConverter().Convert(
                        IoC.Get<ApplicationViewModel>().CurrentPage);

            }
        }

        #endregion


        #region Event Handler

        /// <summary>
        ///     Called when the <see cref="CurrentPage" /> changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            // Get Frames
            var newPageFrame = (d as PageHost)?.NewPage;
            var oldPageFrame = (d as PageHost)?.OldPage;

            // Store the current page content as the old page
            if (newPageFrame != null)
            {
                var oldPageContent = newPageFrame.Content;

                // Remove current page from new page frame
                newPageFrame.Content = null;

                // Move the previous page into the old page frame
                // 这个会再次引发 Page_Loaded 事件
                oldPageFrame.Content = oldPageContent;

                // Animate out previous page when the loaded event fires right after this call due to moving frames

                if (oldPageContent is BasePage oldPage)
                {
                    // Tell old page to animate out
                    oldPage.ShouldAnimateOut = true;

                    // Once it is done, remove it
                    Task.Delay((int) (oldPage.SlideSeconds * 1000)).ContinueWith(t =>
                    {
                        // Jump back to UI thread, Remove old page
                        Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                    });
                }
            }

            if (newPageFrame != null) newPageFrame.Content = e.NewValue;
        }

        #endregion
    }
}