namespace AccountManager.Domain.Entities;

public class Account
{
    public int Number { get; set; }
    public decimal Balance { get; set; } = 0m;
    public required string UserId { get; set; }
    public User? User { get; set; }
}
