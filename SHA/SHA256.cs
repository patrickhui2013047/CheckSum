using Hash = System.Security.Cryptography;
namespace PH.CheckSum
{
    public class SHA256 : HashProcesserBase
    {
        public SHA256() : base("SHA256", true)
        {
            Algorithm = Hash.SHA256.Create();
        }
    }
}
