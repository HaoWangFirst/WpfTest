using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest
{
    public class DirectoryItemViewModel:BaseViewModel
    {
        /// <summary>
        /// 用来展开childern的指令
        /// </summary>
        public ICommand ExpandCommand { get; set; }
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name { get { return DirectoryItemType.Driver == this.Type ? this.FullPath : DirectoryStructrue.GetFileFolderName(this.FullPath); } }
        public ObservableCollection<DirectoryItemViewModel> Childern { get; set; }
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }
        public bool IsExpand
        {
            get
            {
                return this.Childern?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                    Expand();
                else
                    ClearChildern();
            }
        }
        public DirectoryItemViewModel(string fullpath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullpath;
            this.Type = type;
            this.ClearChildern();
        }
        private void ClearChildern()
        {
            this.Childern = new ObservableCollection<DirectoryItemViewModel>();
            if(this.Type != DirectoryItemType.File)
            {
                Childern.Add(null);
            }
        }
        private void Expand()
        {
            if (DirectoryItemType.File == this.Type)
                return;
            Childern = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructrue.GetDirectoryContents(FullPath).Select(content => new DirectoryItemViewModel(FullPath = content.FullPath, Type = content.Type )));
        }

    }
}
