using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Models
{
    public class Business
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int BusinessTypeId { get; set; }
        public string Equipment { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Slogan { get; set; }
        public UserProfile UserProfile { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
