using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class NopCommerceDbContext : DbContext
    {
        public NopCommerceDbContext(DbContextOptions<NopCommerceDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<AclRecord> AclRecord { get; set; }
        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<ActivityLogType> ActivityLogType { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Affiliate> Affiliate { get; set; }
        public virtual DbSet<AnywhereSlider> AnywhereSlider { get; set; }
        public virtual DbSet<BackInStockSubscription> BackInStockSubscription { get; set; }
        public virtual DbSet<BlogComment> BlogComment { get; set; }
        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Carousel3Dsettings> Carousel3Dsettings { get; set; }
        public virtual DbSet<CarouselSettings> CarouselSettings { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryTemplate> CategoryTemplate { get; set; }
        public virtual DbSet<CheckoutAttribute> CheckoutAttribute { get; set; }
        public virtual DbSet<CheckoutAttributeValue> CheckoutAttributeValue { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CrossSellProduct> CrossSellProduct { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerCustomerRoleMapping> CustomerCustomerRoleMapping { get; set; }
        public virtual DbSet<CustomerRole> CustomerRole { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public virtual DbSet<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public virtual DbSet<DiscountRequirement> DiscountRequirement { get; set; }
        public virtual DbSet<DiscountUsageHistory> DiscountUsageHistory { get; set; }
        public virtual DbSet<Download> Download { get; set; }
        public virtual DbSet<EmailAccount> EmailAccount { get; set; }
        public virtual DbSet<ExternalAuthenticationRecord> ExternalAuthenticationRecord { get; set; }
        public virtual DbSet<ForumsForum> ForumsForum { get; set; }
        public virtual DbSet<ForumsGroup> ForumsGroup { get; set; }
        public virtual DbSet<ForumsPost> ForumsPost { get; set; }
        public virtual DbSet<ForumsPrivateMessage> ForumsPrivateMessage { get; set; }
        public virtual DbSet<ForumsSubscription> ForumsSubscription { get; set; }
        public virtual DbSet<ForumsTopic> ForumsTopic { get; set; }
        public virtual DbSet<GenericAttribute> GenericAttribute { get; set; }
        public virtual DbSet<GiftCard> GiftCard { get; set; }
        public virtual DbSet<GiftCardUsageHistory> GiftCardUsageHistory { get; set; }
        public virtual DbSet<GoogleProduct> GoogleProduct { get; set; }
        public virtual DbSet<Jcarousel> Jcarousel { get; set; }
        public virtual DbSet<JcarouselCategory> JcarouselCategory { get; set; }
        public virtual DbSet<JcarouselManufacturer> JcarouselManufacturer { get; set; }
        public virtual DbSet<JcarouselProduct> JcarouselProduct { get; set; }
        public virtual DbSet<JcarouselWidget> JcarouselWidget { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LocaleStringResource> LocaleStringResource { get; set; }
        public virtual DbSet<LocalizedProperty> LocalizedProperty { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<ManufacturerTemplate> ManufacturerTemplate { get; set; }
        public virtual DbSet<MeasureDimension> MeasureDimension { get; set; }
        public virtual DbSet<MeasureWeight> MeasureWeight { get; set; }
        public virtual DbSet<MessageTemplate> MessageTemplate { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
        public virtual DbSet<NewsLetterSubscription> NewsLetterSubscription { get; set; }
        public virtual DbSet<NivoSettings> NivoSettings { get; set; }
        public virtual DbSet<OccadministrationLog> OccadministrationLog { get; set; }
        public virtual DbSet<OccartistSplits> OccartistSplits { get; set; }
        public virtual DbSet<OccisotopeItemTracking> OccisotopeItemTracking { get; set; }
        public virtual DbSet<OccisotopeTracking> OccisotopeTracking { get; set; }
        public virtual DbSet<OccleapaddonProduct> OccleapaddonProduct { get; set; }
        public virtual DbSet<OccleapliveEventAddon> OccleapliveEventAddon { get; set; }
        public virtual DbSet<Occleaplog> Occleaplog { get; set; }
        public virtual DbSet<Occredemption> Occredemption { get; set; }
        public virtual DbSet<OccredemptionCode> OccredemptionCode { get; set; }
        public virtual DbSet<OccredemptionCodeTracking> OccredemptionCodeTracking { get; set; }
        public virtual DbSet<OccredemptionTracking> OccredemptionTracking { get; set; }
        public virtual DbSet<OccspreadShirtLog> OccspreadShirtLog { get; set; }
        public virtual DbSet<Occsubscription> Occsubscription { get; set; }
        public virtual DbSet<OccsubscriptionType> OccsubscriptionType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderNote> OrderNote { get; set; }
        public virtual DbSet<PermissionRecord> PermissionRecord { get; set; }
        public virtual DbSet<PermissionRecordRoleMapping> PermissionRecordRoleMapping { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<PollAnswer> PollAnswer { get; set; }
        public virtual DbSet<PollVotingRecord> PollVotingRecord { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        public virtual DbSet<ProductCategoryMapping> ProductCategoryMapping { get; set; }
        public virtual DbSet<ProductManufacturerMapping> ProductManufacturerMapping { get; set; }
        public virtual DbSet<ProductPictureMapping> ProductPictureMapping { get; set; }
        public virtual DbSet<ProductProductAttributeMapping> ProductProductAttributeMapping { get; set; }
        public virtual DbSet<ProductProductTagMapping> ProductProductTagMapping { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductReviewHelpfulness> ProductReviewHelpfulness { get; set; }
        public virtual DbSet<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMapping { get; set; }
        public virtual DbSet<ProductTag> ProductTag { get; set; }
        public virtual DbSet<ProductTemplate> ProductTemplate { get; set; }
        public virtual DbSet<ProductVariantAttributeCombination> ProductVariantAttributeCombination { get; set; }
        public virtual DbSet<ProductVariantAttributeValue> ProductVariantAttributeValue { get; set; }
        public virtual DbSet<QueuedEmail> QueuedEmail { get; set; }
        public virtual DbSet<RecurringPayment> RecurringPayment { get; set; }
        public virtual DbSet<RecurringPaymentHistory> RecurringPaymentHistory { get; set; }
        public virtual DbSet<RelatedProduct> RelatedProduct { get; set; }
        public virtual DbSet<ReturnRequest> ReturnRequest { get; set; }
        public virtual DbSet<RewardPointsHistory> RewardPointsHistory { get; set; }
        public virtual DbSet<ScheduleTask> ScheduleTask { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<ShipmentItem> ShipmentItem { get; set; }
        public virtual DbSet<ShippingByWeight> ShippingByWeight { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethod { get; set; }
        public virtual DbSet<ShippingMethodRestrictions> ShippingMethodRestrictions { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public virtual DbSet<SliderCategory> SliderCategory { get; set; }
        public virtual DbSet<SliderImage> SliderImage { get; set; }
        public virtual DbSet<SliderManufacturer> SliderManufacturer { get; set; }
        public virtual DbSet<SliderWidget> SliderWidget { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttribute { get; set; }
        public virtual DbSet<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
        public virtual DbSet<StateProvince> StateProvince { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreMapping> StoreMapping { get; set; }
        public virtual DbSet<TaxCategory> TaxCategory { get; set; }
        public virtual DbSet<TaxRate> TaxRate { get; set; }
        public virtual DbSet<TierPrice> TierPrice { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<UrlRecord> UrlRecord { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=testdb3\sqldev;Database=NopCommerceBaseSite31;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AclRecord>(entity =>
            {
                entity.HasIndex(e => new { e.EntityId, e.EntityName })
                    .HasName("IX_AclRecord_EntityId_EntityName");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.AclRecord)
                    .HasForeignKey(d => d.CustomerRoleId)
                    .HasConstraintName("AclRecord_CustomerRole");
            });

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.HasIndex(e => e.CreatedOnUtc)
                    .HasName("IX_ActivityLog_CreatedOnUtc");

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.ActivityLogType)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.ActivityLogTypeId)
                    .HasConstraintName("ActivityLog_ActivityLogType");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("ActivityLog_Customer");
            });

            modelBuilder.Entity<ActivityLogType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("Address_Country");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateProvinceId)
                    .HasConstraintName("Address_StateProvince");
            });

            modelBuilder.Entity<Affiliate>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Affiliate)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Affiliate_Address");
            });

            modelBuilder.Entity<AnywhereSlider>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ToDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BackInStockSubscription>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BackInStockSubscription)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("BackInStockSubscription_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BackInStockSubscription)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("BackInStockSubscription_Product");
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.HasIndex(e => e.BlogPostId)
                    .HasName("IX_BlogComment_BlogPostId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.BlogComment)
                    .HasForeignKey(d => d.BlogPostId)
                    .HasConstraintName("BlogComment_BlogPost");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BlogComment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("BlogComment_Customer");
            });

            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_BlogPost_LanguageId");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.BlogPost)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("BlogPost_Language");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Subject).IsRequired();
            });

            modelBuilder.Entity<Carousel3Dsettings>(entity =>
            {
                entity.ToTable("Carousel3DSettings");

                entity.Property(e => e.Xposition).HasColumnName("XPosition");

                entity.Property(e => e.Yposition).HasColumnName("YPosition");

                entity.Property(e => e.Yradius).HasColumnName("YRadius");

                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.Carousel3Dsettings)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("Carousel3DSettings_SLider");
            });

            modelBuilder.Entity<CarouselSettings>(entity =>
            {
                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.CarouselSettings)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("CarouselSettings_Slider");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Category_DisplayOrder");

                entity.HasIndex(e => e.LimitedToStores)
                    .HasName("IX_Category_LimitedToStores");

                entity.HasIndex(e => e.ParentCategoryId)
                    .HasName("IX_Category_ParentCategoryId");

                entity.HasIndex(e => e.SubjectToAcl)
                    .HasName("IX_Category_SubjectToAcl");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PageSizeOptions).HasMaxLength(200);

                entity.Property(e => e.PriceRanges).HasMaxLength(400);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<CategoryTemplate>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<CheckoutAttribute>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<CheckoutAttributeValue>(entity =>
            {
                entity.Property(e => e.ColorSquaresRgb).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PriceAdjustment).HasColumnType("decimal");

                entity.Property(e => e.WeightAdjustment).HasColumnType("decimal");

                entity.HasOne(d => d.CheckoutAttribute)
                    .WithMany(p => p.CheckoutAttributeValue)
                    .HasForeignKey(d => d.CheckoutAttributeId)
                    .HasConstraintName("CheckoutAttributeValue_CheckoutAttribute");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Country_DisplayOrder");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);

                entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Currency_DisplayOrder");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CustomFormatting).HasMaxLength(50);

                entity.Property(e => e.DisplayLocale).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("decimal");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerGuid)
                    .HasName("IX_Customer_CustomerGuid");

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Customer_Email");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_Customer_Username");

                entity.Property(e => e.BillingAddressId).HasColumnName("BillingAddress_Id");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.LastActivityDateUtc).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddress_Id");

                entity.Property(e => e.Username).HasMaxLength(1000);

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.CustomerBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("Customer_BillingAddress");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.CustomerShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("Customer_ShippingAddress");
            });

            modelBuilder.Entity<CustomerAddresses>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId })
                    .HasName("PK__Customer__3C895822403A8C7D");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("Customer_Addresses_Target");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Customer_Addresses_Source");
            });

            modelBuilder.Entity<CustomerCustomerRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CustomerRoleId })
                    .HasName("PK__Customer__ABACF0F7440B1D61");

                entity.ToTable("Customer_CustomerRole_Mapping");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustomerRoleId).HasColumnName("CustomerRole_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCustomerRoleMapping)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Customer_CustomerRoles_Source");

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.CustomerCustomerRoleMapping)
                    .HasForeignKey(d => d.CustomerRoleId)
                    .HasConstraintName("Customer_CustomerRoles_Target");
            });

            modelBuilder.Entity<CustomerRole>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SystemName).HasMaxLength(255);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.CouponCode).HasMaxLength(100);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiscountAppliedToCategories>(entity =>
            {
                entity.HasKey(e => new { e.DiscountId, e.CategoryId })
                    .HasName("PK__Discount__9AC84AD24F7CD00D");

                entity.ToTable("Discount_AppliedToCategories");

                entity.Property(e => e.DiscountId).HasColumnName("Discount_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.DiscountAppliedToCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("Discount_AppliedToCategories_Target");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountAppliedToCategories)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("Discount_AppliedToCategories_Source");
            });

            modelBuilder.Entity<DiscountAppliedToProducts>(entity =>
            {
                entity.HasKey(e => new { e.DiscountId, e.ProductId })
                    .HasName("PK__Discount__D5903DBF534D60F1");

                entity.ToTable("Discount_AppliedToProducts");

                entity.Property(e => e.DiscountId).HasColumnName("Discount_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountAppliedToProducts)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("Discount_AppliedToProducts_Source");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DiscountAppliedToProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Discount_AppliedToProducts_Target");
            });

            modelBuilder.Entity<DiscountRequirement>(entity =>
            {
                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountRequirement)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("Discount_DiscountRequirements");
            });

            modelBuilder.Entity<DiscountUsageHistory>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountUsageHistory)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("DiscountUsageHistory_Discount");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DiscountUsageHistory)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("DiscountUsageHistory_Order");
            });

            modelBuilder.Entity<EmailAccount>(entity =>
            {
                entity.Property(e => e.DisplayName).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ExternalAuthenticationRecord>(entity =>
            {
                entity.Property(e => e.OauthAccessToken).HasColumnName("OAuthAccessToken");

                entity.Property(e => e.OauthToken).HasColumnName("OAuthToken");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ExternalAuthenticationRecord)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("ExternalAuthenticationRecord_Customer");
            });

            modelBuilder.Entity<ForumsForum>(entity =>
            {
                entity.ToTable("Forums_Forum");

                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Forums_Forum_DisplayOrder");

                entity.HasIndex(e => e.ForumGroupId)
                    .HasName("IX_Forums_Forum_ForumGroupId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.LastPostTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.ForumGroup)
                    .WithMany(p => p.ForumsForum)
                    .HasForeignKey(d => d.ForumGroupId)
                    .HasConstraintName("Forum_ForumGroup");
            });

            modelBuilder.Entity<ForumsGroup>(entity =>
            {
                entity.ToTable("Forums_Group");

                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Forums_Group_DisplayOrder");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<ForumsPost>(entity =>
            {
                entity.ToTable("Forums_Post");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Forums_Post_CustomerId");

                entity.HasIndex(e => e.TopicId)
                    .HasName("IX_Forums_Post_TopicId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ForumsPost)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ForumPost_Customer");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.ForumsPost)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("ForumPost_ForumTopic");
            });

            modelBuilder.Entity<ForumsPrivateMessage>(entity =>
            {
                entity.ToTable("Forums_PrivateMessage");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.FromCustomer)
                    .WithMany(p => p.ForumsPrivateMessageFromCustomer)
                    .HasForeignKey(d => d.FromCustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("PrivateMessage_FromCustomer");

                entity.HasOne(d => d.ToCustomer)
                    .WithMany(p => p.ForumsPrivateMessageToCustomer)
                    .HasForeignKey(d => d.ToCustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("PrivateMessage_ToCustomer");
            });

            modelBuilder.Entity<ForumsSubscription>(entity =>
            {
                entity.ToTable("Forums_Subscription");

                entity.HasIndex(e => e.ForumId)
                    .HasName("IX_Forums_Subscription_ForumId");

                entity.HasIndex(e => e.TopicId)
                    .HasName("IX_Forums_Subscription_TopicId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ForumsSubscription)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ForumSubscription_Customer");
            });

            modelBuilder.Entity<ForumsTopic>(entity =>
            {
                entity.ToTable("Forums_Topic");

                entity.HasIndex(e => e.ForumId)
                    .HasName("IX_Forums_Topic_ForumId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.LastPostTime).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ForumsTopic)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ForumTopic_Customer");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.ForumsTopic)
                    .HasForeignKey(d => d.ForumId)
                    .HasConstraintName("ForumTopic_Forum");
            });

            modelBuilder.Entity<GenericAttribute>(entity =>
            {
                entity.HasIndex(e => new { e.EntityId, e.KeyGroup })
                    .HasName("IX_GenericAttribute_EntityId_and_KeyGroup");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.KeyGroup)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<GiftCard>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.PurchasedWithOrderItem)
                    .WithMany(p => p.GiftCard)
                    .HasForeignKey(d => d.PurchasedWithOrderItemId)
                    .HasConstraintName("GiftCard_PurchasedWithOrderItem");
            });

            modelBuilder.Entity<GiftCardUsageHistory>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.UsedValue).HasColumnType("decimal");

                entity.HasOne(d => d.GiftCard)
                    .WithMany(p => p.GiftCardUsageHistory)
                    .HasForeignKey(d => d.GiftCardId)
                    .HasConstraintName("GiftCardUsageHistory_GiftCard");

                entity.HasOne(d => d.UsedWithOrder)
                    .WithMany(p => p.GiftCardUsageHistory)
                    .HasForeignKey(d => d.UsedWithOrderId)
                    .HasConstraintName("GiftCardUsageHistory_UsedWithOrder");
            });

            modelBuilder.Entity<Jcarousel>(entity =>
            {
                entity.ToTable("JCarousel");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<JcarouselCategory>(entity =>
            {
                entity.ToTable("JCarouselCategory");

                entity.HasOne(d => d.Carousel)
                    .WithMany(p => p.JcarouselCategory)
                    .HasForeignKey(d => d.CarouselId)
                    .HasConstraintName("JCarouselCategory_Carousel");
            });

            modelBuilder.Entity<JcarouselManufacturer>(entity =>
            {
                entity.ToTable("JCarouselManufacturer");

                entity.HasOne(d => d.Carousel)
                    .WithMany(p => p.JcarouselManufacturer)
                    .HasForeignKey(d => d.CarouselId)
                    .HasConstraintName("JCarouselManufacturer_Carousel");
            });

            modelBuilder.Entity<JcarouselProduct>(entity =>
            {
                entity.ToTable("JCarouselProduct");

                entity.HasOne(d => d.Carousel)
                    .WithMany(p => p.JcarouselProduct)
                    .HasForeignKey(d => d.CarouselId)
                    .HasConstraintName("JCarouselProduct_Carousel");
            });

            modelBuilder.Entity<JcarouselWidget>(entity =>
            {
                entity.ToTable("JCarouselWidget");

                entity.Property(e => e.WidgetZone).IsRequired();

                entity.HasOne(d => d.Carousel)
                    .WithMany(p => p.JcarouselWidget)
                    .HasForeignKey(d => d.CarouselId)
                    .HasConstraintName("CarouselWidget_JCarousel");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Language_DisplayOrder");

                entity.Property(e => e.FlagImageFileName).HasMaxLength(50);

                entity.Property(e => e.LanguageCulture)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UniqueSeoCode).HasMaxLength(2);
            });

            modelBuilder.Entity<LocaleStringResource>(entity =>
            {
                entity.HasIndex(e => new { e.ResourceName, e.LanguageId })
                    .HasName("IX_LocaleStringResource");

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ResourceValue).IsRequired();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LocaleStringResource)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("LocaleStringResource_Language");
            });

            modelBuilder.Entity<LocalizedProperty>(entity =>
            {
                entity.Property(e => e.LocaleKey)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.LocaleKeyGroup)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.LocaleValue).IsRequired();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LocalizedProperty)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("LocalizedProperty_Language");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasIndex(e => e.CreatedOnUtc)
                    .HasName("IX_Log_CreatedOnUtc");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.IpAddress).HasMaxLength(200);

                entity.Property(e => e.ShortMessage).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Log_Customer");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasIndex(e => e.DisplayOrder)
                    .HasName("IX_Manufacturer_DisplayOrder");

                entity.HasIndex(e => e.LimitedToStores)
                    .HasName("IX_Manufacturer_LimitedToStores");

                entity.HasIndex(e => e.SubjectToAcl)
                    .HasName("IX_Manufacturer_SubjectToAcl");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PageSizeOptions).HasMaxLength(200);

                entity.Property(e => e.PriceRanges).HasMaxLength(400);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<ManufacturerTemplate>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<MeasureDimension>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ratio).HasColumnType("decimal");

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MeasureWeight>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ratio).HasColumnType("decimal");

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MessageTemplate>(entity =>
            {
                entity.Property(e => e.BccEmailAddresses).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Subject).HasMaxLength(1000);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasIndex(e => e.LanguageId)
                    .HasName("IX_News_LanguageId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Full).IsRequired();

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Short).IsRequired();

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("NewsItem_Language");
            });

            modelBuilder.Entity<NewsComment>(entity =>
            {
                entity.HasIndex(e => e.NewsItemId)
                    .HasName("IX_NewsComment_NewsItemId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("NewsComment_Customer");

                entity.HasOne(d => d.NewsItem)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.NewsItemId)
                    .HasConstraintName("NewsComment_NewsItem");
            });

            modelBuilder.Entity<NewsLetterSubscription>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<NivoSettings>(entity =>
            {
                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.NivoSettings)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("NivoSettings_Slider");
            });

            modelBuilder.Entity<OccadministrationLog>(entity =>
            {
                entity.ToTable("OCCAdministrationLog");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.ShortMessage).HasMaxLength(256);
            });

            modelBuilder.Entity<OccartistSplits>(entity =>
            {
                entity.ToTable("OCCArtistSplits");

                entity.Property(e => e.Occnet).HasColumnName("OCCNet");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<OccisotopeItemTracking>(entity =>
            {
                entity.ToTable("OCCIsotopeItemTracking");
            });

            modelBuilder.Entity<OccisotopeTracking>(entity =>
            {
                entity.ToTable("OCCIsotopeTracking");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(64);

                entity.Property(e => e.Location).HasMaxLength(32);

                entity.Property(e => e.ShortMessage).HasMaxLength(64);

                entity.Property(e => e.TransferUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<OccleapaddonProduct>(entity =>
            {
                entity.ToTable("OCCLEAPAddonProduct");

                entity.Property(e => e.Leapdescription).HasColumnName("LEAPDescription");

                entity.Property(e => e.LeapimageUrl).HasColumnName("LEAPImageUrl");

                entity.Property(e => e.Leapname).HasColumnName("LEAPName");

                entity.Property(e => e.LeappriceCad)
                    .HasColumnName("LEAPPriceCAD")
                    .HasColumnType("decimal");

                entity.Property(e => e.LeappriceEur)
                    .HasColumnName("LEAPPriceEUR")
                    .HasColumnType("decimal");

                entity.Property(e => e.LeappriceGbp)
                    .HasColumnName("LEAPPriceGBP")
                    .HasColumnType("decimal");

                entity.Property(e => e.LeappriceUsd)
                    .HasColumnName("LEAPPriceUSD")
                    .HasColumnType("decimal");

                entity.Property(e => e.LeapproductId).HasColumnName("LEAPProductId");

                entity.Property(e => e.LeappropertyId).HasColumnName("LEAPPropertyId");

                entity.Property(e => e.LeappropertyName).HasColumnName("LEAPPropertyName");

                entity.Property(e => e.Leapsku).HasColumnName("LEAPSku");
            });

            modelBuilder.Entity<OccleapliveEventAddon>(entity =>
            {
                entity.ToTable("OCCLEAPLiveEventAddon");

                entity.Property(e => e.LeapliveEventId).HasColumnName("LEAPLiveEventId");

                entity.HasOne(d => d.AddonProduct)
                    .WithMany(p => p.OccleapliveEventAddon)
                    .HasForeignKey(d => d.AddonProductId)
                    .HasConstraintName("LiveEventAddon_AddonProduct");
            });

            modelBuilder.Entity<Occleaplog>(entity =>
            {
                entity.ToTable("OCCLEAPLog");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.ShortMessage).HasMaxLength(64);
            });

            modelBuilder.Entity<Occredemption>(entity =>
            {
                entity.ToTable("OCCRedemption");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.EndUtc).HasColumnType("datetime");

                entity.Property(e => e.InternalProductType).HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ProductDescription).IsRequired();

                entity.Property(e => e.Sku).HasMaxLength(400);

                entity.Property(e => e.StartUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<OccredemptionCode>(entity =>
            {
                entity.ToTable("OCCRedemptionCode");

                entity.Property(e => e.Available).HasDefaultValueSql("1");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<OccredemptionCodeTracking>(entity =>
            {
                entity.ToTable("OCCRedemptionCodeTracking");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<OccredemptionTracking>(entity =>
            {
                entity.ToTable("OCCRedemptionTracking");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(64);

                entity.Property(e => e.ShortMessage).HasMaxLength(64);

                entity.Property(e => e.TransferUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<OccspreadShirtLog>(entity =>
            {
                entity.ToTable("OCCSpreadShirtLog");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.ShortMessage).HasMaxLength(128);
            });

            modelBuilder.Entity<Occsubscription>(entity =>
            {
                entity.ToTable("OCCSubscription");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Retired).HasDefaultValueSql("0");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<OccsubscriptionType>(entity =>
            {
                entity.ToTable("OCCSubscriptionType");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Order_CustomerId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal");

                entity.Property(e => e.FulfillmentPartnerOrderId1).HasMaxLength(64);

                entity.Property(e => e.FulfillmentPartnerOrderId2).HasMaxLength(64);

                entity.Property(e => e.OrderDiscount).HasColumnType("decimal");

                entity.Property(e => e.OrderShippingExclTax).HasColumnType("decimal");

                entity.Property(e => e.OrderShippingInclTax).HasColumnType("decimal");

                entity.Property(e => e.OrderSubTotalDiscountExclTax).HasColumnType("decimal");

                entity.Property(e => e.OrderSubTotalDiscountInclTax).HasColumnType("decimal");

                entity.Property(e => e.OrderSubtotalExclTax).HasColumnType("decimal");

                entity.Property(e => e.OrderSubtotalInclTax).HasColumnType("decimal");

                entity.Property(e => e.OrderTax).HasColumnType("decimal");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal");

                entity.Property(e => e.PaidDateUtc).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethodAdditionalFeeExclTax).HasColumnType("decimal");

                entity.Property(e => e.PaymentMethodAdditionalFeeInclTax).HasColumnType("decimal");

                entity.Property(e => e.RefundedAmount).HasColumnType("decimal");

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.OrderBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Order_BillingAddress");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Order_Customer");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.OrderShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("Order_ShippingAddress");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderItem_OrderId");

                entity.Property(e => e.DiscountAmountExclTax).HasColumnType("decimal");

                entity.Property(e => e.DiscountAmountInclTax).HasColumnType("decimal");

                entity.Property(e => e.FulfillmentPartnerSku).HasMaxLength(64);

                entity.Property(e => e.ItemWeight).HasColumnType("decimal");

                entity.Property(e => e.OriginalProductCost).HasColumnType("decimal");

                entity.Property(e => e.PriceExclTax).HasColumnType("decimal");

                entity.Property(e => e.PriceInclTax).HasColumnType("decimal");

                entity.Property(e => e.UnitPriceExclTax).HasColumnType("decimal");

                entity.Property(e => e.UnitPriceInclTax).HasColumnType("decimal");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("OrderItem_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("OrderItem_Product");
            });

            modelBuilder.Entity<OrderNote>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderNote_OrderId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Note).IsRequired();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderNote)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("OrderNote_Order");
            });

            modelBuilder.Entity<PermissionRecord>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PermissionRecordRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.PermissionRecordId, e.CustomerRoleId })
                    .HasName("PK__Permissi__4804FB2645BE5BA9");

                entity.ToTable("PermissionRecord_Role_Mapping");

                entity.Property(e => e.PermissionRecordId).HasColumnName("PermissionRecord_Id");

                entity.Property(e => e.CustomerRoleId).HasColumnName("CustomerRole_Id");

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.PermissionRecordRoleMapping)
                    .HasForeignKey(d => d.CustomerRoleId)
                    .HasConstraintName("PermissionRecord_CustomerRoles_Target");

                entity.HasOne(d => d.PermissionRecord)
                    .WithMany(p => p.PermissionRecordRoleMapping)
                    .HasForeignKey(d => d.PermissionRecordId)
                    .HasConstraintName("PermissionRecord_CustomerRoles_Source");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.SeoFilename).HasMaxLength(300);
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Poll)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("Poll_Language");
            });

            modelBuilder.Entity<PollAnswer>(entity =>
            {
                entity.HasIndex(e => e.PollId)
                    .HasName("IX_PollAnswer_PollId");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.PollAnswer)
                    .HasForeignKey(d => d.PollId)
                    .HasConstraintName("PollAnswer_Poll");
            });

            modelBuilder.Entity<PollVotingRecord>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PollVotingRecord)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("PollVotingRecord_Customer");

                entity.HasOne(d => d.PollAnswer)
                    .WithMany(p => p.PollVotingRecord)
                    .HasForeignKey(d => d.PollAnswerId)
                    .HasConstraintName("PollVotingRecord_PollAnswer");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.LimitedToStores)
                    .HasName("IX_Product_LimitedToStores");

                entity.HasIndex(e => e.ParentGroupedProductId)
                    .HasName("IX_Product_ParentGroupedProductId");

                entity.HasIndex(e => e.Published)
                    .HasName("IX_Product_Published");

                entity.HasIndex(e => e.ShowOnHomePage)
                    .HasName("IX_Product_ShowOnHomepage");

                entity.HasIndex(e => e.SubjectToAcl)
                    .HasName("IX_Product_SubjectToAcl");

                entity.HasIndex(e => e.VisibleIndividually)
                    .HasName("IX_Product_VisibleIndividually");

                entity.HasIndex(e => new { e.Published, e.Deleted })
                    .HasName("IX_Product_Deleted_and_Published");

                entity.HasIndex(e => new { e.Price, e.AvailableStartDateTimeUtc, e.AvailableEndDateTimeUtc, e.Published, e.Deleted })
                    .HasName("IX_Product_PriceDatesEtc");

                entity.Property(e => e.AdditionalShippingCharge).HasColumnType("decimal");

                entity.Property(e => e.AllowedQuantities).HasMaxLength(1000);

                entity.Property(e => e.AvailableEndDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.AvailableStartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.FulfillmentPartner).HasMaxLength(64);

                entity.Property(e => e.FulfillmentPartnerSku).HasMaxLength(64);

                entity.Property(e => e.Gtin).HasMaxLength(400);

                entity.Property(e => e.Height).HasColumnType("decimal");

                entity.Property(e => e.InternalProductType).HasMaxLength(64);

                entity.Property(e => e.Length).HasColumnType("decimal");

                entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);

                entity.Property(e => e.MaximumCustomerEnteredPrice).HasColumnType("decimal");

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.MinimumCustomerEnteredPrice).HasColumnType("decimal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.OldPrice).HasColumnType("decimal");

                entity.Property(e => e.PreOrderAvailabilityStartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.Property(e => e.ProductCost).HasColumnType("decimal");

                entity.Property(e => e.RequiredProductIds).HasMaxLength(1000);

                entity.Property(e => e.Searchable).HasDefaultValueSql("1");

                entity.Property(e => e.Sku).HasMaxLength(400);

                entity.Property(e => e.SpecialPrice).HasColumnType("decimal");

                entity.Property(e => e.SpecialPriceEndDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.SpecialPriceStartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Weight).HasColumnType("decimal");

                entity.Property(e => e.Width).HasColumnType("decimal");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductCategoryMapping>(entity =>
            {
                entity.ToTable("Product_Category_Mapping");

                entity.HasIndex(e => new { e.CategoryId, e.ProductId })
                    .HasName("IX_PCM_Product_and_Category");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategoryMapping)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("ProductCategory_Category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategoryMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductCategory_Product");
            });

            modelBuilder.Entity<ProductManufacturerMapping>(entity =>
            {
                entity.ToTable("Product_Manufacturer_Mapping");

                entity.HasIndex(e => new { e.ManufacturerId, e.ProductId })
                    .HasName("IX_PMM_Product_and_Manufacturer");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ProductManufacturerMapping)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("ProductManufacturer_Manufacturer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductManufacturerMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductManufacturer_Product");
            });

            modelBuilder.Entity<ProductPictureMapping>(entity =>
            {
                entity.ToTable("Product_Picture_Mapping");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.ProductPictureMapping)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("ProductPicture_Picture");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictureMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductPicture_Product");
            });

            modelBuilder.Entity<ProductProductAttributeMapping>(entity =>
            {
                entity.ToTable("Product_ProductAttribute_Mapping");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_Product_ProductAttribute_Mapping_ProductId");

                entity.HasOne(d => d.ProductAttribute)
                    .WithMany(p => p.ProductProductAttributeMapping)
                    .HasForeignKey(d => d.ProductAttributeId)
                    .HasConstraintName("ProductVariantAttribute_ProductAttribute");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProductAttributeMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductVariantAttribute_Product");
            });

            modelBuilder.Entity<ProductProductTagMapping>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ProductTagId })
                    .HasName("PK__Product___F62CEB096FB49575");

                entity.ToTable("Product_ProductTag_Mapping");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ProductTagId).HasColumnName("ProductTag_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProductTagMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Product_ProductTags_Source");

                entity.HasOne(d => d.ProductTag)
                    .WithMany(p => p.ProductProductTagMapping)
                    .HasForeignKey(d => d.ProductTagId)
                    .HasConstraintName("Product_ProductTags_Target");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductReview_ProductId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("ProductReview_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductReview_Product");
            });

            modelBuilder.Entity<ProductReviewHelpfulness>(entity =>
            {
                entity.HasOne(d => d.ProductReview)
                    .WithMany(p => p.ProductReviewHelpfulness)
                    .HasForeignKey(d => d.ProductReviewId)
                    .HasConstraintName("ProductReviewHelpfulness_ProductReview");
            });

            modelBuilder.Entity<ProductSpecificationAttributeMapping>(entity =>
            {
                entity.ToTable("Product_SpecificationAttribute_Mapping");

                entity.HasIndex(e => new { e.ProductId, e.SpecificationAttributeOptionId, e.AllowFiltering })
                    .HasName("IX_PSAM_SpecificationAttributeOptionId_AllowFiltering");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSpecificationAttributeMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductSpecificationAttribute_Product");

                entity.HasOne(d => d.SpecificationAttributeOption)
                    .WithMany(p => p.ProductSpecificationAttributeMapping)
                    .HasForeignKey(d => d.SpecificationAttributeOptionId)
                    .HasConstraintName("ProductSpecificationAttribute_SpecificationAttributeOption");
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_ProductTag_Name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<ProductTemplate>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<ProductVariantAttributeCombination>(entity =>
            {
                entity.Property(e => e.FulfillmentPartnerSku).HasMaxLength(64);

                entity.Property(e => e.Gtin).HasMaxLength(400);

                entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);

                entity.Property(e => e.Sku).HasMaxLength(400);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariantAttributeCombination)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductVariantAttributeCombination_Product");
            });

            modelBuilder.Entity<ProductVariantAttributeValue>(entity =>
            {
                entity.HasIndex(e => e.ProductVariantAttributeId)
                    .HasName("IX_ProductVariantAttributeValue_ProductVariantAttributeId");

                entity.Property(e => e.ColorSquaresRgb).HasMaxLength(100);

                entity.Property(e => e.Cost).HasColumnType("decimal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PriceAdjustment).HasColumnType("decimal");

                entity.Property(e => e.WeightAdjustment).HasColumnType("decimal");

                entity.HasOne(d => d.ProductVariantAttribute)
                    .WithMany(p => p.ProductVariantAttributeValue)
                    .HasForeignKey(d => d.ProductVariantAttributeId)
                    .HasConstraintName("ProductVariantAttributeValue_ProductVariantAttribute");
            });

            modelBuilder.Entity<QueuedEmail>(entity =>
            {
                entity.HasIndex(e => e.CreatedOnUtc)
                    .HasName("IX_QueuedEmail_CreatedOnUtc");

                entity.Property(e => e.Bcc).HasMaxLength(500);

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FromName).HasMaxLength(500);

                entity.Property(e => e.SentOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(1000);

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ToName).HasMaxLength(500);

                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.QueuedEmail)
                    .HasForeignKey(d => d.EmailAccountId)
                    .HasConstraintName("QueuedEmail_EmailAccount");
            });

            modelBuilder.Entity<RecurringPayment>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.HasOne(d => d.InitialOrder)
                    .WithMany(p => p.RecurringPayment)
                    .HasForeignKey(d => d.InitialOrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("RecurringPayment_InitialOrder");
            });

            modelBuilder.Entity<RecurringPaymentHistory>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.RecurringPayment)
                    .WithMany(p => p.RecurringPaymentHistory)
                    .HasForeignKey(d => d.RecurringPaymentId)
                    .HasConstraintName("RecurringPaymentHistory_RecurringPayment");
            });

            modelBuilder.Entity<RelatedProduct>(entity =>
            {
                entity.HasIndex(e => e.ProductId1)
                    .HasName("IX_RelatedProduct_ProductId1");
            });

            modelBuilder.Entity<ReturnRequest>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.ReasonForReturn).IsRequired();

                entity.Property(e => e.RequestedAction).IsRequired();

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReturnRequest)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("ReturnRequest_Customer");
            });

            modelBuilder.Entity<RewardPointsHistory>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.UsedAmount).HasColumnType("decimal");

                entity.Property(e => e.UsedWithOrderId).HasColumnName("UsedWithOrder_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RewardPointsHistory)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("RewardPointsHistory_Customer");

                entity.HasOne(d => d.UsedWithOrder)
                    .WithMany(p => p.RewardPointsHistory)
                    .HasForeignKey(d => d.UsedWithOrderId)
                    .HasConstraintName("RewardPointsHistory_UsedWithOrder");
            });

            modelBuilder.Entity<ScheduleTask>(entity =>
            {
                entity.Property(e => e.LastEndUtc).HasColumnType("datetime");

                entity.Property(e => e.LastStartUtc).HasColumnType("datetime");

                entity.Property(e => e.LastSuccessUtc).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ShippedDateUtc).HasColumnType("datetime");

                entity.Property(e => e.TotalWeight).HasColumnType("decimal");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("Shipment_Order");
            });

            modelBuilder.Entity<ShipmentItem>(entity =>
            {
                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentItem)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("ShipmentItem_Shipment");
            });

            modelBuilder.Entity<ShippingByWeight>(entity =>
            {
                entity.Property(e => e.AdditionalFixedCost).HasColumnType("decimal");

                entity.Property(e => e.From).HasColumnType("decimal");

                entity.Property(e => e.LowerWeightLimit).HasColumnType("decimal");

                entity.Property(e => e.PercentageRateOfSubtotal).HasColumnType("decimal");

                entity.Property(e => e.RatePerWeightUnit).HasColumnType("decimal");

                entity.Property(e => e.To).HasColumnType("decimal");

                entity.Property(e => e.Zip).HasMaxLength(400);
            });

            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<ShippingMethodRestrictions>(entity =>
            {
                entity.HasKey(e => new { e.ShippingMethodId, e.CountryId })
                    .HasName("PK__Shipping__9CE6B8E13BFFE745");

                entity.Property(e => e.ShippingMethodId).HasColumnName("ShippingMethod_Id");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ShippingMethodRestrictions)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("ShippingMethod_RestrictedCountries_Target");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.ShippingMethodRestrictions)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .HasConstraintName("ShippingMethod_RestrictedCountries_Source");
            });

            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.HasIndex(e => new { e.ShoppingCartTypeId, e.CustomerId })
                    .HasName("IX_ShoppingCartItem_ShoppingCartTypeId_CustomerId");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerEnteredPrice).HasColumnType("decimal");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("ShoppingCartItem_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ShoppingCartItem_Product");
            });

            modelBuilder.Entity<SliderCategory>(entity =>
            {
                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.SliderCategory)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("SliderCategory_Slider");
            });

            modelBuilder.Entity<SliderImage>(entity =>
            {
                entity.Property(e => e.DisplayText).HasMaxLength(400);

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.SliderImage)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("SliderImage_Slider");
            });

            modelBuilder.Entity<SliderManufacturer>(entity =>
            {
                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.SliderManufacturer)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("SliderManufacturer_Slider");
            });

            modelBuilder.Entity<SliderWidget>(entity =>
            {
                entity.Property(e => e.WidgetZone).IsRequired();

                entity.HasOne(d => d.Slider)
                    .WithMany(p => p.SliderWidget)
                    .HasForeignKey(d => d.SliderId)
                    .HasConstraintName("SliderWidget_Slider");
            });

            modelBuilder.Entity<SpecificationAttribute>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SpecificationAttributeOption>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.SpecificationAttribute)
                    .WithMany(p => p.SpecificationAttributeOption)
                    .HasForeignKey(d => d.SpecificationAttributeId)
                    .HasConstraintName("SpecificationAttributeOption_SpecificationAttribute");
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.HasIndex(e => new { e.DisplayOrder, e.CountryId })
                    .HasName("IX_StateProvince_CountryId");

                entity.Property(e => e.Abbreviation).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateProvince)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("StateProvince_Country");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Hosts).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.SecureUrl).HasMaxLength(400);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<StoreMapping>(entity =>
            {
                entity.HasIndex(e => new { e.EntityId, e.EntityName })
                    .HasName("IX_StoreMapping_EntityId_EntityName");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreMapping)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("StoreMapping_Store");
            });

            modelBuilder.Entity<TaxCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<TaxRate>(entity =>
            {
                entity.Property(e => e.Percentage).HasColumnType("decimal");
            });

            modelBuilder.Entity<TierPrice>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_TierPrice_ProductId");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.TierPrice)
                    .HasForeignKey(d => d.CustomerRoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TierPrice_CustomerRole");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TierPrice)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("TierPrice_Product");
            });

            modelBuilder.Entity<UrlRecord>(entity =>
            {
                entity.HasIndex(e => e.Slug)
                    .HasName("IX_UrlRecord_Slug");

                entity.HasIndex(e => new { e.EntityId, e.EntityName, e.LanguageId, e.IsActive })
                    .HasName("IX_UrlRecord_Custom_1");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);
            });
        }
    }
}