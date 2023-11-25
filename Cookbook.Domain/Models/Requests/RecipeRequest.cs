namespace Cookbook.Domain.Models.Requests;

public class RecipeRequest
{
	public string Id { get; set; }
	public string Name { get; set; }
	public IList<IngredientRequest> Ingredients { get; set; }
	public IList<string> PreparationSteps { get; set; }
	public int Portions { get; set; }
	public PreparationTimeRequest PreparationTime { get; set; }

	public RecipeRequest()
	{
		Id = string.Empty;
		Name = string.Empty;
		Ingredients = new List<IngredientRequest>();
		PreparationSteps = new List<string>();
		Portions = 0;
		PreparationTime = new();
	}
}