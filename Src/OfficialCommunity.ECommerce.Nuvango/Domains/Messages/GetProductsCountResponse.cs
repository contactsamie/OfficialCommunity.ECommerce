using RestSharp.Serializers;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Messages
{
    public class GetProductsCountResponse
    {
        [SerializeAs(Name = "count")]
        public int Count { get; set; }
        [SerializeAs(Name = "pages")]
        public int Pages { get; set; }
    }
}