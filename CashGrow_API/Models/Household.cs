using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CashGrow_API.Models
{
    /// <summary>
    /// Household data model
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Household Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Household Name
        /// </summary>
        public string HouseholdName { get; set; }

        

        /// <summary>
        /// Household Greeting
        /// </summary>
        public string Greeting { get; set; }
        
        /// <summary>
        /// Date household was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Has this household been deleted?
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}