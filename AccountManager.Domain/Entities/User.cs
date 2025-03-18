namespace AccountManager.Domain.Entities;

public class User : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required int AccountNumber { get; set; }
    public Account? Account { get; set; }
}
