using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Activities.Cart.Patch
{
    public class Command : IRequest<Response>
    {
        [FromHeader(Name = "x-session-id")] public string Session { get; set; }
        [FromBody] public JsonPatchDocument<List<Item>> Items { get; set; }
    }
}