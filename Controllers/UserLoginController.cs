using LaborSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;

namespace LoginController.Controllers{
    public class LoginController : Controller {
        public readonly BaseContext _context;
        public LoginController(BaseContext context){
            _context = context;
        }
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
