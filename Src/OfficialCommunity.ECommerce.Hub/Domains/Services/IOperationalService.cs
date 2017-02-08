using System;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Domains.Services
{
    public interface IOperationsService
    {
        Task<IStandardResponse<bool>> LogAsync(string passport
                                                , string message
                                                , Guid? internalCorrelationId = null
                                                , Guid? externalCorrelationId = null
                                                , object request = null
                                                , object response = null
                                                , object log = null
                                                , string createdBy = null
                                                , string level = Domains.Infrastructure.NoSQL.Operation.None

        );
    }
}
