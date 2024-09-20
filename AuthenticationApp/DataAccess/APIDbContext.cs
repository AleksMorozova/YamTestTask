using AuthenticationApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApp.DataAccess;

public class APIDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
    {

    }
}
