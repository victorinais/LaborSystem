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

        // Muestra la vista SignUpUser y carga los modelos necesarios
        public IActionResult SignUpUser() {
            var model = new RegistrationViewModel {
                Identifications = GetIdentifications(),
                Positions = GetPositions(),
                User = new User(),
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
        public async Task<IActionResult> SignUpUser(RegistrationViewModel model) {
            if (!ModelState.IsValid) {
                model.Identifications = GetIdentifications();
                model.Positions = GetPositions();
                return View(model);
            }
            try {
                model.User.DateCreate = DateTime.Now;
                await _context.Users.AddAsync(model.User);
                await _context.SaveChangesAsync();
                
                model.DataSesion.User_Id = model.User.Id;
                await _context.DataSesions.AddAsync(model.DataSesion);
                await _context.SaveChangesAsync();
                return Json(model.DataSesion);

            } catch (DbUpdateException ex) {
                ModelState.AddModelError("", "No se puede guardar: " + ex.Message);
                return View(model);
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
