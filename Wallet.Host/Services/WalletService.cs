using Wallet.Host.Domain.Wallet;
using Wallet.Host.Services.Contracts;
using Wallet.Host.Dto;
using Wallet.Host.Domain.Wallet.Enums;

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

        public async Task<WalletBalanceDto> GetWalletBalance(int walletId, int profileId)
        {
            var wallet = await _walletReadRepository.GetWalletById(walletId);
            if (wallet == null)
                throw new Exception("Source Wallet Not Found.");

            if (wallet.ProfileId != profileId)
                throw new Exception("Profile Is not Owner.");

            var sumCashIn =
                    await _walletReadRepository.GetSumAmountTransaction(walletId, TransactionKind.CashIn);

            var sumCashOut =
                await _walletReadRepository.GetSumAmountTransaction(walletId, TransactionKind.CashOut);

            var balance = sumCashIn.Amount - sumCashOut.Amount;

            return new WalletBalanceDto()
            {
                ProfileId = profileId,
                WalletId = walletId,
                Balance = balance
            };
        }

        #region private

        #endregion private
    }
}
