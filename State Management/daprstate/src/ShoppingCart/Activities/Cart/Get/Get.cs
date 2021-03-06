using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ShoppingCart.Activities.Cart.Get
{
   [Route(Routes.Cart)]
    public class Get : BaseAsyncEndpoint.WithRequest<Query>.WithResponse<Response>
    {
        private readonly IMediator _mediator;

        public Get(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve items in a shopping cart for session Id",
            Description = "Items in a shopping cart for a user with a session id",
            OperationId = "EF0A3653-153F-4E73-8D20-621C9F9FFDC9",
            Tags = new[] {Routes.Cart})
        ]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(NotFoundResult))]
        [Produces("application/json")]
        public override async Task<ActionResult<Response>> HandleAsync([FromRoute] Query query, CancellationToken cancellationToken = new())
        {
            var result = await _mediator.Send(query, cancellationToken);
            if (result == null) return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}