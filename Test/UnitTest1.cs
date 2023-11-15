using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using Gatherama.Shared;
using Gatherama.Services;

namespace Gatherama.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests
{
    private ApiService apiService;
    private PersonDto person;


    [SetUp]

    public void Setup()
    {
        // Create an instance of HttpClient
        var httpClient = new HttpClient();

        // Initialize ApiService with the HttpClient instance
        apiService = new ApiService(httpClient);
        person = new PersonDto();

        person.firstName = "Erkki";
        person.lastName = "Esimerkki";
        person.username = "Eke";
        person.email = "EkeOnEsimerkki@gmail.com";
        person.password = "Erkki";
    }
    [Test]
    public async Task Person_Register_Should_Return_PersonInfoAsync()
    {
        Assert.NotNull(apiService); 
        var response = await apiService.PostPersonAsync(person);
        Console.WriteLine(response);
        
        Assert.That(person.firstName, Is.EqualTo(response.firstName));

        await apiService.DeletePersonAsync((response.Id));
    }
    

}