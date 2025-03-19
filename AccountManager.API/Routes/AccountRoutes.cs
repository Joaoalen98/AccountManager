using System;
using AccountManager.Application.DTOs.Account;
using AccountManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.API.Routes;

public static class AccountRoutes
{
    public static void MapAccountRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/api/account").RequireAuthorization();

        group.MapGet("",
            async (IAccountService service, HttpContext context) =>
            {
                var account = context.User.FindFirst("AccountNumber")?.Value!;
                return await service.GetAccountBalance(account);
            });

        group.MapPost("/transactions",
            async (IAccountService accountService, CreateTransferDTO createTransferDTO, HttpContext context) =>
            {
                var account = context.User.FindFirst("AccountNumber")?.Value!;
                await accountService.Transfer(createTransferDTO, account);
                return Results.Created();
            });

        group.MapGet("transactions",
            async (IAccountService accountService, [FromQuery] DateTime initialDate, [FromQuery] DateTime finalDate, HttpContext context) =>
            {
                var account = context.User.FindFirst("AccountNumber")?.Value!;
                return await accountService.GetAccountTransactions(account, initialDate, finalDate);
            });
    }
}
