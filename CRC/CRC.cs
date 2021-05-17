using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class CRC4 : HashProcesserBase
    {
        public CRC4() : base("CRC4", true)
        {
            Algorithm = Hash.CRC.Create();
        }
    }


}
namespace System.Security.Cryptography
{
    public class CRC : KeyedHashAlgorithm
    {
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }
    }
}
