using budgetBackend.Models;
using System.Collections;
using System.Linq;

namespace budgetBackend.Services
{
    public class BankAccountService
    {
        private static Hashtable BankAccounts { get; set; }

        static BankAccountService()
        {
            var account1 = new BankAccount { AccountName = "Heritage", AccountId = "Someid123", Balance = 0 };
            var account2 = new BankAccount { AccountName = "Benefits", AccountId = "Someid1234", Balance = 0 };
            BankAccounts = new Hashtable();
            BankAccounts.Add(account1.Id, account1);
            BankAccounts.Add(account2.Id, account2);
            MakeDeposit(account1, 20);
        }

        public static List<BankAccount> GetAll()
        {
            var list = BankAccounts.Values.OfType<BankAccount>().ToList();
            list.Reverse();

            return list;
        }

        public static BankAccount? Get(int id)
        {
            var bankAccount = BankAccounts[id];
            if (bankAccount is null)
            {
                return null;
            }

            return (BankAccount) bankAccount;
        }

        public static void Add(BankAccount bankAccount)
        {
            BankAccounts.Add(bankAccount.Id, bankAccount);
        }

        public static void Save(BankAccount bankAccount)
        {
            if (BankAccounts.ContainsKey(bankAccount.Id))
            {
                BankAccounts[bankAccount.Id] = bankAccount;
            } else
            {
                BankAccounts.Add(bankAccount.Id, bankAccount);
            }
        }

        public static void Remove(int id)
        {
            //remove a thing
            var bankAccount = Get(id);

            if (bankAccount is null)
                return;

            BankAccounts.Remove(bankAccount);
        }

        public static void MakeDeposit(BankAccount bankaccount, int ammount)
        {
            bankaccount.MakeDeposit(ammount);
        }

        public static void MakeWithdrawl(BankAccount bankaccount, int ammount)
        {
            bankaccount.MakeWithdrawl(ammount);
        }
    }
}
