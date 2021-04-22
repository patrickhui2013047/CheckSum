using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Hash = System.Security.Cryptography;

namespace PH.CheckSum
{
    public abstract class HashProcesserBase : IHashProcesser
    {
        public Stream InputStream { get; protected set; }

        public string OutString { get; protected set; }

        public string Name { get; }

        public bool Enable { get; set; }

        protected Hash.HashAlgorithm Algorithm { get; set; }

        public HashProcesserBase() { }

        protected HashProcesserBase(string name, bool enable = true)
        {
            Name = name;
            Enable = enable;
        }

        public void Run(Stream inputStream)
        {
            InputStream = inputStream;
            InputStream.Position = 0;
            var bytes = Algorithm.ComputeHash(InputStream);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            OutString = builder.ToString().ToUpper();
            InputStream.Position = 0;
        }
    }
}
