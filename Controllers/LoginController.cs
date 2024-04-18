using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;
using ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborSystem.Data; 
using System.Linq;

namespace LoginController.Controllers {
    public class LoginController : Controller {
        public readonly BaseContext _context;
        public LoginController(BaseContext context){
            _context = context;
        }

        // Muestra la vista Singn In
        public IActionResult SignIn()
        {
            return View();
        }

        // Muestra la vista y trae los modelos en SingnUp
        public IActionResult SignUp()
        {
            var model = new RegistrationViewModel
            {
                Identifications = GetIdentifications(),
                Positions = GetPositions(),
                Employee = new Employee(),
                UserLogin = new UserLogin()
            };
            return View(model);
        }

        // Trae los datos de la tabla Indentification para mostrarlos en el select
        private List<SelectListItem> GetIdentifications()

        {
            var types = _context.Identifications.ToList();
            var list = new List<SelectListItem>();
            foreach(var type in types)
            {
                list.Add(new SelectListItem { Value = type.Id.ToString(), Text = type.Description });
            }
            return list;
        }

        // Trae los datos de la tabla Position para mostrarlos en el select
        private List<SelectListItem> GetPositions()
        {
            var types = _context.Positions.ToList();
            var list = new List<SelectListItem>();
            foreach(var type in types)
            {
                list.Add(new SelectListItem { Value = type.Id.ToString(), Text = type.PositionName});
            }
            return list;
        }

        // Controlador para "CREAR" una nuevo empleado
        //Procesa la peticion   
        [HttpPost]
        public async Task<IActionResult> SignUp(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("SignIn", "Login");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "No se puede guardar, revisa los datos introducidos.");
                return View(employee);
            }
        }

    }
}
