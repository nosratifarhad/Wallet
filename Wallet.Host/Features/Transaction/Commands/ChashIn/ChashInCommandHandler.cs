using MediatR;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Features.Transaction.Commands.ChashIn
{
    public class ChashInCommandHandler : IRequestHandler<ChashInCommand, Unit>
    {
        private readonly ITransactionService _transactionService;

        public ChashInCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Unit> Handle(ChashInCommand request, CancellationToken cancellationToken)
        {
            var transactionDto = new TransactionDto()
            {
                Amount = request.Amount,
                Description = request.Description,
                FinancialVoucherId = request.FinancialVoucherId,
                WalletId = request.WalletId
            };

            await _transactionService.ChashIn(transactionDto);

            return Unit.Value;
        }
    }
}
