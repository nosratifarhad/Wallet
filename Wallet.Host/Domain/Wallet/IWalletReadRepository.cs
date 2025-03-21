using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Dto;

namespace Wallet.Host.Domain.Wallet
{
    public interface IWalletReadRepository
    {
        Task<Currency> GetCurrency(string Code);

        Task<IEnumerable<Currency>> GetCurrencies();

        Task<WalletDto> GetWallet(int profileId);

    }
}
