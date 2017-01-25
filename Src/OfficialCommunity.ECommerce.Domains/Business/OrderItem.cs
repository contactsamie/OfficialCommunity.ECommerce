namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class OrderItem : Base
    {
        public ShippingState ShippingState { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
    }
}
