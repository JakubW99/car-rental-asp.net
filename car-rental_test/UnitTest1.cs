using car_rental_asp.net.Controllers;
using car_rental_asp.net.Models;
using car_rental_asp.net.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace car_rental_test
{
    public class UnitTest1
    {
        public class Tests
        {

            public TestAdminService service = new TestAdminService();
            private AdminsController controller;
           
            public Tests()
            {
                controller = new AdminsController(service);
                service.Save(new Car() { Brand = "VW", Model = "GOLF", Amount = 300, Description = "Compact", Image = "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" });
                service.Save(new Car() { Brand = "XXX", Model = "XXX", Amount = 555, Description = "ABC", Image = "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" });
                service.Save(new Car() { Brand = "ABC", Model = "XYZ", Amount = 300, Description = "Compact", Image = "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" });
                service.Save(new Car() { Brand = "Car", Model = "Model", Amount = 300, Description = "Compact", Image = "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" });


            }

            //Test xUnit
            [Xunit.Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            public async void TestCarsControllerGet(int id)
            {
                Car createdCar = new Car() { Brand = "Audi", Model = "a3", Amount = 250, Description = "Limousine", Image = "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" };
                var task = await controller.Get(id);
                ActionResult<Car> actionResult = Assert.IsType<ActionResult<Car>>(task);
                Car book = Assert.IsType<Car>(actionResult.Value);
                Assert.Equal(book.Id, service.FindBy(book.Id).Id);
            }

            [Fact]
            public async void TestCarsControllerDelete()
            {
                Car createdCar = new Car() { Brand = "Volvo", Model = "V60", Amount = 500, Description = "Wagon", Image = "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" };
                var task = await controller.Delete(1);
                NoContentResult noContentResult = Assert.IsType<NoContentResult>(task);
                var book = service.FindBy(1);
                Assert.Null(book);
            }

            [Fact]
            public async void TestCarsControllerGetAll()
            {
                var task = await controller.Get();
                ActionResult<IEnumerable<Car>> result = Assert.IsType<ActionResult<IEnumerable<Car>>>(task);
                IEnumerable<Car> cars = Assert.IsAssignableFrom<IEnumerable<Car>>(result.Value);
                Assert.Equal(4, cars.Count());
            }

           

        }
    }
}