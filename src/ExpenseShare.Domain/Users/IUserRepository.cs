namespace ExpenseShare.Domain.Users
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        void Add(User user);
    }
}
