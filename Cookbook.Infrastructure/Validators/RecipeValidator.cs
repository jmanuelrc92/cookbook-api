using Cookbook.Domain.Models.Requests;
using FluentValidation;

namespace Cookbook.Infrastructure.Validators;

public class RecipeValidator : AbstractValidator<RecipeRequest>
{
	public RecipeValidator()
	{
		RuleFor(recipe => recipe.Name).NotEmpty();
		RuleFor(recipe => recipe.Portions).GreaterThanOrEqualTo(1);
		RuleFor(recipe => recipe.PreparationTime).SetValidator(new PreparationTimeValidator());

		RuleFor(recipe => recipe.PreparationSteps).NotEmpty();
		RuleForEach(recipe => recipe.PreparationSteps).NotEmpty();

		RuleFor(recipe => recipe.Ingredients).NotEmpty();
		RuleForEach(recipe => recipe.Ingredients).SetValidator(new IngredientValidator());
	}
}
