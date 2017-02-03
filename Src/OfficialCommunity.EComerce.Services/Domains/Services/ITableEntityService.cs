using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Services
{
    public interface ITableEntityService<T> where T : IBaseTableEntity
    {
        Task<StandardResponse<T>> Create(string passport, T entity, string user);
        Task<StandardResponse<T>> Delete(string passport, T entity, string user);
        Task<StandardResponse<IEnumerable<T>>> Read(string passport);
        Task<StandardResponse<T>> Read(string passport, Guid id);
        Task<StandardResponse<T>> Update(string passport, T entity, string user);
    }
}