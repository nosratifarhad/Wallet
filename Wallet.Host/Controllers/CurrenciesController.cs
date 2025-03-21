using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Host.Features.Wallet.Commands.CreateWallet;

namespace Wallet.Host.Controllers
{
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CurrenciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/v1/currencies")]
        public async Task<IActionResult> CreateCurrency([FromBody] CreateCurrencyCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }
    }
}
