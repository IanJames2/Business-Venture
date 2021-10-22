using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Models
{
    public class BusinessStaff
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int StaffId { get; set; }
        public DateTime DateEmployed { get; set; }
        public string PositionTitle { get; set; }
    }
}
