using LaborSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborSystem.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<IdentificationType> Identifications { get; set; }
    public DbSet<PositionsType> Positions { get; set; }
}
