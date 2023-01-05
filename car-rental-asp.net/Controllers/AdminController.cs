using car_rental_asp.net.Data;
using car_rental_asp.net.Models;
using car_rental_asp.net.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_asp.net.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public IAdminService _adminService;
        public AdminController(ApplicationDbContext context,IAdminService adminService)
        {
            _adminService = adminService;

        }
        [Authorize(Roles ="ADMIN")]
        public ActionResult Index()
        {
            return View(_adminService.FindAll());
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if(ModelState.IsValid)
            {
               _adminService.Save(car);
                return RedirectToAction(nameof(Index));
            }
           return View(car);
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var car = _adminService.FindBy(id);
            return car is null ? NotFound() : View(car);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            if (ModelState.IsValid)
            {
                _adminService.Update(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _adminService.FindBy(id);
            return car is null ? NotFound() : View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            if (_adminService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return Problem("Trying delete no existing car");
        }
    }
}
