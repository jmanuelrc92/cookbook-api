namespace Cookbook.Domain.Models.Requests;

public class IngredientRequest
{
	public decimal Quantity { get; set; }
	public string Unit { get; set; }
	public string Product { get; set; }
	public string PreparationNotes { get; set; }

	public IngredientRequest()
	{
		Quantity = 0;
		Unit = string.Empty;
		Product = string.Empty;
		PreparationNotes = string.Empty;
	}
}