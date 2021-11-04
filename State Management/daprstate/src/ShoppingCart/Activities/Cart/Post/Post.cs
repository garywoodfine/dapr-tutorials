using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using ShoppingCart.Activities.Sample.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Activities;
using Swashbuckle.AspNetCore.Annotations;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    [Route(Routes.Cart)]
    public class Post : BaseAsyncEndpoint.WithRequest<Command>.WithoutResponse
    {
        private readonly IMediator _mediator;

        public Post(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        
        [HttpPost]
        [SwaggerOperation(
            Summary = "Retrieve an article by id ",
            Description = "Retrieves a full articles ",
            OperationId = "EF0A3653-153F-4E73-8D20-621C9F9FFDC9",
            Tags = new[] {Routes.Cart})
        ]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(NotFoundResult))]
        [Produces("application/json")]
        public async override Task<ActionResult> HandleAsync([FromRoute] Command request, CancellationToken cancellationToken = new CancellationToken())
        {
            var response = await _mediator.Send(request, cancellationToken);
            return new CreatedResult(
                new Uri($"/{Routes.Cart}/{response.Id}", UriKind.Relative),
                new {id = response.Reference});
        }
    }
}

//dapr run --app-id "article-service" --app-port "5001" --dapr-grpc-port "50010" --dapr-http-port "5010" --components-path "./components" -- dotnet run --project ./ShoppingCart.csproj --urls="http://+:5001"