using MediatR;

namespace Wallet.Host.Features.Transaction.Commands.ChashIn
{
    public class ChashInCommand : IRequest<Unit>
    {
        public int WalletId { get; set; }
        public int ProfileId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int FinancialVoucherId { get; set; }
    }
}
