using LaborSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;

namespace LaborSystem.Controllers;
public class EmployeesController : Controller {
    public readonly BaseContext _context;
    public EmployeesController(BaseContext context){
        _context = context;
    }
    public async Task<IActionResult> Index(){
        return View(await _context.Employees.ToListAsync());
    }
}

