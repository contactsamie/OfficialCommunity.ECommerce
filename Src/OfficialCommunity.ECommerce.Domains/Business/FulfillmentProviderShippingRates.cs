using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class FulfillmentProviderShippingRates
    {
        public string Name { get; set; }
        public List<ShippingRate> Rates { get; set; }
    }
}