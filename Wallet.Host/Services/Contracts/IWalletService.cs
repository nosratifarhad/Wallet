using Wallet.Host.Dto;

namespace Wallet.Host.Services.Contracts
{
    public interface IWalletService
    {
        Task<WalletBalanceDto> GetWalletBalance(int walletId, int profileId);
    }
}
