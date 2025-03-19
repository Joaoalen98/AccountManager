namespace AccountManager.Application.DTOs.Account;

public record class GetAccountBalanceDTO(
    string Number,
    decimal Balance
)
{

}
