namespace AccountManager.Domain.Entities;

public class Transaction : EntityBase
{
    public required int PayerAccountNumber { get; set; }
    public required int PayeeAccountNumber { get; set; }
    public required string Description { get; set; }
    public required decimal Value { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
