using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;
using ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborSystem.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public IActionResult SignInUser() {
            var model = new RegistrationViewModel {
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
            try {
                model.Identifications = GetIdentifications();
                model.Positions = GetPositions();

                model.User.DateCreate = DateTime.Now;
                await _context.Users.AddAsync(model.User);
                await _context.SaveChangesAsync();
                
                model.DataSesion.User_Id = model.User.Id;
                await _context.DataSesions.AddAsync(model.DataSesion);
                await _context.SaveChangesAsync();
                return RedirectToAction("SignIn", "Login");

            } catch (DbUpdateException ex) {
                throw;
            }
        }

        // Procesa los datos de inicio de sesión
        [HttpPost]
        public async Task<IActionResult> SignInUser(DataSesion model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var user = await _context.DataSesions
                .FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user != null) {
                return RedirectToAction("Index", "Records");
            } else {
                ModelState.AddModelError("", "usuario y contraseña Invalios, intenta nuevamente");
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
