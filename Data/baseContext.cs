using Microsoft.EntityFrameworkCore;
using LaborSystem.Models;
namespace LaborSystem.Data;

public class BaseContext : DbContext{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options){
        
    }
    public DbSet<Employee> Employees { get; set; }
    
}