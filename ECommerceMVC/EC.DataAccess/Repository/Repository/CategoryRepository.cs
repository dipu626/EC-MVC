using EC.DataAccess.Data;
using EC.DataAccess.Repository.IRepository;
using EC.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EC.DataAccess.Repository.Repository
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            dbContext.Categories.Update(category);
        }
    }
}
