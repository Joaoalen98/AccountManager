using System;
using AccountManager.Application.DTOs.Account;
using AccountManager.Application.DTOs.Transactions;

namespace AccountManager.Application.Interfaces;

public interface IAccountService
{
    Task<GetAccountBalanceDTO> GetAccountBalance(string accountNumber);
    Task<IEnumerable<GetTransactionDTO>> GetAccountTransactions(string accountNumber, DateTime initialDate, DateTime finalDate);
    Task Transfer(CreateTransferDTO createTransferDTO, string payerAccountNumber);
}
