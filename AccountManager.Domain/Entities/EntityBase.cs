namespace AccountManager.Domain.Entities;

public class EntityBase
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
}
