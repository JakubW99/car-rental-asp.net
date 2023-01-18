using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using car_rental_asp.net.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static car_rental_asp.net.Models.Car;

namespace car_rental_asp.net.Controllers
{
    public class CarsController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public IAdminService _adminService;
        public CarsController(ApplicationDbContext context, IAdminService adminService)
        {
            dbContext = context;
           _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = _adminService.FindAll();
            
            return View(cars);
        }

        public IActionResult Post()
        {
            return View();
        }

    }
}