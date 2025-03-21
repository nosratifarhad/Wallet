using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Dto;

namespace Wallet.Host.Domain.Wallet
{
    public interface IWalletWriteRepository
    {
        Task CreateCurrency(Currency currency);
        Task UpdateCurrency(Currency currency);
        Task CreateWallet(UserWallet userWallet);

        Task ChashIn(Transaction transaction);
        Task ChashOut(Transaction transaction);

    }
}
