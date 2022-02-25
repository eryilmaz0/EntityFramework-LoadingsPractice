using EntityFrameworkLoadings.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLoadings.API.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts):base(opts)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
}