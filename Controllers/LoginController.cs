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
        public IActionResult SignEmployee(Employee employee)
        {
            try
            {
                var lista = new Employee()
                {
                    Names = employee.Names,
                    IdentificationType_Id = employee.IdentificationType_Id,
                    LastNames = employee.LastNames,
                    DocumentNumber = employee.DocumentNumber,
                    PositionType_Id = employee.PositionType_Id,
                };
                _context.Employees.Add(lista);
                _context.SaveChanges();

                // Redirigir al usuario a una acción específica después de guardar los datos
                return RedirectToAction("SignIn", "Login");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "No se puede guardar, revisa los datos introducidos.");
                return View("SignUp"); 
            }
        }

        public IActionResult SignUpUserLogin(UserLogin userLogin)
        {
            var List = new UserLogin()
            {
                UserName = userLogin.UserName,
                Password = userLogin.Password,
                Employee_Id = 82
            };

            _context.UserLogin.Add(List);
            _context.SaveChanges();

            // Redirigir al usuario a la acción SignIn después de guardar los datos
            return RedirectToAction("SignIn", "Login");
        }
    }
}
