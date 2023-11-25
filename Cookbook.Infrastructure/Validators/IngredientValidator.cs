using Cookbook.Domain.Models.Requests;
using FluentValidation;

namespace Cookbook.Infrastructure.Validators;

public class IngredientValidator : AbstractValidator<IngredientRequest>
{
	public IngredientValidator()
	{
		RuleFor(ingredient => ingredient.Quantity).GreaterThan(0);
		RuleFor(ingredient => ingredient.Unit).NotEmpty();
		RuleFor(ingredient => ingredient.Product).NotEmpty();
		RuleFor(ingredient => ingredient.PreparationNotes).NotEmpty();
	}
}
