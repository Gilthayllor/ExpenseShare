using ExpenseShare.Domain.Expenses;
using ExpenseShare.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseShare.Infrastructure.Configurations
{
    internal sealed class ExpenseParticipantConfiguration : IEntityTypeConfiguration<ExpenseParticipant>
    {
        public void Configure(EntityTypeBuilder<ExpenseParticipant> builder)
        {
            builder.ToTable("ExpenseParticipants");

            builder.HasKey(x => new
            {
                x.UserId,
                x.ExpenseId
            });

            builder.OwnsOne(x => x.AmountOwed, builder =>
            {
                builder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                    .HasColumnName("AmountOwedCurrency");
                builder.Property(x => x.Amount)
                    .HasPrecision(18, 2)
                    .HasColumnName("AmountOwed");
            });

            builder.OwnsOne(x => x.AmountPaid, builder =>
            {
                builder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                    .HasColumnName("AmountPaidCurrency");
                builder.Property(x => x.Amount)
                    .HasPrecision(18,2)
                    .HasColumnName("AmountPaid");
            });

            builder.HasOne<Expense>()
                .WithMany(x => x.ExpenseParticipants)
                .HasForeignKey(x => x.ExpenseId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Ignore(x => x.RemainingAmount);
        }
    }
}
