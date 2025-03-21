using MediatR;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Features.Transaction.Commands.Swap
{
    public class SwapCommandHandler : IRequestHandler<SwapCommand, Unit>
    {
        private readonly ITransactionService _transactionService;

        public SwapCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Unit> Handle(SwapCommand request, CancellationToken cancellationToken)
        {
            var swapDto = new SwapDto()
            {
                ProfileId = request.ProfileId,
                Description =request.Description,
                DestinationWalletId = request.DestinationWalletId,
                FinancialVoucherId = request.FinancialVoucherId,
                SourceAmount = request.SourceAmount,
                SourceWalletId = request.SourceWalletId
            };

            await _transactionService.Swap(swapDto);

            return Unit.Value;
        }
    }
}
