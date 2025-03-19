namespace AccountManager.Application.DTOs.Transactions;

public record class GetTransactionDTO(
    string Id,
    decimal Amount,
    string Description,
    DateTime Date
)
{

}
