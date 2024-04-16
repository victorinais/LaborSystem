namespace LaborSystem.Models
{
    public class Employee{
        public int Id { get; set; }
        public string? Names { get; set;}
        public int IdentificationType_Id { get; set; }
        public string? LastNames { get; set; }
        public string? DocumentNumber { get; set; }
        public int PositionType_Id { get; set; }
        public int UserLogin_Id { get; set; }

    }

}
