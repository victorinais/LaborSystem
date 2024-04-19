using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;
using ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborSystem.Data;

namespace LoginController.Controllers {
    public class LoginController : Controller {
        private readonly BaseContext _context;

        public LoginController(BaseContext context) {
            _context = context;
        }

        // Muestra la vista SignUpEmployee y carga los modelos necesarios
        public IActionResult SignUpEmployee() {
            var model = new RegistrationViewModel {
                Identifications = GetIdentifications(),
                Positions = GetPositions(),
                Employee = new Employee(),
                DataSesion = new DataSesion()
            };
            return View(model);
        }

        // Muestra la vista Singn In
        public IActionResult SignIn()
        {
            return View();
        }

        // Procesa la creación de un nuevo usuario
        [HttpPost]
        public IActionResult SignUpEmployee(RegistrationViewModel model) {
            if (!ModelState.IsValid) {
                model.Identifications = GetIdentifications();
                model.Positions = GetPositions();
                return View(model);
            }

            try {
                _context.Employees.Add(model.Employee);
                _context.SaveChanges();

                // Asignar el ID del empleado recién creado al modelo DataSesion
                model.DataSesion.Employee_Id = model.Employee.Id;
                _context.DataSesions.Add(model.DataSesion);
                _context.SaveChanges();

                return RedirectToAction("SignUpDataSesion", "Login", new { id = model.Employee.Id});


            } catch (DbUpdateException ex) {
                ModelState.AddModelError("", "No se puede guardar: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SignUpDataSesion(int id) {
            var model = new DataSesion { Employee_Id = id };
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUpDataSesion(DataSesion DataSesion) {
            try {
                _context.DataSesions.Add(DataSesion);
                _context.SaveChanges();

                return RedirectToAction("SignIn", "Login");
            } catch (Exception ex) {
                ModelState.AddModelError("", "Ocurrió un error al registrar el usuario. Por favor, intenta de nuevo.");
                return View(DataSesion);
            }
        }

        private List<SelectListItem> GetIdentifications() {
            var types = _context.Identifications.ToList();
            var list = new List<SelectListItem>();
            foreach (var type in types) {
                list.Add(new SelectListItem { Value = type.Id.ToString(), Text = type.Description });
            }
            return list;
        }

        private List<SelectListItem> GetPositions() {
            var types = _context.Positions.ToList();
            var list = new List<SelectListItem>();
            foreach (var type in types) {
                list.Add(new SelectListItem { Value = type.Id.ToString(), Text = type.PositionName });
            }
            return list;
        }
    }
}
