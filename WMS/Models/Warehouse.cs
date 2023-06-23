using CommunityToolkit.Mvvm.ComponentModel;

namespace WMS.Models;

public class Warehouse : ObservableObject
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string Name { get; set; }
}
