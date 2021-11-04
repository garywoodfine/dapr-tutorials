using System;
using ShoppingCart.Resources;

namespace ShoppingCart.Content.Exceptions
{
    [Serializable]
    public class NotFoundException : DaprStateException
    {
        public NotFoundException(string title, string message) : base(ExceptionTitle.NotFound, message)
        {
        }
    }
}