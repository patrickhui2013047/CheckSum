using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA1 : HashProcessorBase
    {
        public SHA1() : base("SHA1", true)
        {
            Algorithm = Hash.SHA1.Create();
        }
    }
}
