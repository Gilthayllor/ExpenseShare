namespace ExpenseShare.Domain.Expenses
{
    public interface IExpenseRepository
    {
        Task Add(Expense expense);
    }
}
