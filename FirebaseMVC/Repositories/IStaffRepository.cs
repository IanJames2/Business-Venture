using System;
using System.Collections.Generic;
using BusinessVenture.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Repositories
{
    public interface IStaffRepository
    {
        List<Staff> GetAllStaffByUserProfileId(int userProfileId);
        Staff GetStaffById(int id);
        void AddStaffMember(Staff staff);
        void UpdateStaff(Staff staff);
        void DeleteStaff(int staffId);
    }
}

