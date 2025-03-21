using Wallet.Host.Domain.Wallet;
using Wallet.Host.Dto;

namespace Wallet.Host.Repositories
{
    public class WalletReadRepository : IWalletReadRepository
    {
        public Task<bool> GetIsExistWallet(int walletId)
        {
            throw new NotImplementedException();
        }

        public Task<WalletDto> GetWallet(int profileId)
        {
            throw new NotImplementedException();
        }

        public Task<WalletInfoDto> GetWalletById(int walletId)
        {
            throw new NotImplementedException();
        }
    }
}
