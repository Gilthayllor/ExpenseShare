﻿namespace ExpenseShare.Domain.Abstractions
{
    public interface IUnityOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
