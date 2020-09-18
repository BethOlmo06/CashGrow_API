using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashGrow_API.Models
{
    /// <summary>
    /// Budget Item properties
    /// </summary>
    public class BudgetItem
    {

        /// <summary>
        /// Budget item Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Id of the budget to which the item belongs
        /// </summary>
        public int BudgetId { get; set; }

        /// <summary>
        /// Date the budget item was created in the app
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// name of the budget item
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Maximum amount the user wishes to spend
        /// </summary>
        public decimal TargetAmount { get; set; }

        /// <summary>
        /// Current amount spent
        /// </summary>
        public decimal CurrentAmount { get; set; }

        /// <summary>
        /// Is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}