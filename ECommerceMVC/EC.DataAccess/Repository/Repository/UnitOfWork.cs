using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;

namespace EC.DataAccess.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public ICategoryRepository CategoryRepository { get;private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            CategoryRepository = new CategoryRepository(dbContext);
        }


        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
