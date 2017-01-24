using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Address
    {
        public Address()
        {
            Affiliate = new HashSet<Affiliate>();
            CustomerBillingAddress = new HashSet<Customer>();
            CustomerShippingAddress = new HashSet<Customer>();
            CustomerAddresses = new HashSet<CustomerAddresses>();
            OrderBillingAddress = new HashSet<Order>();
            OrderShippingAddress = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual ICollection<Affiliate> Affiliate { get; set; }
        public virtual ICollection<Customer> CustomerBillingAddress { get; set; }
        public virtual ICollection<Customer> CustomerShippingAddress { get; set; }
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual ICollection<Order> OrderBillingAddress { get; set; }
        public virtual ICollection<Order> OrderShippingAddress { get; set; }
        public virtual Country Country { get; set; }
        public virtual StateProvince StateProvince { get; set; }
    }
}
