using System.Collections.Generic;
using ShoppingCart.Content.Activities.Cart.Post.Models;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class Response
    {
        public List<Item> Items { get; set; }
        public bool Exists { get; set; }
    }
}