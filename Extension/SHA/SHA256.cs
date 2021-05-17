using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA256 : HashProcessorBase
    {
        public SHA256() : base("SHA256", true)
        {
            Algorithm = Hash.SHA256.Create();
        }
    }
}
