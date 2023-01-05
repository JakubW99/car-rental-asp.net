namespace car_rental_asp.net.Models
{
    public class CarRental
    {
        public int Id { get; set; } 
        public Car Car { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }

    }
}
