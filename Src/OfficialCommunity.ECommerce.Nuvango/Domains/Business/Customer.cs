using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class Customer
    {
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string EMail { get; set; }
    }
}