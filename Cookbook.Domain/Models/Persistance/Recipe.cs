using Cookbook.Domain.Extensions;

namespace Cookbook.Domain.Models.Persistance;

[BsonCollection("recipes")]
public class Recipe : Document
{
	public string Name { get; set; }
	public IList<Ingredient> Ingredients { get; set; }
	public IList<PreparationStep> PreparationSteps { get; set; }
	public int Portions { get; set; }
	public PreparationTime PreparationTime { get; set; }

	public Recipe()
	{
		Name = string.Empty;
		Ingredients = new List<Ingredient>();
		PreparationSteps = new List<PreparationStep>();
		Portions = 0;
		PreparationTime = new();
	}
}