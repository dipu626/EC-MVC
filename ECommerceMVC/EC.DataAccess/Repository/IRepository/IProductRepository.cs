using EC.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateAsync(Product product);
    }
}
