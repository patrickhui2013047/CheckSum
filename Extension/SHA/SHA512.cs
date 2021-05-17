using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA512 : HashProcessorBase
    {
        public SHA512() : base("SHA512", true)
        {
            Algorithm = Hash.SHA512.Create();
        }
    }
}
