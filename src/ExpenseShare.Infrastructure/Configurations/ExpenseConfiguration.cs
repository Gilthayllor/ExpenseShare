using ExpenseShare.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseShare.Infrastructure.Configurations
{
    internal sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, value => new Name(value));
            
            builder.Property(x => x.Description)
                .HasConversion(x => x.Value, value => new Description(value));

            builder.OwnsOne(x => x.ExpenseValue, builder =>
            {
                builder.Property(money => money.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code))
                    .HasColumnName("ExpenseCurrency");
                builder.Property(money => money.Amount)
                    .HasPrecision(18,2)
                    .HasColumnName("ExpenseAmount");
            });

            var participantsNavigation = builder.Metadata.FindNavigation(nameof(Expense.ExpenseParticipants));
            participantsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
