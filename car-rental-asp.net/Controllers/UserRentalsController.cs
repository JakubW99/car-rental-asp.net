using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace car_rental_asp.net.Controllers
{
    public class UserRentalsController : Controller
    {
        public ApplicationDbContext dbContext { get; set; }
        
        public UserRentalsController(ApplicationDbContext context)
        {
            
            dbContext = context;
        }
        public IActionResult Index()
        {
          
            UserRental userRental = new UserRental();
            foreach(var item in dbContext.CarRentals)
            {

                userRental.Car = item.Car;
                userRental.UserId = item.UserId;
                dbContext.UserRentals.Add(userRental);
            }
            var currentUserRentals =dbContext.UserRentals.Where(x=> x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View(currentUserRentals);
        }
    }
}
