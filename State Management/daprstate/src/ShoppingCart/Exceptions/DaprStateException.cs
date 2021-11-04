using System;

namespace ShoppingCart.Content.Exceptions
{
    public class DaprStateException : Exception
    {
        public DaprStateException(string title, string message) : base(message) => Title = title;
        public string Title { get; set; }
    }
}