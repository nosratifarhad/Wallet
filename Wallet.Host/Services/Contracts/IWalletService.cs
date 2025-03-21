using Wallet.Host.Dto;

namespace Wallet.Host.Services.Contracts
{
    public interface IWalletService
    {
        Task CreateDefaultWallet(int profileId);

        Task<WalletDto> GetWalletBalance(int walletId);
    }
}
