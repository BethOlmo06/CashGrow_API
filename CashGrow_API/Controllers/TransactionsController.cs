using CashGrow_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CashGrow_API.Controllers
{

    /// <summary>
    /// Transactions data
    /// </summary>
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get data for all transactions
        /// </summary>
        /// <returns>Returns a list of all transactions and corresponding data.</returns>
        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await db.GetAllTransactionData();
        }

        /// <summary>
        /// Get data for all households as JSON
        /// </summary>
        /// <returns>Returns a list of all households and corresponding data, in JSON format.</returns>
        [Route("GetAllTransactionData/json")]
        public async Task<IHttpActionResult> GetAllTransactionDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllTransactionData());
            return Ok(json);
        }

        /// <summary>
        /// Get data for a single transaction.
        /// </summary>
        /// <param name="trId">Transaction Id</param>
        /// <returns>Returns data for a chosen transaction.</returns>
        [Route("GetTransactionDataById")]
        public async Task<Transaction> GetTransactionDataById(int trId)
        {
            return await db.GetTransactionDataById(trId);
        }

        /// <summary>
        /// Get data for a single transaction as JSON.
        /// </summary>
        /// <param name="trId">Transaction Id</param>
        /// <returns>Returns data for a chosen transaction, in JSON format.</returns>
        [Route("GetTransactionDataById/json")]
        public async Task<IHttpActionResult> GetTransactionDataByIdAsJson(int trId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionDataById(trId)));
        }

        /// <summary>
        /// Create a new Transaction record
        /// </summary>
        /// <param name="Id">Transaction Id</param>
        /// <param name="AccountId">Bank Account Id</param>
        /// <param name="BudgetItemId">Budget Item Id</param>
        /// <param name="OwnerId">Target Amount</param>
        /// <param name="TransactionType">Transaction Type</param>
        /// <param name="Amount">Amount</param>
        /// <param name="Memo">Memo</param>
        /// <param name="BankAccount_Id">Bank Account Id</param>
        /// <returns>Inserts a new Budget record.</returns>
        [Route("CreateNewTransaction")]
        public IHttpActionResult CreateNewTransaction(int Id, int AccountId, int BudgetItemId, string OwnerId, int TransactionType, decimal Amount, string Memo, int BankAccount_Id)
        {
            return Ok();
        }

        /// <summary>
        /// Update a Transaction.
        /// </summary>
        /// <param name="Id">Budget Item Id</param>
        /// <param name="AccountId">Bank Account Id</param>
        /// <param name="BudgetItemId">Budget Item Id</param>
        /// <param name="TransactionType">Transaction Type</param>
        /// <param name="Amount">Amount</param>
        /// <param name="Memo">Memo</param>
        /// <param name="BankAccount_Id">Bank Account Id</param>
        [HttpPut, Route("UpdateTransaction")]
        public IHttpActionResult UpdateTransaction(int Id, int AccountId, int BudgetItemId, int TransactionType, decimal Amount, string Memo, int BankAccount_Id)
        {
            return Ok();
        }

        /// <summary>
        /// Delete a Transaction record.
        /// </summary>
        /// <param name="Id">Transaction Id</param>
        /// <returns>Deletes a Transaction record.</returns>
        [HttpDelete, Route("DeleteTransaction")]
        public IHttpActionResult DeleteTransaction(int Id)
        {
            return Ok();
        }


    }
}
