namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class CartItem 
    {
        public string FulfillmentProvider { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
