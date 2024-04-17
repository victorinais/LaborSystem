using LaborSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;

namespace LaborSystem.Controllers;

public class RecordsController : Controller{
  public readonly BaseContext _context;
  public RecordsController(BaseContext context){
    _context = context;
  }
  public IActionResult Index()
  {
    return View();
  }
  [HttpPost]
  public async Task<IActionResult> Create(Record record){
    _context.Records.Add(record);
    _context.SaveChanges();
    return RedirectToAction("Index");
  }
}
