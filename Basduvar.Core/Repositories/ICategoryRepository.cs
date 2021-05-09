using Basduvar.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basduvar.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
