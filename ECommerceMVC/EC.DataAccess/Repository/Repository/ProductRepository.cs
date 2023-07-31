using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;
using EC.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            List<Product> products = await dbContext.Products.Include(it => it.Category).ToListAsync();
            return products;
        }

        public new async Task<Product?> GetAsync(Expression<Func<Product, bool>> filter)
        {
            Product? product = await dbContext.Products.Include(it => it.Category).FirstOrDefaultAsync(filter);
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            dbContext.Update(product);
        }

    }
}
