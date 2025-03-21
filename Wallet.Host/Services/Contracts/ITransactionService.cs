using Wallet.Host.Dto;

namespace Wallet.Host.Services.Contracts
{
    public interface ITransactionService
    {
        Task ChashIn(TransactionDto transactionDto);

        Task ChashOut(TransactionDto transactionDto);

        Task Swap(SwapDto swapDto);
    }
}
