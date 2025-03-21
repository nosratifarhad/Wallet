using MassTransit;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Subscription.CreateProfile
{
    public class CreateProfileConsumer : IConsumer<CreateProfileEvent>
    {
        private readonly IWalletService _walletService;
        public CreateProfileConsumer(IWalletService walletService)
        {
            _walletService = walletService;
        }
        public async Task Consume(ConsumeContext<CreateProfileEvent> context)
        {
            await _walletService.CreateDefaultWallet(context.Message.ProfileId);
        }
    }
}
