namespace Wallet.Host.Dto
{
    public class SwapDto
    {
        public int ProfileId { get; set; }
        public int SourceWalletId { get; set; }
        public int DestinationWalletId { get; set; }
        public int SourceAmount { get; set; }
        public string Description { get; set; }
        public int FinancialVoucherId { get; set; }
    }
}
