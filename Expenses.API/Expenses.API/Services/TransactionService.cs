using Expenses.API.Data;
using Expenses.API.DTOs;
using Expenses.API.Models;
using Expenses.API.Services.Interfaces;


namespace Expenses.API.Services
{
    public class TransactionService(AppDbContext context) : ITransactionService
    {

        public Transaction? Add(PostTransactionDto transaction)
        {
            var newTransaction = new Transaction
            {
                Type = transaction.Type,
                Amount = transaction.Amount,
                Category = transaction.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Transactions.Add(newTransaction);
            context.SaveChanges();

            return newTransaction;
        }

        public void Delete(int id)
        {
            var existingTransaction = context.Transactions.FirstOrDefault(n => n.Id == id);
            
            context.Transactions.Remove(existingTransaction!);
            context.SaveChanges();
        }

        public List<Transaction> GetAllTransactions()
        {
            var transactions = context.Transactions.ToList();
            return transactions;
        }

        public Transaction? GetTransactionById(int id)
        {
            var transaction = context.Transactions.FirstOrDefault(n => n.Id == id);
            return transaction;

        }

        public Transaction? Update(int id, PutTransactionDto transaction)
        {
            var existingTransaction = context.Transactions.FirstOrDefault(n => n.Id == id);

            existingTransaction.Type = transaction.Type;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Category = transaction.Category;
            existingTransaction.UpdatedAt = DateTime.UtcNow;
            context.SaveChanges();
            return existingTransaction;
        }

    }
}
