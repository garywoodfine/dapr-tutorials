using System.Data;
using FluentValidation;

namespace ShoppingCart.Activities.Cart.Get
{
    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(b => b.Session).NotNull().NotEmpty();
        } 
    }
}