using System.Collections.Generic;
using OfficialCommunity.ECommerce.Nuvango.Domains.Business;
using RestSharp.Serializers;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Messages
{
    public class GetRatesRequest
    {
        [SerializeAs(Name = "currency_code")]
        public string Currency { get; set; }
        [SerializeAs(Name = "ship_address")]
        public Address ShippingAddress { get; set; }
        [SerializeAs(Name = "order_items")]
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
