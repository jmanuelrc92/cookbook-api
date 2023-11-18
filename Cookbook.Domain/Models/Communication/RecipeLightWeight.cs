namespace Cookbook.Domain.Models.Communication;

public class RecipeLightWeight
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string PhotoURL { get; set; }

	public RecipeLightWeight()
	{
		Id = string.Empty;
		Name = string.Empty;
		PhotoURL = string.Empty;
	}
}
