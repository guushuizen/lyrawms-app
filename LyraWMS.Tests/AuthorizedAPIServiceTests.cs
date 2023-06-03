using System.Reflection;
using LyraWMS.Models;
using LyraWMS.Services;

namespace Tests;

public class AuthorizedAPIServiceTests
{
    
    private string GetFileContents(string resourceFile)
    {
        var asm = Assembly.GetExecutingAssembly();
        using (var stream = asm.GetManifestResourceStream($"LyraWMS.Tests.Resources.{resourceFile}"))
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
        var client = new AuthorizedAPIService(new AuthenticationService());

        string body = GetFileContents("picklistResponse.json");
        FullPicklist parsed = client.DeserializeJson<FullPicklist>(body, "picklist");
        
        Assert.Equal(parsed.Id, 6713);
        Assert.Equal(parsed.Order.Reference, "O2023-04505");
        Assert.Equal(parsed.ShippingAddress.Fullname, "Bart Spilt");
    }
    
    [Fact]
    public void TestParsePicklistListResponse()
    {
        var client = new AuthorizedAPIService(new AuthenticationService());

        string body = GetFileContents("picklistListResponse.json");
        List<Picklist> parsed = client.DeserializeJson<List<Picklist>>(body, "rows");

        Assert.Equal(parsed[0].Id, 6716);
        Assert.Equal(parsed[0].Customer, "Bart Spilt");
    }
}