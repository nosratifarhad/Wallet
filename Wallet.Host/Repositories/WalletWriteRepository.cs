using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Repositories
{
    public class WalletWriteRepository : IWalletWriteRepository
    {
        public Task CreateWallet(UserWallet userWallet)
        {
            throw new NotImplementedException();
        }
    }
}
