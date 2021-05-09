using Basduvar.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basduvar.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
        //bool ControlInnerBarcode(Product product);
    }
}
