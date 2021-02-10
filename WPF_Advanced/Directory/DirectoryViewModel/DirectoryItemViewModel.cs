#region License

// author:         吴经纬
// created:        23:44
// description:

#endregion

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using PropertyChanged;
using WPF_Advanced.Directory.Data;

namespace WPF_Advanced.Directory.DirectoryViewModel
{
    /*
     * 当你实现 AddINotifyPropertyChangedInterface
     * 它会 反射这个类，然后给属性添加上 PropertyChanged 事件触发
     * 这样你就不需要为每一个属性都去触发这个事件了
     */
    public class DirectoryItemViewModel : BasicViewModel
    {
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            // Create commands
            ExpandCommand = new RelayCommand(Expand);

            FullPath = fullPath;
            Type = type;

            // 添加一个 dummy item 可以 让 TreeViewItem 能够展开
            ClearChildren();
        }



        #region Property

        public DirectoryItemType Type { get; set; }

        public string ImageName => Type == DirectoryItemType.Drive ? "drive" :
            Type == DirectoryItemType.File ? "file" :
            IsExpanded ? "folder-open" : "folder-closed";

        public string FullPath { get; set; }

        public string Name =>
            Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileOrFolderName(FullPath);

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        ///     代表这个 TreeViewItem 能否被展开
        /// </summary>
        public bool CanExpand => Type != DirectoryItemType.File;

        /// <summary>
        ///     代表 文件夹项目 是否已经被展开
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }

            set
            {
                // 如果 UI 表示可以被展开，查找所有子路径
                if (value) 
                    Expand();
                // 如果文件夹不可以展开，清除 dummy item
                else
                    this.ClearChildren();
            }
        }



        #endregion

        /// <summary>
        ///     The Command to expand folder
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #region Helper

        /// <summary>
        ///     移除 null item
        /// </summary>
        private void ClearChildren()
        {
            // 获取该空文件夹
            Children = new ObservableCollection<DirectoryItemViewModel>();

            // 为文件夹添加一个展开箭头，即使当中没有文件
            if (Type != DirectoryItemType.File) Children.Add(null);
        }

        /// <summary>
        ///     查找所有子路径
        /// </summary>
        private void Expand()
        {
            if (Type == DirectoryItemType.File) return;

            var children = DirectoryStructure.GetDirectoryContents(FullPath);

            Children = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure.GetDirectoryContents(FullPath)
                    .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        #endregion
    }

}