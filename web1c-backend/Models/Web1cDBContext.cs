using web1c_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace web1c_backend.Models
{
    public class Web1cDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public Web1cDBContext(DbContextOptions<Web1cDBContext> options) : base(options)
        { }
    }
}
