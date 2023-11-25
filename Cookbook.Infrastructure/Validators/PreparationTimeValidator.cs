using Cookbook.Domain.Models.Requests;
using FluentValidation;

namespace Cookbook.Infrastructure.Validators;

public class PreparationTimeValidator : AbstractValidator<PreparationTimeRequest>
{
	public PreparationTimeValidator()
	{
		RuleFor(preparationTime => preparationTime.Time).GreaterThan(0);
		RuleFor(preparationTime => preparationTime.Unit).NotEmpty();
		RuleFor(preparationTime => preparationTime.TimeInSeconds).GreaterThan(0);
	}
}
