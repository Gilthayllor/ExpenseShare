using ExpenseShare.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseShare.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name);

            builder.Property(x => x.Email)
                .HasMaxLength(250)
                .HasConversion(x => x.Value, value => new Email(value));
        }
    }
}
