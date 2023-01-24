//using car_rental_asp.net.ViewModels;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;

//namespace car_rental_asp.net.Models
//{
//    public class TestAdminService :IAdminService
//    {
//        private readonly Dictionary<int, CarViewModel?> repository = new Dictionary<int, CarViewModel?>();
//        private readonly IWebHostEnvironment webHostEnvironment;
//        private int counter = 1;
//        private int UniqId()
//        {
//            return counter++;
//        }

        
//        public bool Delete(int? id)
//        {
//            if (id is null)
//            {
//                return false;
//            }
//            return repository.Remove(id ?? 1);
//        }

//        //public Car? FindBy(int? id)
//        //{
//        //    if (id is null)
//        //    {
//        //        return null;
//        //    }
//        //    Car car = new Car();
//        //    var model = repository.TryGetValue(id ?? 1, out car) ? car : null;
          
//        //    string uniqueFileName = UploadedFile(model);
//        //    car.Brand = model.Brand;
//        //    car.Model = model.Model;
//        //    car.Id = model.Id;
//        //    car.Image = uniqueFileName;
//        //    car.YearOfProduction = model.YearOfProduction;
//        //    car.Amount = model.Amount;
//        //    car.Specification = model.Specification;
//        //    car.Description = model.Description;

//        //    return car;
//        //}
//        private string UploadedFile(CarViewModel model)
//        {
//            string uniqueFileName = null;

//            if (model.Image != null)
//            {
//                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
//                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    model.Image.CopyTo(fileStream);
//                }
//            }
//            return uniqueFileName;
//        }
//        public IEnumerable<Car?> FindAll()
//        {
//            return throw new NotImplementedException();
//        }

//        public int Save(CarViewModel car)
//        {
//            car.Id = UniqId();
//            repository.Add(car.Id, car);
//            return 1;
//        }

//        public bool Update(CarViewModel car)
//        {
//            if (repository.ContainsKey(car.Id))
//            {
//                repository[car.Id] = car;
//                return true;
//            }

//            return false;
//        }

//        public IEnumerable<CarRental> GetCarRentals(int id)
//        {
//            throw new NotImplementedException();
//        }

      

//        public CarRental FindCarRental(int? id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
