using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashGrow_API.Models
{
    /// <summary>
    /// Bank Account properties
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Bank Account Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the household to which the bank account belongs
        /// </summary>
        public int? HouseholdId { get; set; }

        /// <summary>
        /// Id of the account owner
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Date account was created in the app
        /// </summary>
        public DateTime Created { get; set; }
    }
}