using CashGrow_API.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CashGrow_API.Controllers
{
    /// <summary>
    /// Households data.
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get data for all households
        /// </summary>
        /// <returns>Returns a list of all households and corresponding data.</returns>
        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }

        /// <summary>
        /// Get data for all households as JSON
        /// </summary>
        /// <returns>Returns a list of all households and corresponding data, in JSON format.</returns>
        [Route("GetAllHouseholdData/json")]
        public async Task<IHttpActionResult>GetAllHouseholdDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(json);
        }

        /// <summary>
        /// Get data for a single household.
        /// </summary>
        /// <param name="hId">Household Id</param>
        /// <returns>Returns data for a chosen household.</returns>
        [Route("GetDataForSingleHousehold")]
        public async Task<Household> GetHouseholdDataById(int hId) 
        {
            return await db.GetHouseholdDataById(hId);
        }

        /// <summary>
        /// Get data for a single household as JSON.
        /// </summary>
        /// <param name="hId">Household Id</param>
        /// <returns>Returns data for a chosen household, in JSON format.</returns>
        [Route("GetDataForSingleHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdDataByIdAsJson(int hId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdDataById(hId)));
        }

        /// <summary>
        /// Get budgets and bank accounts for each household.
        /// </summary>
        /// <param name="hId">Household Id</param>
        /// <param name="buId">Budget Id</param>
        /// <param name="baId">Bank Account Id</param>
        /// <returns>Returns a list of households, with corresponding budgets and bank accounts.</returns>
        [Route("GetHouseholdBudgetsAndBankAccounts")]
        public async Task<List<Household>> GetHouseholdBudgetsAndBankAccounts(int hId, int buId, int baId)
        {
            return await db.GetHouseholdBudgetsAndBankAccounts(hId, buId, baId);
        }

        /// <summary>
        /// Get budgets and bank accounts for each household as JSON.
        /// </summary>
        /// <param name="hId">Household Id</param>
        /// <param name="buId">Budget Id</param>
        /// <param name="baId">Bank Account Id</param>
        /// <returns>Returns a list of households, with corresponding budgets and bank accounts - in JSON format.</returns>
        [Route("GetHouseholdBudgetsAndBankAccounts/json")]
        public async Task<IHttpActionResult> GetHouseholdBudgetsAndBankAccountsAsJson(int hId, int buId, int baId)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdBudgetsAndBankAccounts(hId, buId, baId)));
        }

        /// <summary>
        /// Create a new Household record
        /// </summary>
        /// <param name="Id">Household Id</param>
        /// <param name="HouseholdName">Household Name</param>
        /// <param name="Greeting">Greeting</param>
        /// <returns>Inserts a new Household record.</returns>
        [Route("CreateNewHousehold")]
        public IHttpActionResult CreateNewHousehold(int Id, string HouseholdName, string Greeting)
        {
            return Ok();
        }

        /// <summary>
        /// Update a Household.
        /// </summary>
        /// <param name="Id">Household Id</param>
        /// <param name="HouseholdName">Household Name</param>
        /// <param name="Greeting">Greeting</param>
        /// <returns>Update data for a single Household.</returns>
        [HttpPut, Route("UpdateHousehold")]
        public IHttpActionResult UpdateHousehold(int Id, string HouseholdName, string Greeting)
        {
            return Ok();
        }

        /// <summary>
        /// Delete a Household record.
        /// </summary>
        /// <param name="Id">Household Id</param>
        /// <returns>Deletes a Household record.</returns>
        [HttpDelete, Route("DeleteHousehold")]
        public IHttpActionResult DeleteHousehold(int Id)
        {
            return Ok();
        } 

    }
}
