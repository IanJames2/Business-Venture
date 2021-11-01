using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace BusinessVenture.Models
{
    public class ProductOrService
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select the business that will sell this product!")]
        public int BusinessId { get; set; }

        [Required(ErrorMessage = "Type in a name for your product or service to continue!")]
        public string NameOfProductOrService { get; set; }

        [Range(1, 2000000000)]
        [Required(ErrorMessage = "You must have a cost for your product or service!")]
        public int Cost { get; set; }

        public Business Business { get; set; }
    }
}
