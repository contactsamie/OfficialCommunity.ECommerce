using System;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Extensions
{
    public static class IOperationsServiceExtensions
    {
        public static async Task<IStandardResponse<bool>> LogTraceAsync(this IOperationsService service
            , string passport
            , string message
            , Guid? internalCorrelationId = null
            , Guid? externalCorrelationId = null
            , object request = null
            , object response = null
            , object log = null
            , string createdBy = null
        )
        {
            return await service.LogAsync(passport
                , message
                , internalCorrelationId
                , externalCorrelationId
                , request
                , response
                , log
                , createdBy
                , Operation.Trace
            );
        }

        public static async Task<IStandardResponse<bool>> LogDebugAsync(this IOperationsService service
            , string passport
            , string message
            , Guid? internalCorrelationId = null
            , Guid? externalCorrelationId = null
            , object request = null
            , object response = null
            , object log = null
            , string createdBy = null
        )
        {
            return await service.LogAsync(passport
                , message
                , internalCorrelationId
                , externalCorrelationId
                , request
                , response
                , log
                , createdBy
                , Operation.Debug
            );
        }

        public static async Task<IStandardResponse<bool>> LogInformationAsync(this IOperationsService service
            , string passport
            , string message
            , Guid? internalCorrelationId = null
            , Guid? externalCorrelationId = null
            , object request = null
            , object response = null
            , object log = null
            , string createdBy = null
        )
        {
            return await service.LogAsync(passport
                , message
                , internalCorrelationId
                , externalCorrelationId
                , request
                , response
                , log
                , createdBy
                , Operation.Information
            );
        }
        public static async Task<IStandardResponse<bool>> LogWarningAsync(this IOperationsService service
            , string passport
            , string message
            , Guid? internalCorrelationId = null
            , Guid? externalCorrelationId = null
            , object request = null
            , object response = null
            , object log = null
            , string createdBy = null
        )
        {
            return await service.LogAsync(passport
                , message
                , internalCorrelationId
                , externalCorrelationId
                , request
                , response
                , log
                , createdBy
                , Operation.Warning
            );
        }
        public static async Task<IStandardResponse<bool>> LogErrorAsync(this IOperationsService service
            , string passport
            , string message
            , Guid? internalCorrelationId = null
            , Guid? externalCorrelationId = null
            , object request = null
            , object response = null
            , object log = null
            , string createdBy = null
        )
        {
            return await service.LogAsync(passport
                , message
                , internalCorrelationId
                , externalCorrelationId
                , request
                , response
                , log
                , createdBy
                , Operation.Error
            );
        }
        public static async Task<IStandardResponse<bool>> LogCriticalAsync(this IOperationsService service
            , string passport
            , string message
            , Guid? internalCorrelationId = null
            , Guid? externalCorrelationId = null
            , object request = null
            , object response = null
            , object log = null
            , string createdBy = null
        )
        {
            return await service.LogAsync(passport
                , message
                , internalCorrelationId
                , externalCorrelationId
                , request
                , response
                , log
                , createdBy
                , Operation.Critical
            );
        }
    }
}