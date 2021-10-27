using System;
using System.Collections.Generic;
using BusinessVenture.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Repositories
{
    public interface IProductOrServiceRepository
    {
        List<ProductOrService> GetAllProductsOrServicesByUserProfileId(int userProfileId);
        ProductOrService GetProductOrServiceById(int id);
        void AddProductOrService(ProductOrService productOrService);
        void UpdateProductOrService(ProductOrService productOrService);
        void DeleteProductOrService(int productOrServiceId);

    }
}
