using System;
using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA512 : HashProcesserBase
    {
        public SHA512() : base("SHA512")
        {
            Algorithm = Hash.SHA512.Create();
        }
    }
}
