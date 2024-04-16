using Microsoft.EntityFrameworkCore;
using PaymentAndDiscountCardSystemDAL;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;

namespace PaymentAndDiscountCardSystemTests.Common
{
    public class CustomerContextFactory
    {
        public static Guid CustomerAId = Guid.NewGuid();
        public static Guid CustomerBId = Guid.NewGuid();

        public static Guid CustomerIdForDelete = Guid.NewGuid();
        public static Guid CustomerIdForUpdate = Guid.NewGuid();

        public static StoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new StoreDbContext(options);
            context.Database.EnsureCreated();
            //context.Customers.AddRange(
            //    new Customer.Create
            //    {
            //        Id = Guid.Parse("3D10E2DD - 37F8 - 4F84 - 82BB - 9A7F95BC6A1A"),
            //        Name = "Jora",
            //        AccumulatedAmount = 0,
            //        DiscountCards = null
            //    });

            return context;
        }
    }
}
