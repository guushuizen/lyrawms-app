using System.Reflection;
using LyraWMS.Models;
using LyraWMS.Services;

namespace LyraWMS.Tests;

public class AuthorizedAPIServiceTests
{
    private AuthorizedAPIService _apiService = new(new AuthenticationService(new StorageService()));

    private string GetFileContents(string resourceFile)
    {
        var asm = Assembly.GetExecutingAssembly();
        using (
            var stream = asm.GetManifestResourceStream($"LyraWMS.Tests.Resources.{resourceFile}")
        )
        {
            if (stream != null)
            {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }
        return string.Empty;
    }

    [Fact]
    public void TestParsePicklistResponse()
    {
        string body = GetFileContents("picklistResponse.json");
        FullPicklist parsed = _apiService.DeserializeJson<FullPicklist>(body, "picklist");

        Assert.Equal(parsed.Id, 62);
        Assert.Equal(parsed.Order.Reference, "O2022-00097");
        Assert.Equal(parsed.ShippingAddress.Fullname, "ir. Nadine van Maasgouw");
    }

    [Fact]
    public void TestParsePicklistListResponse()
    {
        string body = GetFileContents("picklistListResponse.json");
        List<Picklist> parsed = _apiService.DeserializeJson<List<Picklist>>(body, "rows");

        Assert.Equal(parsed[0].Id, 6716);
        Assert.Equal(parsed[0].Customer, "Bart Spilt");
    }

    [Fact]
    public void TestProductListResponseParsing()
    {
        string body = GetFileContents("productListResponse.json");
        List<Product> parsedProducts = _apiService.DeserializeJson<List<Product>>(body, "rows");

        Assert.Null(parsedProducts[0].FulfilmentClientName);
        Assert.Equal("Smederij Recers CV", parsedProducts[3].FulfilmentClientName);

        Assert.Equal(2033, parsedProducts[0].ProductLocations[0].Stock);
        Assert.Equal(2033, parsedProducts[0].TotalStock);
    }
}
