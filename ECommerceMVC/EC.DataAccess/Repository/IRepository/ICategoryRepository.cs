using EC.Models.CategoryModels;

namespace EC.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task UpdateAsync(Category category);
        //Task SaveAsync();
    }
}
