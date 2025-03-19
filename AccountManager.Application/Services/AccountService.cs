using System;
using AccountManager.Application.DTOs.Account;
using AccountManager.Application.DTOs.Transactions;
using AccountManager.Application.Exceptions;
using AccountManager.Application.Interfaces;
using AccountManager.Domain.Entities;
using AccountManager.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Application.Services;

public class AccountService(AccountManagerDbContext context) : IAccountService
{
    public async Task<GetAccountBalanceDTO> GetAccountBalance(string accountNumber)
    {
        var account = await context.Accounts
            .AsNoTracking()
            .Where(a => a.Number == accountNumber)
            .Select(a => new GetAccountBalanceDTO(a.Number, a.Balance))
            .FirstOrDefaultAsync();

        if (account == null)
            throw new NotFoundException("Conta não encontrada");

        return account;
    }

    public async Task Transfer(CreateTransferDTO createTransferDTO, string payerAccountNumber)
    {
        var txn = await context.Database.BeginTransactionAsync();

        try
        {
            if (createTransferDTO.Amount < 0.01m)
                throw new BadRequestException("Valor da transferência deve ser maior que zero");

            var payerAccount = await context.Accounts
                .Where(a => a.Number == payerAccountNumber)
                .FirstOrDefaultAsync();

            var payeeAccount = await context.Accounts
                .Where(a => a.Number == createTransferDTO.PayeeAccountNumber)
                .FirstOrDefaultAsync();

            if (payerAccount == null)
                throw new NotFoundException("Conta pagadora não encontrada");

            if (payeeAccount == null)
                throw new NotFoundException("Conta beneficiária não encontrada");

            if (payerAccount.Balance < createTransferDTO.Amount)
                throw new BadRequestException("Saldo insuficiente para operação");

            var payerAccountTransaction = new Transaction
            {
                AccountNumber = payerAccount.Number,
                Amount = -createTransferDTO.Amount,
                Date = DateTime.Now,
                Description = $"Transferência enviada para {payeeAccount.Number}"
            };

            var payeeAccountTransaction = new Transaction
            {
                AccountNumber = payeeAccount.Number,
                Amount = createTransferDTO.Amount,
                Date = DateTime.Now,
                Description = $"Transferência recebida de {payerAccount.Number}"
            };

            await context.Transactions.AddAsync(payerAccountTransaction);
            await context.Transactions.AddAsync(payeeAccountTransaction);

            payerAccount.Balance -= createTransferDTO.Amount;
            payeeAccount.Balance += createTransferDTO.Amount;

            await context.SaveChangesAsync();
            await txn.CommitAsync();
        }
        catch (System.Exception)
        {
            await txn.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<GetTransactionDTO>> GetAccountTransactions(
        string accountNumber, DateTime initialDate, DateTime finalDate)
    {
        var transactions = await context.Transactions
            .AsNoTracking()
            .Where(t => t.AccountNumber == accountNumber && t.Date >= initialDate && t.Date <= finalDate)
            .OrderByDescending(t => t.Date)
            .Select(t => new GetTransactionDTO(t.Id, t.Amount, t.Description, t.Date))
            .ToListAsync();

        return transactions;
    }
}
