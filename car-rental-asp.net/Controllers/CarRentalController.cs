using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace car_rental_asp.net.Controllers
{
    public class CarRentalController : Controller
    {
        public ApplicationDbContext dbContext { get; set; }

        public CarRentalController(ApplicationDbContext context)
        {
            dbContext = context;

        }
        public IActionResult Index()
        {

            return View();

        }
        public IActionResult Post(int id)
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(int id, CarRental carRental)
        {

            var thisCar  = await dbContext.Cars.FindAsync(id);


            CarRental c_Rental = new CarRental();
            c_Rental.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            c_Rental.Car = dbContext.Cars.Find(id);
            c_Rental.StartDate = carRental.StartDate;
            c_Rental.EndDate = carRental.EndDate;
            c_Rental.Amount = (thisCar.Amount/7) * Convert.ToDecimal((carRental.EndDate - carRental.StartDate).TotalDays);
            dbContext.Add(c_Rental);
            await dbContext.SaveChangesAsync();


            return View();
        }
    }
}

