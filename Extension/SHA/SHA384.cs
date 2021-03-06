﻿using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA384 : HashProcessorBase
    {
        public SHA384() : base("SHA384", false)
        {
            Algorithm = Hash.SHA384.Create();
        }
    }
}
