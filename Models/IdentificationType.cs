namespace LaborSystem.Models
{
    public class IdentificationType
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
