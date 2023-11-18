namespace Cookbook.Domain.Models.Persistance;
public class Ingredient
{
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    public string Product { get; set; }
    public string PreparationNotes { get; set; }

   public Ingredient()
   {
      Quantity = 0;
      Unit = string.Empty;
      Product = string.Empty;
      PreparationNotes = string.Empty;
   }
}