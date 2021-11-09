using FluentValidation;

namespace ShoppingCart.Content.Activities.Cart.Post
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(b => b.Session).NotNull().NotEmpty();
        }
    }
}