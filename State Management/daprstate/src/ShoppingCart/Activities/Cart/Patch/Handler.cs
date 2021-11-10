using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShoppingCart.Content.Activities.Cart.Post;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Activities.Cart.Patch
{
    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IService<Item> _cartStateService;

        public Handler(IService<Item> cartStateService)
        {
            _cartStateService = cartStateService;
        }
        
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var items = await _cartStateService.Update(request.Session, request.Items, cancellationToken);
            return await Task.FromResult(new Response
            {
                Items = items
            });
        }
    }
}