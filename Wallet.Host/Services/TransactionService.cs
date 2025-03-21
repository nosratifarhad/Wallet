using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Domain.Wallet.Enums;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Services
{
    public class TransactionService : ITransactionService
    {
        private const decimal MaxLimitedAmount = 1000000;

        private readonly IWalletReadRepository _walletReadRepository;
        private readonly ITransactionWriteRepository _transactionWriteRepository;

        public TransactionService(IWalletReadRepository walletReadRepository,
            ITransactionWriteRepository transactionWriteRepository)
        {
            _walletReadRepository = walletReadRepository;
            _transactionWriteRepository = transactionWriteRepository;
        }

        public async Task ChashIn(TransactionDto transactionDto)
        {
            var existingWallet = await _walletReadRepository.GetIsExistWallet(transactionDto.WalletId);
            if (!existingWallet)
                throw new Exception("Wallet Not Found.");

            if (transactionDto.Amount >= MaxLimitedAmount)
                throw new Exception("Your Cannot CashIn this Amount");

            var transaction = new Transaction()
            {
                Amount = transactionDto.Amount,
                Description = transactionDto.Description,
                WalletId = transactionDto.WalletId,
                FinancialVoucherId = transactionDto.FinancialVoucherId,
                CreateDateUtc = DateTime.UtcNow,
                Kind = TransactionKind.CashIn
            };

            await _transactionWriteRepository.ChashIn(transaction);
        }

        public async Task ChashOut(TransactionDto transactionDto)
        {
            var existingWallet = await _walletReadRepository.GetIsExistWallet(transactionDto.WalletId);
            if (!existingWallet)
                throw new Exception("Wallet Not Found.");

            if (transactionDto.Amount >= MaxLimitedAmount)
                throw new Exception("Your Cannot CashIn this Amount");

            var transaction = new Transaction()
            {
                Amount = transactionDto.Amount,
                Description = transactionDto.Description,
                WalletId = transactionDto.WalletId,
                FinancialVoucherId = transactionDto.FinancialVoucherId,
                CreateDateUtc = DateTime.UtcNow,
                Kind = TransactionKind.CashOut
            };

            await _transactionWriteRepository.ChashOut(transaction);
        }

        public async Task Swap(SwapDto swapDto)
        {
            var sourceWallet = await _walletReadRepository.GetWalletById(swapDto.SourceWalletId);
            if (sourceWallet == null)
                throw new Exception("Source Wallet Not Found.");

            var destinationWallet = await _walletReadRepository.GetWalletById(swapDto.DestinationWalletId);
            if (destinationWallet == null)
                throw new Exception("Destination Wallet Not Found.");

            if ((sourceWallet.ProfileId != destinationWallet.ProfileId) &&
                (sourceWallet.ProfileId != swapDto.ProfileId) &&
                (destinationWallet.ProfileId != swapDto.ProfileId))
                throw new Exception("Profile Is not Owner.");

            var destinationAmound = sourceWallet.Currency.Ratio / destinationWallet.Currency.Ratio * swapDto.SourceAmount;

            var sourceTransaction = new Transaction()
            {
                Amount = swapDto.SourceAmount,
                Description = swapDto.Description,
                WalletId = swapDto.SourceWalletId,
                Kind = TransactionKind.CashOut,
                FinancialVoucherId = swapDto.FinancialVoucherId,
                CreateDateUtc = DateTime.UtcNow,
            };

            var destinationTransaction = new Transaction()
            {
                Amount = destinationAmound,
                Description = swapDto.Description,
                WalletId = swapDto.DestinationWalletId,
                Kind = TransactionKind.CashIn,
                FinancialVoucherId = swapDto.FinancialVoucherId,
                CreateDateUtc = DateTime.UtcNow,
            };

            await _transactionWriteRepository.ChashOut(sourceTransaction);
            await _transactionWriteRepository.ChashIn(destinationTransaction);
        }
    }
}
