using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    /// <summary>
    /// Information of a Directory
    /// </summary>
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name { get {return this.Type==DirectoryItemType.Driver? this.FullPath: DirectoryStructrue.GetFileFolderName(this.FullPath); } }
    }
}
