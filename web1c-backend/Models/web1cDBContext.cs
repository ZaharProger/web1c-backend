using web1c_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace web1c_backend.Models
{
    public class web1cDBContext : DBContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public web1cDBContext(DbContextOptions<web1cDBContext> options) : base(options)
        { }
    }
}
