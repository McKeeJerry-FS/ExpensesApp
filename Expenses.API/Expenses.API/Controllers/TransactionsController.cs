using Expenses.API.Data;
using Expenses.API.DTOs;
using Expenses.API.Models;
using Expenses.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionService service) : ControllerBase
    {

        [HttpGet("All")]
        public IActionResult GetTransactions()
        {
            var allTransactions = service.GetAllTransactions();
            return Ok(allTransactions);
        }

        [HttpGet("Details/{id:int}")]
        public IActionResult GetTransaction(int id)
        {
            var transaction = service.GetTransactionById(id);
            if (transaction is null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("Create")]
        public IActionResult CreateTransaction([FromBody] PostTransactionDto payload)
        {
            var newTransaction = service.Add(payload);
            return Ok(newTransaction);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdateTransaction(int id, [FromBody] PutTransactionDto payload)
        {
            var updatedTransaction = service.Update(id, payload);
            if (updatedTransaction is null)
            {
                return NotFound();
            }
            return Ok(updatedTransaction);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult DeleteTransaction(int id)
        {
            service.Delete(id);
            return Ok();
        }   

    }
}
