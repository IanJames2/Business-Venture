using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessVenture.Models.ViewModels
{
    public class BusinessFormViewModel
    {
        public Business Business { get; set; }
        public List<BusinessType> BusinessTypes { get; set; }
    }
}
