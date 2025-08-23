using Expenses.API.DTOs;
using Expenses.API.Models;

namespace Expenses.API.Services.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetAllTransactions();
        Transaction? GetTransactionById(int id);
        Transaction? Add(PostTransactionDto transaction);
        Transaction? Update(int id, PutTransactionDto transaction);
        void Delete(int id);
    }
}
