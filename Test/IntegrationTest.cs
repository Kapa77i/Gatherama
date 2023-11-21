using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using Gatherama.Shared;
using Gatherama.Services;
using System.Net.Http;

namespace Gatherama.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests
{
    private ApiService apiService;
    private PersonDto person;
    private readonly string _baseEndpoint = "https://gatheramaapi.azurewebsites.net";


    [SetUp]

    public void Setup()
    {

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
        // Create an instance of HttpClient
        var httpClient = new HttpClient();
        //var originalBaseAddress = httpClient.BaseAddress;
        httpClient.BaseAddress = new Uri(_baseEndpoint);
        apiService = new ApiService(httpClient);

        Assert.NotNull(apiService);
        

        var response = await apiService.PostPersonAsync(person);
        Console.WriteLine(response);
        
        Assert.That(person.firstName, Is.EqualTo(response.firstName));
        Assert.That(person.lastName, Is.EqualTo(response.lastName));
        Assert.That(person.username, Is.EqualTo(response.username));    
        Assert.That(person.email, Is.EqualTo(response.email));
        Assert.That(person.password, Is.EqualTo(response.password));


        await apiService.DeletePersonAsync((response.Id));
    }
    

}