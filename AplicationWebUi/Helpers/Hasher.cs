using NETCore.Encrypt.Extensions;

namespace AplicationWebUi.Helpers
{
    public class Hasher : IHasher
    {
        private readonly IConfiguration _configuration;

        public Hasher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DoMd5HashedString(string pass)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = pass + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }
    }
}
