using MassTransit.DependencyInjection;
using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Domain.Wallet.Enums;
using Wallet.Host.Dto;

namespace Wallet.Host.Domain.Wallet
{
    public interface IWalletReadRepository
    {
        Task<Currency> GetCurrency(string Code);

        Task<IEnumerable<Currency>> GetCurrencies();

        Task<WalletDto> GetWallet(int profileId);

        Task<WalletInfoDto> GetWalletById(int walletId);

        Task<bool> GetIsExistWallet(int walletId);

        Task<Transaction> GetSumAmountTransaction(int walletId, TransactionKind kind);

    }
}
