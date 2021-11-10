using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class Handler: IRequestHandler<Command, Response>
    {
        private readonly IService<Item> _cartService;

        public Handler(IService<Item> cartService)
        {
            _cartService = cartService;
        }
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
           
            return new Response
            {
                Exists =  await _cartService.Save(request.Session, request.Items, cancellationToken),
                Items = request.Items
            };
        }
    }
}