using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class Command : IRequest<Response>
    {
     [Required][FromHeader(Name = "x-session-id")] public string Session { get; set; }
        [FromBody] public List<Item> Items { get; set; }
        
    }
}