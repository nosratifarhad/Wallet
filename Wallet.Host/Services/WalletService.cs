using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Enums;
using Wallet.Host.Services.Contracts;
using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Dto;

namespace Wallet.Host.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletReadRepository _walletReadRepository;
        private readonly IWalletWriteRepository _walletWriteRepository;
        private const string DefaultWalletName = "DefaultWallet";

        public WalletService(
            IWalletReadRepository walletReadRepository,
            IWalletWriteRepository walletWriteRepository)
        {
            _walletReadRepository = walletReadRepository;
            _walletWriteRepository = walletWriteRepository;
        }

        public async Task CreateDefaultWallet(int profileId)
        {
            var walletDto = await _walletReadRepository.GetWallet(profileId);
            if (walletDto != null)
                return;

            var walletId = await CreateWallet(profileId);

            await CreateCurrencyWallet(walletId);
        }

        public Task<WalletDto> GetWalletBalance(int walletId)
        {
            throw new NotImplementedException();
        }

        #region private
        private async Task<int> CreateWallet(int profileId)
        {
            var userWallet = new UserWallet()
            {
                ProfileId = profileId,
                Status = WalletStatus.Active,
                Title = DefaultWalletName,
            };

            int walletId = await _walletWriteRepository.CreateWallet(userWallet);

            return walletId;
        }

        private async Task CreateCurrencyWallet(int walletId)
        {
            var currencyWallet = new CurrencyWallet()
            {
                WalletId = walletId,
                CurrencyCode = "IRR"
            };

            await _walletWriteRepository.CreateCurrencyWallet(currencyWallet);
        }

        #endregion private
    }
}
