using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    public class DirectoryStructureViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        public DirectoryStructureViewModel()
        {
            var childerns = DirectoryStructrue.GetLogicalDrivers();
            Items = new ObservableCollection<DirectoryItemViewModel>(childerns.Select(childern => new DirectoryItemViewModel(childern.FullPath, DirectoryItemType.Driver)));
        }
    }
}
