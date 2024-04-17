using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;
using ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborSystem.Data; 
using System.Linq;

namespace ViewModelsController.Controllers
{
    public class ViewModelsController : Controller
    {
        private readonly BaseContext _context;

        public ViewModelsController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var Identification = await _context.Identifications
                .Select(i => new SelectListItem
                {
                    Text = i.Description,
                    Value = i.Id.ToString()
                })
                .ToListAsync();

            var viewModel = new RegistrationViewModel
            {
                Identifications = Identification
            };

            return View(viewModel);
        }
    }
}

