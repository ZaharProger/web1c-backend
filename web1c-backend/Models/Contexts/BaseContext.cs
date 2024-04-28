using Microsoft.EntityFrameworkCore;
using web1c_backend.Models.Entities;

namespace web1c_backend.Models.Contexts
{
    public class BaseContext: DbContext
    {
        public virtual DbSet<En_user> Users { get; set; }
        public virtual DbSet<En_session> Sessions { get; set; }
        public virtual DbSet<En_debtor_card> DebtorCards { get; set; }
        public virtual DbSet<En_history> History { get; set; }

        public BaseContext(DbContextOptions<Web1cDBContext> options): base(options) 
        {
        }
    }
}
