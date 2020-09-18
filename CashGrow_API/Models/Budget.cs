using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashGrow_API.Models
{
    /// <summary>
    /// Budget properties
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// Budget Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the household to which the budget belongs
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// Id of the budget owner
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Date budget was created in the app
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Budget name
        /// </summary>
        public string BudgetName { get; set; }
    }
}