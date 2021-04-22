using System;
using PH.Dll;
using PH.CheckSum;
using System.Collections.Generic;
using System.Reflection;

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
