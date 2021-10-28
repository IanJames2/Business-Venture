using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Models.ViewModels
{
    public class ProductOrServiceFormViewModel
    {
        public ProductOrService ProductOrService { get; set; }
        public List<Business> Businesses { get; set; }
    }
}
