using ExpenseShare.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Domain.Expenses.Events
{
    public sealed record ExpensePartipantRemovedDomainEvent(Guid UserId, Guid ExpenseId): IDomainEvent;
}
