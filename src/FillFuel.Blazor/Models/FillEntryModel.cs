namespace FillFuel.Blazor.Models;

public class FillEntryModel
{
    public string Id { get; set; } = string.Empty;
    public DateTime FillDate { get; set; }
    public double Amount { get; set; }
}