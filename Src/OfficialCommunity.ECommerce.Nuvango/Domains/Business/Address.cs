using RestSharp.Deserializers;
using RestSharp.Serializers;

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

        [SerializeAs(Name = "first_name")]
        [DeserializeAs(Name = "first_name")]
        public string FirstName { get; set; }

        [SerializeAs(Name = "last_name")]
        [DeserializeAs(Name = "last_name")]
        public string LastName { get; set; }

        [SerializeAs(Name = "company")]
        [DeserializeAs(Name = "company")]
        public string Company { get; set; }

        [SerializeAs(Name = "address1")]
        [DeserializeAs(Name = "address1")]
        public string Address1 { get; set; }

        [SerializeAs(Name = "address2")]
        [DeserializeAs(Name = "address2")]
        public string Address2 { get; set; }

        [SerializeAs(Name = "city")]
        [DeserializeAs(Name = "city")]
        public string City { get; set; }

        [SerializeAs(Name = "region")]
        [DeserializeAs(Name = "region")]
        public string Region { get; set; }

        [SerializeAs(Name = "country")]
        [DeserializeAs(Name = "country")]
        public string Country { get; set; }

        [SerializeAs(Name = "zip")]
        [DeserializeAs(Name = "zip")]
        public string Zip { get; set; }

        [SerializeAs(Name = "phone")]
        [DeserializeAs(Name = "phone")]
        public string Phone { get; set; }
    }
}
