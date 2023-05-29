using System.Collections.ObjectModel;
using System.Globalization;
using LyraWMS.Models;

namespace LyraWMS.BindingConverters;

public class PickedQuantityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var productUuid = (string) values[0];
        var picklist = (FullPicklist) values[1];
        var pickedQuantities = (ObservableCollection<KeyValuePair<string, int>>) values[2];

        if (productUuid == null || picklist == null || pickedQuantities == null)
        {
            return "";
        }

        Product? productInPicklist = picklist.Products.Find(p => p.Uuid == productUuid);

        if (productInPicklist == null)
            return "0/0";

        int pickedQuantity = pickedQuantities.First(kvp => kvp.Key == productUuid).Value;
        
        return $"{pickedQuantity}/{productInPicklist.Pivot.Amount}";
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}