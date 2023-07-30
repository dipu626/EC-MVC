using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;
using EC.Models.Category;

namespace EC.DataAccess.Repository.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task SaveAsync()
        //{
        //    await this.dbContext.SaveChangesAsync();
        //}

        public async Task UpdateAsync(Category category)
        {
            dbContext.Categories.Update(category);
        }
    }
}
