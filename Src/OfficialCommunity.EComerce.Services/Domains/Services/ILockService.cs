﻿using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Domains.Services
{
    public interface ILockService
    {
        Task<StandardResponse<bool>> Acquire(string passport, string key, string id);
        Task<StandardResponse<bool>> Read(string passport, string key, string id);
        Task<StandardResponse<bool>> Release(string passport, string key, string id);
    }
}
