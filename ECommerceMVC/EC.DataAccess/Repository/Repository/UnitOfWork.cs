using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;

namespace EC.DataAccess.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Categories = new CategoryRepository(dbContext);
            Products = new ProductRepository(dbContext);
        }


        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
