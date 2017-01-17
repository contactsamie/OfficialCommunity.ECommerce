using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class Address
    {
        public static Address From(ECommerce.Domains.Business.Address address)
        {
            return new Address
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                Company = address.Company,
                Address1 = address.Address1,
                Address2 = address.Address2,
                City = address.City,
                Region = address.Region,
                Country = address.Country,
                Zip = address.Zip
            };
        }

        public static Address From(ECommerce.Domains.Business.Customer customer
                        , ECommerce.Domains.Business.Address address)
        {
            var from = From(address);
            from.Phone = customer.Phone;
            return from;
        }

        public static ECommerce.Domains.Business.Address To(Address address)
        {
            return new ECommerce.Domains.Business.Address
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                Company = address.Company,
                Address1 = address.Address1,
                Address2 = address.Address2,
                Address3 = string.Empty,
                City = address.City,
                Region = address.Region,
                Country = address.Country,
                Zip = address.Zip
            };
        }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }
        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }
        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
    }
}
