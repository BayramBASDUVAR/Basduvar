using Basduvar.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basduvar.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        //Category ye özgü methodlar yazılabilir
    }
}
