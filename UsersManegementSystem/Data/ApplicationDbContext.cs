using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using UsersManegementSystem.Models;


namespace UsersManegementSystem.Data
{
    public class ApplicationDbContext: DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
    }
}
