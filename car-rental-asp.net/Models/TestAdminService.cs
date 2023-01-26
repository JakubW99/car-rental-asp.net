using car_rental_asp.net.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace car_rental_asp.net.Models
{
    public class TestAdminService : IAdminService
    {
        private readonly Dictionary<int, Car?> repository = new Dictionary<int, Car?>();

        private int counter = 1;
        private int UniqId()
        {
            return counter++;
        }

        public Car? Save(Car? car)
        {
            car.Id = UniqId();
            repository.Add(car.Id, car);
            return car;
        }

        public async Task<Car> SaveAsync(Car car)
        {
            car.Id = UniqId();
            repository.Add(car.Id, car);
            return car;
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            return repository.Remove(id ?? 1);
        }

        public bool Update(Car? car)
        {
            if (repository.ContainsKey(car.Id))
            {
                repository[car.Id] = car;
                return true;
            }

            return false;
        }

        public Car? FindBy(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return repository.TryGetValue(id ?? 1, out var car) ? car : null;
        }

        public IEnumerable<Car?> FindAll()
        {
            return repository.Values;
        }

        public int Save(CarViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(CarViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarRental> GetCarRentals(int id)
        {
            throw new NotImplementedException();
        }

        public CarRental FindCarRental(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
