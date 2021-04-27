using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Hash = System.Security.Cryptography;

namespace PH.CheckSum
{
    public delegate void CompleteHandler();
    public interface IHashProcesser
    {
        Stream InputStream { get; }
        string OutString { get;}
        string Name { get; }
        bool Enable { get; set; }

        event CompleteHandler Complete;
        

        void Run(Stream inputStream);

    }
}
