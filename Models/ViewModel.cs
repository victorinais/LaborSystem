using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using LaborSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public DataSesion? DataSesion { get; set; }
        [Required]
        public User? User { get; set; }
        public List<SelectListItem> Identifications{ get; set; }
        public List<SelectListItem> Positions{ get; set; }

    }
}
