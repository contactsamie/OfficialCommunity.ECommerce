using ExpressMapper;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
            Mapper.Register<ECommerce.Domains.Business.Address, Domains.Business.Address>();
            Mapper.Register<Domains.Business.Address, ECommerce.Domains.Business.Address>()
                .Ignore(dest => dest.Address3);

            Mapper.Register<ECommerce.Domains.Business.Customer, Domains.Business.Address>()
                .Ignore(dest => dest.Address1)
                .Ignore(dest => dest.Address2)
                .Ignore(dest => dest.City)
                .Ignore(dest => dest.Company)
                .Ignore(dest => dest.FirstName)
                .Ignore(dest => dest.LastName)
                .Ignore(dest => dest.Country)
                .Ignore(dest => dest.Region)
                .Ignore(dest => dest.Zip)
                ;
            Mapper.Register<Domains.Business.Address, ECommerce.Domains.Business.Customer>()
                .Ignore(dest => dest.EMail)
                .Ignore(dest => dest.Fax)
                ;

            Mapper.Register<ECommerce.Domains.Business.BasketLine, Domains.Business.OrderItem>()
                .Member(dest => dest.Id, src => int.Parse(src.Id));
            Mapper.Register<Domains.Business.OrderItem, ECommerce.Domains.Business.BasketLine>()
                .Member(dest => dest.Sku, src => src.Id.ToString());

            Mapper.Register<ECommerce.Domains.Business.ShippingRate, Domains.Business.ShippingRate>();
            Mapper.Register<Domains.Business.ShippingRate, ECommerce.Domains.Business.ShippingRate>();

            Mapper.Compile();
        }
    }
}
