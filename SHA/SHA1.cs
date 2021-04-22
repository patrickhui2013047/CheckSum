using System;
using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA1 : HashProcesserBase
    {
        public SHA1() : base("SHA1")
        {
            Algorithm = Hash.SHA1.Create();
        }
    }
}
