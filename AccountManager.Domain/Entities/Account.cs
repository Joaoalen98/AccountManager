namespace AccountManager.Domain.Entities;

public class Account
{
    public required string Number { get; set; }
    public decimal Balance { get; set; } = 0m;
    public required string UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}
