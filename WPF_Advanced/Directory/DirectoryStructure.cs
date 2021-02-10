#region License
// author:         吴经纬
// created:        22:37
// description:
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WPF_Advanced.Directory.Data;

namespace WPF_Advanced.Directory
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives().Select(
                drive => new DirectoryItem()
                {
                    FullPath = drive,
                    Type = DirectoryItemType.Drive
                }).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create a blank list for directories
            var items = new List<DirectoryItem>();

            #region Get Folders

            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(
                        dirs.Select(
                            dir => new DirectoryItem()
                            {
                                FullPath = dir,
                                Type = DirectoryItemType.Folder
                            }));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            #endregion

            #region Get Files


            try
            {
                var files = System.IO.Directory.GetFiles(fullPath);

                if (files.Length > 0)
                {
                    items.AddRange(files.Select(
                        file => new DirectoryItem()
                        {
                            FullPath = file,
                            Type = DirectoryItemType.File
                        }));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            #endregion

            return items;
        }

        #region Helper

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="directoryPath">The full path</param>
        /// <returns></returns>
        public static string GetFileOrFolderName(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                return string.Empty;
            }
            // 将 linux 类型路径符号也置换成 win 系统路径符号
            var normalizePath = directoryPath.Replace('/', '\\');

            var lastIndex = normalizePath.LastIndexOf('\\');

            // 如果没有找到反斜杠，返回path本身
            if (lastIndex < 0)
            {
                return directoryPath;
            }

            return directoryPath.Substring(lastIndex + 1);
        }

        #endregion

    }
}