using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessVenture.Models;

namespace BusinessVenture.Repositories
{
    public interface IBusinessTypeRepository
    {
        List<BusinessType> GetAll();
    }
}
