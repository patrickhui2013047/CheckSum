using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hash = System.Security.Cryptography;

namespace Algorithm
{
    public class MD5:HashProcesser
    {
        public MD5() : base("MD5")
        {
            Algorithm = Hash.MD5.Create();
        }
    }
    public class SHA1 : HashProcesser
    {
        public SHA1() : base("SHA-1")
        {
            Algorithm = Hash.SHA1.Create();
        }
    }
    public class SHA256 : HashProcesser
    {
        public SHA256() : base("SHA-256")
        {
            Algorithm = Hash.SHA256.Create();
        }
    }
    public class SHA512 : HashProcesser
    {
        public SHA512() : base("SHA-512")
        {
            Algorithm = Hash.SHA512.Create();
        }
    }
}
