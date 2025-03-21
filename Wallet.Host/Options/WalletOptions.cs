namespace Wallet.Host.Options
{
    public class AppSettings
    {
        public WalletOptions WalletOptions { get; set; } = null!;
    }

    public sealed class WalletOptions
    {
        public const string SectionName = "WalletOptions";

        public required string Host { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
