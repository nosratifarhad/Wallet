using MediatR;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Features.Transaction.Commands.ChashOut
{
    public class ChashOutCommandHandler : IRequestHandler<ChashOutCommand, Unit>
    {
        private readonly ITransactionService _transactionService;

        public ChashOutCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Unit> Handle(ChashOutCommand request, CancellationToken cancellationToken)
        {
            var transactionDto = new TransactionDto()
            {
                Amount = request.Amount,
                Description = request.Description,
                FinancialVoucherId = request.FinancialVoucherId,
                WalletId = request.WalletId
            };

            await _transactionService.ChashOut(transactionDto);

            return Unit.Value;
        }
    }
}
