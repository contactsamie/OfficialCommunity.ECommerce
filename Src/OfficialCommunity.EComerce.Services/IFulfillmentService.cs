namespace OfficialCommunity.ECommerce.Services
{
    public interface IFulfillmentService : IService
    {
        IFufillmentCatalogService Catalog { get; }
        IFufillmentOrdersService Orders { get; }
        IFufillmentShippingService Shipping { get; }
    }
}