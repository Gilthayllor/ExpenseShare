using ExpenseShare.Domain.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Infrastructure.Configurations
{
    public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, value => new Name(value));

            builder.Property(x => x.RoomCode)
                .HasConversion(x => x.Value, value => Code.FromValue(value));

            var usersNavigation =
              builder.Metadata.FindNavigation(nameof(Room.Users));
            usersNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.SetNull);

            var expensesNavigation =
              builder.Metadata.FindNavigation(nameof(Room.Expenses));
            expensesNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.Expenses)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId);
        }
    }
}
