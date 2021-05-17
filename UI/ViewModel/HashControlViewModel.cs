using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PH.CheckSum.UI.ViewModel
{
    public class HashControlViewModel : ViewModelBase
    {
        public IHashProcessor Processor;


        public string Name { get { return Processor.Name; } }

        public string Hash
        {
            get { return Processor.OutString; }
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
            Processor.StartCompute(input);
        }
        public void StartCompute(Stream input)
        {
            Processor.StartCompute(input);
        }
        public void Reset()
        {
            Processor.Reset();
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
            Processor = new MD5();
            Processor.Complete += HashComplete;
        }
        public HashControlViewModel(IHashProcessor processor)
        {
            Copy = new RelayCommand(o => Copy_Clicked());
            Processor = processor;
            Processor.Complete += HashComplete;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
