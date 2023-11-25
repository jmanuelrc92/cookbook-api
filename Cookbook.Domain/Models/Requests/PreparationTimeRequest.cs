namespace Cookbook.Domain.Models.Requests;

public class PreparationTimeRequest
{
	public int Time { get; set; }
	public string Unit { get; set; }
	public int TimeInSeconds { get; set; }

	public PreparationTimeRequest()
	{
		Time = 0;
		Unit = string.Empty;
		TimeInSeconds = 0;
	}
}