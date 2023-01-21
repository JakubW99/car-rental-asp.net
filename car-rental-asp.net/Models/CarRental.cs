using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace car_rental_asp.net.Models
{
    public class CarRental : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public  Car Car { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [Display(Name ="Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    errorMessage: "EndDate must be greater than StartDate"
               );
            }
        }

    }
}
