
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public int IdentificationType_Id { get; set; }
        [ForeignKey("IdentificationType_Id")]
        public IdentificationType IdentificationType { get; set; }
        public string? LastNames { get; set; }
        public string? DocumentNumber { get; set; }
        public int PositionType_Id { get; set; }
        [ForeignKey("PositionType_Id")]
        public PositionsType PositionType { get; set; }
    }
}
