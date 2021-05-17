using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using Hash = System.Security.Cryptography;

namespace CheckSumLib
{
    public class CheckSum
    {
        public bool MD5 { get; private set; }
        public bool SHA1 { get; private set; }
        public bool SHA256 { get; private set; }
        public bool SHA512 { get; private set; }
        public bool StringMode { get; private set; }
        public bool CompareMode { get; private set; }
        public string CompareInput { get; private set; }
        public string Input { get; private set; }
        public Stream InputStream { get; private set; }
        private bool needInput = true;
        private bool haveArgs = true;
        private bool haveComplexArgs = true;
        private CheckSumArgumentsList argumentsList = new CheckSumArgumentsList();

        public CheckSum()
        {

        }

        public void Config(string[] args)
        {
            #region pre-define setting
            SHA1 = false;
            SHA256 = true;
            SHA512 = false;
            MD5 = true;
            CompareMode = false;

            #endregion

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (argumentsList.Contain(args[i]))
                    {
                        var argument = argumentsList.GetArgument(args[i]);
                        if (argument.IsComplexInput)
                        {
                            var argumentInput = args[i + 1];
                            switch (argument.Name)
                            {
                                case "-compare":
                                    CompareMode = true;
                                    CompareInput = argumentInput;
                                    break;
                                default:
                                    throw new Exception("Unknown\nI don't what make this happen, but seem \"" + args[i] + "\"make it occur.");
                            }
                            i++;
                        }
                        else
                        {
                            switch (argument.Name)
                            {
                                case "-string":
                                    StringMode = true;
                                    break;
                                case "-all":
                                    SHA1 = true;
                                    SHA256 = true;
                                    SHA512 = true;
                                    MD5 = true;
                                    break;
                                case "-sha1":
                                    SHA1 = true;
                                    break;
                                case "sha256":
                                    SHA256 = true;
                                    break;
                                case "-sha512":
                                    SHA512 = false;
                                    break;
                                case "-md5":
                                    MD5 = true;
                                    break;
                                default:
                                    throw new Exception("Unknown\nI don't what make this happen, but seem \"" + args[i] + "\"make it occur.");

                            }
                        }

                    }
                    else
                    {
                        throw new Exception("Unknow argument " + args[i]);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Input))
                    {
                        Input = args[i];
                    }
                    else
                    {
                        throw new Exception("Multiple input detected, conflicted input: " + Input + " and " + args[i]);
                    }
                }
            }

        }

        public void Run()
        {
            if (StringMode)
            {
                InputStream = new MemoryStream(Encoding.ASCII.GetBytes(Input));
            }
            else
            {
                Uri uri;
                if (!Uri.TryCreate(Input, UriKind.RelativeOrAbsolute, out uri))
                {
                    throw new Exception("Invaild target path");
                }
                InputStream = new FileStream(uri.ToString(), FileMode.Open, FileAccess.Read);
            }
            if (string.IsNullOrEmpty(Input))
            {
                throw new Exception("Empty input");
            }

            var result = new NameValueCollection();
            if (MD5)
            {
                var hash = Hash.MD5.Create();
                var stream = new BufferedStream(InputStream);
                stream.Position = 0;
                var bytes = hash.ComputeHash(stream);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                var text = builder.ToString();
                result.Add("MD5", text);
                Console.WriteLine(string.Format("{0}: {1}", "MD5", text));
            }
            if (SHA1)
            {
                var hash = Hash.SHA1.Create();
                var stream = new BufferedStream(InputStream);
                stream.Position = 0;
                var bytes = hash.ComputeHash(stream);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                var text = builder.ToString();
                result.Add("SHA1", text);
                Console.WriteLine(string.Format("{0}: {1}", "SHA1", text));
            }
            if (SHA256)
            {
                var hash = Hash.SHA256.Create();
                var stream = new BufferedStream(InputStream);
                stream.Position = 0;
                var bytes = hash.ComputeHash(stream);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                var text = builder.ToString();
                result.Add("SHA256", text);
                Console.WriteLine(string.Format("{0}: {1}", "SHA256", text));
            }
            if (SHA512)
            {
                var hash = Hash.SHA512.Create();
                var stream = new BufferedStream(InputStream);
                stream.Position = 0;
                var bytes = hash.ComputeHash(stream);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                var text = builder.ToString();
                result.Add("SHA512", text);
                Console.WriteLine(string.Format("{0}: {1}", "SHA512", text));
            }

            if (CompareMode)
            {
                var flag = false;
                foreach (string key in result.AllKeys)
                {
                    if (result.Get(key) == CompareInput)
                    {
                        Console.WriteLine("{0} match", key.ToUpper());
                        flag = true;
                        break;
                    }
                }
                if (!flag) { Console.WriteLine("No matched hash found"); }
            }

        }

        public void Help()
        {
            Console.WriteLine("Usage:");
            var argsWithInput = new List<CheckSumArgument>();
            var argsWithoutInput = new List<CheckSumArgument>();
            if (argumentsList.Count > 0)
            {

                foreach (CheckSumArgument argument in argumentsList.GetArguments())
                {
                    if (argument.IsComplexInput)
                    {
                        argsWithInput.Add(argument);
                    }
                    else
                    {
                        argsWithoutInput.Add(argument);
                    }
                }
            }
            if (needInput) { Console.Write("checksum target"); }
            if (haveArgs)
            {

                var temp = new List<string>();
                foreach (CheckSumArgument argument in argsWithoutInput)
                {
                    var temp2 = new List<string>();
                    temp2.Add(argument.Name);
                    foreach (string alias in argument.Alias)
                    {
                        temp2.Add(alias);
                    }
                    temp.Add(string.Join("|", temp2));
                }
                Console.Write(" [{0}]", string.Join("] [", temp));

            }
            if (haveComplexArgs)
            {
                var temp = new List<string>();
                foreach (CheckSumArgument argument in argsWithInput)
                {
                    var temp2 = new List<string>();
                    temp2.Add(argument.Name);
                    foreach (string alias in argument.Alias)
                    {
                        temp2.Add(alias);
                    }
                    temp.Add(string.Format("{0} {1}", string.Join("|", temp2), argument.InputName));
                }
                Console.Write(" [{0}]", string.Join(" ", temp));

            }
            Console.WriteLine();

            Console.WriteLine("Input:");
            if (needInput) { Console.WriteLine("\t{0}\t\t{1}", "target", "URL of the target.\n\t\t\te.g. D:/test.txt => D:/text.txt\n\t\t\te.g. http://example.com/example.txt => http://example.com/example.txt"); }
            if (haveArgs)
            {
                foreach (CheckSumArgument argument in argsWithoutInput)
                {
                    Console.WriteLine("\t{0}\t\t{1}", argument.Name, argument.Description);
                }
            }
            if (haveComplexArgs)
            {
                foreach (CheckSumArgument argument in argsWithInput)
                {
                    Console.WriteLine("\t{0}\t{1}", argument.Name, argument.Description);
                }

            }

        }

        public void Error(Exception e)
        {
            Console.WriteLine("Error:" + e.ToString());
            Help();
        }

    }
    class CheckSumArgumentsList : NameObjectCollectionBase
    {
        public CheckSumArgumentsList()
        {

            var str = new CheckSumArgument("-string", "Hash the string but not file");
            str.Alias.Add("-s");
            BaseAdd("all", str);

            var all = new CheckSumArgument("-all", "Output all hash value.");
            all.Alias.Add("-a");
            BaseAdd("all", all);

            var md5 = new CheckSumArgument("-md5", "Allow output MD5.");
            BaseAdd("md5", md5);

            var sha1 = new CheckSumArgument("-sha1", "Allow output SHA1.");
            sha1.Alias.Add("-1");
            BaseAdd("sha1", sha1);

            var sha256 = new CheckSumArgument("-sha256", "Allow output SHA256.");
            sha256.Alias.Add("-256");
            BaseAdd("sha256", sha256);

            var sha512 = new CheckSumArgument("-sha512", "Allow output SHA512.");
            sha512.Alias.Add("-512");
            BaseAdd("sha512", sha512);

            var help = new CheckSumArgument("-help", "Show help manul");
            help.Alias.Add("-?");
            BaseAdd("help", help);

            var compare = new CheckSumArgument("-compare", "Compare with input. This mode will check all hash.", true, "hash");
            compare.Alias.Add("-c");
            BaseAdd("compare", compare);

        }

        public CheckSumArgument[] GetArguments()
        {

            return BaseGetAllValues().Cast<CheckSumArgument>().ToArray();
        }

        public CheckSumArgument GetArgument(string name, bool allowAlias = true)
        {

            var buff = GetArguments().Where(arg => arg.Name == name || arg.Alias.Contains(name));
            if (!allowAlias)
            {
                buff = GetArguments().Where(arg => arg.Name == name);
            }
            return buff.ToArray()[0];
        }

        public bool Contain(string name, bool allowAlias = true)
        {
            var buff = GetArguments().Where(arg => arg.Name == name || arg.Alias.Contains(name));
            if (!allowAlias)
            {
                buff = GetArguments().Where(arg => arg.Name == name);
            }

            return buff.Any();
        }
    }
    class CheckSumArgument
    {
        public string Name { get; private set; }
        public List<string> Alias { get; private set; }
        public string Description { get; private set; }
        public bool IsComplexInput { get; private set; }
        public string InputName { get; private set; }

        public CheckSumArgument(string name, string description = "", bool complex = false, string inputName = "")
        {
            Name = name;
            Description = description;
            IsComplexInput = complex;
            InputName = inputName;
            Alias = new List<string>();
        }
    }
}

