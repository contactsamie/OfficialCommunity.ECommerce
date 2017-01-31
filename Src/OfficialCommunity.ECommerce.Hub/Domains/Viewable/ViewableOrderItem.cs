using OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    public class ViewableOrderItem
    {
        public ShippingState ShippingState { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
    }
}