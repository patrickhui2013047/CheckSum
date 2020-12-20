using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hash = System.Security.Cryptography;

namespace Algorithm
{
    public abstract class HashProcesser
    {
        public Stream InputStream { get; private set; }
        public string OutString { get; private set; }
        public string Name { get; }
        public bool Enable { get; set; }
        protected Hash.HashAlgorithm Algorithm { get; set; }

        protected HashProcesser(string name, bool enable = true)
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
            OutString = builder.ToString();
            InputStream.Position = 0;
        }
    }
}

