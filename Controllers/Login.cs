using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborSystem.Data;
using LaborSystem.Models;

namespace LaborSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly BaseContext _context;
        public LoginController(BaseContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}