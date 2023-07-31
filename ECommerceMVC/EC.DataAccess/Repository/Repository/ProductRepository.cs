using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;
using EC.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace EC.DataAccess.Repository.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public new async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await dbContext.Products.Include(it => it.Category).ToListAsync();
            return products;
        }

        public async Task UpdateAsync(Product product)
        {
            dbContext.Update(product);
        }

    }
}
