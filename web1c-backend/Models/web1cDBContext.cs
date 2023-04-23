using web1c_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace web1c_backend.Models
{
    public class Web1cDBContext : DbContext
    {
        public DbSet<En_user> Users { get; set; }
        public DbSet<En_session> Sessions { get; set; }
        public DbSet<En_event_record> Events { get; set; }
        public DbSet<En_debtor_card> Debtor_Cards { get; set; }
        public DbSet<En_debtor_agreement> Debtor_Agreement { get; set; }

        public Web1cDBContext(DbContextOptions<Web1cDBContext> options) : base(options)
        { }
    }
}
