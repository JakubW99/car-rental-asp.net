using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace car_rental_asp.net.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter car brand")]
        [Display(Name = "Brand")]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter car model name")]
        [Display(Name = "Model")]
        [StringLength(30)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please enter car specification")]
        [Display(Name = "Specification")]
        [StringLength(50)]
        public string Specification { get; set; }
        [Required(ErrorMessage = "Please enter amount")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Please enter year of car production")]
        [Display(Name = "Year")]
        public DateTime YearOfProduction { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        [Display(Name = "Image")]
        public string Image { get; set; }
        public List<CarRental> CarRentals { get; set; }
        public Car()
        {

        }
    }
}
