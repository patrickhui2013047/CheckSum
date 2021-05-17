using Microsoft.Win32;
using PH.Dll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
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
        private OpenFileDialog _fileSelector = new OpenFileDialog();
        public bool FileEnable { get { return !TextEnable; } }
        public bool FileControlEnable { get { return FileEnable && IsNotBusy; } }
        #endregion

        #region Text Member
        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set 
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
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
                OnPropertyChanged(nameof(TextControlEnable));
                OnPropertyChanged(nameof(FileControlEnable));
            }
        }
        public bool TextControlEnable { get { return TextEnable && IsNotBusy; } }

        #endregion

        #region Hash Control Member
        public bool AutoCompute { get; set; }

        public List<IHashProcesser> HashProcesserList = new List<IHashProcesser>();
        public List<HashControlViewModel> _hashControlList = new List<HashControlViewModel>();
        public ObservableCollection<HashControlViewModel> HashControlCollection { get { return new ObservableCollection<HashControlViewModel>(_hashControlList.OrderBy(item => item.IsEnable)); } }
        #endregion

        #region Hash Member
        private string _hash = string.Empty;
        public string Hash
        {
            get { return _hash; }
            set
            {
                _hash = value;
                OnPropertyChanged(nameof(Hash));
            }
        }

        public ICommand PasteHash { get; private set; }
        #endregion

        #region Process Control
        private static object _processLock = new object();
        private static object _doneLock = new object();
        private string _status = "Pending...";
        public string Status
        {
            get { return _status; }
            private set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private int _processCount = 0;
        public int ProcessCount
        {
            get { return _processCount; }
            private set
            {
                _processCount = value;
                OnPropertyChanged(nameof(ProcessDone));
                OnPropertyChanged(nameof(ProcessCount));
                if (ProcessDone >= ProcessCount && ProcessCount > 0)
                {
                    IsBusy = false;
                    ProcessCount = 0;
                    ProcessDone = 0;
                }
            }
        }
        private int _processDone = 0;
        public int ProcessDone
        {
            get { return _processDone; }
            private set
            {

                _processDone = value;
                OnPropertyChanged(nameof(ProcessDone));
                if (ProcessDone >= ProcessCount && ProcessCount > 0)
                {
                    IsBusy = false;
                    Status = "Completed";
                    ProcessCount = 0;
                    ProcessDone = 0;
                }

            }
        }
        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
                OnPropertyChanged(nameof(IsNotBusy));
                OnPropertyChanged(nameof(TextControlEnable));
                OnPropertyChanged(nameof(FileControlEnable));
            }
        }
        public bool IsNotBusy { get { return !IsBusy; } }
        #endregion

        #region Event
        public ICommand Compute { get; private set; }
        public ICommand Compare { get; private set; }
        public ICommand ComputeNCompare { get; private set; }
        public ICommand ItemDrop { get; private set; }

        private void ComputeHash()
        {
            _hashControlList.ForEach(item => item.Reset());
            var enableHash = _hashControlList.FindAll(item => item.IsEnable);
            ProcessCount = enableHash.Count;
            if (!(ProcessCount > 0))
            {
                return;
            }
            IsBusy = true;
            Status = "Hash computing...";
            foreach (var hash in enableHash)
            {
                Stream stream;
                if (FileEnable)
                {
                    stream = new FileStream(File, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                else if (TextEnable)
                {
                    stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(Text));
                }
                else
                {
                    throw new Exception("Input setting error");
                }
                hash.Completed += HashComputed;
                hash.StartCompute(stream);

            }
        }

        private void CompareHash()
        {
            var compare = Hash.ToUpper();
            foreach (var hash in _hashControlList.FindAll(item => item.IsEnable))
            {
                if (hash.Hash == compare)
                {
                    MessageBox.Show(string.Format("{0} is matched.", hash.Name));
                }
            }
        }

        private void OpenFileSelector()
        {

            if ((bool)_fileSelector.ShowDialog())
            {
                File = _fileSelector.FileName;
            }
            if (AutoCompute)
            {
                ComputeHash();
            }
        }

        private void SetCommand()
        {
            Compute = new RelayCommand(o => ComputeHash());
            Compare = new RelayCommand(o => CompareHash());
            ComputeNCompare = new RelayCommand(o =>
            {
                ComputeHash();
                while (IsBusy) { }
                CompareHash();
            });
            BrowseFile = new RelayCommand(o => OpenFileSelector());
            PasteHash = new RelayCommand(o =>
            {
                if (Clipboard.ContainsText())
                {
                    Hash = Clipboard.GetText();
                }
            });
            PlasteText = new RelayCommand(o => 
            {
                if (Clipboard.ContainsText())
                {
                    Text = Clipboard.GetText();
                }
                if (AutoCompute)
                {
                    ComputeHash();
                }
            });
        }

        private void HashComputed()
        {
            lock (_processLock)
            {

                ProcessDone++;
            }
        }

        public void ItemDroped(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                var data = (string[])e.Data.GetData(DataFormats.FileDrop);
                TextEnable = false;
                File = data[0];
                if (AutoCompute)
                {
                    ComputeHash();
                }
            }else if (e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
                e.Effects = DragDropEffects.Copy;
                var data = (string)e.Data.GetData(DataFormats.UnicodeText);
                TextEnable = true;
                Text = data;
                if (AutoCompute)
                {
                    ComputeHash();
                }
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
        #endregion

        #region Thread Control
        private Thread workerThread;
        public void StartWorking(ThreadStart threadStart)
        {
            workerThread = new Thread(threadStart);
            workerThread.IsBackground = true;
            workerThread.Name = "Worker";
            workerThread.Start();
        }
        public void StartWorking(ParameterizedThreadStart parameterizedThreadStart, object obj)
        {
            workerThread = new Thread(parameterizedThreadStart);
            workerThread.IsBackground = true;
            workerThread.Name = "Worker";
            workerThread.Start(obj);
        }
        #endregion

        public MainViewModel()
        {
            LoadProcesser();
            SetCommand();
        }

        public void LoadProcesser()
        {
            _hashControlList.Clear();
            HashProcesserList.Clear();
            DllLoader<IHashProcesser> dllLoader = new DllLoader<IHashProcesser>();
            var test = (IHashProcesser)dllLoader.Types[0].GetConstructor(Type.EmptyTypes).Invoke(null);
            dllLoader.Types.ForEach(item => HashProcesserList.Add((IHashProcesser)Activator.CreateInstance(item)));
            HashProcesserList.ForEach(item => _hashControlList.Add(new HashControlViewModel(item)));
            //OnPropertyChanged(nameof(HashControlCollection));
        }

        public byte[] ReadToEnd(MemoryStream stream)
        {

            return stream.ToArray();
        }
    }
}
