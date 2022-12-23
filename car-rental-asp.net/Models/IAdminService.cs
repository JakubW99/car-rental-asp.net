namespace car_rental_asp.net.Models
{
    public interface IAdminService
    {
        public int Save(Car car);
        public bool Delete(int? id);
        public bool Update(Car car);

        public Car? FindBy(int? id);
        public bool ChangeStatus(Car car);
        public ICollection<Car> FindAll();


    }
}
