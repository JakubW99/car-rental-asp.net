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
        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _adminService.FindAll();
        }


        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Car> Get(int id)
        {
            
            return _adminService.FindBy(id);
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
        public IActionResult Delete(int id)
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
