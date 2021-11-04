using System.Collections.Generic;
using ShoppingCart.Resources;

namespace ShoppingCart.Content.Exceptions
{
    public class ValidationException : DaprStateException
    {
        public ValidationException( string message, IReadOnlyDictionary<string, string[]> errors) : base(ExceptionTitle.Validation , message) =>
            Errors = errors;

        public IReadOnlyDictionary<string, string[]> Errors { get; }
    }
}