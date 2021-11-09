using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
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
            Summary = "Create a shopping cart for a user",
            Description = "Create a shopping cart for a user",
            OperationId = "4D730510-3399-4324-BB2D-0A6C7270F783",
            Tags = new[] {Routes.Cart})
        ]
        [ProducesResponseType(StatusCodes.Status201Created)]
       public async override Task<ActionResult> HandleAsync([FromRoute] Command request, CancellationToken cancellationToken = new CancellationToken())
        {
           var response=  await _mediator.Send(request, cancellationToken);
             return new CreatedResult(
                 new Uri($"/{Routes.Cart}/{request.Session}", UriKind.Relative), response);
        }
    }
}

//dapr run --app-id "article-service" --app-port "5001" --dapr-grpc-port "50010" --dapr-http-port "5010" --components-path "./components" -- dotnet run --project ./ShoppingCart.csproj --urls="http://+:5001"