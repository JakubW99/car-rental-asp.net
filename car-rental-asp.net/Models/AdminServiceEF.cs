using car_rental_asp.net.Data;
using car_rental_asp.net.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace car_rental_asp.net.Models
{
    public class AdminServiceEF : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminServiceEF(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        
      
        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }

            var find = _context.Cars.Find(id);
            if (find is not null)
            {
                _context.Cars.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(CarViewModel model)
        {
            try
            {
                var find = _context.Cars.Find(model.Id);
                
                if (find is not null)
                {
                    string uniqueFileName = UploadedFile(model);
                    find.Model = model.CarModel;
                    find.Brand = model.Brand;
                    find.YearOfProduction = model.YearOfProduction;
                    find.Amount = model.Amount;
                    find.Description = model.Description;
                    find.Specification = model.Specification;
                    find.Image = UploadedFile(model);
                   _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public  int Save(CarViewModel model)
        {

            try
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
               var entityEntry = _context.Add(car);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
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

        public Car? FindBy(int? id)
        {
            
            return id is null ? null : _context.Cars.Find(id);
        }

        public IEnumerable<Car> FindAll()
        {
            return _context.Cars;
        }

        public CarRental FindCarRental(int? id)
        {
            return id is null ? null : _context.CarRentals.Find(id);
        }

        public IEnumerable<CarRental> GetCarRentals(int id)
        {
            return _context.CarRentals.Where(x=>x.Car.Id==id);
        }
    }
}
