using System;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Services
{
    public interface IStoreTokenService
    {
        IStandardResponse<string> GenerateSecretAsString();
        IStandardResponse<byte[]> GenerateSecretAsBytes(int numberOfBytes);
        IStandardResponse<string> GenerateToken(string secret, string salt, Guid entityId);
        Task<IStandardResponse<StoreTableEntity>> LookupStoreAsync(string passport, string token);
    }
}