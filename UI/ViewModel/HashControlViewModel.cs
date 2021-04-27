using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PH.CheckSum;

namespace PH.CheckSum.UI.ViewModel
{
    public class HashControlViewModel : ViewModelBase
    {
        public IHashProcesser Processer;


        public string Name { get { return Processer.Name; } }

        public string Hash
        {
            get { return Processer.OutString; }
        }

        private bool _isEnable;
        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }

        public ICommand Copy { get; private set; }

        private void Copy_Clicked()
        {
            Clipboard.SetText(Hash);
        }

        private void HashComplete()
        {
            OnPropertyChanged(nameof(Hash));
        }

        public HashControlViewModel() 
        {
            Copy = new RelayCommand(o=>Copy_Clicked());
            Processer = new MD5();
            Processer.Complete += HashComplete;
        }

        

        public HashControlViewModel(IHashProcesser processer)
        {
            Copy = new RelayCommand(o => Copy_Clicked());
            Processer = processer;
            Processer.Complete += HashComplete;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
