using Cookbook.Domain.Models.Communication.Responses;
using Cookbook.Domain.Models.Requests;
using Cookbook.Infrastructure.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : Controller
{

	public RecipeController()
	{
	}

	[HttpPost, HttpPut]
	[Route("save")]

	public IActionResult SaveRecipeAsync(RecipeRequest saveRecipeRequest)
	{
		RecipeValidator validator = new();
		ValidationResult result = validator.Validate(saveRecipeRequest);

		if (!result.IsValid)
		{
			return BadRequest(new ApiResponse()
			{
				Success = false,
				ErrorCode = 1,
				Message = "Recipe not valid",
				Data = result.Errors.ToArray()
			});
		}

		//await _repository.InsertOneAsync(recipe);

		return Ok(new ApiResponse()
		{
			Success = true,
			ErrorCode = 0,
			Message = "Recipe created!",
			Data = saveRecipeRequest
		});
	}
}
