namespace Personal_Finance_Manager.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; } = default(DateTime?);
        public string Category { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
