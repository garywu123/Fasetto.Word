using Fasetto.Word.Core.ViewModel;
using Fasetto.Word.ViewModel;

namespace Fasetto.Word
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        // 不再需要 ApplicationViewModel，因为它存在与我们 IoC container 当中。
        // /// <summary>
        // ///     The View Model to switch content of the frame. Because it is global.
        // ///     We move the CurrentPage property into Fasetto.World.Core project
        // ///     Because we still need to set the DataContext for the MainWindow Frame.
        // ///     Set Frame Content to Bind with this <see cref="ApplicationViewModel" />
        // ///     with its current page property and set the Element name is the
        // ///     <see cref="MainWindow" />. Please check Xaml file.
        // /// </summary>
        // public ApplicationViewModel ApplicationViewModel => new ApplicationViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }
    }
}