using PH.CheckSum;
using PH.Dll;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static DllLoader<IHashProcesser> Loader;
        static List<IHashProcesser> Processers;
        static void Main(string[] args)
        {
            Loader = new DllLoader<IHashProcesser>();
            Processers = new List<IHashProcesser>();
            var test = Loader.Types;
            test.ForEach(item => Processers.Add((IHashProcesser)Activator.CreateInstance(item)));
            Console.WriteLine("Hello World!");
        }
    }
}
