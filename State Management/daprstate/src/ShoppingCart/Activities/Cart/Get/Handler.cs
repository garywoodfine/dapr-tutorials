using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShoppingCart.Content.Activities.Cart.Post;
using ShoppingCart.Content.Activities.Cart.Post.Models;
using ShoppingCart.Content.Exceptions;

namespace ShoppingCart.Activities.Cart.Get
{
    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IService<Item> _cartStateService;


        public Handler(IService<Item> cartStateService)
        {
            _cartStateService = cartStateService;
        }
        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var items = await _cartStateService.Get(request.Session, cancellationToken);
            return new Response { Items = items };
        }
    }
}

