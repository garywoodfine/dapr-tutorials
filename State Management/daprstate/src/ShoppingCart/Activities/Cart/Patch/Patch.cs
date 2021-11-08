using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ShoppingCart.Activities.Cart.Patch
{
    [Route(Routes.Cart)]
    public class Patch : BaseAsyncEndpoint.WithRequest<Command>.WithResponse<Response>
    {
        private readonly IMediator _mediator;

        public Patch(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch]
        [SwaggerOperation(
            Summary = "Update items in a shopping cart",
            Description = "Update items in a shopping cart for a user with session id",
            OperationId = "3E520260-2CB4-462A-BA04-C2F7CFAB1EEE",
            Tags = new[] { Routes.Cart })
        ]
        public override async Task<ActionResult<Response>> HandleAsync([FromRoute] Command request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var response = await _mediator.Send(request, cancellationToken);
            return new OkObjectResult(response);
        }
    }
}