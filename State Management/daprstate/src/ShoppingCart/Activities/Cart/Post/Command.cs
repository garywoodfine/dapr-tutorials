using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class Command : IRequest<Response>
    {
        [FromHeader(Name = "x-session-id")] public string Session { get; set; }
        [FromBody] public List<Item> Items { get; set; }
        
    }
}