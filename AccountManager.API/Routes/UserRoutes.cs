using AccountManager.Application.DTOs.User;
using AccountManager.Application.Interfaces;

namespace AccountManager.API.Routes;

public static class UserRoutes
{
    public static void MapUserRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/api/users");

        group.MapPost("signup",
            async (IUserService userService, CreateUserDTO createUserDTO) =>
            {
                await userService.CreateUser(createUserDTO);
                return Results.Created();
            });

        group.MapPost("signin", async (IUserService userService, LoginUserDTO login) =>
            await userService.UserLogin(login.Email, login.Password));

        group.MapGet("", () =>
        {
            return Results.Ok();
        })
        .RequireAuthorization();
    }
}
