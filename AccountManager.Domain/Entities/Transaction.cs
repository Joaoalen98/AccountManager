namespace AccountManager.Domain.Entities;

public class Transaction : EntityBase
{
    public required string AccountNumber { get; set; }
    public Account? Account { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
