using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Jose;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public class StoreTokenService : IStoreTokenService
    {
        private const string EntityIdKey = "entityId";

        private static readonly char[] SecretStringTemplate;

        static StoreTokenService()
        {
            SecretStringTemplate = "123456789ABCDEFGHJKMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz".ToCharArray();
        }

        private readonly ILogger<StoreTokenService> _logger;
        private readonly IStoreEntityService _storeEntityService;

        public StoreTokenService(ILogger<StoreTokenService> logger
            , IStoreEntityService storeEntityService)
        {
            _logger = logger;
            _storeEntityService = storeEntityService;
        }

        public IStandardResponse<string> GenerateSecretAsString()
        {
            return RandomString(64).GenerateStandardResponse();
        }

        public IStandardResponse<byte[]> GenerateSecretAsBytes(int numberOfBytes)
        {
            var secretkey = new byte[numberOfBytes];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(secretkey);
            }

            return secretkey.GenerateStandardResponse();
        }

        public IStandardResponse<string> GenerateToken(string secret
                                                        , string salt
                                                        , Guid entityId)
        {
            var payload = new Dictionary<string, object>();
            var headers = new Dictionary<string, object>
            {
                {"typ", "JWT"},
                {"cty", "JWT"},
                {EntityIdKey, entityId}
            };

            byte[] key;
            using (var generator = new Rfc2898DeriveBytes(Convert.FromBase64String(secret)
                                                            , Convert.FromBase64String(salt)
                                                            , 300))
            {
                key = generator.GetBytes(32);
            }

            return JWT.Encode(payload
                , key
                , JweAlgorithm.A256GCMKW
                , JweEncryption.A256CBC_HS512
                , JweCompression.DEF
                , headers).GenerateStandardResponse();
        }

        public async Task<IStandardResponse<StoreTableEntity>> LookupStoreAsync(string passport, string token)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(LookupStoreAsync))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var headers = JWT.Headers(token);

                    if (!headers.ContainsKey(EntityIdKey))
                    {
                        return default(StoreTableEntity).GenerateStandardError("Missing Store Entity Id");
                    }

                    var entityId = new Guid(headers[EntityIdKey].ToString());

                    var store = await _storeEntityService.ReadEntity(passport, entityId);

                    if (store.HasError)
                        return default(StoreTableEntity).GenerateStandardError(store.StandardError);

                    byte[] key;
                    using (var generator = new Rfc2898DeriveBytes(Convert.FromBase64String(store.Response.Secret)
                                                                    , Convert.FromBase64String(store.Response.Salt)
                                                                    , 300))
                    {
                        key = generator.GetBytes(32);
                    }

                    JWT.Decode(token, key);

                    return store;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(LookupStoreAsync)} Failed");
                    return default(StoreTableEntity).GenerateStandardError($"{nameof(LookupStoreAsync)} Failed");
                }
            }
        }

        static byte[] Base64UrlDecode(string arg)
        {
            var s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: s += "=="; break; // Two pad chars
                case 3: s += "="; break; // One pad char
                default:
                    throw new System.Exception(
                        "Illegal base64url string!");
            }
            return Convert.FromBase64String(s); // Standard base64 decoder
        }

        private static string RandomString(int length)
        {
            var random = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(random);

                var buffer = new char[length];
                var usableLength = SecretStringTemplate.Length;

                for (var index = 0; index < length; index++)
                {
                    buffer[index] = SecretStringTemplate[random[index] % usableLength];
                }

                return new string(buffer);
            }
        }

        private static byte[] SecretAsBytes(string secret)
        {
            return Encoding.UTF8.GetBytes(secret);
        }
    }
}