using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashGrow_API.Models
{
    /// <summary>
    /// Transaction properties
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the bank account the transaction belongs to
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Id of the budget item the transaction belongs to
        /// </summary>
        public int? BudgetItemId { get; set; }

        /// <summary>
        /// Account owner Id
        /// </summary>
        public string OwnerId { get; set; }

        //needs enum using directive - but we're not worrying with enums??
        //public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Date transaction was entered into the app
        /// </summary>
        public DateTime Created { get; set; }
    }
}