using Microsoft.EntityFrameworkCore;
using TimeTrigger_AzureFunction.Models;

namespace TimeTrigger_AzureFunction
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
