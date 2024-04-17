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
        private List<SelectListItem> GetPositions()
        {
            var types = _context.Positions.ToList();
            var list = new List<SelectListItem>();
            foreach(var type in types)
            {
                list.Add(new SelectListItem { Value = type.Id.ToString(), Text = $"{type.PositionName} - {type.Department}" });
            }
            return list;
        }
    }
}
