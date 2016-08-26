using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sms.Data.Models.Mapping
{
    public class CountrySmMap : EntityTypeConfiguration<CountrySm>
    {
        public CountrySmMap()
        {
            // Primary Key
            this.HasKey(t => t.CountrySmsId);

            // Properties
            this.Property(t => t.CountryName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MobileCountryCode)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.CountryCode)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("CountrySms");
            this.Property(t => t.CountrySmsId).HasColumnName("CountrySmsId");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.MobileCountryCode).HasColumnName("MobileCountryCode");
            this.Property(t => t.CountryCode).HasColumnName("CountryCode");
            this.Property(t => t.SmsPrice).HasColumnName("SmsPrice");
        }
    }
}
