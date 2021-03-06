using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Activities.Cart.Get
{
    public class Query : IRequest<Response>
    {
        [FromHeader(Name = "x-session-id")] public string Session { get; set; }
    }
}