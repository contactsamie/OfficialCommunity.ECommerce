using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Isotope.Services
{
    public partial class IsotopeService : IFufillmentCatalogService
    {
        private static readonly ECommerce.Services.Domains.Commands.GetEntityCountResponse GetProductsCountError = null;
        public async Task<IStandardResponse<ECommerce.Services.Domains.Commands.GetEntityCountResponse>> GetProductsCount(
            string passport
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(GetProductsCount))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetProductsCountError.GenerateStandardError("Operation Failed");
        }

        private static readonly IList<Product> GetProductsError = null;
        public async Task<IStandardResponse<IList<Product>>> GetProducts(
            string passport
            , int page
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(GetProducts))
                    .Data(nameof(page), page)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetProductsError.GenerateStandardError("Operation Failed");
        }

        private static readonly Product GetProductError = null;
        public async Task<IStandardResponse<Product>> GetProduct(
            string passport
            , string id
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(GetProduct))
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetProductError.GenerateStandardError("Operation Failed");
        }
    }
}