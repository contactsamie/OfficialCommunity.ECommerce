using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Jose;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Services
{
    public class StoreTokenService : IStoreTokenService
    {
        private const string EntityIdKey = "entityId";

        private readonly ILogger<StoreTokenService> _logger;
        private readonly IStoreEntityService _storeEntityService;

        public StoreTokenService(ILogger<StoreTokenService> logger
            , IStoreEntityService storeEntityService)
        {
            _logger = logger;
            _storeEntityService = storeEntityService;
        }

        public IStandardResponse<string> GenerateSecret()
        {
            var secretkey = new byte[64];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(secretkey);
            }

            return Encoding.UTF8.GetString(secretkey).GenerateStandardResponse();
        }

        public IStandardResponse<string> GenerateToken(string secret, Guid entityId)
        {
            var payload = new Dictionary<string, object>();
            var headers = new Dictionary<string, object>
            {
                {"typ", "JWT"},
                {"cty", "JWT"},
                {EntityIdKey, entityId}
            };

            return JWT.Encode(payload
                , SecretAsBytes(secret)
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

                    var entityId = (Guid) headers[EntityIdKey];

                    var store = await _storeEntityService.ReadEntity(passport, entityId);

                    if (store.HasError)
                        return default(StoreTableEntity).GenerateStandardError(store.StandardError);

                    JWT.Decode(token, SecretAsBytes(store.Response.Secret));

                    return store;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(LookupStoreAsync)} Failed");
                    return default(StoreTableEntity).GenerateStandardError($"{nameof(LookupStoreAsync)} Failed");
                }
            }
        }

        private static byte[] SecretAsBytes(string secret)
        {
            return Encoding.UTF8.GetBytes(secret);
        }
    }
}
