using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;
using EC.Models.ProductModels;

namespace EC.DataAccess.Repository.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task UpdateAsync(Product product)
        {
            dbContext.Update(product);
        }

    }
}
