using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class MD5 : HashProcesserBase
    {
        public MD5() : base("MD5", true)
        {
            Algorithm = Hash.MD5.Create();
        }
    }
}
