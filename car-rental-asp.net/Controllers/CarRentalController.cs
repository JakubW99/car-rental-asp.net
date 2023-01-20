using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace car_rental_asp.net.Controllers
{
    public class CarRentalController : Controller
    {
        public ApplicationDbContext dbContext { get; set; }
        public IAdminService _adminService;
        public CarRentalController(ApplicationDbContext context, IAdminService adminService)
        {
            dbContext = context;
            _adminService = adminService;
        }
        public IActionResult Index()
        {

            return View();

        }
        [Authorize]
        public async Task<IActionResult> Post(int id)
        {
            CarRental carRental = new CarRental();
            var car = await dbContext.Cars.FindAsync(id);
            carRental.Car = car;
            car.CarRentals = await dbContext.CarRentals.Where(x => x.Car.Id == id).ToListAsync();

            return View(carRental);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(int id, CarRental carRental)
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cars = await dbContext.Cars.ToListAsync();
            var thisCar = cars.Where(x => x.Id == id).FirstOrDefault();
            var allCarRentals = await dbContext.CarRentals.Where(x => x.Car.Id == id).ToListAsync();
         
            CarRental c_Rental = new CarRental();

            c_Rental.UserId = currentUser;
            c_Rental.Car = thisCar;
            c_Rental.StartDate = carRental.StartDate;
            c_Rental.EndDate = carRental.EndDate;
            c_Rental.Amount = thisCar.Amount * Convert.ToDecimal((carRental.EndDate - carRental.StartDate).TotalDays);
       
            if (carRental.StartDate >= carRental.EndDate || (carRental.EndDate-carRental.StartDate).TotalDays <1)
                return RedirectToAction("Post", "CarRental");
            else
                foreach (var rental in allCarRentals)
                {
                    if (carRental.StartDate.Date >= rental.StartDate.Date && carRental.EndDate.Date <= rental.EndDate.Date)
                    {
                        return RedirectToAction("Post", "CarRental");
                    }
                }
                
                dbContext.Add(c_Rental);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Cars");

        }
        public async Task<IActionResult> Get(int id)
        {
            var cars = await dbContext.Cars.ToListAsync();
            return View(await dbContext.CarRentals.Where(x => x.Car.Id == id).ToListAsync());
        }
    }
}

