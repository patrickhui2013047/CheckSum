using System.IO;
using System.Windows;
using System.Windows.Input;

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
        public event CompleteHandler Completed;

        private void Copy_Clicked()
        {
            Clipboard.SetText(Hash);
        }
        public void StartCompute(byte[] input)
        {
            Processer.StartCompute(input);
        }
        public void StartCompute(Stream input)
        {
            Processer.StartCompute(input);
        }
        public void Reset()
        {
            Processer.Reset();
            OnPropertyChanged(nameof(Hash));
        }

        private void HashComplete()
        {
            OnPropertyChanged(nameof(Hash));
            if (Completed != null)
            {
                Completed.Invoke();
            }
        }

        public HashControlViewModel()
        {
            Copy = new RelayCommand(o => Copy_Clicked());
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
