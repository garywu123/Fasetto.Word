#region License
// author:         吴经纬
// created:        22:37
// description:
#endregion

namespace WPF_Advanced.Directory.Data
{
    /// <summary>
    /// Information about a directory item such as a drive, a file or a folder
    /// </summary>
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name => 
            this.Type == DirectoryItemType.Drive ? 
                this.FullPath : 
                DirectoryStructure.GetFileOrFolderName(FullPath);
    }
}