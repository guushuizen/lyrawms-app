namespace LyraWMS.Models;

public class Pivot
{
    public int PicklistId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public string Status { get; set; }
    public int Id { get; set; }
    public string OrderProductId { get; set; }
    public bool ManuallyAdded { get; set; }
}
