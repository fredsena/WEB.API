using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sms.Data.Models.Mapping
{
    public class SmsTransactionMap : EntityTypeConfiguration<SmsTransaction>
    {
        public SmsTransactionMap()
        {
            // Primary Key
            this.HasKey(t => t.SmsTransactionId);

            // Properties
            this.Property(t => t.from)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.to)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.message)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SmsTransaction");
            this.Property(t => t.SmsTransactionId).HasColumnName("SmsTransactionId");
            this.Property(t => t.from).HasColumnName("from");
            this.Property(t => t.to).HasColumnName("to");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.DateTransaction).HasColumnName("DateTransaction");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
