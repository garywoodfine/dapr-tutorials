using System;
using System.Collections.Generic;
using ShoppingCart.Resources;

namespace ShoppingCart.Content.Exceptions
{
    [Serializable]
    public class NotFoundException : DaprStateException
    {
        public NotFoundException( string message, IReadOnlyDictionary<string, string[]> errors) : base(ExceptionTitle.NotFound, message, errors)
        {
        }
    }
}