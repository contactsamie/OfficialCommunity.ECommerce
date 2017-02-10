using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Services
{
    public interface ITableEntityService<T> where T : IBaseTableEntity
    {
        Task<StandardResponse<T>> CreateEntity(string passport, T entity, string user);
        Task<StandardResponse<T>> DeleteEntity(string passport, T entity, string user);
        Task<StandardResponse<IEnumerable<T>>> ReadEntities(string passport);
        Task<StandardResponse<T>> ReadEntity(string passport, Guid id);
        Task<StandardResponse<T>> UpdateEntity(string passport, T entity, string user);
    }
}