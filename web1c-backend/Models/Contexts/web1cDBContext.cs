using web1c_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace web1c_backend.Models.Contexts
{
    public class Web1cDBContext : BaseContext
    {
        public override DbSet<En_user> Users { get; set; }
        public override DbSet<En_session> Sessions { get; set; }
        public override DbSet<En_debtor_card> DebtorCards { get; set; }
        public override DbSet<En_history> History { get; set; }

        public Web1cDBContext(): base(new DbContextOptions<Web1cDBContext>())
        { }

        public Web1cDBContext(DbContextOptions<Web1cDBContext> options): base(options)
        { 
            
        }
    }
}
