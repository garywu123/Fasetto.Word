#region License
// author:         吴经纬
// created:        17:47
// description:
#endregion

using System.Collections.ObjectModel;
using System.Linq;
using WPF_Advanced.Directory.Data;

namespace WPF_Advanced.Directory.DirectoryViewModel
{
    /// <summary>
    /// The view model for the application main Directory view
    /// </summary>
    public class DirectoryStructureViewModel:BasicViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure.GetLogicalDrives()
                    .Select(drive => 
                        new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
    }
}