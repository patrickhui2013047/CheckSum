using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PH.CheckSum.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region File Member
        private string _file = string.Empty;
        public string File
        {
            get { return _file; }
            set
            {
                _file = value;
                OnPropertyChanged(nameof(File));
            }
        }

        public ICommand BrowseFile { get; private set; }

        public bool FileEnable { get { return !TextEnable; } }
        #endregion

        #region Text Member
        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ICommand PlasteText { get; private set; }

        private bool _textEnable = false;
        public bool TextEnable
        {
            get { return _textEnable; }
            set
            {
                _textEnable = value;
                OnPropertyChanged(nameof(TextEnable));
                OnPropertyChanged(nameof(FileEnable));
            }
        }

        #endregion

        #region Hash Control Member
        public List<HashControlViewModel> _hashControlList = new List<HashControlViewModel>();
        public ObservableCollection<HashControlViewModel> HashControlCollection { get { return new ObservableCollection<HashControlViewModel>(_hashControlList); } }
        #endregion

        public MainViewModel() { }
    }
}
