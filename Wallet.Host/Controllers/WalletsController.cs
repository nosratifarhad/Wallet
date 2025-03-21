using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Wallet.Host.Features.Wallet.Queries.GetWalletBalance;

namespace Wallet.Host.Controllers
{
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/v1/wallets/{walletId}/balance")]
        public async Task<IActionResult> GetWalletBalance(int walletId)
        {
            int profileId = 123;//get from token

            await _mediator.Send(new GetWalletBalanceQuery(walletId, profileId));

            return Created();
        }

    }
}
