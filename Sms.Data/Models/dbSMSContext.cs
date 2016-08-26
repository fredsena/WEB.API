using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Sms.Data.Models.Mapping;

namespace Sms.Data.Models
{
    public partial class dbSMSContext : DbContext
    {
        static dbSMSContext()
        {
            Database.SetInitializer<dbSMSContext>(null);
        }

        public dbSMSContext()
            : base("Name=dbSMSContext")
        {
        }

        public DbSet<CountrySm> CountrySms { get; set; }
        public DbSet<SmsTransaction> SmsTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountrySmMap());
            modelBuilder.Configurations.Add(new SmsTransactionMap());
        }
    }
}
