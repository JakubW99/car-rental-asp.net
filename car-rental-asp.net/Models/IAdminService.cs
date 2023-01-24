using car_rental_asp.net.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace car_rental_asp.net.Models
{
    public interface IAdminService
    {
        public int Save(CarViewModel model);
        public bool Delete(int? id);
        public bool Update(CarViewModel model);

        public Car? FindBy(int? id);
        public IEnumerable<CarRental> GetCarRentals(int id);
        public IEnumerable<Car> FindAll();
        public CarRental FindCarRental(int? id);

    }
}
