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
    /// Budget Items data
    /// </summary>

    public class BudgetItemController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get data for all budget items
        /// </summary>
        /// <returns>Returns a list of all budget items and corresponding data.</returns>
        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await db.GetAllBudgetItemData();
        }

        /// <summary>
        /// Get data for all budget items as JSON
        /// </summary>
        /// <returns>Returns a list of all budget items and corresponding data, in JSON format.</returns>
        [Route("GetAllBudgetItemData/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetItemData());
            return Ok(json);
        }

        /// <summary>
        /// Get data for a single budget item.
        /// </summary>
        /// <param name="biId">Budget Item</param>
        /// <returns>Returns data for a chosen household.</returns>
        [Route("GetBudgetItemDataById")]
        public async Task<BudgetItem> GetBudgetItemDataById(int biId)
        {
            return await db.GetBudgetItemDataById(biId);
        }

        /// <summary>
        /// Get data for a single budget item as JSON.
        /// </summary>
        /// <param name="biId">Household Id</param>
        /// <returns>Returns data for a chosen budget item, in JSON format.</returns>
        [Route("GetBudgetItemDataById/json")]
        public async Task<IHttpActionResult> GetBudgetItemDataByIdAsJson(int biId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemDataById(biId)));
        }

        /// <summary>
        /// Create a new Budget Item record
        /// </summary>
        /// <param name="Id">Budget Item Id</param>
        /// <param name="BudgetId">Budget Id</param>
        /// <param name="ItemName">Item Name</param>
        /// <param name="TargetAmount">Target Amount</param>
        /// <param name="CurrentAmount">Current Amount</param>
        /// <returns>Inserts a new Budget record.</returns>
        [Route("CreateNewBudgetItem")]
        public IHttpActionResult CreateNewBudgetItem(int Id, int BudgetId, string ItemName, decimal TargetAmount, decimal CurrentAmount)
        {
            return Ok();
        }

        /// <summary>
        /// Update a Budget Item.
        /// </summary>
        /// <param name="Id">Budget Item Id</param>
        /// <param name="BudgetId">Budget Id</param>
        /// <param name="ItemName">Item Name</param>
        /// <param name="TargetAmount">Target Amount</param>
        /// <param name="CurrentAmount">Current Amount</param>
        /// <returns>Update data for a single Budget.</returns>
        [HttpPut, Route("UpdateBudgetItem")]
        public IHttpActionResult UpdateBudgetItem(int Id, int BudgetId, string ItemName, decimal TargetAmount, decimal CurrentAmount)
        {
            return Ok();
        }

        /// <summary>
        /// Delete a Budget record.
        /// </summary>
        /// <param name="Id">Budget Item Id</param>
        /// <returns>Deletes a Budget Item record.</returns>
        [HttpDelete, Route("DeleteBudgetItem")]
        public IHttpActionResult DeleteBudgetItem(int Id)
        {
            return Ok();
        }





    }
}
