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

            builder.OwnsOne(x => x.Name, builder =>
            {
                builder.Property(x => x.FirstName)
                    .HasColumnName("FirstName");

                builder.Property(x => x.LastName)
                    .HasColumnName("LastName");

                builder.HasData(
                new
                {
                    UserId = Guid.Parse("2DFC78FB-1674-42B0-9FED-A2CA496A6E79"),
                    FirstName = "Gilthayllor",
                    LastName = "Sousa"
                },
                new
                {
                    UserId = Guid.Parse("34A24C2B-D3E8-41A1-B3ED-B9A5E59AAE47"),
                    FirstName = "Sara",
                    LastName = "Brandão"
                });
            });

            builder.Property(x => x.Email)
                .HasMaxLength(250)
                .HasConversion(x => x.Value, value => new Email(value));

            builder.HasData([
                  new
                  {
                      Id = Guid.Parse("2DFC78FB-1674-42B0-9FED-A2CA496A6E79"),
                      Email = new Email("gilthayllor@outlook.com")
                  },
                  new {
                      Id = Guid.Parse("34A24C2B-D3E8-41A1-B3ED-B9A5E59AAE47"),
                      Email = new Email("saralimabrandao@outlook.com")
                  }
            ]);
        }
    }
}
