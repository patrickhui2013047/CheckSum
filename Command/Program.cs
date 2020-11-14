using System;
using CheckSumLib;
namespace Command
{
    class Program
    {
        static CheckSum CheckSum;
        static void Main(string[] args)
        {
            try
            {
                CheckSum = new CheckSum();
                if (args.Length <1)
                {
                    CheckSum.Help();
                    return;
                }
                CheckSum.Config(args);
                CheckSum.Run();


            }
            catch (Exception e)
            {
                CheckSum.Error(e);
            }
        }
    }
}
