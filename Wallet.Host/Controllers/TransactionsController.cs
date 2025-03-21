using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Wallet.Host.Features.Transaction.Commands.ChashIn;
using Wallet.Host.Features.Transaction.Commands.ChashOut;
using Wallet.Host.Features.Transaction.Commands.Swap;

namespace Wallet.Host.Controllers
{
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/v1/transactions/chash-in")]
        public async Task<IActionResult> ChashIn([FromBody] ChashInCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

        [HttpPost("api/v1/transactions/chash-out")]
        public async Task<IActionResult> ChashOut([FromBody] ChashOutCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

        [HttpPost("api/v1/transactions/Swap")]
        public async Task<IActionResult> Swap([FromBody] SwapCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

    }
}
