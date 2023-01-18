using System.ComponentModel.DataAnnotations;
using car_rental_asp.net.Models;
using Microsoft.AspNetCore.Http;
namespace car_rental_asp.net.ViewModels
{
    public class CarViewModel
    {
        private IFormFile image;

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter car brand")]
        [Display(Name = "Brand")]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter car model name")]
        [Display(Name = "Model")]
        [StringLength(30)]
        public string CarModel { get; set; }
        [Required(ErrorMessage = "Please enter car specification")]
        [Display(Name = "Specification")]
        [StringLength(50)]
        public string Specification { get; set; }
        [Required(ErrorMessage = "Please enter amount")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Please enter year of car production")]
        [Display(Name = "Year")]
        public DateTime YearOfProduction { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public IFormFile Image { get => image; set => image = value; }


    }
}
