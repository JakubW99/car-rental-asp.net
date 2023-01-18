using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace car_rental_asp.net.Controllers
{

    public class UserRentalsController : Controller
    {

        public ApplicationDbContext dbContext { get; set; }

        public CarRental _carRental { get; set; }  
        public UserRentalsController(ApplicationDbContext context)
        {

            dbContext = context;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cars = await dbContext.Cars.ToListAsync();
            var carRentals = dbContext.CarRentals.Where(x => x.UserId == currentUser);
            
             
            
            await dbContext.SaveChangesAsync();
            return View(carRentals);
        }

        
    }
}
