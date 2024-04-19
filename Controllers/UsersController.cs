using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;
using ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborSystem.Data;


namespace LaborSystem.Controllers;
public class UsersController : Controller {
    public readonly BaseContext _context;
    public UsersController(BaseContext context){
        _context = context;
    }
    //Listar todos los Empleados
    public async Task<IActionResult> Index(){
        return View(await _context.Users.ToListAsync());
    }
    //Detalles de empleados por Id
    public async Task<IActionResult> Details(int? id)
    {
        var User = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        var viewModel = new RegistrationViewModel
        {
            User = User,
        };
        return View(viewModel);
    }


}

