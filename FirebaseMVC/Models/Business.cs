using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace BusinessVenture.Models
{
    public class Business
    {

        public int Id { get; set; }
        public int UserProfileId { get; set; }
        [Required(ErrorMessage = "Must select a Business")]
        public int BusinessTypeId { get; set; }
        [Required(ErrorMessage = "Please enter the equipment for your business")] 
        public string Equipment { get; set; }
        [Required(ErrorMessage = "You must enter a Title for your Business")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Type in a Location for your Business")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Slogan is required")]
        public string Slogan { get; set; }
        public UserProfile UserProfile { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
