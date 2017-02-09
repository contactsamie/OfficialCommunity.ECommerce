using System.Collections.Generic;
using OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Services.Domains.Commands
{
    public class GetShippingRateQuote
    {
        public class Request
        {
            public string Passport { get; set; }
            public Address Address { get; set; }
            public string Currency { get; set; }
            public List<CartItem> Items { get; set; }
        }

        public class Response
        {
            public List<FulfillmentProviderShippingRates> FulfillmentProviderShippingRates { get; set; }
        }
    }
}