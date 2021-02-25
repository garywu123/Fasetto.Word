using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fasetto.Word.Page;

namespace Fasetto.Word.Control
{
    /// <summary>
    /// Interaction logic for BubbleContent.xaml
    /// </summary>
    public partial class BubbleContent : UserControl
    {

        #region Dependency Property

        // /// <summary>
        // ///     Register <see cref="CurrentPage" /> as dependency property
        // /// </summary>
        // public static readonly DependencyProperty UiViewModel =
        //     DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage),
        //         typeof(PageHost),
        //         new UIPropertyMetadata(CurrentPagePropertyChanged));
        //
        // /// <summary>
        // ///     The current page to show in the page host
        // /// </summary>
        // public BasePage CurrentPage
        // {
        //     get => (BasePage)GetValue(CurrentPageProperty);
        //     set => SetValue(CurrentPageProperty, value);
        // }

        #endregion

        public BubbleContent()
        {
            InitializeComponent();
        }
    }
}
