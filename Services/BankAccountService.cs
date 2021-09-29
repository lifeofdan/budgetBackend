using budgetBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace budgetBackend.Services
{
    public class BankAccountService
    {
        static List<BankAccount> BankAccounts { get; set; }

        static BankAccountService()
        {
            BankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountName = "Heritage", AccountId = "Someid123", Balance = 0, Date = DateTime.Now, }
            };
        }

        public static List<BankAccount> GetAll() => BankAccounts;

        public static BankAccount? Get(int id)
        {
            var bankAccount = BankAccounts.FirstOrDefault(b => b.Id == id);
            return bankAccount;
        }
    }
}
