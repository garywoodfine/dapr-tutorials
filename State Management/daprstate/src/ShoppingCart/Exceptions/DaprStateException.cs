using System;
using System.Collections.Generic;

namespace ShoppingCart.Content.Exceptions
{
    public class DaprStateException : Exception
    {
        public DaprStateException(string title, string message, IReadOnlyDictionary<string, string[]> errors) : base(message) => Title = title;
        public string Title { get; set; }
        public IReadOnlyDictionary<string, string[]> Errors { get; }
    }
}