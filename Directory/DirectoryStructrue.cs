    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    /// <summary>
    /// 获取当前path下的文件夹和文件 top的
    /// </summary>
     public class DirectoryStructrue
    {
        public static List<DirectoryItem> GetDirectoryContents(string fullpath)
        {
            var items = new List<DirectoryItem>();
            try
            {
                var dirs = Directory.GetDirectories(fullpath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }

            try
            {
                var files = Directory.GetFiles(fullpath);
                if (files.Length >0)
                    items.AddRange(files.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }
            return items;
        }
        /// <summary>
        /// 获取根目录
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrivers()
        {
            return Directory.GetLogicalDrives().Select(driver => new DirectoryItem { FullPath = driver, Type = DirectoryItemType.Driver }).ToList();
        }
        /// <summary>
        /// 获取绝对路径的文件夹名称
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace('/', '\\');
            var index = normalizedPath.LastIndexOf('\\');
            if (index < 0)
                return path;
            return normalizedPath.Substring(index + 1);
        }
    }
}
