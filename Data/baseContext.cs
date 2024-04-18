using LaborSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborSystem.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }
    public DbSet<Record> Records { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<UserLogin> UserLogin { get; set; }
    public DbSet<IdentificationType> Identifications { get; set; }
    public DbSet<PositionsType> Positions { get; set; }
}
