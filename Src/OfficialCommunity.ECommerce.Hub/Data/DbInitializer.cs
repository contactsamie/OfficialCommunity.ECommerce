namespace OfficialCommunity.ECommerce.Hub.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ECommerceDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
