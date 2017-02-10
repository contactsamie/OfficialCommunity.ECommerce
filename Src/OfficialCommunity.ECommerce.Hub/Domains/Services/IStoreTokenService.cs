using System;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Domains.Services
{
    public interface IStoreTokenService
    {
        IStandardResponse<string> GenerateSecret();
        IStandardResponse<string> GenerateToken(string secret, Guid entityId);
        Task<IStandardResponse<StoreTableEntity>> LookupStoreAsync(string passport, string token);
    }
}