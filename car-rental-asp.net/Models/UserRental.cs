using System.ComponentModel.DataAnnotations;

namespace car_rental_asp.net.Models
{
    public class UserRental
    {
        [Key]
        public int RentalId { get; set; }
        public string UserId { get; set; }
        public CarRental CarRental { get; set; }
        public Car Car { get; set; }
    }
}
