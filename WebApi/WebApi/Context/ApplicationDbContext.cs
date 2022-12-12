using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }    
        public DbSet<Player> playerDb { get; set; }
    }
}
