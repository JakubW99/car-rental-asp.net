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
        private readonly IWebHostEnvironment webHostEnvironment;
        public CarsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var car = await dbContext.Cars.ToListAsync();
            return View(car);
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car();
                string uniqueFileName = UploadedFile(model);
                car.Brand = model.Brand;
                car.Model = model.CarModel;
                car.Id = model.Id;
                car.Image = uniqueFileName;
                car.YearOfProduction = model.YearOfProduction;
                car.Amount = model.Amount;
                car.Specification = model.Specification;
                car.Description = model.Description;
                dbContext.Add(car);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

    }

    private string UploadedFile(CarViewModel model)
    {
        string uniqueFileName = null;

        if (model.Image != null)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.Image.CopyTo(fileStream);
            }
        }
        return uniqueFileName;
    }
}
}