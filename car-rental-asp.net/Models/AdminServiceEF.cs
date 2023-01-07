using car_rental_asp.net.Data;
using Microsoft.EntityFrameworkCore;

namespace car_rental_asp.net.Models
{
    public class AdminServiceEF : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminServiceEF(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public bool ChangeStatus(Car car)
        {
            throw new NotImplementedException();
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

        public bool Update(Car car)
        {
            try
            {
                var find = _context.Cars.Find(car.Id);
                if (find is not null)
                {
                    find.Model = car.Model;
                    find.Brand = car.Brand;
                    find.YearOfProduction = car.YearOfProduction;
                    find.Amount = car.Amount;
                    find.Description = car.Description;
                    find.Specification = car.Specification;
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

        public int Save(Car car)
        {

            try
            {
                var entityEntry = _context.Cars.Add(car);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }

        public Car? FindBy(int? id)
        {
            return id is null ? null : _context.Cars.Find(id);
        }

        public DbSet<Car> FindAll()
        {
            return _context.Cars;
        }

        public CarRental FindCarRental(int? id)
        {
            return id is null ? null : _context.CarRentals.Find(id);
        }
    }
}
