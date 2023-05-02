using web1c_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace web1c_backend.Models
{
    public class Web1cDBContext : DbContext
    {
        public DbSet<En_user> Users { get; set; }
        public DbSet<En_session> Sessions { get; set; }
        public DbSet<En_event_record> Events { get; set; }
        public DbSet<En_debtor_card> DebtorCards { get; set; }
        public DbSet<En_debtor_agreement> DebtorAgreements { get; set; }
        public DbSet<En_budget> Budgets { get; set; }
        public DbSet<En_business> Businesses { get; set; }
        public DbSet<En_counterparty> Counterparties { get; set; }
        public DbSet<En_counterparty_agreement> CounterpartyAgreements { get; set; }
        public DbSet<En_counter_type> CounterTypes { get; set; }
        public DbSet<En_currency> Currencies { get; set; }
        public DbSet<En_event_state> Event_States { get; set; }
        public DbSet<En_payment_process> PaymentProcesses { get; set; }
        public DbSet<En_society> Societies { get; set; }
        public DbSet<En_turnover> Turnovers { get; set; }
        public DbSet<En_work_type> WorkTypes { get; set; }
        public DbSet<En_market> Markets { get; set; }
        public DbSet<En_history> History { get; set; }
        public Web1cDBContext(DbContextOptions<Web1cDBContext> options) : base(options)
        { }
    }
}
