using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class Handler: IRequestHandler<Command, Response>
    {
        private readonly IService<Item> _articleService;

        public Handler(IService<Item> articleService)
        {
            _articleService = articleService;
        }
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            await _articleService.Save(request.Session, request.Items);
            return new Response { Items = request.Items };
        }
    }
}