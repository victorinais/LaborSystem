namespace LaborSystem.Models
{
    public class PositionsType
    {
        public int Id { get; set; }
        public string? PositionName { get; set; }
        public List<User> Users { get; set; }
    }
}
