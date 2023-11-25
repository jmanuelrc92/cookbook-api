namespace Cookbook.Domain.Models.Persistance;
public class PreparationStep
{
	public int Order { get; set; }
	public string Step { get; set; }
	
	public PreparationStep()
	{
		Order= 0;
		Step = string.Empty;
	}
}
