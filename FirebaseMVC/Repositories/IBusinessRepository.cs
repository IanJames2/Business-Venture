using System;
using System.Collections.Generic;
using BusinessVenture.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Repositories
{
    public interface IBusinessRepository
    {
        List<Business> GetAllBusinessesByUserProfileId(int userProfileId);
        Business GetBusinessById(int id);
        void AddBusiness(Business business);
        void UpdateBusiness(Business business);
        void DeleteBusiness(int businessId);
    }
}
