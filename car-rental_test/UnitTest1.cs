//using car_rental_asp.net.Controllers;
//using car_rental_asp.net.Models;
//using car_rental_asp.net.ViewModels;
//using Xunit;

//namespace car_rental_test
//{
//    public class UnitTest1
//    {
//        public class Tests
//        {

//            private IAdminService service = new TestAdminService();
//            private AdminsController controller;

//            public Tests()
//            {
//                controller = new AdminsController(service);
//                service.Save(new CarViewModel() { Brand="VW",CarModel="GOLF",  Amount=300, Description="Compact",  Image= "08eb1ff6-deb3-4f26-9be7-138c1be6925e_bmw.png" })
                    
//            }

//            //Test xUnit
//            [Xunit.Theory]
//            [InlineData(1)]
//            [InlineData(2)]
//            [InlineData(3)]
//            [InlineData(4)]
//            public async void TestBooksControllerGet(int id)
//            {
//                Book createdBook = new Book() { Title = "Nowa", ReleaseDate = new DateTime(2020, 10, 10) };
//                var task = await controller.GetBook(id);
//                ActionResult<Book> actionResult = Assert.IsType<ActionResult<Book>>(task);
//                Book book = Assert.IsType<Book>(actionResult.Value);
//                Assert.Equal(book.Id, service.FindBy(book.Id).Id);
//            }

//            [Fact]
//            public async void TestBooksControllerDelete()
//            {
//                Book createdBook = new Book() { Title = "Nowa", ReleaseDate = new DateTime(2020, 10, 10) };
//                var task = await controller.DeleteBook(1);
//                NoContentResult noContentResult = Assert.IsType<NoContentResult>(task);
//                var book = service.FindBy(1);
//                Assert.Null(book);
//            }

//            [Fact]
//            public async void TestBooksControllerGetAll()
//            {
//                var task = await controller.GetBooks();
//                ActionResult<IEnumerable<Book>> result = Assert.IsType<ActionResult<IEnumerable<Book>>>(task);
//                IEnumerable<Book> books = Assert.IsAssignableFrom<IEnumerable<Book>>(result.Value);
//                Assert.Equal(4, books.Count());
//            }

//            [Fact]
//            public async void TestBooksControllerPost()
//            {
//                BookDto createdBook = new BookDto() { Id = 1, Title = "Nowa", ReleaseDate = new DateTime(2020, 10, 10) };
//                var task = await controller.PostBook(createdBook);
//                var createdResult = Assert.IsType<ActionResult<Book>>(task);
//                Assert.NotNull(service.FindBy(createdBook.Id));
//            }
//        }
//    }
//}