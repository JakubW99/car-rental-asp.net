using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

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
          
        
            return View(dbContext.CarRentals);
        }
    }
}
