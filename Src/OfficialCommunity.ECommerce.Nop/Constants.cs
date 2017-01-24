namespace OfficialCommunity.ECommerce.Nop
{
    public static class Constants
    {
        // Order Status

        public const int OrderStatusPending = 10;
        public const int OrderStatusProcessing = 20;
        public const int OrderStatusComplete = 30;
        public const int OrderStatusCancelled = 40;

        // Payment Status

        public const int PaymentStatusPending = 10;
        public const int PaymentStatusAuthorized = 20;
        public const int PaymentStatusPaid = 30;
        public const int PaymentStatusPartiallyRefunded = 35;
        public const int PaymentStatusRefunded = 40;
        public const int PaymentStatusVoided = 50;

        // Shipping Status

        public const int ShippingStatusShippingNotRequired = 10;
        public const int ShippingStatusNotYetShipped = 20;
        public const int ShippingStatusPartiallyShipped = 25;
        public const int ShippingStatusShipped = 30;
        public const int ShippingStatusDelivered = 40;
    }
}
