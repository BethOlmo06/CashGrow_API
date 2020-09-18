using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

namespace CashGrow_API.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
            :base("ApiConnection")
        {
        }
        #region Households
        public DbSet<Household> Households { get; set; }

       public async Task<List<Household>>GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }

        public async Task<Household> GetHouseholdDataById(int hId)
        {
            return await Database.SqlQuery<Household>("GetHouseHoldDataById @hId",
                new SqlParameter("hId", hId)).FirstOrDefaultAsync();
        }

        public async Task<List<Household>> GetHouseholdBudgetsAndBankAccounts(int hId, int buId, int baId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdBudgetsAndBankAccounts @baId, @buId",
                new SqlParameter("hId", hId),
                new SqlParameter("buId", buId),
                new SqlParameter("baId", baId)).ToListAsync();
        }

        public int CreateNewHousehold(int Id, string HouseholdName, string Greeting)
        {
            return Database.ExecuteSqlCommand("CreateNewHousehold @Id, @HouseholdName @Greeting",
                new SqlParameter("Id", Id),
                new SqlParameter("HouseholdName", HouseholdName),
                new SqlParameter("Greeting", Greeting));
        }

        public int UpdateHousehold(int Id, string HouseholdName, string Greeting)
        {
            return Database.ExecuteSqlCommand("UpdateHousehold @Id, @HouseholdName @Greeting",
                new SqlParameter("Id", Id),
                new SqlParameter("HouseholdName", HouseholdName),
                new SqlParameter("Greeting", Greeting));
        }

        public int DeleteHousehold(int Id)
        {
            return Database.ExecuteSqlCommand("DeleteHousehold @Id",
                new SqlParameter("Id", Id));
            
        }

        #endregion

        #region Bank Accounts
        public DbSet<BankAccount> BankAccounts { get; set; }

        public async Task<List<BankAccount>>GetAllBankData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankData").ToListAsync();
        }

        public async Task<BankAccount>GetBankDataById(int baId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankDataById @Id",
                new SqlParameter("Id", baId)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetBankAndTransactionData(int baId, int trId)
        {
            return await Database.SqlQuery<Transaction>("GetBankAndTransactionData @baId, @trId",
            new SqlParameter("baId", baId),
            new SqlParameter("trId", trId)).ToListAsync();
        }

        public int CreateNewBankAccount(int HouseholdId, string OwnerId, string AccountName, decimal StartingBalance, decimal WarningBalance, int AccountType)
        {
            return Database.ExecuteSqlCommand("[CreateNewBankAccount] @HouseholdId @OwnerId, @AccountName, @StartingBalance, @WarningBalance, @AccountType",
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("AccountName", AccountName),
                new SqlParameter("StartingBalance", StartingBalance),
                new SqlParameter("WarningBalance", WarningBalance),
                new SqlParameter("AccountType", AccountType));

        }

        public int UpdateBankAccount(int Id, int HouseholdId, string AccountName, decimal WarningBalance, int AccountType)
        {
            return Database.ExecuteSqlCommand("[UpdateBankAccount] @Id, @HouseholdId, @AccountName @WarningBalance, @AccountType",
                new SqlParameter("Id", Id),
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("AccountName", AccountName),
                new SqlParameter("WarningBalance", WarningBalance),
                new SqlParameter("AccountType", AccountType));
        }

        public int DeleteBankAccount(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteBankAccount] @Id",
                new SqlParameter("Id", Id));
            
        }

        #endregion

        #region Budgets
        public DbSet<Budget> Budgets { get; set; }

        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetData").ToListAsync();
        }

        public async Task<Budget>GetBudgetDataById(int buId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @Id",
                new SqlParameter("Id", buId)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetAndItemData(int buId, int biId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetAndItemData @buId, @biId",
            new SqlParameter("buId", buId),
            new SqlParameter("biId", biId)).ToListAsync();
        }

        public int CreateNewBudget(int Id, int HouseholdId, string OwnerId, string BudgetName, decimal CurrentAmount)
        {
            return Database.ExecuteSqlCommand("[CreateNewBudget] @Id, @HouseholdId @OwnerId, @BudgetName, @CurrentAmount",
                new SqlParameter("Id", Id),
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("BudgetName", BudgetName),
                new SqlParameter("CurrentAmount", CurrentAmount));

        }

        public int UpdateBudget(int Id, int HouseholdId, string BudgetName, decimal CurrentAmount)
        {
            return Database.ExecuteSqlCommand("[UpdateBudget] @Id, @HouseholdId, @BudgetName @CurrentAmount",
                new SqlParameter("Id", Id),
                new SqlParameter("HouseholdId", HouseholdId),
                new SqlParameter("BudgetName", BudgetName),
                new SqlParameter("CurrentAmount", CurrentAmount));
        }

        public int DeleteBudget(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteBudget] @BudgetName",
                new SqlParameter("Id", Id));

        }

        #endregion

        #region Budget Items
        public DbSet<BudgetItem> BudgetItems { get; set; }

        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItemData").ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDataById(int biId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataById @Id",
                new SqlParameter("Id", biId)).FirstOrDefaultAsync();
        }

        public int CreateNewBudgetItem(int Id, int BudgetId, string ItemName, decimal TargetAmount, decimal CurrentAmount)
        {
            return Database.ExecuteSqlCommand("[CreateNewBudgetItem] @Id, @BudgetId, @ItemName, @TargetAmount, @CurrentAmount",
                new SqlParameter("Id", Id),
                new SqlParameter("BudgetId", BudgetId),
                new SqlParameter("ItemName", ItemName),
                new SqlParameter("TargetAmount", TargetAmount),
                new SqlParameter("CurrentAmount", CurrentAmount));

        }

        public int UpdateBudgetItem(int Id, int BudgetId, string ItemName, decimal TargetAmount, decimal CurrentAmount)
        {
            return Database.ExecuteSqlCommand("[UpdateBudgetItem] @Id, @BudgetId, @ItemName, @TargetAmount, @CurrentAmount",
                new SqlParameter("Id", Id),
                new SqlParameter("BudgetId", BudgetId),
                new SqlParameter("ItemName", ItemName),
                new SqlParameter("TargetAmount", TargetAmount),
                new SqlParameter("CurrentAmount", CurrentAmount));
        }

        public int DeleteBudgetItem(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteBudget] @ItemName",
                new SqlParameter("Id", Id));

        }

        #endregion

        #region Transactions
        public DbSet<Transaction> Transactions { get; set; }

        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactionData").ToListAsync();
        }

        public async Task<Transaction> GetTransactionDataById(int trId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @Id",
                new SqlParameter("Id", trId)).FirstOrDefaultAsync();
        }

        public int CreateNewTransaction(int Id, int AccountId, int BudgetItemId, string OwnerId, int TransactionType, decimal Amount, string Memo, int BankAccount_Id)
        {
            return Database.ExecuteSqlCommand("[CreateNewTransaction] @Id, @AccountId, @BudgetItemId, @OwnerId, @TransactionType, @Amount, @Memo, @BankAccount_Id",
                new SqlParameter("Id", Id),
                new SqlParameter("AccountId", AccountId),
                new SqlParameter("BudgetItemId", BudgetItemId),
                new SqlParameter("OwnerId", OwnerId),
                new SqlParameter("TransactionType", TransactionType),
                new SqlParameter("Amount", Amount),
                new SqlParameter("Memo", Memo),
                new SqlParameter("BankAccount_Id", BankAccount_Id));

        }

        public int UpdateTransaction(int Id, int AccountId, int BudgetItemId, int TransactionType, decimal Amount, string Memo, int BankAccount_Id)
        {
            return Database.ExecuteSqlCommand("[UpdateTransaction] @Id, @AccountId, @BudgetItemId, @TransactionType, @Amount, @Memo, @BankAccount_Id",
                new SqlParameter("Id", Id),
                new SqlParameter("AccountId", AccountId),
                new SqlParameter("BudgetItemId", BudgetItemId),
                new SqlParameter("TransactionType", TransactionType),
                new SqlParameter("Amount", Amount),
                new SqlParameter("Memo", Memo),
                new SqlParameter("BankAccount_Id", BankAccount_Id));
        }

        public int DeleteTransaction(int Id)
        {
            return Database.ExecuteSqlCommand("[DeleteTransaction] @Id",
                new SqlParameter("Id", Id));

        }

        #endregion
    }
}