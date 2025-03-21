using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Domain.Wallet
{
    public interface IWalletWriteRepository
    {
        Task CreateCurrency(Currency currency);
        Task UpdateCurrency(Currency currency);
        Task<int> CreateWallet(UserWallet userWallet);
        Task CreateCurrencyWallet(CurrencyWallet currencyWallet);
    }
}
