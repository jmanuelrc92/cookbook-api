namespace Cookbook.Domain.Models.Persistance;

public class PreparationTime
{
    public int Time { get; set; }
    public string Unit { get; set; }
    public int TimeInSeconds { get; set; }

   public PreparationTime()
   {
      Time = 0;
      Unit = string.Empty;
      TimeInSeconds = 0;
   }
}
