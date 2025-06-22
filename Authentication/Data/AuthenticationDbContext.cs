using Authentication.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication
{
    public class AuthenticationDbContext:DbContext
    {
        public AuthenticationDbContext(DbContextOptions options):base(options) { }
        public DbSet<UserAccount> Users { get; set; }
    }
}
