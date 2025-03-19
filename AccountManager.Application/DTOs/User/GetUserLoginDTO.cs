namespace AccountManager.Application.DTOs.User;

public record class GetUserLoginDTO(
    string Token,
    DateTime ExpiresAt,
    string UserId,
    string AccountNumber
)
{

}
