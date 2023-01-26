using car_rental_asp.net.Models;
using car_rental_asp.net.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_asp.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private IAdminService _adminService;
        private TestAdminService _testAdminService;
        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }
      
        [Route("GetCarrentals/{id}")]
        [HttpGet("{id}", Name = "GetCarRentals")]
        public IEnumerable<CarRental> GetCarRentals(int id)
        {
            return _adminService.GetCarRentals(id);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>?>> Get()
        {
            if (_adminService is null)
            {
                return NotFound();
            }
            return new ActionResult<IEnumerable<Car?>>(_adminService.FindAll());
        }


        [Route("Get/{id}")]
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Car?>> Get(int id)
        {

            if (_adminService == null)
            {
                return NotFound();
            }

            var car = _adminService.FindBy(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }
        [Authorize(Roles="ADMIN")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarViewModel model)
        {
             _adminService.Save(model);
                return Created("", model);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CarViewModel model)
        {
            model.Id = (int)id;
            if (_adminService.Update(model))
            {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
        }
        [Authorize(Roles = "ADMIN")]
        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _adminService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
