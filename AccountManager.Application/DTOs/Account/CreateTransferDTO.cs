namespace AccountManager.Application.DTOs.Account;

public record class CreateTransferDTO(
    string PayeeAccountNumber,
    decimal Amount
)
{

}
