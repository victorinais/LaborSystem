using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using LaborSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public UserLogin UserLogin { get; set; }
        [Required]
        public Employee Employee { get; set; }
        public List<SelectListItem> Identifications{ get; set; }
        public List<SelectListItem> Positions{ get; set; }

    }
}
