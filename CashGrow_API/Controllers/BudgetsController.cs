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
    /// Budgets data
    /// </summary>
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get data for all budgets
        /// </summary>
        /// <returns>Returns a list of all budgets and corresponding data.</returns>
        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await db.GetAllBudgetData();
        }

        /// <summary>
        /// Get data for all budgets as JSON
        /// </summary>
        /// <returns>Returns a list of all budgets and corresponding data, in JSON format.</returns>
        [Route("GetAllBudgetData/json")]
        public async Task<IHttpActionResult> GetAllBudgetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetData());
            return Ok(json);
        }

        /// <summary>
        /// Get data for a single budget.
        /// </summary>
        /// <param name="buId">Household Id</param>
        /// <returns>Returns data for a chosen budget.</returns>
        [Route("GetDataForSingleBudget")]
        public async Task<Budget> GetBudgetDataById(int buId)
        {
            return await db.GetBudgetDataById(buId);
        }

        /// <summary>
        /// Get data for a single budget as JSON.
        /// </summary>
        /// <param name="buId">Household Id</param>
        /// <returns>Returns data for a chosen budget, in JSON format.</returns>
        [Route("GetDataForSingleBudget/json")]
        public async Task<IHttpActionResult> GetBudgetDataByIdAsJson(int buId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetDataById(buId)));
        }

        /// <summary>
        /// Get budget items for each budget.
        /// </summary>
        /// <param name="buId">Budget Id</param>
        /// <param name="biId">Budget Item Id</param>
        /// <returns>Returns a list of budgets, with corresponding budget items.</returns>
        [Route("GetBudgetAndItemData")]
        public async Task<List<BudgetItem>> GetBudgetAndItemData(int buId, int biId)
        {
            return await db.GetBudgetAndItemData(buId, biId);
        }

        /// <summary>
        /// Get budget items for each budget as JSON.
        /// </summary>
        /// <param name="buId">Budget Id</param>
        /// <param name="biId">Budget Item Id</param>
        /// <returns>Returns a list of budgets, with corresponding budget items - in JSON format.</returns>
        [Route("GetBudgetAndItemData/json")]
        public async Task<IHttpActionResult> GetBudgetAndItemDataAsJson(int buId, int biId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetAndItemData(buId, biId)));
        }

        /// <summary>
        /// Create a new Budget record
        /// </summary>
        /// <param name="Id">Budget Id</param>
        /// <param name="HouseholdId">Household Id</param>
        /// <param name="OwnerId">Owner Id</param>
        /// <param name="BudgetName">Budget Name</param>
        /// <param name="CurrentAmount">Current Amount</param>
        /// <returns>Inserts a new Budget record.</returns>
        [Route("CreateNewBudget")]
        public IHttpActionResult CreateNewBudget(int Id, int HouseholdId, string OwnerId, string BudgetName, decimal CurrentAmount)
        {
            return Ok();
        }

        /// <summary>
        /// Update a Budget.
        /// </summary>
        /// <param name="Id">Budget Id</param>
        /// <param name="HouseholdId">Household Name</param>
        /// <param name="BudgetName">Budget Name</param>
        /// <param name="CurrentAmount">Current Amount</param>
        /// <returns>Update data for a single Budget.</returns>
        [HttpPut, Route("UpdateBudget")]
        public IHttpActionResult UpdateBudget(int Id, int HouseholdId, string BudgetName, decimal CurrentAmount)
        {
            return Ok();
        }

        /// <summary>
        /// Delete a Budget record.
        /// </summary>
        /// <param name="Id">Budget Id</param>
        /// <returns>Deletes a Budget record.</returns>
        [HttpDelete, Route("DeleteBankAccount")]
        public IHttpActionResult DeleteBudget(int Id)
        {
            return Ok();
        }


    }
}
