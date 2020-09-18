using CashGrow_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;

namespace CashGrow_API.Controllers
{
    /// <summary>
    /// Bank Account data
    /// </summary>
    [RoutePrefix("api/BankAccounts")]
   
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get all bank data
        /// </summary>
        /// <returns>Returns a list of all bank accounts and corresponding data.</returns>
        [Route ("Accounts")]
        public async Task<List<BankAccount>> GetAllBAnkData()
        {
            return await db.GetAllBankData();
        }

        /// <summary>
        /// Get data for all bank accounts as JSON
        /// </summary>
        /// <returns>Returns a list of all bank accounts and corresponding data, in JSON format.</returns>
        [Route("GetAllBAnkData/json")]
        public async Task<IHttpActionResult> GetAllBAnkDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBankData());
            return Ok(json);
        }

        /// <summary>
        /// Get data for a single bank account.
        /// </summary>
        /// <param name="baId">Household Id</param>
        /// <returns>Returns data for a chosen household.</returns>
        [Route("GetDataForSingleBankAccount")]
        public async Task<BankAccount> GetBankDataById(int baId)
        {
            return await db.GetBankDataById(baId);
        }

        /// <summary>
        /// Get data for a single bank account as JSON.
        /// </summary>
        /// <param name="baId">Household Id</param>
        /// <returns>Returns data for a chosen household, in JSON format.</returns>
        [Route("GetDataForSingleHousehold/json")]
        public async Task<IHttpActionResult> GetBankDataByIdAsJson(int baId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBankDataById(baId)));
        }

        /// <summary>
        /// Get transactions for each bank account.
        /// </summary>
        /// <param name="baId">Bank Account</param>
        /// <param name="trId">Transaction Id</param>
        /// <returns>Returns a list of households, with corresponding budgets and bank accounts.</returns>
        [Route("GetHouseholdBudgetsAndBankAccounts")]
        public async Task<List<Transaction>> GetBankAndTransactionData(int baId, int trId)
        {
            return await db.GetBankAndTransactionData(baId, trId);
        }

        /// <summary>
        /// Get transactions for each bank account as JSON.
        /// </summary>
        /// <param name="baId">Bank Account</param>
        /// <param name="trId">Transaction Id</param>
        /// <returns>Returns a list of households, with corresponding budgets and bank accounts - in JSON format.</returns>
        [Route("GetHouseholdBudgetsAndBankAccounts/json")]
        public async Task<IHttpActionResult> GetBankAndTransactionDataAsJson(int baId, int trId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBankAndTransactionData(baId, trId)));
        }

        /// <summary>
        /// Create a new Bank Account record
        /// </summary>
        /// <param name="Id">Bank Account Id</param>
        /// <param name="HouseholdId">Household Id</param>
        /// <param name="OwnerId">Owner Id</param>
        /// <param name="AccountName">Account Name</param>
        /// <param name="StartingBalance">Starting Balance</param>
        /// <param name="WarningBalance">Warning Balance</param>
        /// <param name="AccountType">Account Type</param>
        /// <returns>Inserts a new Bank Account record.</returns>
        [Route("CreateNewBankAccount")]
        public IHttpActionResult CreateNewBankAccount(int Id, int HouseholdId, string OwnerId, string AccountName, decimal StartingBalance, decimal WarningBalance, int AccountType)
        {
            return Ok();
        }

        /// <summary>
        /// Update a Household.
        /// </summary>
        /// <param name="Id">Bank Account Id</param>
        /// <param name="HouseholdId">Household Name</param>
        /// <param name="AccountName">Account Name</param>
        /// <param name="WarningBalance">Warning Balance</param>
        /// <param name="AccountType">Account Type</param>
        /// <returns>Update data for a single Household.</returns>
        [HttpPut, Route("UpdateBankAccount")]
        public IHttpActionResult UpdateBankAccount(int Id, int HouseholdId, string AccountName, decimal WarningBalance, int AccountType)
        {
            return Ok();
        }

        /// <summary>
        /// Delete a Bank Account record.
        /// </summary>
        /// <param name="Id">Bank Account Id</param>
        /// <returns>Deletes a Bank Account record.</returns>
        [HttpDelete, Route("DeleteBankAccount")]
        public IHttpActionResult DeleteBankAccount(int Id)
        {
            return Ok();
        }


    }
}
