using System.IO;

namespace PH.CheckSum
{
    public delegate void CompleteHandler();
    public interface IHashProcesser
    {
        Stream InputStream { get; }
        string OutString { get; }
        string Name { get; }
        bool Enable { get; set; }

        event CompleteHandler Complete;


        void Run(Stream inputStream);
        void StartCompute(byte[] input);
        void StartCompute(Stream input);

        void Reset();
    }
}
