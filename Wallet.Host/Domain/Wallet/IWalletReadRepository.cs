using Wallet.Host.Dto;

namespace Wallet.Host.Domain.Wallet
{
    public interface IWalletReadRepository
    {
        Task<WalletDto> GetWallet(int profileId);

        Task<WalletInfoDto> GetWalletById(int walletId);

        Task<bool> GetIsExistWallet(int walletId);
    }
}
