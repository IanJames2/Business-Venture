using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Models
{
    public class ProductOrService
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string NameOfProductOrService { get; set; }
        public int Cost { get; set; }
    }
}
