using budgetBackend.Services;
using budgetBackend.Models;

namespace budgetBackend.Models
{
    public class BankAccount
    {
        private static int indexer = 1;
        public BankAccount()
        {
            Id = indexer;
            indexer++;
            Date = DateTime.Now;
        }

        public int Id { get; }
        public string? AccountId { get; set; }

        public string? AccountName {  get; set; }

        public decimal Balance { get; set;  }
        public DateTime Date { get; }

        // Take a positive transaction and add it to the balance.
        public void MakeDeposit(decimal ammount)
        {
            Balance += ammount;
        }

        public void MakeWithdrawl(decimal ammount)
        {
            if (Balance - ammount !> 0)
            {
                Balance -= ammount;
            } else
            {
                throw new ArgumentException("You cannot withdraw more than you have");
            }
        }

    }
}