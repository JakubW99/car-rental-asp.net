using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace car_rental_asp.net.ViewModels
{
    public class CarViewModel
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter car brand")]
        [Display(Name = "Car brand")]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter car model name")]
        [Display(Name = "Car model")]
        [StringLength(30)]
        public string CarModel { get; set; }
        [Required(ErrorMessage = "Please enter car specification")]
        [Display(Name = "Car specification")]
        [StringLength(50)]
        public string Specification { get; set; }
        [Required(ErrorMessage = "Please enter amount")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Please enter year of car production")]
        public DateTime YearOfProduction { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public IFormFile Image { get; set; }
   
   
    }
}
