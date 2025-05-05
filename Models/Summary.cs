namespace Personal_Finance_Manager.Models
{
    public class Summary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Decimal TotalIncome { get; set; }
        public Decimal Expenses { get; set; }
        public Decimal NetBalance { get; set; }
        public User User { get; set; }
    } 
}
