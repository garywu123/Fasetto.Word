using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)e.OriginalSource;

            var subFolder = GetSubFolderName(button);

            if (subFolder != null)
            {
                var type = GetType();
                var assembly = type.Assembly;
                Trace.WriteLine($"Namespaces: {type.Namespace}.{button.Content}", "DEBUG");

                var window = (Window)assembly.CreateInstance(
                    type.Namespace + "." + subFolder + "." + button.Content);

                if (window == null)
                    MessageBox.Show("Window Object not exist.");
                else
                    window.ShowDialog();
            }
            
        }

        private string GetSubFolderName(Button button)
        {
            switch (button.Content)
            {
                case "TreeViewExample":
                    return "TreeView";

                default:
                    return null;
            }
        }
    }
}
