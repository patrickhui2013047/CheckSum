using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PH.Dll
{
    public class DllLoader
    {
        public string Path { get; }
        public List<Type> Types { get; }
        public List<FileInfo> Dlls { get; }

        public DllLoader(string path = null)
        {
            Types = new List<Type>();
            Dlls = new List<FileInfo>();
            if (path == null)
            {
                path = Environment.CurrentDirectory;
            }
            Path = path;
            var files = Directory.EnumerateFiles(Path, "*.dll");
            foreach (var filePath in files)
            {
                Dlls.Add(new FileInfo(filePath));
                var dll = Assembly.LoadFile(filePath);
                TypeExtracter(dll).ForEach(item => Types.Add(item));
            }
        }

        protected virtual List<Type> TypeExtracter(Assembly dll)
        {
            return dll.GetTypes().ToList();
        }

    }

    public class DllLoader<TClass> : DllLoader where TClass : class
    {
        protected override List<Type> TypeExtracter(Assembly dll)
        {
            return dll.GetTypes().ToList().Where(item => IsInheritedClasses(item)).ToList();
        }

        bool IsInheritedClasses(Type type)
        {
            //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
            return type.IsClass && !type.IsAbstract && (type.IsSubclassOf(typeof(TClass)) || type.GetInterfaces().ToList().Contains(typeof(TClass)));
        }
    }
}
