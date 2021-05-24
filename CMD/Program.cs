using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using PH.CheckSum;
using PH.CheckSum.CMD.Properties;
using PH.Dll;


//TODO: full function test

namespace PH.CheckSum.CMD
{
    class Program
    {
        public static List<IHashProcessor> HashProcessorList = new List<IHashProcessor>();

        public static List<Parameter> AviliableParameter = new List<Parameter>();

        static List<Parameter> EnabledParameter = new List<Parameter>();
        static List<bool> DoneFlag = new List<bool>();

        static bool IsDefault = true;
        static bool IsText = false;
        static bool IsDone = false;

        static int BaseLine = 0;

        static object ConsoleLock = new object();

        static Regex InputFilter = new Regex(@"(?<para>-[\w\d]+)|(?<quoted>""[\w\d\s""]*"")| (?<text>^[\w\d\.\/\\:] +$)");

        static void Main(string[] args)
        {
            LoadProcessor();
            AviliableParameter.Add(PredefinedParameter.File);
            AviliableParameter.Add(PredefinedParameter.Text);
            AviliableParameter.Add(PredefinedParameter.List);
            AviliableParameter.Add(PredefinedParameter.Help);
            HashProcessorList.ForEach(item => AviliableParameter.Add(new HashParameter(item)));
            //==================================================================================
            if (args.Length == 0)
            {
                Console.WriteLine("No input parameter detected.");
                Help();
                return;
            }
            int index = 0;
            string input = string.Empty;

            //analysis input arguments
            do
            {
                var arg = args[index];

                if (!arg.StartsWith('-'))
                {
                    input = arg;
                    IsText = true;
                }

                var result = InputFilter.Match(arg);
                if (result.Success)
                {
                    if (result.Groups.Cast<Group>().Where(item => item.Success && item.Name == "para").Count() > 0)
                    {
                        arg = arg.Substring(1);
                        var para = AviliableParameter.Find(item =>
                        {
                            var isTrue = item.Name == arg;
                            if (item.Alies != null)
                            {
                                isTrue = isTrue || item.Alies.Contains(arg);
                            }
                            return isTrue;
                        });
                        EnabledParameter.Add(para);
                    }
                    if (result.Groups.Cast<Group>().Where(item => item.Success && item.Name == "quoted").Count() > 0)
                    {
                        input = result.Value;
                        IsText = true;
                    }
                    if (result.Groups.Cast<Group>().Where(item => item.Success && item.Name == "text").Count() > 0)
                    {
                        input = result.Value;
                    }
                }
                index++;
            } while (index < args.Length);

            //conflict detection
            if (EnabledParameter.Contains(PredefinedParameter.Text) && EnabledParameter.Contains(PredefinedParameter.File))
            {
                Console.WriteLine("Error: text and file are used together.");
            }

            //config the Hash processer
            foreach (Parameter para in EnabledParameter)
            {
                if (para.GetType() == typeof(HashParameter))
                {
                    if (IsDefault)
                    {
                        HashProcessorList.ForEach(item => item.Enable = false);
                    }
                    IsDefault = false;
                    var name = ((HashParameter)para).FullName;
                    HashProcessorList.Find(item => item.Name == name).Enable = true;
                }
                if (para == PredefinedParameter.File)
                {
                    IsText = false;
                }
                else if (para == PredefinedParameter.Text)
                {
                    IsText = true;
                }
                else if (para == PredefinedParameter.Help)
                {
                    Help();
                    return;
                }
                else if (para == PredefinedParameter.List)
                {
                    List();
                    return;
                }
            }

            //remove quotation
            if (input.StartsWith('"') && input.EndsWith('"'))
            {
                input = input.Substring(1, input.Length - 2);
            }

            Compute(input, IsText);
        }

        //TODO: Check layout
        static void Help()
        {
            var help = Resources.ResourceManager.GetString("HelpContent");
            Console.WriteLine(help);
        }

        //TODO: Check layout
        static void List()
        {
            Console.WriteLine("{0}\t\t\t{1}", "Name", "Parameter name");
            foreach (IHashProcessor processor in HashProcessorList)
            {
                Console.WriteLine("{0}\t\t\t{1}", processor.Name, '-' + processor.Name.ToLower());
            }
        }

        //TODO: File hashing checking
        static void Compute(string input, bool isText)
        {
            List<Thread> ThreadPool = new List<Thread>();
            var enabledProcessor = HashProcessorList.FindAll(item => item.Enable);
            DoneFlag = new List<bool>();
            enabledProcessor.ForEach(item => DoneFlag.Add(false));
            if (!(enabledProcessor.Count > 0))
            {
                return;
            }
            BaseLine = Console.GetCursorPosition().Top;
            if (!IsText)
            {
                if (File.Exists(input))
                {
                    
                }
                else
                {
                    Console.WriteLine("Unable to find the file with the path: {0}", input);
                    return;
                }
            }

            for (int i = 0; i < enabledProcessor.Count; i++)
            {
                Console.WriteLine("{0}:\t", enabledProcessor[i].Name);
                Thread thread = new Thread(Run);
                thread.Start(new WorkerConfig()
                {
                    Input = input,
                    IsText = isText,
                    LineOffset = i,
                    Processor = enabledProcessor[i]
                });
            }


            while (!IsDone)
            {

            }
        }

        private static void Run(object obj)
        {
            var config = (WorkerConfig)obj;
            bool isDone = false;
            Stream stream;
            if (config.IsText)
            {
                stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(config.Input));
            }
            else
            {
                stream = new FileStream(config.Input, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            config.Processor.Complete += delegate ()
            {
                isDone = true;
            };
            config.Processor.StartCompute(stream);
            while (!isDone)
            {

            }
            DoneFlag[config.LineOffset] = true;
            lock (ConsoleLock)
            {
                Console.SetCursorPosition(0, BaseLine + config.LineOffset);
                Console.WriteLine("{0}\t{1}", config.Processor.Name, config.Processor.OutString);
            }

        }

        public static void LoadProcessor()
        {
            HashProcessorList.Clear();
            DllLoader<IHashProcessor> dllLoader = new DllLoader<IHashProcessor>();
            var test = (IHashProcessor)dllLoader.Types[0].GetConstructor(Type.EmptyTypes).Invoke(null);
            dllLoader.Types.ForEach(item => HashProcessorList.Add((IHashProcessor)Activator.CreateInstance(item)));
        }
    }

    class Parameter
    {
        public string Name { get; set; }
        public string[] Alies { get; set; }
    }

    class HashParameter : Parameter
    {
        public string FullName { get; }
        public HashParameter(IHashProcessor processor)
        {
            Name = processor.Name.ToLower();
            FullName = processor.Name;
        }
    }

    static class PredefinedParameter
    {
        public static readonly Parameter Help = new Parameter()
        {
            Name = "help",
            Alies = new string[] { "h" }
        };
        public static readonly Parameter List = new Parameter()
        {
            Name = "list",
            Alies = new string[] { "l" }
        };
        public static readonly Parameter File = new Parameter()
        {
            Name = "file",
            Alies = new string[] { "f" }
        };
        public static readonly Parameter Text = new Parameter()
        {
            Name = "text",
            Alies = new string[] { "t" }
        };
    }

    class WorkerConfig
    {
        public string Input { get; set; }
        public bool IsText { get; set; }
        public int LineOffset { get; set; }
        public IHashProcessor Processor { get; set; }
    }
}
