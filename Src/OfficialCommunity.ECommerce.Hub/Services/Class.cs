using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Services
{
    public interface IOperationalService
    {
        Task<StandardResponse<bool>> LogAsync(string message
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
