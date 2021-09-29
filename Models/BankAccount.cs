namespace budgetBackend.Models
{
    public class BankAccount
    {
        
        public int Id {  get; set; }
        public string? AccountId { get; set; }

        public string? AccountName {  get; set; }

        public decimal Balance { get; set;  }
        public DateTime Date { get; set; }

    }
}