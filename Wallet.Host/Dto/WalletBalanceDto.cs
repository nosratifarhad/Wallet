namespace Wallet.Host.Dto
{
    public class WalletBalanceDto
    {
        public int WalletId { get; set; }
        public int ProfileId { get; set; }
        public decimal Balance { get; set; }
    }
}
