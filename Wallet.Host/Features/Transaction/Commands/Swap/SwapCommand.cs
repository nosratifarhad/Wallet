using MediatR;

namespace Wallet.Host.Features.Transaction.Commands.Swap
{
    public class SwapCommand : IRequest<Unit>
    {
        public int ProfileId { get; set; }
        public int SourceWalletId { get; set; }
        public int DestinationWalletId { get; set; }
        public int SourceAmount { get; set; }
        public string Description { get; set; }
        public int FinancialVoucherId { get; set; }

    }
}
