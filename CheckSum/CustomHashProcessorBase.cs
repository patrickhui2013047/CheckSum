using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PH.CheckSum
{
    public interface IHashAlgorithm
    {
        Task<byte[]> ComputeHashAsync(Stream InputStream);
    }


    public class CustomHashProcessorBase : IHashProcessor
    {
        public Stream InputStream { get; protected set; }

        public string OutString { get; protected set; }

        public string Name { get; }

        public bool Enable { get; set; }

        public bool IsComputing { get; set; }

        protected IHashAlgorithm Algorithm { get; set; }

        private Thread thread;

        public CustomHashProcessorBase()
        {
            OutString = string.Empty;
        }

        protected CustomHashProcessorBase(string name, bool enable = true)
        {
            Name = name;
            Enable = enable;
            OutString = string.Empty;
        }

        public event CompleteHandler Complete;

        public async void Run(Stream inputStream)
        {
            Console.WriteLine("[{0}] is handling {1}", Thread.CurrentThread.ManagedThreadId, Name);
            if (!IsComputing)
            {
                IsComputing = true;
                InputStream = inputStream;
                InputStream.Position = 0;
                var bytes = await Algorithm.ComputeHashAsync(InputStream);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                OutString = builder.ToString().ToUpper();
                InputStream.Position = 0;
                if (Complete != null)
                {
                    Complete.Invoke();
                }
                IsComputing = false;
                Console.WriteLine("[{0}] is ended.", Thread.CurrentThread.ManagedThreadId);
            }
        }

        private void ThreadRun(object obj)
        {
            Run((Stream)obj);
        }

        public void StartCompute(byte[] input)
        {
            if (!IsComputing)
            {
                MemoryStream stream = new MemoryStream(input, 0, input.Length);
                thread = new Thread(ThreadRun);
                thread.Name = Name;
                thread.Start(stream);
            }
        }

        public void StartCompute(Stream stream)
        {
            if (!IsComputing)
            {
                thread = new Thread(ThreadRun);
                thread.Name = Name;
                thread.Start(stream);
            }
        }

        public void Reset()
        {
            OutString = string.Empty;
        }

        public void ThreadHalt()
        {
            foreach (var d in Complete.GetInvocationList())
            {
                Complete -= (CompleteHandler)d;
            }
            //thread.Join();
            //TODO: find a way to stop thread safty.
        }
    }
}
