
using Microsoft.EntityFrameworkCore;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Entity.Products;

namespace PaymentAndDiscountCardSystemDAL.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Product> Entities => throw new NotImplementedException();

        public async Task<Guid> Create(ProductViewModel entityModelView)
        {
            var product = new Product
                (
                entityModelView.Name,
                entityModelView.Description,
                entityModelView.Count,
                entityModelView.Price
                );

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<bool> Delete(Guid productId)
        {
            await _dbContext.Products
                 .Where(p => p.Id == productId)
                 .ExecuteDeleteAsync();
            return true;
        }

        public async Task<Product> Get(Guid produtctId)
        {
          return  await _dbContext.Products
                .Where(p=>p.Id == produtctId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> Update(Guid productId, ProductViewModel entityModelView)
        {
            await _dbContext.Products
                .Where(p => p.Id == productId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, entityModelView.Name)
                .SetProperty(p => p.Count, entityModelView.Count)
                .SetProperty(p => p.Price, entityModelView.Price));

            return await _dbContext.Products.FindAsync(productId);
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
