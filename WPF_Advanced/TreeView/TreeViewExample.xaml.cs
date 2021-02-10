using System.Windows;
using WPF_Advanced.Directory.DirectoryViewModel;

namespace WPF_Advanced.TreeView
{
    /// <summary>
    ///     TreeViewExample.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewExample
    {
        public TreeViewExample()
        {
            InitializeComponent();

            this.DataContext = new DirectoryStructureViewModel();

        }
    }
}