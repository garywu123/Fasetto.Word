using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Page;

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
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;
            
            // Remove current page from new page frame
            newPageFrame.Content = null;

            // Move the previous page into the old page frame
            // 这个会再次引发 Page_Loaded 事件
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page when the loaded event fires right after this call due to moving frames

            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
                
            }
            newPageFrame.Content = e.NewValue;
        }

        #endregion
    }
}